using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eduGRID_ExecutorApp
{
    public partial class MainBG : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        Executor_Utilities.ExecutorContainerWrapper CurrentExecutorWrapper=null;
        Executor_Utilities.ExecutorContainerWrapper[] ExecutorCollection=null;

        public MainBG()
        {
            InitializeComponent();
        }


        private void Create_Executor()
        {
            if (ExecutorCollection == null)
                ExecutorCollection = new Executor_Utilities.ExecutorContainerWrapper[1];
            else
                Array.Resize(ref ExecutorCollection, ExecutorCollection.Length + 1);

            ExecutorCollection[ExecutorCollection.GetUpperBound(0)] = new Executor_Utilities.ExecutorContainerWrapper();
            CurrentExecutorWrapper = ExecutorCollection[ExecutorCollection.GetUpperBound(0)];

            RefreshUIControls();

            inspect_Executor.BringToFront();
            inspect_Executor.Visible = true;
        }

        private void RefreshUIControls()
        {
            bool connected = CurrentExecutorWrapper.Started;

            txMgrHost.Text = CurrentExecutorWrapper.Config.ManagerHost;
            txMgrPort.Text = CurrentExecutorWrapper.Config.ManagerPort.ToString();

            cmbId.Items.Clear();
            for (int index = 0; index < CurrentExecutorWrapper.Config.GetIdCount(); index++)
            {
                cmbId.Items.Add(CurrentExecutorWrapper.Config.GetIdAtLocation(index));

                if (index == 0)
                {
                    cmbId.SelectedIndex = index;
                }
            }

            txOwnPort.Text = CurrentExecutorWrapper.Config.OwnPort.ToString();
            txUsername.Text = CurrentExecutorWrapper.Config.Username;
            txPassword.Text = CurrentExecutorWrapper.Config.Password;
            cbDedicated.Checked = CurrentExecutorWrapper.Config.Dedicated;

            btn_Executor_Start.Enabled = !connected;
            btn_Executor_Reset.Enabled = !connected;
            btn_Executor_Stop.Enabled = !btn_Executor_Start.Enabled;

            txMgrHost.Enabled = !connected;
            txMgrPort.Enabled = !connected;
            txUsername.Enabled = !connected;
            txPassword.Enabled = !connected;
            txOwnPort.Enabled = !connected;
            cbDedicated.Enabled = !connected;

            //udHBInterval.Value = (decimal)CurrentExecutorWrapper.Config.HeartBeatInterval;
            //udMaxRetry.Value = (decimal)CurrentExecutorWrapper.Config.RetryMax;

            //chkRetryConnect.Checked = CurrentExecutorWrapper.Config.RetryConnect;
            //udReconnectInterval.Value = (decimal)CurrentExecutorWrapper.Config.RetryInterval;

            PBar.Visible = false;
            PBar.Value = 0;

            bool executing = false;
            if (CurrentExecutorWrapper._container != null && CurrentExecutorWrapper._container.Executors != null)
            {
                foreach (Alchemi.Executor.GExecutor executor in CurrentExecutorWrapper._container.Executors)
                {
                    if (executor != null && executor.ExecutingNonDedicated)
                    {
                        executing = true;
                        break;
                    }
                }

            }
            Exctr_instance_return.Enabled = ((!CurrentExecutorWrapper.Config.Dedicated) && (connected) && (!executing));
            //btStopExec.Enabled = ((!CurrentExecutorWrapper.Config.Dedicated) && (connected) && (executing));

            //string sbAppend = (CurrentExecutorWrapper.Config.Dedicated ? " (dedicated)" : " (non-dedicated)");
            if ((connected && executing) || (connected && CurrentExecutorWrapper.Config.Dedicated))
            {
                inspect_Executor.ValuesSecondary.Description = "Executing";
            }
            else if (connected)
            {
                inspect_Executor.ValuesSecondary.Description = "Connected";
            }
            else
            {
                inspect_Executor.ValuesSecondary.Description = "Disconnected";
            }
        }

        private void GetConfigFromUI()
        {
            if (CurrentExecutorWrapper.Config == null)
            {
                CurrentExecutorWrapper.Config = new Alchemi.Executor.Configuration();
            }
            // read config from ui controls
            CurrentExecutorWrapper.Config.ManagerHost = txMgrHost.Text;
            CurrentExecutorWrapper.Config.ManagerPort = int.Parse(txMgrPort.Text);
            CurrentExecutorWrapper.Config.OwnPort = int.Parse(txOwnPort.Text);
            CurrentExecutorWrapper.Config.Dedicated = false;// cbDedicated.Checked;
            CurrentExecutorWrapper.Config.HeartBeatInterval = 5;// (int)udHBInterval.Value;
            CurrentExecutorWrapper.Config.RetryConnect = true;// chkRetryConnect.Checked;
            CurrentExecutorWrapper.Config.RetryInterval = 30;// (int)udReconnectInterval.Value;
            CurrentExecutorWrapper.Config.RetryMax = 3;// (int)udMaxRetry.Value;
        }

        private void Connections_Click(object sender, EventArgs e)
        {
            Create_Executor();
        }

        private void btn_Executor_Start_Click(object sender, EventArgs e)
        {
            GetConfigFromUI();
            CurrentExecutorWrapper.ConnectExecutor();
            RefreshUIControls();
        }

        private void btn_Executor_Stop_Click(object sender, EventArgs e)
        {
            CurrentExecutorWrapper.DisconnectExecutor();
            RefreshUIControls();
        }

        private void btn_Executor_Reset_Click(object sender, EventArgs e)
        {
            CurrentExecutorWrapper._container.ReadConfig(true);
            CurrentExecutorWrapper.Config = CurrentExecutorWrapper._container.Config;
            RefreshUIControls();
        }

        private void Exctr_instance_return_Click(object sender, EventArgs e)
        {
            CurrentExecutorWrapper.ConnectExecutor();
            RefreshUIControls();

        }
    }
}