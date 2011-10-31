#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	JobSubmitter.cs
* Project		:	Alchemi Job Submitter 
* Created on	:	2003
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Akshay Luther (akshayl@csse.unimelb.edu.au), Rajkumar Buyya (raj@csse.unimelb.edu.au), and Krishna Nadiminti (kna@csse.unimelb.edu.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion


using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Remoting.Lifetime;
using System.Data;
using System.Text;
using Alchemi.Core;
using Alchemi.Core.Utility;

namespace Alchemi.DevTools
{
    class JobSubmitter
    {
        [STAThread]
        static void Main(string[] args)
        {
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(DefaultErrorHandler);

            Console.WriteLine("\nAlchemi [.NET Grid Computing Framework]");
            Console.WriteLine("http://www.alchemi.net\n");

            Console.WriteLine("Job Submitter v{0}", Utils.AssemblyVersion);

            IManager manager;
            SecurityCredentials sc;

            if (args.Length < 4)
            {
                Usage();
                return;
            }
            
            try
            {
                manager = (IManager) GNode.GetRemoteRef(new RemoteEndPoint(args[0], int.Parse(args[1]), RemotingMechanism.TcpBinary));
                manager.PingManager();
                sc = new SecurityCredentials(args[2], args[3]);
                manager.AuthenticateUser(sc);
                Console.Write("Connected to Manager at {0}:{1}\n", args[0], args[1]);
            }
            catch (Exception e)
            {
                Error("Could not connect to Manager", e);
                return;
            }

            Aliases aliases = Aliases.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, "aliases.dat"));
            
            string[] cmd;
            bool interactive;

            if (args.Length > 4)
            {
                cmd = new string[args.Length - 4];
                for (int i=0; i<args.Length - 4; i++)
                {
                    cmd[i] = args[i+4];
                }
                interactive = false;
            }
            else
            {
                cmd = new string[] {""};
                interactive = true;
            }

            while (true)
            {
                if (interactive)
                {
                    Console.Write("\n> ");
                    string line = Console.ReadLine();
                    cmd = line.Split();
                    cmd[0] = cmd[0].ToLower();
                }
                
                try
                {
                    string appId;

                    switch (cmd[0])
                    {
                        case "st":
                        case "submittask": // taskXmlFile
                            string task = EmbedFiles(Utils.ReadStringFromFile(cmd[1]));
                            appId = CrossPlatformHelper.CreateTask(manager, sc, task);
							string newAlias = aliases.NewAlias(appId);
							try
							{
								WriteLine("Task submitted (alias = {1}).", appId, newAlias);
							}
							catch
							{
							}
                            break;

                        case "gfj":
                        case "getfinishedjobs": // alias, (directory, default=".")
                            appId = (string) aliases.Table[cmd[1]];

                            string taskDir = cmd.Length > 2 ? cmd[2] : ".";

                            string taskXml = CrossPlatformHelper.GetFinishedJobs(manager, sc, appId);
                            XmlDocument fin = new XmlDocument();
                            fin.LoadXml(taskXml);

                            WriteLine("Got {0} job(s).", fin.SelectNodes("task/job").Count);
							Console.WriteLine("Job XML: \n" + taskXml);

                            foreach (XmlNode outputFileNode in fin.SelectNodes("task/job/output/embedded_file"))
                            {
                                //string jobDir = string.Format("{0}\\job_{1}", taskDir, outputFileNode.ParentNode.ParentNode.Attributes["id"].Value);
                                string jobDir = taskDir;
								if (!Directory.Exists(jobDir))
								{
									Directory.CreateDirectory(jobDir);
								}

                                //if (outputFileNode.InnerText != "")
                                //{
                                    string filePath = string.Format("{0}\\{1}", jobDir, outputFileNode.Attributes["name"].Value);
                                    Utils.WriteBase64EncodedToFile(
                                        filePath,
                                        outputFileNode.InnerText
                                        );
                                    WriteLine("Wrote file {0} for job {1}.", filePath, outputFileNode.ParentNode.ParentNode.Attributes["id"].Value);
                               // }
                            }
                            break;
                        
                            // TODO: (allow option to specify alias)
                        case "ct":
                        case "createtask": // no arguments
                            appId = manager.Owner_CreateApplication(sc);
                            WriteLine(appId);
                            WriteLine("Task created (alias = {1}).", appId, aliases.NewAlias(appId));
                            break;

                        case "aj":
                        case "addjob": // alias, jobXml, jobId, (priority, default=0)
                            appId = (string) aliases.Table[cmd[1]];
                            int priority = 0;
                            if (cmd.Length > 4)
                            {
                                priority = int.Parse(cmd[4]);
                            }
                            CrossPlatformHelper.AddJob(manager, sc, appId, int.Parse(cmd[3]), priority, EmbedFiles(Utils.ReadStringFromFile(cmd[2])));
                            WriteLine("Job added.");
                            break;

                        /*
                        case "listapps": // no arguments
                            DataTable apps = manager.Owner_GetLiveApplicationList(null).Tables[0];
                            apps.Columns.Add("alias", typeof(string));
                            apps.Columns.Add("state_disp", typeof(string));
                            foreach (DataRow app in apps.Rows)
                            {
                                string alias = aliases.GetAlias(app["application_id"].ToString());
                                if (alias == "")
                                {
                                    alias = aliases.NewAlias(app["application_id"].ToString());
                                }
                                app["alias"] = alias;
                                app["state_disp"] = Enum.Parse(typeof(ApplicationState), app["state"].ToString()).ToString();
                            }
                            Console.WriteLine(ConsoleFormatter.FormatDataTable(
                                apps,
                                new string[] {"alias", "state_disp", "time_created"}, 
                                new string[] {"alias", "state", "time_created"}
                                ));
                            break;

                        case "listthreads": // alias
                            appId = (string) aliases.Table[cmd[1]];
                            DataTable threads = manager.Owner_GetThreadList(null, appId).Tables[0];

                            threads.Columns.Add("state_disp", typeof(string));
                            foreach (DataRow thread in threads.Rows)
                            {
                                thread["state_disp"] = Enum.Parse(typeof(ThreadState), thread["state"].ToString());
                            }

                            Console.WriteLine(ConsoleFormatter.FormatDataTable(
                                threads,
                                new string[] {"thread_id", "state_disp", "time_started", "time_finished"},
                                new string[] {"thread_id", "state", "time_started", "time_finished"}
                                ));
                            break;
                        
                        case "getthreadstate": // alias, threadId
                            appId = (string) aliases.Table[cmd[1]];
                            ThreadState state = manager.Owner_GetThreadState(null, new ThreadIdentifier(appId, int.Parse(cmd[2])));
                            WriteLine("State = {0}.", state);
                            break;

                        case "abortthread": // alias, threadId
                            appId = (string) aliases.Table[cmd[1]];
                            manager.Owner_AbortThread(null, new ThreadIdentifier(appId, int.Parse(cmd[2])));
                            WriteLine("Thread aborted.");
                            break;

                        case "stoptask": // alias
                            appId = (string) aliases.Table[cmd[1]];
                            manager.Owner_StopApplication(null, appId);
                            WriteLine("Task stopped.");
                            break;
                            
                         */        

                        case "h":
                        case "help":
                        case "?":
                            if (cmd.Length == 2)
                            {
                                Usage(cmd[1]);
                            }
                            else
                            {
                                Usage();
                            }
                            break;
                        
                        case "quit":
                        case "q":
                        case "exit":
                        case "x":
                            return;

                        default:
                            Error("Unknown command '{0}'", cmd[0]);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Error("Incorrect syntax or parameter (" + e.Message.ToString() + ")");
                }
                
                if (!interactive)
                {
                    return;
                }
            }

        }

    	private static void DefaultErrorHandler(object sender, UnhandledExceptionEventArgs e)
    	{
    		Console.Error.WriteLine("An unexpected error occured. It may be possible to continue after the error." + Environment.NewLine + e.ExceptionObject.ToString());
    	}

    	private static string EmbedFiles(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            foreach (XmlNode embeddedFile in doc.SelectNodes("//embedded_file"))
            {
                if (embeddedFile.Attributes["location"] != null)
                {
                    embeddedFile.InnerText = Utils.ReadBase64EncodedFromFile(embeddedFile.Attributes["location"].Value);
                }
            }
            return doc.OuterXml;
        }

        private static void Error(string msg, params object[] pars)
        {
            Console.WriteLine("[Error] " + msg, pars);
            Console.WriteLine("Use the 'help' command for usage.");
        }

        private static void WriteLine(string format, params object[] arg)
        {
            Console.WriteLine("-- " + format, arg);
        }

        public static void Usage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("\talchemi_jsub <manager_host> <manager_port> <username> <password>");
            Console.WriteLine("\t  Connects to the specified Alchemi Manager and starts in interactive\n\t  mode.");
            Console.WriteLine("\n\talchemi_jsub <manager_host> <manager_port> <username> <password> [cmd]");
            Console.WriteLine("\t  Connects to the specified Alchemi Manager, executes the specified\n\t  command and exits.");
            Console.WriteLine("\nCommands:");
            Console.WriteLine("\taddjob");
            Console.WriteLine("\tcreatetask");
            Console.WriteLine("\tgetfinishedjobs");
            //Console.WriteLine("\tgetthreadstate");
            Console.WriteLine("\thelp");
            //Console.WriteLine("\tlistapps");
            //Console.WriteLine("\tlistthreads");
            //Console.WriteLine("\tabortthread");
            //Console.WriteLine("\tstoptask");
            Console.WriteLine("\tsubmittask");
            Console.WriteLine("\texit");
            Console.WriteLine("\nUse 'help <command>' for help on a particular command.");
        }

        public static void Usage(string cmd)
        {
            switch (cmd)
            {
                case "submittask":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\tsubmittask <taskxmlfile>");
                    Console.WriteLine("\t  Submits a task.");
                    break;
                case "getfinishedjobs":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\tgetfinishedjobs <alias>");
                    Console.WriteLine("\t  Gets finished jobs for a task.");
                    break;
                /*
                case "abortthread":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\tabortthread <alias> <thread_id>");
                    Console.WriteLine("\t  Aborts a thread.");
                    break;
                */    
                
                case "addjob":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\taddjob <alias> <job_xml> <job_id> [priority]");
                    Console.WriteLine("\t  Adds a job to a task.");
                    break;

                case "createtask":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\tcreatetask");
                    Console.WriteLine("\t  Creates a task (to which jobs can be added).");
                    break;
                /*
                case "getthreadstate":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\tgetthreadstate <alias> <thread_id>");
                    Console.WriteLine("\t  Gets the state of a thread.");
                    break;
                */
                case "help":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\thelp [command]");
                    Console.WriteLine("\t  Shows help.");
                    break;
                /*
                case "listapps":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\tlistapps");
                    Console.WriteLine("\t  Lists running applications.");
                    break;
                case "listthreads":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\tlistthreads <alias>");
                    Console.WriteLine("\tLists the threads in an application.");
                    break;
                case "stopapp":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\tstopapp <alias>");
                    Console.WriteLine("\tStops an application.");
                    break;
                    */
                case "exit":
                    Console.WriteLine("Usage:");
                    Console.WriteLine("\texit");
                    Console.WriteLine("\tExits the utility.");
                    break;
                default:
                    Error("Unknown command '{0}'", cmd);
                    break;
            }

        }
    }

    [Serializable]
    public class Aliases
    {
        private Hashtable _Table = new Hashtable();
        private int _Counter = 1000;
        private string _File;

        public Hashtable Table
        {
            get { return _Table; }
        }
        
        public static Aliases FromFile(string file)
        {
            Aliases a;
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    a = (Aliases) bf.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
                a = new Aliases(file);
            }
            return a;
        }

        public Aliases(string file)
        {
            _File = file;
        }

        public string NewAlias(string orig)
        {
            string alias = (++_Counter).ToString();
            _Table.Add(alias, orig);
            this.Save();
            return alias;
        }

        public string GetAlias(string orig)
        {
            string alias = "";
            foreach (string key in Table.Keys)
            {
                if (Table[key].ToString() == orig)
                {
                    alias = key;
                    break;
                }
            }
            return alias;
        }

        public void Save()
        {
            using (Stream s = new FileStream(_File, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(s, this);
                s.Close();
            }
        }
    }

    public class ConsoleFormatter
    {
        public static string FormatDataTable(DataTable dt, string[] colsToDisplay, string[] colHeaders)
        {
            if (colHeaders.Length != colsToDisplay.Length)
            {
                throw new ArgumentException("Column counts must match.");
            }
            
            // calculate column lengths
            int[] colLen = new int[colsToDisplay.Length];

            for (int c=0; c<colsToDisplay.Length; c++)
            {
                colLen[c] = 0;
                for (int r=0; r<dt.Rows.Count; r++)
                {
                    if (dt.Rows[r][colsToDisplay[c]].ToString().Length > colLen[c])
                    {
                        colLen[c] = dt.Rows[r][colsToDisplay[c]].ToString().Length;
                    }
                }
                if (colHeaders[c].Length > colLen[c])
                {
                    colLen[c] = colHeaders[c].Length;
                }
            }

            StringBuilder sb = new StringBuilder();

            // line
            sb.Append("\n");
            sb.Append("+");
            for (int c=0; c<colsToDisplay.Length; c++)
            {
                sb.Append("-" + Repeat("-", colLen[c]) + "-+");
            }
            
            // header text
            sb.Append("\n");
            sb.Append("|");
            for (int c=0; c<colsToDisplay.Length; c++)
            {
                sb.Append(" " + colHeaders[c] + Repeat(" ", colLen[c] - colHeaders[c].Length) + " |");
            }

            // line
            sb.Append("\n");
            sb.Append("+");
            for (int c=0; c<colsToDisplay.Length; c++)
            {
                sb.Append("-" + Repeat("-", colLen[c]) + "-+");
            }
            
            // data
            for (int r=0; r<dt.Rows.Count; r++)
            {
                sb.Append("\n");
                sb.Append("|");
                for (int c=0; c<colsToDisplay.Length; c++)
                {
                    sb.Append(" " + dt.Rows[r][colsToDisplay[c]] + Repeat(" ", colLen[c] - dt.Rows[r][colsToDisplay[c]].ToString().Length) + " |");
                }
            }

            // line
            sb.Append("\n");
            sb.Append("+");
            for (int c=0; c<colsToDisplay.Length; c++)
            {
                sb.Append("-" + Repeat("-", colLen[c]) + "-+");
            }

            return sb.ToString();
        }

        private static string Repeat(string s, int i)
        {
            string ret = "";
            for (int j=0; j<i; j++)
            {
                ret += s;
            }
            return ret;
        }


        private void Error(string message, Exception e)
        {
            Console.WriteLine("{0} ({1} : {2})", message, e.GetType(), e.Message);
        }

    }
}
