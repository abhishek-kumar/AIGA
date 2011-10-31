using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using System.ServiceProcess;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSR.LST;

namespace MSR.LST.Services
{
    /// <summary>
    /// Summary description for ServiceControlButtons.
    /// </summary>
    public class ServiceControlButtons : System.Windows.Forms.UserControl
    {
        #region WinForm Designer Privates
        private MSR.LST.MediaControlButton startServiceBtn;
        private MSR.LST.MediaControlButton stopServiceBtn;
        private System.Windows.Forms.Label startServiceLbl;
        private System.Windows.Forms.Label stopServiceLbl;
        private System.Windows.Forms.CheckBox autoStartChkBx;
        private System.ComponentModel.Container components = null;
        #endregion

        #region Members
        private string serviceName;

        private SimpleServiceController service = null;
        #endregion

        #region Constructor, Dispose
        public ServiceControlButtons()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }
        #endregion

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startServiceBtn = new MSR.LST.MediaControlButton();
            this.stopServiceBtn = new MSR.LST.MediaControlButton();
            this.startServiceLbl = new System.Windows.Forms.Label();
            this.stopServiceLbl = new System.Windows.Forms.Label();
            this.autoStartChkBx = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // startServiceBtn
            // 
            this.startServiceBtn.ImageType = MSR.LST.MediaControlImage.Play;
            this.startServiceBtn.Location = new System.Drawing.Point(0, 0);
            this.startServiceBtn.Name = "startServiceBtn";
            this.startServiceBtn.Size = new System.Drawing.Size(24, 24);
            this.startServiceBtn.TabIndex = 7;
            this.startServiceBtn.Click += new System.EventHandler(this.startServiceBtn_Click);
            // 
            // stopServiceBtn
            // 
            this.stopServiceBtn.ImageType = MSR.LST.MediaControlImage.Stop;
            this.stopServiceBtn.Location = new System.Drawing.Point(0, 36);
            this.stopServiceBtn.Name = "stopServiceBtn";
            this.stopServiceBtn.Size = new System.Drawing.Size(24, 24);
            this.stopServiceBtn.TabIndex = 8;
            this.stopServiceBtn.Click += new System.EventHandler(this.stopServiceBtn_Click);
            // 
            // startServiceLbl
            // 
            this.startServiceLbl.Location = new System.Drawing.Point(32, 0);
            this.startServiceLbl.Name = "startServiceLbl";
            this.startServiceLbl.Size = new System.Drawing.Size(72, 24);
            this.startServiceLbl.TabIndex = 5;
            this.startServiceLbl.Text = "Start Service";
            this.startServiceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stopServiceLbl
            // 
            this.stopServiceLbl.Location = new System.Drawing.Point(32, 36);
            this.stopServiceLbl.Name = "stopServiceLbl";
            this.stopServiceLbl.Size = new System.Drawing.Size(72, 24);
            this.stopServiceLbl.TabIndex = 6;
            this.stopServiceLbl.Text = "Stop Service";
            this.stopServiceLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // autoStartChkBx
            // 
            this.autoStartChkBx.Location = new System.Drawing.Point(128, 32);
            this.autoStartChkBx.Name = "autoStartChkBx";
            this.autoStartChkBx.Size = new System.Drawing.Size(176, 28);
            this.autoStartChkBx.TabIndex = 9;
            this.autoStartChkBx.Text = "Automatically start this service when the system starts";
            this.autoStartChkBx.CheckedChanged += new System.EventHandler(this.autoStartChkBx_CheckedChanged);
            // 
            // ServiceControlButtons
            // 
            this.Controls.Add(this.startServiceBtn);
            this.Controls.Add(this.stopServiceBtn);
            this.Controls.Add(this.startServiceLbl);
            this.Controls.Add(this.stopServiceLbl);
            this.Controls.Add(this.autoStartChkBx);
            this.Name = "ServiceControlButtons";
            this.Size = new System.Drawing.Size(304, 60);
            this.ResumeLayout(false);

        }
        #endregion

        #region Properties
        public string ServiceName
        {
            get
            {
                return serviceName;
            }
            set
            {
                serviceName = value;
            }
        }

        /// <summary>
        /// The service to which we connect to start, stop, and change settings.
        /// </summary>
        public SimpleServiceController ServiceController
        {
            get
            {
                return service;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Connects to the Reflector service using the App.Config setting and sets the
        /// status of the service start/stop buttons as necessary.
        /// </summary>
        /// <returns>
        /// True if connected ok; false if can't find service
        /// </returns>
        public bool ConnectToService()
        {
            try
            {
                if( serviceName != null )
                {
                    service = new SimpleServiceController(serviceName);
                }

                SetServiceStatus();
            }
            catch
            {
                this.service = null;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sets the enabled/disabled property on the three service-related UI elements
        /// </summary>
        public void SetServiceStatus()
        {
            if( service == null )
            {
                this.startServiceBtn.Enabled = false;
                this.stopServiceBtn.Enabled = false;
                this.autoStartChkBx.Enabled = false;
            }
            else
            {
                this.startServiceBtn.Enabled = service.Stopped;
                this.stopServiceBtn.Enabled = service.Running;
                this.autoStartChkBx.Checked = service.AutoStartService;
            }
        }
        #endregion

        #region Event Handlers
        public void stopServiceBtn_Click(object sender, System.EventArgs e)
        {
            if (service.Stopped)
            {
                MessageBox.Show(this, "The service is already stopped.", "Service Stopped",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    service.StopServiceAndWait();
                }
                catch (System.ServiceProcess.TimeoutException)
                {
                    MessageBox.Show(this, "The service did not stop in a timely fashion."
                        + "\nMake sure the service is stopped.", "Service Stop Timeout",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            SetServiceStatus();
        }

        public void startServiceBtn_Click(object sender, System.EventArgs e)
        {
            if (service.Running)
            {
                MessageBox.Show(this, "The service is already started.", "Service Started",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    service.StartServiceAndWait();
                }
                catch (System.ServiceProcess.TimeoutException)
                {
                    MessageBox.Show(this, "The service did not start in a timely fashion."
                        + "\nMake sure the service is started.", "Service Start Timeout",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            SetServiceStatus();
        }

        public void autoStartChkBx_CheckedChanged(object sender, System.EventArgs e)
        {
            service.AutoStartService = autoStartChkBx.Checked;
        }
        #endregion
    }
}
