using System;
using System.Configuration;
using System.Collections;
using System.Windows.Forms;

// Add a reference to Control.interop.dll: interfaces used - IVideoWindow
// Add a reference to MDShowManager.dll: classes used - VideoDevice, MDShowUtility 
using MSR.LST.MDShow;

// Code Flow (CF)
// 1. Enumerate devices and select one.
// 2. Initialize it and set some properties on it.
// 3. Render it (connect the filters in the internal filtergraph for the device).
// 4. Set the video window to appear in a custom form, or let DShow provide the display form.
// 5. Call Run to start the graph processing
// 6. Dispose device when done (clean up internal filtergraph).

namespace DShowInterop
{
    public class MDShowInteropForm : System.Windows.Forms.Form
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new MDShowInteropForm());
        }


        public MDShowInteropForm()
        {
            InitializeComponent();
        }
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.CheckedListBox cklbCameras;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.cklbCameras = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // pb1
            // 
            this.pb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.pb1.Location = new System.Drawing.Point(0, 40);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(400, 300);
            this.pb1.TabIndex = 0;
            this.pb1.TabStop = false;
            // 
            // cklbCameras
            // 
            this.cklbCameras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.cklbCameras.Location = new System.Drawing.Point(0, 0);
            this.cklbCameras.Name = "cklbCameras";
            this.cklbCameras.Size = new System.Drawing.Size(400, 34);
            this.cklbCameras.TabIndex = 1;
            this.cklbCameras.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklbCameras_ItemCheck);
            // 
            // MDShowInteropForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(400, 342);
            this.Controls.Add(this.cklbCameras);
            this.Controls.Add(this.pb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MDShowInteropForm";
            this.Text = "MDShowInteropForm";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MDShowInteropForm_Closing);
            this.Load += new System.EventHandler(this.MDShowInteropForm_Load);
            this.ResumeLayout(false);

        }
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #endregion

        /// <summary>
        /// The selected video device
        /// </summary>
        private VideoCaptureGraph vcg;

        private void MDShowInteropForm_Load(object sender, System.EventArgs e)
        {
            // CF1 Add video devices to UI
            foreach(FilterInfo fi in VideoSource.Sources())
            {
                cklbCameras.Items.Add(fi);
            }
        }

        private void cklbCameras_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            if(e.NewValue == CheckState.Checked)
            {
                // We only support one device at a time for this sample
                UncheckAllDevices();

                // CF1 Select camera
                // CF2 Initialize - Create filter and internal graph
                vcg = new VideoCaptureGraph((FilterInfo)cklbCameras.SelectedItem); 
                vcg.RenderLocal();   // CF3 Connect all the filters
                VideoWindow();       // CF4 Set video window (if you like)
                vcg.Run();           // CF5 Start graph -> Show video
            }
            else // Unchecked
            {
                Cleanup();
            }
        }

        // CF4 Set the video window to a custom form
        private void VideoWindow()
        {
            // Must render before adjusting the VideoWindow
            IVideoWindow iVW = (IVideoWindow)vcg.FilgraphManager;
            iVW.Owner = pb1.Handle.ToInt32();
            iVW.SetWindowPosition(-4, -32, 408, 336);
        }

        private void Cleanup()
        {
            if(vcg != null)
            {
                vcg.Dispose(); // CF6 Dispose device when done (clean up internal filtergraph)
                vcg = null;

                // This shouldn't be necessary, but there seems to be some kind
                // of outstanding reference count that is taken care of here
                GC.Collect();
            }
        }

        private void MDShowInteropForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Cleanup();
        }

        private void UncheckAllDevices()
        {
            foreach(int i in cklbCameras.CheckedIndices)
            {
                cklbCameras.SetItemChecked(i, false);
            }
        }
    }
}
