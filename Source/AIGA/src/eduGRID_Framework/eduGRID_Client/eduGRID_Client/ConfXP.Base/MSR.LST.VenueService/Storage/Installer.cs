using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Security.AccessControl;
using Microsoft.Win32;
using System.Reflection;

namespace MSR.LST.ConferenceXP.VenueService
{
    /// <summary>
    /// Summary description for Installer.
    /// </summary>
    [RunInstaller(true)]
    public class StorageInstaller : System.Configuration.Install.Installer
    {
        public static readonly string LocalMachineSubkey = @"Software\Microsoft Research\ConferenceXP\Venue Service\";

        static StorageInstaller()
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            LocalMachineSubkey += string.Format("{0}.{1}", v.Major, v.Minor);
        }

        public StorageInstaller()
        {
        }

        private string InstallPath
        {
            get
            {
                // This is set on the custom Install action as CustomActionData
                // And is pulled from the MSI installer
                return Context.Parameters["webdir"];
            }
        }

        public override void Install(IDictionary savedState)
        {
            base.Install(savedState);

            // Create .dat file
            //
            // NOTE: during install we can't access the Web.config file, so the file name
            //  is just hard-coded here.  Given that you can't change the web.config file
            //  during install, this really shouldn't be a problem.  If someone changes the
            //  file location, then they'll have to deal with the problem of file permissions.
            //
            Console.WriteLine("Creating Venue Service data file.");
            string filepath = InstallPath + @"VenueService.dat";
            if( !File.Exists(filepath) )
            {
                using (FileStorage file = new FileStorage(filepath))
                {
                    // Add two sample venues
                    file.AddVenue(new Venue("someone@hotmail.com", "234.7.13.19", 5004,
                        "Sample Venue 1", null, null));
                    file.AddVenue(new Venue("somebody@hotmail.com", "235.8.14.20", 5004,
                        "Sample Venue 2", null, null));
                }
            }
            else
            {
                Console.WriteLine("Data file exists.  Skipping creating file.");
            }

            // Store the location of the .dat file so the admin tool can find it
            using(RegistryKey key = Registry.LocalMachine.CreateSubKey(LocalMachineSubkey))
            {
                key.SetValue("DataFile", filepath);
            }

            try
            {
                FileSecurity fileSec = File.GetAccessControl(filepath);
                fileSec.AddAccessRule(new FileSystemAccessRule("IUSR_" + Environment.MachineName, 
                    FileSystemRights.Modify, AccessControlType.Allow));
                File.SetAccessControl(filepath, fileSec);
            }
            catch(Exception)
            {
                MessageBox.Show(
                    "Setting the file security for the venueservice.dat file failed. \n" +
                    "This may be caused by the Internet Guest Account not being present \n" +
                    "or properly named. \n" +
                    "\nFor Venue Service to work properly, the data file must be \n" +
                    "modifiable by the Internet Guest Account. You must add \"modify\" \n" +
                    "permissions on the file for the Internet Guest Account.",
                    "File Security Changes Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall (savedState);

            try
            {
                // Delete the registry key
                Registry.LocalMachine.DeleteSubKeyTree(LocalMachineSubkey);
            }
            catch{}
        }
    }
}
