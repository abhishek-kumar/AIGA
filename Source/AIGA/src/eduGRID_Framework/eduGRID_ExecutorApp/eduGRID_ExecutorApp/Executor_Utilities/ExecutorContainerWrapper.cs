using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using Alchemi.Core;
using Alchemi.Core.Executor;
using Alchemi.Executor;
using log4net;

namespace eduGRID_ExecutorApp.Executor_Utilities
{
    class ExecutorContainerWrapper
    {
        public ExecutorContainer _container = null;
        public Configuration Config = null;
        public string ExecutorName = "";
        static readonly Logger logger = new Logger();


        /// <summary>
        /// Event handler for status changes during Manager startup.
        /// </summary>
        public delegate void ExecutorStartProgress(string statusMessage, int percentDone);

        public ExecutorContainerWrapper()
        {
            _container = new ExecutorContainer();
            _container.ReadConfig(false);
            Config = _container.Config;

            //_container.NonDedicatedExecutingStatusChanged += new NonDedicatedExecutingStatusChangedEventHandler(this.RefreshUIControls);
            _container.GotDisconnected += new GotDisconnectedEventHandler(this.Executor_GotDisconnected);
            _container.ExecConnectEvent += new ExecutorConnectStatusEventHandler(this.ExecutorConnect_Status);


            //now application should refresh ui with config values

        }

        public bool Started
        {
            get
            {
                bool started = false;
                started = _container == null ? false : _container.Connected;
                return started;
            }
        }

        public void ConnectExecutor()
        {
            //should be called only when Config is upto date with ui
            try
            {
                Log("Attempting to connect to Manager...");
                _container.Config = Config;
                _container.Connect();
                Log("Connected to Manager.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error connecting to manager!");
                logger.Error("Error connecting to manager.", ex);
                Log("Error connecting to manager.");
                return;
            }

            //now to start execution
            try
            {
                foreach (GExecutor executor in _container.Executors)
                {
                    executor.StartNonDedicatedExecuting(1000);
                }
                
                Log("Started Execution.");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error starting Execution!");
                logger.Error("Error starting non-dedication execution.", ex);
                Log("Error starting non-dedication execution.");
            }
        }

        public void DisconnectExecutor()
        {
            //stop execution
            try
            {
                foreach (GExecutor executor in _container.Executors)
                {
                    executor.StopNonDedicatedExecuting();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error stopping non-dedication execution.", ex);
                Log("Error stopping non-dedication execution.");
            }

            //disconnect
            try
            {
                _container.Disconnect();
                Log("Disconnected successfully.");
            }
            catch (Exception ex)
            {
                logger.Debug("Error disconnecting from Manager.", ex);
                Log("Error disconnecting from Manager." + ex.Message);
            }
            
        }

        private void LogHandler(object sender, LogEventArgs e)
        {
            //Handle Log messages
            // Create a logger for use in this class
            ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            switch (e.Level)
            {
                case LogLevel.Debug:
                    string message = e.Source + ":" + e.Member + " - " + e.Message;
                    logger.Debug(message, e.Exception);
                    break;
                case LogLevel.Info:
                    logger.Info(e.Message);
                    break;
                case LogLevel.Error:
                    logger.Error(e.Message, e.Exception);
                    break;
                case LogLevel.Warn:
                    logger.Warn(e.Message, e.Exception);
                    break;
            }
        }

        private void RefreshUIControls()
        {

        }

        private void Executor_GotDisconnected()
        {
        }

        private void ExecutorConnect_Status(string msg, int percentDone)
        {
        }

        private void Log(string LString)
        {
        }
    }
}
