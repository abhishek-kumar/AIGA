using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Principal;
using System.ServiceProcess;
using System.Windows.Forms;
using Microsoft.Win32;


namespace MSR.LST.ConferenceXP.ArchiveService
{
    [RunInstaller(true)]
    public class ArchiveWindowsServiceInstaller : System.Configuration.Install.Installer
    {
        #region Privates & Constants
        static ushort[] ports = {8082, 5004, 5005};
        static ProtocolType[] portTypes = {ProtocolType.Tcp, ProtocolType.Udp, ProtocolType.Udp};
        const string portMapName = "ConferenceXP Archive Service";
        const string sqlServiceName = "MSSqlServer";

        const string sql2000DataDir = @"C:\Program Files\Microsoft SQL Server\MSSQL\Data";
        const string sql2005DataDir = @"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data";
        bool sqlFound; // keep a note on this, so we can show the error if necessary
        #endregion

        #region CTor
        public ArchiveWindowsServiceInstaller()
        {
            // - Define and create the service installer
            ServiceInstaller archiveInstaller = new ServiceInstaller();
            archiveInstaller.StartType = ServiceStartMode.Automatic;
            archiveInstaller.ServiceName = ArchiveWindowsService.ShortName;
            archiveInstaller.DisplayName = ArchiveWindowsService.DisplayName;
            archiveInstaller.ServicesDependedOn = GetDependencies();
            archiveInstaller.Committed += new InstallEventHandler(archiveInstaller_Committed);
            Installers.Add(archiveInstaller);

            // - Define and create the process installer
            ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();
            processInstaller.Account = ServiceAccount.LocalService;
            Installers.Add(processInstaller);

            // - Add the installer for Archiver to the list
            AssemblyInstaller arcInstall = new AssemblyInstaller();
            arcInstall.Assembly = Assembly.Load("Archiver");
            Installers.Add(arcInstall);
        }
        #endregion

        #region Install/Uninstall
        public override void Install (IDictionary savedState)
        {
            CheckAdministratorRole();

            #region Add the firewall punchthrough
            try
            {
                MessageBox.Show(
                    "Installation will now add this application to \n"+
                    "your Windows Firewall Exceptions list.",
                    "Firewall", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MSR.LST.Net.FirewallUtility.AddFirewallException (portMapName,
                    ports, portTypes, Context.Parameters["assemblypath"]);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(
                    "There was an error adding this application \n"+
                    "to your firewall's exception list.  Please \n"+
                    "add the application manually to your firewall.\n"+
                    "\n\nException error message: "+ex.Message,
                    "Firewall Exception Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            #region Check for no SQL and show the error message here
            if (!this.sqlFound) // Show the error msg here that we couldn't show earlier
            {
                MessageBox.Show(
                    "Microsoft SQL Server was not detected on this computer. Be sure to \n" +
                    "create the database by executing AddDatabase.sql and AddSPs.sql. You must \n"+
                    "edit the SqlConnectionString in the ArchiveWindowsService.exe.config file \n"+
                    "and restart the service. Be advised that connecting Archive Service \n"+
                    "to SQL Server on another server will adversely affect performance.\n",
                    "SQL Server Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else // only try to create the database if we know SQL is installed
            {
                CreateDatabase();
                CreateStoredProcedures();
            }
            #endregion

            base.Install(savedState);
        }

        /// <summary>
        /// Starts the Archive Service after the installation has committed.
        /// </summary>
        private void archiveInstaller_Committed(object sender, InstallEventArgs e)
        {
            // Start the archive service at the end of installation
            try
            {
                ServiceController sc = new ServiceController(ArchiveWindowsService.ShortName);
                sc.Start();
            }
            catch (Exception ex)
            {
                // Don't except - that would cause a rollback.  Instead, just tell the user.
                MessageBox.Show(
                    "The service was installed successfully, but the service could not be started. \n" +
                    "Make sure SQL Server is installed and running. \n\nException:\n" + ex.ToString(),
                   "Service Start Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Uninstall (IDictionary savedState)
        {
            CheckAdministratorRole();

            #region Remove firewall punchthrough
            try
            {
                MSR.LST.Net.FirewallUtility.RemoveFirewallException (portMapName,
                    ports, portTypes, Context.Parameters["assemblypath"]);
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(
                    "There was an error removing this application \n"+
                    "from your firewall's exception list.  Please \n"+
                    "remove the application manually to your firewall.\n"+
                    "\n\nException error message: "+ex.Message,
                    "Firewall Exception Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            #endregion

            #region Make sure the service is stopped.
            try
            {
                ServiceController sc = new ServiceController(ArchiveWindowsService.ShortName);
                if (sc.Status != ServiceControllerStatus.Stopped)
                    sc.Stop();
            }
            catch {}
            #endregion

            if (sqlFound) // don't bother trying to remove it if we already know SQL can't be found
            {
                RemoveDatabase();
            }

            base.Uninstall(savedState);
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Gets the installation directory for this install.
        /// </summary>
        private string InstallPath
        {
            get
            {
                string assemblyPath = Context.Parameters["assemblypath"];
                return assemblyPath.Substring (0, assemblyPath.LastIndexOf('\\')+1);
            }
        }

        /// <summary>
        /// Checks to make sure we're running as the administrator.  If not, exit.
        /// </summary>
        private static void CheckAdministratorRole()
        {
            WindowsPrincipal wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (wp.IsInRole(WindowsBuiltInRole.Administrator) == false)
            {
                MessageBox.Show("You must be an Administrator to uninstall Archive Service.", 
                    "Administrator Privileges Required", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }

        /// <summary>
        /// Returns MSSQL as a dependency if it is installed, otherwise returns null.  This allows the service to work
        /// better if SQL is installed, but also allows the service to be installed (not fail) if SQL isn't installed.
        /// (Not having SQL installed is common for proper hosted services, where SQL is in the tier-2 servers.)
        /// </summary>
        private string[] GetDependencies()
        {
            ServiceController sqlController;
            ServiceControllerStatus sqlStatus;
            try
            {
                sqlController = new ServiceController(sqlServiceName);
                sqlStatus = sqlController.Status; // should throw if the service does't exist

                this.sqlFound = true;
            }
            catch
            {
                // Don't show the error message here, or we'll see it in install, commit, and uninstall
                this.sqlFound = false;
                return null;
            }

            if (sqlStatus != ServiceControllerStatus.Running) // start the service if it isn't already
            {
                try
                {
                    sqlController.Start();
                    sqlController.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 10)); // wait 10 seconds, in hope
                }
                catch {}
            }

            return new string[]{sqlServiceName};
        }

        /// <summary>
        /// Creates the database and the schema, but does not create the stored procedures.  That's done in CreateStoredProcedures().  Because
        /// wiping the schema & database would cause the user to lose all of their data, this is an optional activity.
        /// </summary>
        private void CreateDatabase()
        {
            // Verify the user wants to wipe the database
            DialogResult dr = MessageBox.Show(
                "Would you like to initialize the ArchiveService database? If you already have \n"
                + "an ArchiveService database set up, this action will CLEAR it. If you do not have \n"
                + "the database, you must initialize it for Archive Service to work properly.",
                "Initialize Database", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,  MessageBoxDefaultButton.Button1);
            if( dr != DialogResult.Yes )
                return;

            Console.WriteLine("\nPlease wait while the database initializes.  This may take several minutes...");

            try
            {
                string addDBFilePath = InstallPath + "AddDatabase.sql";
                UpdateDefaultDataPath(addDBFilePath);
                RunOsqlFile(addDBFilePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "Failed to create the ArchiveService database.  Run AddDatabase.sql using your database \n" +
                    "tools (osql.exe, in the tools directory) to complete the operation. \n\nException: \n"+ex.ToString(),
                    "Database Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Console.WriteLine("Database initialization complete.\n");
        }

        /// <summary>
        /// Replaces a placeholder string in the .sql file with the default directory SQL server stores
        /// data files in.  Note this is different depending on the version of SQL server.
        /// </summary>
        private void UpdateDefaultDataPath(string addDBFile)
        {
            bool sql2000 = Directory.Exists(sql2000DataDir);
            bool sql2005 = Directory.Exists(sql2005DataDir);
            string dataDirectoryPath;
            if (sql2005)
                dataDirectoryPath = sql2005DataDir;
            else if (sql2000)
                dataDirectoryPath = sql2000DataDir;
            else
                throw new InvalidOperationException("The SQL Server data directory could not be found.");

            FileStream file = File.Open(addDBFile, FileMode.Open, FileAccess.Read);
            StreamReader fileReader = new StreamReader(file);
            string fullFileText = fileReader.ReadToEnd();
            file.Close();

            fullFileText = fullFileText.Replace(@"'MSSQLServerLocation\", '\'' + dataDirectoryPath + '\\');

            StreamWriter fileWriter = new StreamWriter(addDBFile, false);
            fileWriter.Write(fullFileText);
            fileWriter.Close();
        }

        /// <summary>
        /// Creates all of the stored procedures for the database.  Because these can change version to version, 
        /// but the schema is less likely to change, we automatically run this script every time you install.
        /// </summary>
        private void CreateStoredProcedures()
        {
            Console.WriteLine("\nPlease wait while the stored procedures are created...");

            try
            {
                RunOsqlFile(InstallPath+"AddSPs.sql");
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "Failed to add the stored procuedures to the database. Run AddSPs.sql using your database \n" +
                    "tools (osql.exe, in the tools directory) to complete the operation. \n\nException: \n"+ex.ToString(),
                    "Database Operation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Console.WriteLine("Stored procedure creation complete.\n");
        }

        private void RemoveDatabase()
        {
            // Verify the user wants to delete the database
            DialogResult dr = MessageBox.Show("Would you like to delete the ArchiveService database?"
                + "\n This action will delete all recordings to date.",
                "Delete Database", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,  MessageBoxDefaultButton.Button1);
            if( dr != DialogResult.Yes )
                return;

            try
            {
                RunOsqlFile(InstallPath+"DropDatabase.sql");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to drop Archive Service database.  Please run DropDatabase.sql using "
                    + "your database tools (osql.exe, in the tools directory).  Exception: \n"+ex.ToString());
            }
        }

        /// <summary>
        /// Finds the OSQL tool on a SQL 2000 or 2005 installation and runs the specified file under
        /// the current users's credentials.
        /// </summary>
        /// <param name="file">The full path to a .sql file to run.</param>
        private static void RunOsqlFile(string file)
        {
            // First, determine if 2005 is installed
            string key = "SOFTWARE\\Microsoft\\Microsoft SQL Server\\90\\Tools\\ClientSetup";
            if (Registry.LocalMachine.OpenSubKey(key) == null) // 2005 is not installed; use the 2000 path
            {
                key = key.Replace('9', '8');
            }

            string val = "SQLPath";
            string osqlLocation = (string)Registry.LocalMachine.OpenSubKey(key).GetValue(val) + "\\BINN\\osql.exe";

            // Call osql on our file
            Process osql = Process.Start(osqlLocation, "-E -i \""+file+"\"");

            // Wait for osql to finish (can be quite some time, depending on the DB init size
            osql.WaitForExit();

            // This is wishful thinking.  Read the note in AddSPs.sql to see why. (pfb)
            if( osql.ExitCode != 0 )
                throw new InvalidOperationException("OSQL.exe failed to run properly on the file specified with the current users's permissions.");
        }
        #endregion
    }

}
