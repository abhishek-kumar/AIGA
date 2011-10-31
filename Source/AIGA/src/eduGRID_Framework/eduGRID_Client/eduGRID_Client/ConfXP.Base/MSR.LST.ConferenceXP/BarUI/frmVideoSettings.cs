using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;
using MSR.LST.MDShow;

namespace MSR.LST.ConferenceXP
{
    public class frmVideoSettings : System.Windows.Forms.Form
    {
        #region Windows Form Designer generated code

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox ckEnableCompression;
        private System.Windows.Forms.Label lblBitRate;
        private System.Windows.Forms.HScrollBar hsbBitRate;
        private System.Windows.Forms.Label lblKeyFrameRate;
        private System.Windows.Forms.HScrollBar hsbKeyFrameRate;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnVideo;
        private System.Windows.Forms.GroupBox gbCustomCompression;
        private System.Windows.Forms.GroupBox gbCurrentSettings;
        private System.Windows.Forms.Label lblCurrentSettings;
        private System.Windows.Forms.ComboBox cboUpstreamPropPages;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Label lblMoreConfig;
        private System.Windows.Forms.GroupBox gbCameraAndVideo;

        private System.ComponentModel.Container components = null;
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.cboUpstreamPropPages = new System.Windows.Forms.ComboBox();
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnVideo = new System.Windows.Forms.Button();
            this.gbCurrentSettings = new System.Windows.Forms.GroupBox();
            this.lblCurrentSettings = new System.Windows.Forms.Label();
            this.gbCustomCompression = new System.Windows.Forms.GroupBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.lblBitRate = new System.Windows.Forms.Label();
            this.hsbBitRate = new System.Windows.Forms.HScrollBar();
            this.lblKeyFrameRate = new System.Windows.Forms.Label();
            this.hsbKeyFrameRate = new System.Windows.Forms.HScrollBar();
            this.btnApply = new System.Windows.Forms.Button();
            this.ckEnableCompression = new System.Windows.Forms.CheckBox();
            this.lblMoreConfig = new System.Windows.Forms.Label();
            this.gbCameraAndVideo = new System.Windows.Forms.GroupBox();
            this.gbCurrentSettings.SuspendLayout();
            this.gbCustomCompression.SuspendLayout();
            this.gbCameraAndVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnOK.Location = new System.Drawing.Point(424, 256);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 23);
            this.btnOK.TabIndex = 42;
            this.btnOK.Text = "Close";
            // 
            // cboUpstreamPropPages
            // 
            this.cboUpstreamPropPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUpstreamPropPages.Enabled = false;
            this.cboUpstreamPropPages.Location = new System.Drawing.Point(8, 70);
            this.cboUpstreamPropPages.Name = "cboUpstreamPropPages";
            this.cboUpstreamPropPages.Size = new System.Drawing.Size(272, 21);
            this.cboUpstreamPropPages.TabIndex = 64;
            this.cboUpstreamPropPages.SelectedIndexChanged += new System.EventHandler(this.cboUpstreamPropPages_SelectedIndexChanged);
            // 
            // btnCamera
            // 
            this.btnCamera.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCamera.Location = new System.Drawing.Point(8, 20);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(120, 24);
            this.btnCamera.TabIndex = 65;
            this.btnCamera.Text = "btnCamera";
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnVideo
            // 
            this.btnVideo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVideo.Location = new System.Drawing.Point(152, 20);
            this.btnVideo.Name = "btnVideo";
            this.btnVideo.Size = new System.Drawing.Size(128, 24);
            this.btnVideo.TabIndex = 66;
            this.btnVideo.Text = "btnVideo";
            this.btnVideo.Click += new System.EventHandler(this.btnVideo_Click);
            // 
            // gbCurrentSettings
            // 
            this.gbCurrentSettings.Controls.Add(this.lblCurrentSettings);
            this.gbCurrentSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbCurrentSettings.Location = new System.Drawing.Point(304, 8);
            this.gbCurrentSettings.Name = "gbCurrentSettings";
            this.gbCurrentSettings.Size = new System.Drawing.Size(216, 238);
            this.gbCurrentSettings.TabIndex = 68;
            this.gbCurrentSettings.TabStop = false;
            this.gbCurrentSettings.Text = "gbCurrentSettings";
            // 
            // lblCurrentSettings
            // 
            this.lblCurrentSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblCurrentSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblCurrentSettings.Location = new System.Drawing.Point(3, 16);
            this.lblCurrentSettings.Name = "lblCurrentSettings";
            this.lblCurrentSettings.Size = new System.Drawing.Size(210, 219);
            this.lblCurrentSettings.TabIndex = 63;
            this.lblCurrentSettings.Text = "lblCurrentSettings";
            // 
            // gbCustomCompression
            // 
            this.gbCustomCompression.Controls.Add(this.btnDefault);
            this.gbCustomCompression.Controls.Add(this.lblBitRate);
            this.gbCustomCompression.Controls.Add(this.hsbBitRate);
            this.gbCustomCompression.Controls.Add(this.lblKeyFrameRate);
            this.gbCustomCompression.Controls.Add(this.hsbKeyFrameRate);
            this.gbCustomCompression.Controls.Add(this.btnApply);
            this.gbCustomCompression.Enabled = false;
            this.gbCustomCompression.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbCustomCompression.Location = new System.Drawing.Point(8, 112);
            this.gbCustomCompression.Name = "gbCustomCompression";
            this.gbCustomCompression.Size = new System.Drawing.Size(288, 136);
            this.gbCustomCompression.TabIndex = 70;
            this.gbCustomCompression.TabStop = false;
            // 
            // btnDefault
            // 
            this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDefault.Location = new System.Drawing.Point(8, 104);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(104, 23);
            this.btnDefault.TabIndex = 83;
            this.btnDefault.Text = "btnDefault";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // lblBitRate
            // 
            this.lblBitRate.Location = new System.Drawing.Point(8, 64);
            this.lblBitRate.Name = "lblBitRate";
            this.lblBitRate.Size = new System.Drawing.Size(240, 16);
            this.lblBitRate.TabIndex = 68;
            this.lblBitRate.Text = "lblBitRate";
            // 
            // hsbBitRate
            // 
            this.hsbBitRate.LargeChange = 1;
            this.hsbBitRate.Location = new System.Drawing.Point(8, 80);
            this.hsbBitRate.Minimum = 1;
            this.hsbBitRate.Name = "hsbBitRate";
            this.hsbBitRate.Size = new System.Drawing.Size(272, 17);
            this.hsbBitRate.TabIndex = 69;
            this.hsbBitRate.TabStop = true;
            this.hsbBitRate.Value = 1;
            this.hsbBitRate.ValueChanged += new System.EventHandler(this.hsbBitRate_ValueChanged);
            // 
            // lblKeyFrameRate
            // 
            this.lblKeyFrameRate.Location = new System.Drawing.Point(8, 24);
            this.lblKeyFrameRate.Name = "lblKeyFrameRate";
            this.lblKeyFrameRate.Size = new System.Drawing.Size(248, 16);
            this.lblKeyFrameRate.TabIndex = 66;
            this.lblKeyFrameRate.Text = "lblKeyFrameRate";
            // 
            // hsbKeyFrameRate
            // 
            this.hsbKeyFrameRate.LargeChange = 1;
            this.hsbKeyFrameRate.Location = new System.Drawing.Point(8, 40);
            this.hsbKeyFrameRate.Maximum = 8;
            this.hsbKeyFrameRate.Minimum = 1;
            this.hsbKeyFrameRate.Name = "hsbKeyFrameRate";
            this.hsbKeyFrameRate.Size = new System.Drawing.Size(272, 16);
            this.hsbKeyFrameRate.TabIndex = 67;
            this.hsbKeyFrameRate.Value = 1;
            this.hsbKeyFrameRate.ValueChanged += new System.EventHandler(this.hsbKeyFrameRate_ValueChanged);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnApply.Location = new System.Drawing.Point(184, 104);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(95, 23);
            this.btnApply.TabIndex = 82;
            this.btnApply.Text = "btnApply";
            this.btnApply.Click += new System.EventHandler(this.btnApplyCompression_Click);
            // 
            // ckEnableCompression
            // 
            this.ckEnableCompression.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckEnableCompression.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ckEnableCompression.Location = new System.Drawing.Point(16, 112);
            this.ckEnableCompression.Name = "ckEnableCompression";
            this.ckEnableCompression.Size = new System.Drawing.Size(144, 16);
            this.ckEnableCompression.TabIndex = 64;
            this.ckEnableCompression.Text = "ckEnableCompression";
            this.ckEnableCompression.CheckedChanged += new System.EventHandler(this.ckEnableCompression_CheckedChanged);
            // 
            // lblMoreConfig
            // 
            this.lblMoreConfig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMoreConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblMoreConfig.Location = new System.Drawing.Point(8, 54);
            this.lblMoreConfig.Name = "lblMoreConfig";
            this.lblMoreConfig.Size = new System.Drawing.Size(272, 16);
            this.lblMoreConfig.TabIndex = 80;
            this.lblMoreConfig.Text = "lblMoreConfig";
            // 
            // gbCameraAndVideo
            // 
            this.gbCameraAndVideo.Controls.Add(this.lblMoreConfig);
            this.gbCameraAndVideo.Controls.Add(this.btnVideo);
            this.gbCameraAndVideo.Controls.Add(this.btnCamera);
            this.gbCameraAndVideo.Controls.Add(this.cboUpstreamPropPages);
            this.gbCameraAndVideo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbCameraAndVideo.Location = new System.Drawing.Point(8, 10);
            this.gbCameraAndVideo.Name = "gbCameraAndVideo";
            this.gbCameraAndVideo.Size = new System.Drawing.Size(288, 100);
            this.gbCameraAndVideo.TabIndex = 82;
            this.gbCameraAndVideo.TabStop = false;
            this.gbCameraAndVideo.Text = "Configure Camera and Video Stream";
            // 
            // frmVideoSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(530, 288);
            this.ControlBox = false;
            this.Controls.Add(this.gbCameraAndVideo);
            this.Controls.Add(this.ckEnableCompression);
            this.Controls.Add(this.gbCustomCompression);
            this.Controls.Add(this.gbCurrentSettings);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmVideoSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmVideoSettings_Load);
            this.gbCurrentSettings.ResumeLayout(false);
            this.gbCustomCompression.ResumeLayout(false);
            this.gbCameraAndVideo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        
        #endregion

        #region Statics

        private const string TAB = "     ";

        private const int BitRateMultiplier = 50;

        #endregion STatics

        #region Members

        private VideoCapability vc;
        private VideoCaptureGraph vcg;

        private frmAVDevices frmAV;

        #endregion Members

        #region Constructor

        public frmVideoSettings(VideoCapability vc, frmAVDevices frmAV)
        {
            InitializeComponent();

            Debug.Assert(vc != null);
            Debug.Assert(vc.VideoCaptureGraph != null);
            Debug.Assert(frmAV != null);

            this.vc = vc;
            this.vcg = vc.VideoCaptureGraph;
            this.frmAV = frmAV;
        }


        #endregion Constructor

        #region Load

        private void frmVideoSettings_Load(object sender, System.EventArgs e)
        {
            StaticText();
            InitializeUI();
        }

        private void StaticText()
        {
            lblMoreConfig.Text = "Additional camera configuration options (if available)";
            btnCamera.Text = "Camera...";
            btnVideo.Text = "Video Format...";
            ckEnableCompression.Text = "Enable Video Compression";
            btnDefault.Text = "Restore Defaults";
            btnApply.Text = "Apply";
            gbCurrentSettings.Text = "Current Settings";
        }
        
        private void InitializeUI()
        {
            try
            {
                this.Text = "Advanced Video Settings: " + vcg.Source.FriendlyName;

                IBaseFilter[] upstreamFilters = vcg.Source.UpstreamFilters;
                if(upstreamFilters != null && upstreamFilters.Length > 0)
                {
                    ArrayList propPages = new ArrayList();
                    foreach(IBaseFilter iBF in upstreamFilters)
                    {
                        if(Filter.HasDialog(iBF))
                        {
                            propPages.Add(new PropertyPage((ISpecifyPropertyPages)iBF,
                                Filter.Name(iBF)));
                        }
                    }

                    // Populate the property page configuration combo box
                    cboUpstreamPropPages.DataSource = propPages;
                    cboUpstreamPropPages.DisplayMember = "Name";
                    cboUpstreamPropPages.SelectedIndex = 0;

                    cboUpstreamPropPages.Enabled = true;
                }

                // Enable the appropriate buttons
                btnCamera.Enabled = vcg.Source.HasSourceDialog;
                btnVideo.Enabled = vcg.Source.HasFormatDialog;

                // Update compressor settings
                ckEnableCompression.Enabled = false;
                ckEnableCompression.Checked = vc.RegCompressorEnabled;
                ckEnableCompression.Enabled = true;

                // Get these setup correctly whether there is a compressor or not
                UpdateKeyFrameRateLabel();
                UpdateBitRateLabel();

                UpdateCurrentSettings();
            }
            catch(COMException ex)
            {
                Log(DShowError._AMGetErrorText(ex.ErrorCode));
                Log(ex.ToString());
            }
            catch(Exception ex)
            {
                Log(ex.ToString());
            }
        }


        #endregion Load

        private void btnCamera_Click(object sender, System.EventArgs e)
        {
            try
            {
                if(vcg.VideoSource.HasSourceDialog)
                {
                    // Vfw is not as flexible as WDM, need to stop the graph first
                    if(vcg.VideoSource.IsVfw)
                    {
                        frmAV.RenderAndRunVideo(vcg, false);
                        vcg.RemoveFiltersDownstreamFrom(vcg.Source);
                    }

                    vcg.VideoSource.ShowSourceDialog(this.Handle);
                    
                    if(vcg.VideoSource.IsVfw)
                    {
                        vc.AddVideoCompressor();
                        frmAV.RenderAndRunVideo(vcg);
                    }

                    vc.SaveCameraSettings();
                    UpdateCurrentSettings();
                }
            }
            catch(COMException ex)
            {
                Log(DShowError._AMGetErrorText(ex.ErrorCode));
                Log(ex.ToString());
            }
            catch(Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private void btnVideo_Click(object sender, System.EventArgs e)
        {
            try
            {
                if(vcg.VideoSource.HasFormatDialog)
                {
                    frmAV.RenderAndRunVideo(vcg, false);
                    vcg.RemoveFiltersDownstreamFrom(vcg.Source);

                    vcg.VideoSource.ShowFormatDialog(this.Handle);
                
                    vc.AddVideoCompressor();
                    frmAV.RenderAndRunVideo(vcg);
    
                    vc.SaveVideoSettings();
                    UpdateCurrentSettings();
                }
            }
            catch(COMException ex)
            {
                Log(DShowError._AMGetErrorText(ex.ErrorCode));
                Log(ex.ToString());
            }
            catch(Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private void cboUpstreamPropPages_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if(cboUpstreamPropPages.Enabled) // Flag for programmatic vs. user input
                {
                    PropertyPage pp = (PropertyPage)cboUpstreamPropPages.SelectedItem;
                    pp.Show(this.Handle);

                    // To save Crossbar info
                    vc.SaveCameraSettings();
                    UpdateCurrentSettings();
                }
            }
            catch(COMException ex)
            {
                Log(DShowError._AMGetErrorText(ex.ErrorCode));
                Log(ex.ToString());
            }
            catch(Exception ex)
            {
                Log(ex.ToString());
            }
        }

        
        private void ckEnableCompression_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                gbCustomCompression.Enabled = ckEnableCompression.Checked;

                if(ckEnableCompression.Enabled) // Flag for programmatic / user
                {
                    frmAV.RenderAndRunVideo(vcg, false);

                    // Must come before vc.AddVideoCompressor
                    vc.RegCompressorEnabled = ckEnableCompression.Checked;

                    if(ckEnableCompression.Checked)
                    {
                        vc.AddVideoCompressor();
                    }
                    else
                    {
                        vcg.RemoveCompressor();
                    }

                    frmAV.RenderAndRunVideo(vcg);

                    UpdateCurrentSettings();
                }
            }
            catch(COMException ex)
            {
                Log(DShowError._AMGetErrorText(ex.ErrorCode));
                Log(ex.ToString());
            }
            catch(Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private void hsbBitRate_ValueChanged(object sender, System.EventArgs e)
        {
            UpdateBitRateLabel();
        }

        private void hsbKeyFrameRate_ValueChanged(object sender, System.EventArgs e)
        {
            UpdateKeyFrameRateLabel();
        }


        private void btnDefault_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmAV.RenderAndRunVideo(vcg, false);

                vc.RegCustomCompression = false;
                vc.AddVideoCompressor();

                frmAV.RenderAndRunVideo(vcg);

                UpdateCurrentSettings();
            }
            catch(COMException ex)
            {
                Log(DShowError._AMGetErrorText(ex.ErrorCode));
                Log(ex.ToString());
            }
            catch(Exception ex)
            {
                Log(ex.ToString());
            }
        }

        private void btnApplyCompression_Click(object sender, System.EventArgs e)
        {
            try
            {
                frmAV.RenderAndRunVideo(vcg, false);

                // Create the custom settings and set them
                VideoCompressorQualityInfo vcqi = VideoCompressor.DefaultQualityInfo;
                vcqi.BitRate = (uint)BitRateValue;
                vcqi.KeyFrameRate = KeyFrameRateValue;
                vcg.VideoCompressor.QualityInfo = vcqi;

                frmAV.RenderAndRunVideo(vcg);

                // Save them
                vc.SaveVideoCompressorSettings();
                vc.RegCustomCompression = true;

                UpdateCurrentSettings();
            }
            catch(COMException ex)
            {
                Log(DShowError._AMGetErrorText(ex.ErrorCode));
                Log(ex.ToString());
            }
            catch(Exception ex)
            {
                Log(ex.ToString());
            }
        }
        

        private void UpdateCurrentSettings()
        {
            lblCurrentSettings.Text = null;

            UpdateCustomCompressionFields();

            UpdateCameraSettings();
            UpdateVideoSettings();
            UpdateCompressorSettings();
        }

        private void UpdateCameraSettings()
        {
            VideoSource vs = vcg.VideoSource;
            if(vs.HasVideoStandards || vs.HasPhysConns)
            {
                lblCurrentSettings.Text = "Camera";

                if(vs.HasVideoStandards)
                {
                    lblCurrentSettings.Text += string.Format("\r\n{0}{1}", TAB, 
                        "Video standard: " + vs.CurrentVideoStandard);
                }

                if(vs.HasPhysConns)
                {
                    lblCurrentSettings.Text += string.Format("\r\n{0}{1}", TAB, 
                        "Video source: " + vs.CurrentPhysicalConnector);
                }
            }
        }

        private void UpdateVideoSettings()
        {
            _AMMediaType mt;
            object formatBlock;
            vcg.Source.GetMediaType(out mt, out formatBlock);

            // TODO - Is VIH the right type for all video?
            VIDEOINFOHEADER vih = (VIDEOINFOHEADER)formatBlock;
            BITMAPINFOHEADER bmih = vih.BitmapInfo;

            if(lblCurrentSettings.Text == String.Empty)
            {
                lblCurrentSettings.Text = "Video stream";
            }
            else
            {
                lblCurrentSettings.Text += "\r\n\r\nVideo stream";
            }

            lblCurrentSettings.Text += string.Format("\r\n{0}Resolution: {1}x{2}" +
                "\r\n{0}Frame rate: {3} fps \r\n{0}Color space: {4} ({5} bit)" +
                "\r\n{0}Uncompressed bit rate: {6} Kbps", 
                TAB, bmih.Width, bmih.Height, vih.FrameRate.ToString("F2"),
                MediaType.SubType.GuidToString(mt.subtype), bmih.BitCount, 
                (uint)(bmih.Width * bmih.Height * bmih.BitCount * vih.FrameRate) / 1000);
        }

        private void UpdateCompressorSettings()
        {
            if(vcg.Compressor == null)
            {
                lblCurrentSettings.Text += string.Format("\r\n\r\nCompressor \r\n{0}Disabled", TAB);
            }
            else
            {
                VideoCompressorQualityInfo vcqi = vcg.VideoCompressor.QualityInfo;

                lblCurrentSettings.Text += string.Format("\r\n\r\nCompressor" +
                    "\r\n{0}Name: {1} \r\n{0}Media sub-type: {2} \r\n{0}Compressed bit rate: {3} Kbps" + 
                    "\r\n{0}{4}", 
                    TAB, vcg.Compressor.FriendlyName, 
                    MediaType.SubType.GuidToString(vcqi.MediaSubType), vcqi.BitRate / 1000, 
                    KeyFrameRateString);
            }
        }


        private void UpdateCustomCompressionFields()
        {
            if(vcg.VideoCompressor != null)
            {
                VideoCompressorQualityInfo vcqi = vcg.VideoCompressor.QualityInfo;
                BitRateValue = (int)vcqi.BitRate;
                KeyFrameRateValue = vcqi.KeyFrameRate;
            }
        }

        private void UpdateKeyFrameRateLabel()
        {
            lblKeyFrameRate.Text = KeyFrameRateString;
        }
        private string KeyFrameRateString
        {
            get
            {
                return string.Format("Key frame every {0} seconds", hsbKeyFrameRate.Value);
            }
        }

        private void UpdateBitRateLabel()
        {
            lblBitRate.Text = string.Format("Bit rate: {0} Kbps", BitRateValue / 1000);
        }

        
        private int BitRateValue
        {
            get
            {
                return hsbBitRate.Value * BitRateMultiplier * 1000;
            }

            set
            {
                hsbBitRate.Value = Math.Min(
                    (int)(value / (BitRateMultiplier * 1000)), 
                    hsbBitRate.Maximum);
            }
        }

        private int KeyFrameRateValue
        {
            get
            {
                return hsbKeyFrameRate.Value * 1000;
            }

            set
            {
                hsbKeyFrameRate.Value = value / 1000;
            }
        }


        private void Log(string msg)
        {
            frmAV.Log(msg);
        }
    }
}
