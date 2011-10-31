using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Microsoft.Ink.Samples.Controls.InkToolBarControls
{
    /// <summary>
    /// Summary description for ColorPicker.
    /// </summary>
    internal class ColorPickerControl : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.TabControl m_tabControl;
        private System.Windows.Forms.TabPage m_webTab;
        private Microsoft.Ink.Samples.Controls.InkToolBarControls.ColorListBox m_webList;
        private System.Windows.Forms.TabPage m_systemTab;
        private Microsoft.Ink.Samples.Controls.InkToolBarControls.ColorListBox m_systemList;
        private System.Windows.Forms.Panel panel1;
        private Color m_color;
        internal event EventHandler ColorChanged;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        internal ColorPickerControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitForm call
            PopulateListBoxes();
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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_tabControl = new System.Windows.Forms.TabControl();
            this.m_webTab = new System.Windows.Forms.TabPage();
            this.m_webList = new Microsoft.Ink.Samples.Controls.InkToolBarControls.ColorListBox();
            this.m_systemTab = new System.Windows.Forms.TabPage();
            this.m_systemList = new Microsoft.Ink.Samples.Controls.InkToolBarControls.ColorListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_tabControl.SuspendLayout();
            this.m_webTab.SuspendLayout();
            this.m_systemTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tabControl
            // 
            this.m_tabControl.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                       this.m_webTab,
                                                                                       this.m_systemTab});
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.Size = new System.Drawing.Size(208, 236);
            this.m_tabControl.TabIndex = 0;
            // 
            // m_webTab
            // 
            this.m_webTab.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                   this.m_webList});
            this.m_webTab.Location = new System.Drawing.Point(4, 22);
            this.m_webTab.Name = "m_webTab";
            this.m_webTab.Size = new System.Drawing.Size(200, 210);
            this.m_webTab.TabIndex = 0;
            this.m_webTab.Text = "Web";
            // 
            // m_webList
            // 
            this.m_webList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_webList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_webList.Items.AddRange(new object[] {
                                                           "Transparent",
                                                           "Black",
                                                           "DimGray",
                                                           "Gray",
                                                           "DarkGray",
                                                           "Silver",
                                                           "LightGray",
                                                           "Gainsboro",
                                                           "WhiteSmoke",
                                                           "White",
                                                           "RosyBrown",
                                                           "IndianRed",
                                                           "Brown",
                                                           "Firebrick",
                                                           "LightCoral",
                                                           "Maroon",
                                                           "DarkRed",
                                                           "Red",
                                                           "Snow",
                                                           "MistyRose",
                                                           "Salmon",
                                                           "Tomato",
                                                           "DarkSalmon",
                                                           "Coral",
                                                           "OrangeRed",
                                                           "LightSalmon",
                                                           "Sienna",
                                                           "SeaShell",
                                                           "Chocolate",
                                                           "SaddleBrown",
                                                           "SandyBrown",
                                                           "PeachPuff",
                                                           "Peru",
                                                           "Linen",
                                                           "Bisque",
                                                           "DarkOrange",
                                                           "BurlyWood",
                                                           "Tan",
                                                           "AntiqueWhite",
                                                           "NavajoWhite",
                                                           "BlanchedAlmond",
                                                           "PapayaWhip",
                                                           "Moccasin",
                                                           "Orange",
                                                           "Wheat",
                                                           "OldLace",
                                                           "FloralWhite",
                                                           "DarkGoldenrod",
                                                           "Cornsilk",
                                                           "Gold",
                                                           "Khaki",
                                                           "LemonChiffon",
                                                           "PaleGoldenrod",
                                                           "DarkKhaki",
                                                           "Beige",
                                                           "LightGoldenrodYellow",
                                                           "Olive",
                                                           "Yellow",
                                                           "LightYellow",
                                                           "Ivory",
                                                           "OliveDrab",
                                                           "YellowGreen",
                                                           "DarkOliveGreen",
                                                           "GreenYellow",
                                                           "Chartreuse",
                                                           "LawnGreen",
                                                           "DarkSeaGreen",
                                                           "ForestGreen",
                                                           "LimeGreen",
                                                           "PaleGreen",
                                                           "DarkGreen",
                                                           "Green",
                                                           "Lime",
                                                           "Honeydew",
                                                           "SeaGreen",
                                                           "MediumSeaGreen",
                                                           "SpringGreen",
                                                           "MintCream",
                                                           "MediumSpringGreen",
                                                           "MediumAquaMarine",
                                                           "AquaMarine",
                                                           "Turquoise",
                                                           "LightSeaGreen",
                                                           "MediumTurquoise",
                                                           "DarkSlateGray",
                                                           "PaleTurquoise",
                                                           "Teal",
                                                           "DarkCyan",
                                                           "Aqua",
                                                           "LightCyan",
                                                           "Azure",
                                                           "DarkTurquoise",
                                                           "CadetBlue",
                                                           "PowderBlue",
                                                           "LightBlue",
                                                           "DeepSkyBlue",
                                                           "SkyBlue",
                                                           "LightSkyBlue",
                                                           "SteelBlue",
                                                           "AliceBlue",
                                                           "DodgerBlue",
                                                           "SlateGray",
                                                           "LightSlateGray",
                                                           "LightSteelBlue",
                                                           "CornflowerBlue",
                                                           "RoyalBlue",
                                                           "MidnightBlue",
                                                           "Lavender",
                                                           "Navy",
                                                           "DarkBlue",
                                                           "MediumBlue",
                                                           "Blue",
                                                           "GhostWhite",
                                                           "SlateBlue",
                                                           "DarkSlateBlue",
                                                           "MediumSlateBlue",
                                                           "MediumPurple",
                                                           "BlueViolet",
                                                           "Indigo",
                                                           "DarkOrchid",
                                                           "DarkViolet",
                                                           "MediumOrchid",
                                                           "Thistle",
                                                           "Plum",
                                                           "Violet",
                                                           "Purple",
                                                           "DarkMagenta",
                                                           "Fuchsia",
                                                           "Orchid",
                                                           "MediumVioletRed",
                                                           "DeepPink",
                                                           "HotPink",
                                                           "LavenderBlush",
                                                           "PaleVioletRed",
                                                           "Crimson",
                                                           "Pink",
                                                           "LightPink"});
            this.m_webList.Name = "m_webList";
            this.m_webList.Size = new System.Drawing.Size(200, 210);
            this.m_webList.TabIndex = 0;
            this.m_webList.SelectedIndexChanged += new System.EventHandler(this.WebList_SelectedIndexChanged);
            // 
            // m_systemTab
            // 
            this.m_systemTab.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                      this.m_systemList});
            this.m_systemTab.Location = new System.Drawing.Point(4, 22);
            this.m_systemTab.Name = "m_systemTab";
            this.m_systemTab.Size = new System.Drawing.Size(200, 210);
            this.m_systemTab.TabIndex = 1;
            this.m_systemTab.Text = "System";
            this.m_systemTab.Visible = false;
            // 
            // m_systemList
            // 
            this.m_systemList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_systemList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.m_systemList.Name = "m_systemList";
            this.m_systemList.Size = new System.Drawing.Size(200, 210);
            this.m_systemList.TabIndex = 0;
            this.m_systemList.SelectedIndexChanged += new System.EventHandler(this.SystemList_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                 this.m_tabControl});
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 236);
            this.panel1.TabIndex = 2;
            // 
            // ColorPickerControl
            // 
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.panel1});
            this.Name = "ColorPickerControl";
            this.Size = new System.Drawing.Size(208, 236);
            this.m_tabControl.ResumeLayout(false);
            this.m_webTab.ResumeLayout(false);
            this.m_systemTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void PopulateListBoxes()
        {
            // Populate system colors list box
            System.Reflection.PropertyInfo[] pInfos = typeof(SystemColors).GetProperties();

            foreach (System.Reflection.PropertyInfo p in pInfos)
                this.m_systemList.Items.Add(p.Name);
        }

        private void WebList_SelectedIndexChanged(object source, EventArgs e)
        {
            if (m_webList.SelectedIndex >= 0)
            {
                this.m_color = Color.FromName((string)m_webList.SelectedItem);
                OnColorChanged();
                this.Hide();
            }
        }

        private void SystemList_SelectedIndexChanged(object source, EventArgs e)
        {
            if (m_systemList.SelectedIndex >= 0)
            {
                this.m_color = Color.FromName((string)m_systemList.SelectedItem);
                OnColorChanged();
                this.Hide();
            }
        }

        internal Color Color
        {
            get { return m_color; }
            set 
            { 
                m_color = value;

                //Look for color in the web list, otherwise in the system list.
                m_webList.SelectedIndex = m_webList.Items.IndexOf(m_color.Name);
                if (m_webList.SelectedIndex >= 0)
                    m_tabControl.SelectedTab = m_webTab;
                else
                {
                    m_systemList.SelectedIndex = m_systemList.Items.IndexOf(m_color.Name);
                    if (m_systemList.SelectedIndex >= 0 )
                        m_tabControl.SelectedTab = m_systemTab;
                }
            }
        }

        protected void OnColorChanged()
        {
            if (ColorChanged != null)
                ColorChanged(this, new EventArgs());
        }


        private void TabControl_LostFocus(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Lost Focus");

//          Point mousePos = Control.MousePosition;
//          if ( !this.ClientRectangle.Contains(PointToClient(mousePos)) ) 
//          {
//              if (this.LostFocusEx != null)
//                  this.LostFocusEx(this, e);
//          }
        }

//      protected override void OnVisibleChanged(System.EventArgs e)
//      {
//          if (this.Visible)
//              this.Capture = true;
//
//          base.OnVisibleChanged(e);
//      }
//
//      protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
//      {
//          this.Hide();
//          this.Capture = false;
//          base.OnMouseDown(e);
//      }
    }
}
