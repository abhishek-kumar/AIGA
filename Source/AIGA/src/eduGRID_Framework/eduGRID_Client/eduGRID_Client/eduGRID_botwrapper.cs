using System;
using System.Collections.Generic;
using System.Text;
using Alchemi.Core;
using Alchemi.Core.Owner;


namespace eduGRID_Client
{
    class eduGRID_botwrapper
    {
        public GApplication ga=null;

        /// <summary>
        /// 
        /// Const.Tor
        /// </summary>
        public eduGRID_botwrapper(string ManIP, int Port)
        {
            // create grid application
            ga = new GApplication(true);
            ga.GConnection = new GConnection(ManIP, Port, "user", "user");
            ga.Connection = new GConnection(ManIP, Port, "user", "user");


            ga.ApplicationName = "eduGRID Bot Client";

            // add GridThread module (this current one!) as a dependency
            ga.Manifest.Add(new ModuleDependency(typeof(eduGRID_Thread).Module));

            // subscribe to events
            ga.ThreadFinish += new GThreadFinish(ThreadFinished);
            ga.ThreadFailed += new GThreadFailed(ThreadFailed);
            //ga.ApplicationFinish += new GApplicationFinish(ApplicationFinished);

            ga.Start();
        }


        public bool converse(string squery)
        {
            try
            {
                eduGRID_Thread thread = new eduGRID_Thread(squery);
                ga.StartThread(thread);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void ThreadFinished(GThread th)
        {
            // cast GThread back to eduGRID_Thread
            eduGRID_Thread thread = (eduGRID_Thread)th;

        }

        private void ThreadFailed(GThread th, Exception e)
        {
        }

        public void Disconnect()
        {
            if (ga != null)
                ga.Stop();
            ga = null;
        }
    }

    
    [Serializable]
    public class eduGRID_Thread : GThread
    {
        private string _input, _output;

        public string Result
        {
            get { return _output; }
        }

        public eduGRID_Thread(string input)
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
}
