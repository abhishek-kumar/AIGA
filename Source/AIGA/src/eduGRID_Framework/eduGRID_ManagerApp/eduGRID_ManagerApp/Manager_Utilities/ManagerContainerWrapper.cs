using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using Alchemi.Core;
using Alchemi.Core.Manager;
using Alchemi.Manager;

namespace eduGRID_ManagerApp.Manager_Utilities
{
    class ManagerContainerWrapper
    {
        public ManagerContainer _container = null;
        public Configuration Config = null;
        public string ManagerName = "";
        static readonly Logger logger = new Logger();
        
        
        /// <summary>
        /// Event handler for status changes during Manager startup.
        /// </summary>
        public delegate void ManagerStartProgress(string statusMessage, int percentDone);

        public ManagerContainerWrapper()
        {
            ManagerContainer.ManagerStartEvent += new ManagerStartStatusEventHandler(this.Manager_StartStatusEvent);
            _container = new ManagerContainer();
            _container.RemotingConfigFile = "eduGRID_ManagerApp.exe.config";
            _container.ReadConfig(false, AppDomain.CurrentDomain.BaseDirectory, "eduGRIDManager.config.xml");
            Config = _container.Config;
            //After this is initialized, Application should read Config and fill up ui with default values
        }

        public bool Start(Configuration ConfigFromUI)
        {
            
            _container.Config = ConfigFromUI;


            try
            {
                _container.Start();

                Msgbox.ShowMsgbox("Manager started","Manager is Running!", "", "", "OK");

                //for heirarchical stuff
                //				if (Config.Intermediate)
                //				{
                //					//Config.Id = Manager.Id;
                //					//Config.Dedicated = Manager.Dedicated;
                //				}
                return true;

            }
            catch (Exception ex)
            {
                _container = null;
                string errorMsg = string.Format("Could not start Manager. Reason: {0}{1}", Environment.NewLine, ex.Message);
                if (ex.InnerException != null)
                {
                    errorMsg += string.Format("{0}", ex.InnerException.Message);
                }
                //Log(errorMsg);
                logger.Error(errorMsg, ex);
                return false;
            }


            //Application should refresh UI controls now

        }

        public bool Stop()
        {

            try
            {
                _container.Stop();
                _container = null;
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Error stopping manager", ex);
                return false;
            }

            //Refresh ui controlls
        }



        public static event ManagerStartProgress GRIDManagerStartProgress;

        public void Manager_StartStatusEvent(string msg, int percentDone)
        {
            //fire event here
            if (GRIDManagerStartProgress != null)
                GRIDManagerStartProgress(msg, percentDone);
        }
    }
}
