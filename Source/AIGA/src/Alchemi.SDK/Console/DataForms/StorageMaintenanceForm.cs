#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
* Title         :  StorageMaintenanceForm.cs
* Project       :  Alchemi.Console.DataForms
* Created on    :  05 May 2006
* Copyright     :  Copyright © 2006 Tibor Biro (tb@tbiro.com)
* Author        :  Tibor Biro (tb@tbiro.com)
* License       :  GPL
*                    This program is free software; you can redistribute it and/or
*                    modify it under the terms of the GNU General Public
*                    License as published by the Free Software Foundation;
*                    See the GNU General Public License
*                    (http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/
#endregion

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Alchemi.Core;
using Alchemi.Core.Owner;
using Alchemi.Core.Manager.Storage;

namespace Alchemi.Console.DataForms
{
    public partial class StorageMaintenanceForm : Form
    {
        private ConsoleNode m_console;
        private StorageMaintenanceParameters m_maintenanceParameters;
        private Thread m_maintenanceThread;
        private PleaseWait m_pleaseWait;
        private String m_errorMessage;
        private bool m_success;

        public StorageMaintenanceForm(ConsoleNode console)
        {
            InitializeComponent();

            m_console = console;

            this.Load += new EventHandler(StorageMaintenanceForm_Load);
        }

        void StorageMaintenanceForm_Load(object sender, EventArgs e)
        {
            lstApplicationStatesToRemove.Items.Clear();

            ApplicationState[] states = (ApplicationState[])Enum.GetValues(typeof(ApplicationState));

            foreach (ApplicationState state in states)
            {
                lstApplicationStatesToRemove.Items.Add(state);
            }
        }

        /// <summary>
        /// convert the controls options into the StorageMaintenanceParameters object
        /// </summary>
        /// <returns></returns>
        private StorageMaintenanceParameters GetStorageMaintenanceParameters()
        {
            StorageMaintenanceParameters result = new StorageMaintenanceParameters();

            // application level options
            result.RemoveAllApplications = chkRemoveAllApplications.Checked;
            
            if (chkRemoveApplicationsByState.Checked)
            {
                IEnumerator enumerator = lstApplicationStatesToRemove.SelectedItems.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    result.AddApplicationStateToRemove((ApplicationState)enumerator.Current);
                }
            }

            if (chkRemoveApplicationsByTimeCreated.Checked)
            {
                result.ApplicationTimeCreatedCutOff = new TimeSpan(0, Convert.ToInt32(numTimeApplicationCreatedCutOffInMinutes.Value), 0);
            }

            if (chkRemoveApplicationsByTimeCompleted.Checked)
            {
                result.ApplicationTimeCompletedCutOff = new TimeSpan(0, Convert.ToInt32(numTimeApplicationCompletedCutOffInMinutes.Value), 0);
            }

            // executor level options
            result.RemoveAllExecutors = chkRemoveAllExecutors.Checked;

            if (chkRemoveExecutorsByTimePinged.Checked)
            {
                result.ExecutorPingTimeCutOff = new TimeSpan(0, Convert.ToInt32(numTimeExecutorPingedCutOffInMinutes.Value), 0);
            }

            return result;
        }

        private void btnPerformMaintenance_Click(object sender, EventArgs e)
        {
            m_maintenanceParameters = GetStorageMaintenanceParameters();

            m_success = false;

            m_maintenanceThread = new Thread(new ThreadStart(MaintenanceWorkerThread));

            m_maintenanceThread.Start();

            //wait a bit to see if it is done already and if so no longer display the wait dialog.
            m_maintenanceThread.Join(1000);

            if (m_maintenanceThread.ThreadState != System.Threading.ThreadState.Stopped)
            {

                // put up the display dialog
                m_pleaseWait = new PleaseWait();

                if (m_pleaseWait.ShowDialog() != DialogResult.OK)
                {
                    m_maintenanceThread.Join(1000);

                    m_maintenanceThread.Abort();
                }
            }

            m_maintenanceThread = null;

            StringBuilder message = new StringBuilder();

            if (m_success)
            {
                message.Append("Maintenance task completed.");
            }
            else
            {
                message.Append("Maintenance task aborted.");

                if (m_errorMessage != null)
                {
                    message.AppendFormat(" Error message: {0}", m_errorMessage);
                }
            }

            MessageBox.Show(message.ToString());
        }

        /// <summary>
        /// Called from inside the thread to signal that the thread completed.
        /// This must be called from the UI thread.
        /// </summary>
        private void WorkerThreadCompleted()
        {
            m_pleaseWait.DialogResult = DialogResult.OK;
        }

        private void WorkerThreadAborted()
        {
            m_pleaseWait.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Thread doing the call to the server. 
        /// This call might block so in order to get a decent UI response a separate thread is necessary.
        /// </summary>
        private void MaintenanceWorkerThread()
        {
            try
            {
                m_console.Manager.Admon_PerformStorageMaintenance(m_console.Credentials, m_maintenanceParameters);
            }
            catch (AuthorizationException aex)
            {
                m_errorMessage = aex.Message;
                m_success = false;

                // done, let everybody know that we are done
                MethodInvoker mia = new MethodInvoker(WorkerThreadAborted);
                mia.BeginInvoke(null, null);

                return;
            }
            catch (Exception ex)
            {
                m_errorMessage = ex.ToString();
                m_success = false;

                // done, let everybody know that we are done
                MethodInvoker mia = new MethodInvoker(WorkerThreadAborted);
                mia.BeginInvoke(null, null);

                return;
            }

            m_success = true;

            // done, let everybody know that we are done
            MethodInvoker mic = new MethodInvoker(WorkerThreadCompleted);
            mic.BeginInvoke(null, null);
        }

        private void chkRemoveAllExecutors_CheckedChanged(object sender, EventArgs e)
        {
            EnabledControls();
        }

        private void chkRemoveAllApplications_CheckedChanged(object sender, EventArgs e)
        {
            EnabledControls();
        }

        /// <summary>
        /// Update the enabled controls based on the selections.
        /// 
        /// Rules:
        /// 
        /// If all executors are to be deleted the specific executor level options are disabled
        /// If all applications are to be deleted the specific application level options are disabled
        /// 
        /// </summary>
        public void EnabledControls()
        {
            if (chkRemoveAllApplications.Checked)
            {
                chkRemoveApplicationsByTimeCreated.Enabled = false;
                numTimeApplicationCreatedCutOffInMinutes.Enabled = false;

                chkRemoveApplicationsByTimeCompleted.Enabled = false;
                numTimeApplicationCompletedCutOffInMinutes.Enabled = false;

                chkRemoveApplicationsByState.Enabled = false;
                lstApplicationStatesToRemove.Enabled = false;
            }
            else
            {
                chkRemoveApplicationsByTimeCreated.Enabled = true;
                numTimeApplicationCreatedCutOffInMinutes.Enabled = true;

                chkRemoveApplicationsByTimeCompleted.Enabled = true;
                numTimeApplicationCompletedCutOffInMinutes.Enabled = true;

                chkRemoveApplicationsByState.Enabled = true;
                lstApplicationStatesToRemove.Enabled = true;
            }

            if (chkRemoveAllExecutors.Checked)
            {
                chkRemoveExecutorsByTimePinged.Enabled = false;
                numTimeExecutorPingedCutOffInMinutes.Enabled = false;
            }
            else
            {
                chkRemoveExecutorsByTimePinged.Enabled = true;
                numTimeExecutorPingedCutOffInMinutes.Enabled = true;
            }

        }

    }
}