using System;
using Alchemi.Core;
using Alchemi.Core.Owner;

namespace Alchemi.Examples.Tutorial
{
    [Serializable]
    public class MultiplierThread : GThread
    {
        private string _input, _output;
    
        public string Result
        {
            get { return _output; }
        }

        public MultiplierThread(string input)
        {
            _input = input;
        }

        public override void Start()
        {
            //_output = this.queryresponse(_input);
            //stage1: do nothing
            _output = this.queryresponse(_input);
        }
    }
    
    class MultiplierApplication
    {
        static GApplication ga;
        static bool flag = false;
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("[enter] to start grid application ....");
            Console.ReadLine();
      
            // create grid application
            ga = new GApplication(new GConnection("localhost", 80, "user", "user"));
            ga.ApplicationName = "Alchemi Tutorial - Alchemi sample";

            // add GridThread module (this executable) as a dependency
            ga.Manifest.Add(new ModuleDependency(typeof(MultiplierThread).Module));

            System.Console.WriteLine("successfully connected to manager and now going to start thread...");

            string I="Hello";
            while (true)
            {
                flag = false;

                int i;
                for (i = 0; i < 100; i++)
                {
                    System.Console.Write("\nYour Query/You say: ");
                    I = System.Console.ReadLine();

                    //check for break signal
                    if ((I.ToLower() == "quit") || (I.ToLower() == "exit"))
                        break;

                    // create thread
                    MultiplierThread thread = new MultiplierThread(I);

                    // add thread to application
                    ga.Threads.Add(thread);

                }   
                
                // subscribe to events
                ga.ThreadFinish += new GThreadFinish(ThreadFinished);
                ga.ThreadFailed += new GThreadFailed(ThreadFailed);
                ga.ApplicationFinish += new GApplicationFinish(ApplicationFinished);

                // start application
                ga.Start();

                break;
                while (!flag)
                {
                    //do nothing but wait...
                }
            }
            Console.ReadLine();
        }

        static void ThreadFinished(GThread th)
        {
            // cast GThread back to MultiplierThread
            MultiplierThread thread = (MultiplierThread) th;

            Console.WriteLine("Bot Response/Bot says: " + thread.Result);
            Console.WriteLine(
                "                 >> thread # {0} finished.\n",
                thread.Id);
            flag = true;
            //Main(new string[] { "" });
        }

        static void ThreadFailed(GThread th, Exception e)
        {
            Console.WriteLine(
                "thread # {0} finished with error '{1}'",
                th.Id,
                e.Message);
        }

        static void ApplicationFinished()
        {
            Console.WriteLine("\napplication finished");
            Console.WriteLine("\n[enter] to continue ...");
        }
    }
}
