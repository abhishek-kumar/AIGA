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
    public class frmAudioSettings : System.Windows.Forms.Form
    {
        // Please do not set the audio pin combo box to sorted.  We use the index
        // not the name, to determine which pin was selected.
        #region Windows Form Designer generated code

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblInputSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAudio;
        private System.Windows.Forms.ComboBox cboMicrophonePins;
        private System.Windows.Forms.CheckBox ckAudioCompression;
        private System.Windows.Forms.ComboBox cboLinkedCamera;
        private System.Windows.Forms.GroupBox gbCurrentSettings;
        private System.Windows.Forms.Label lblCurrentSettings;
        private System.Windows.Forms.GroupBox gbMicAndAudio;

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
            this.gbCurrentSettings = new System.Windows.Forms.GroupBox();
            this.lblCurrentSettings = new System.Windows.Forms.Label();
            this.cboMicrophonePins = new System.Windows.Forms.ComboBox();
            this.lblInputSource = new System.Windows.Forms.Label();
            this.btnAudio = new System.Windows.Forms.Button();
            this.ckAudioCompression = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLinkedCamera = new System.Windows.Forms.ComboBox();
            this.gbMicAndAudio = new System.Windows.Forms.GroupBox();
            this.gbCurrentSettings.SuspendLayout();
            this.gbMicAndAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnOK.Location = new System.Drawing.Point(424, 142);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 23);
            this.btnOK.TabIndex = 43;
            this.btnOK.Text = "Close";
            // 
            // gbCurrentSettings
            // 
            this.gbCurrentSettings.Controls.Add(this.lblCurrentSettings);
            this.gbCurrentSettings.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbCurrentSettings.Location = new System.Drawing.Point(304, 6);
            this.gbCurrentSettings.Name = "gbCurrentSettings";
            this.gbCurrentSettings.Size = new System.Drawing.Size(216, 112);
            this.gbCurrentSettings.TabIndex = 76;
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
            this.lblCurrentSettings.Size = new System.Drawing.Size(210, 93);
            this.lblCurrentSettings.TabIndex = 23;
            this.lblCurrentSettings.Text = "lblCurrentSettings";
            // 
            // cboMicrophonePins
            // 
            this.cboMicrophonePins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMicrophonePins.Location = new System.Drawing.Point(8, 36);
            this.cboMicrophonePins.Name = "cboMicrophonePins";
            this.cboMicrophonePins.Size = new System.Drawing.Size(272, 21);
            this.cboMicrophonePins.TabIndex = 64;
            this.cboMicrophonePins.SelectedIndexChanged += new System.EventHandler(this.cboMicrophonePins_SelectedIndexChanged);
            // 
            // lblInputSource
            // 
            this.lblInputSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblInputSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblInputSource.Location = new System.Drawing.Point(8, 20);
            this.lblInputSource.Name = "lblInputSource";
            this.lblInputSource.Size = new System.Drawing.Size(264, 16);
            this.lblInputSource.TabIndex = 79;
            this.lblInputSource.Text = "lblInputSource";
            // 
            // btnAudio
            // 
            this.btnAudio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAudio.Location = new System.Drawing.Point(24, 82);
            this.btnAudio.Name = "btnAudio";
            this.btnAudio.Size = new System.Drawing.Size(136, 24);
            this.btnAudio.TabIndex = 80;
            this.btnAudio.Text = "btnAudio";
            this.btnAudio.Click += new System.EventHandler(this.btnAudio_Click);
            // 
            // ckAudioCompression
            // 
            this.ckAudioCompression.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ckAudioCompression.Location = new System.Drawing.Point(8, 62);
            this.ckAudioCompression.Name = "ckAudioCompression";
            this.ckAudioCompression.Size = new System.Drawing.Size(160, 16);
            this.ckAudioCompression.TabIndex = 81;
            this.ckAudioCompression.CheckedChanged += new System.EventHandler(this.ckAudioCompression_CheckedChanged);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(8, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 16);
            this.label1.TabIndex = 84;
            this.label1.Text = "Select a camera to associate with your microphone";
            // 
            // cboLinkedCamera
            // 
            this.cboLinkedCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLinkedCamera.Location = new System.Drawing.Point(8, 144);
            this.cboLinkedCamera.Name = "cboLinkedCamera";
            this.cboLinkedCamera.Size = new System.Drawing.Size(272, 21);
            this.cboLinkedCamera.Sorted = true;
            this.cboLinkedCamera.TabIndex = 85;
            this.cboLinkedCamera.SelectedIndexChanged += new System.EventHandler(this.cboLinkedCamera_SelectedIndexChanged);
            // 
            // gbMicAndAudio
            // 
            this.gbMicAndAudio.Controls.Add(this.lblInputSource);
            this.gbMicAndAudio.Controls.Add(this.cboMicrophonePins);
            this.gbMicAndAudio.Controls.Add(this.btnAudio);
            this.gbMicAndAudio.Controls.Add(this.ckAudioCompression);
            this.gbMicAndAudio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbMicAndAudio.Location = new System.Drawing.Point(8, 6);
            this.gbMicAndAudio.Name = "gbMicAndAudio";
            this.gbMicAndAudio.Size = new System.Drawing.Size(288, 112);
            this.gbMicAndAudio.TabIndex = 87;
            this.gbMicAndAudio.TabStop = false;
            this.gbMicAndAudio.Text = "Configure Microphone and Audio Stream";
            // 
            // frmAudioSettings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(530, 174);
            this.ControlBox = false;
            this.Controls.Add(this.gbMicAndAudio);
            this.Controls.Add(this.gbCurrentSettings);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboLinkedCamera);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAudioSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAudioSettings_Load);
            this.gbCurrentSettings.ResumeLayout(false);
            this.gbMicAndAudio.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region Statics

        private const string TAB = "     ";

        #endregion STatics

        #region Members

        private AudioCapability ac;
        private AudioCaptureGraph acg;

        private frmAVDevices frmAV;

        #endregion Members

        #region Constructor

        public frmAudioSettings(AudioCapability ac, frmAVDevices frmAV)
        {
            InitializeComponent();

            Debug.Assert(ac != null);
            Debug.Assert(ac.AudioCaptureGraph != null);
            Debug.Assert(frmAV != null);

            this.ac = ac;
            this.acg = ac.AudioCaptureGraph;
            this.frmAV = frmAV;
        }

        
        #endregion Constructor

        private void frmAudioSettings_Load(object sender, System.EventArgs e)
        {
            try
            {
                StaticText();
                this.Text = "Advanced Audio Settings: " + acg.Source.FriendlyName;

                RestoreLinkedCamera();
                RestoreInputPin();
                RestoreCompression();

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

        private void StaticText()
        {
            btnAudio.Text = "Audio Format...";
            lblInputSource.Text = "Choose microphone's input source";
            ckAudioCompression.Text = "Enable audio compression";

            gbCurrentSettings.Text = "Current Settings";
            lblCurrentSettings.Text = null;
        }

        private void RestoreLinkedCamera()
        {
            // List the selected cameras
            foreach(FilterInfo fi in frmAV.vcs.Keys)
            {
                cboLinkedCamera.Items.Add(fi);
            }

            // Read from registry and select camera, if in list
            string[] linkedCamera = AVReg.ValueNames(AVReg.LinkedCamera);
            if(linkedCamera != null && linkedCamera.Length > 0)
            {
                Debug.Assert(linkedCamera.Length == 1);

                for(int i = 0; i < cboLinkedCamera.Items.Count; i++)
                {
                    FilterInfo fi = (FilterInfo)cboLinkedCamera.Items[i];
                    if(fi.Moniker == linkedCamera[0])
                    {
                        cboLinkedCamera.SelectedItem = fi;
                    }
                }
            }

            if(cboLinkedCamera.SelectedIndex == -1 && cboLinkedCamera.Items.Count > 0)
            {
                cboLinkedCamera.SelectedIndex = 0;
            }

            cboLinkedCamera.Enabled = cboLinkedCamera.Items.Count > 1;
        }

        private void RestoreInputPin()
        {
            foreach(IPin pin in acg.AudioSource.InputPins)
            {
                cboMicrophonePins.Items.Add(Pin.Name(pin));
            }
            cboMicrophonePins.Enabled = acg.AudioSource.InputPins.Count > 1;
            
            if(cboMicrophonePins.Items.Count > 0)
            {
                cboMicrophonePins.SelectedIndex = acg.AudioSource.InputPinIndex;
            }
        }

        private void RestoreCompression()
        {
            ckAudioCompression.Enabled = false;
            ckAudioCompression.Checked = ac.RegCompressorEnabled;
            btnAudio.Enabled = !ckAudioCompression.Checked;
            ckAudioCompression.Enabled = true;
        }


        private void btnAudio_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Show the form
                frmAudioFormat af = new frmAudioFormat(acg.AudioSource);
                if(af.ShowDialog(this) == DialogResult.OK)
                {
                    // Get the media type they selected and set it
                    _AMMediaType mt;
                    object fb;
                    af.GetMediaType(out mt, out fb);

                    #region Log

                    Log("Setting media type to...");
                    Log(MediaType.Dump(mt) + MediaType.FormatType.Dump(fb));

                    #endregion Log

                    frmAV.RenderAndRunAudio(acg, false);
                    acg.RemoveFiltersDownstreamFrom(acg.Source);

                    try
                    {
                        acg.AudioSource.SetMediaType(mt, fb);
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

                    ac.SaveAudioSettings();
                    ac.AddAudioCompressor();
                    frmAV.RenderAndRunAudio(acg);

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

        private void cboMicrophonePins_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            acg.AudioSource.InputPinIndex = cboMicrophonePins.SelectedIndex;
            ac.SaveMicrophoneSettings();
        }

        private void ckAudioCompression_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                btnAudio.Enabled = !ckAudioCompression.Checked;

                if(ckAudioCompression.Enabled)
                {
                    ac.RegCompressorEnabled = ckAudioCompression.Checked;

                    frmAV.RenderAndRunAudio(acg, false);
                    acg.RemoveFiltersDownstreamFrom(acg.Source);

                    if(ckAudioCompression.Checked)
                    {
                        ac.AddAudioCompressor();
                    }

                    frmAV.RenderAndRunAudio(acg);
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

        private void cboLinkedCamera_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            frmAV.SaveLinkedCamera((FilterInfo)cboLinkedCamera.SelectedItem);
        }


        private void UpdateCurrentSettings()
        {
            _AMMediaType mt;
            object fb;

            if(ckAudioCompression.Checked)
            {
                acg.Compressor.GetMediaType(out mt, out fb);
            }
            else
            {
                acg.Source.GetMediaType(out mt, out fb);
            }

            WAVEFORMATEX wfe = (WAVEFORMATEX)fb;

            lblCurrentSettings.Text = string.Format("Audio format" +
                "\r\n{0}Channels: {1} \r\n{0}Bits per sample: {2}" +
                "\r\n{0}Frequency: {3} \r\n{0}Kbps: {4}", 
                TAB, wfe.Channels, wfe.BitsPerSample, wfe.SamplesPerSec, 
                wfe.AvgBytesPerSec * 8 / 1000);

        }


        private void Log(string msg)
        {
            frmAV.Log(msg);
        }
    }
}
