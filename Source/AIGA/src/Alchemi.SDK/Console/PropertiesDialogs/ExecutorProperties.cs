using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Alchemi.Core;
using Alchemi.Core.Manager.Storage;
using Alchemi.Core.Utility;
using NPlot;
using AxisDrag = NPlot.Windows.PlotSurface2D.Interactions.AxisDrag;
using HorizontalDrag = NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag;
using PlotSurface2D = NPlot.Windows.PlotSurface2D;
using VerticalDrag = NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag;

namespace Alchemi.Console.PropertiesDialogs
{
	public class ExecutorProperties : PropertiesForm
	{
		private TextBox txId;
		private Label label9;
		private TextBox txUsername;
		private Label label3;
		private CheckBox chkDedicated;
		private CheckBox chkConnected;
		private TextBox txPort;
		private Label label2;
		private Label label10;
		private TextBox txPingTime;
		private TabPage tabAdvanced;
		private TabPage tabPerf;
		private Label label6;
		private TextBox txOS;
		private TextBox txArch;
		private TextBox txMaxCPU;
		private TextBox txNumCPUs;
		private Label label8;
		private TextBox txMaxDisk;
		private Label label7;
		private Label label4;
		private Label label5;

		private IContainer components = null;

		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private ConsoleNode console;

		public ExecutorProperties(ConsoleNode console)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.console = console;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ExecutorProperties));
			this.txId = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txUsername = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkDedicated = new System.Windows.Forms.CheckBox();
			this.chkConnected = new System.Windows.Forms.CheckBox();
			this.txPort = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txPingTime = new System.Windows.Forms.TextBox();
			this.tabAdvanced = new System.Windows.Forms.TabPage();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txOS = new System.Windows.Forms.TextBox();
			this.txArch = new System.Windows.Forms.TextBox();
			this.txMaxCPU = new System.Windows.Forms.TextBox();
			this.txNumCPUs = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txMaxDisk = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tabPerf = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.plotSurface = new NPlot.Windows.PlotSurface2D();
			this.tmRefreshSystem = new System.Windows.Forms.Timer(this.components);
			this.tabs.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabAdvanced.SuspendLayout();
			this.tabPerf.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.tabAdvanced);
			this.tabs.Controls.Add(this.tabPerf);
			this.tabs.Name = "tabs";
			this.tabs.Controls.SetChildIndex(this.tabPerf, 0);
			this.tabs.Controls.SetChildIndex(this.tabAdvanced, 0);
			this.tabs.Controls.SetChildIndex(this.tabGeneral, 0);
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.label10);
			this.tabGeneral.Controls.Add(this.txPingTime);
			this.tabGeneral.Controls.Add(this.chkDedicated);
			this.tabGeneral.Controls.Add(this.chkConnected);
			this.tabGeneral.Controls.Add(this.txPort);
			this.tabGeneral.Controls.Add(this.label2);
			this.tabGeneral.Controls.Add(this.txId);
			this.tabGeneral.Controls.Add(this.label9);
			this.tabGeneral.Controls.Add(this.txUsername);
			this.tabGeneral.Controls.Add(this.label3);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Controls.SetChildIndex(this.iconBox, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lbName, 0);
			this.tabGeneral.Controls.SetChildIndex(this.lineLabel, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label3, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txUsername, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label9, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txId, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label2, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txPort, 0);
			this.tabGeneral.Controls.SetChildIndex(this.chkConnected, 0);
			this.tabGeneral.Controls.SetChildIndex(this.chkDedicated, 0);
			this.tabGeneral.Controls.SetChildIndex(this.txPingTime, 0);
			this.tabGeneral.Controls.SetChildIndex(this.label10, 0);
			// 
			// btnApply
			// 
			this.btnApply.Name = "btnApply";
			// 
			// btnCancel
			// 
			this.btnCancel.Name = "btnCancel";
			// 
			// btnOK
			// 
			this.btnOK.Name = "btnOK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// iconBox
			// 
			this.iconBox.Image = ((System.Drawing.Image)(resources.GetObject("iconBox.Image")));
			this.iconBox.Name = "iconBox";
			// 
			// lbName
			// 
			this.lbName.Name = "lbName";
			// 
			// lineLabel
			// 
			this.lineLabel.Name = "lineLabel";
			// 
			// imgListSmall
			// 
			this.imgListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListSmall.ImageStream")));
			// 
			// txId
			// 
			this.txId.BackColor = System.Drawing.Color.White;
			this.txId.Location = new System.Drawing.Point(96, 80);
			this.txId.Name = "txId";
			this.txId.ReadOnly = true;
			this.txId.Size = new System.Drawing.Size(216, 20);
			this.txId.TabIndex = 26;
			this.txId.Text = "txId";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 82);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(17, 16);
			this.label9.TabIndex = 25;
			this.label9.Text = "Id:";
			// 
			// txUsername
			// 
			this.txUsername.BackColor = System.Drawing.Color.White;
			this.txUsername.Location = new System.Drawing.Point(96, 144);
			this.txUsername.Name = "txUsername";
			this.txUsername.ReadOnly = true;
			this.txUsername.Size = new System.Drawing.Size(144, 20);
			this.txUsername.TabIndex = 24;
			this.txUsername.Text = "txUsername";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 144);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 16);
			this.label3.TabIndex = 23;
			this.label3.Text = "Username:";
			// 
			// chkDedicated
			// 
			this.chkDedicated.AutoCheck = false;
			this.chkDedicated.Location = new System.Drawing.Point(16, 240);
			this.chkDedicated.Name = "chkDedicated";
			this.chkDedicated.Size = new System.Drawing.Size(80, 24);
			this.chkDedicated.TabIndex = 30;
			this.chkDedicated.Text = "Dedicated";
			// 
			// chkConnected
			// 
			this.chkConnected.AutoCheck = false;
			this.chkConnected.Location = new System.Drawing.Point(16, 208);
			this.chkConnected.Name = "chkConnected";
			this.chkConnected.Size = new System.Drawing.Size(80, 24);
			this.chkConnected.TabIndex = 29;
			this.chkConnected.Text = "Connected";
			// 
			// txPort
			// 
			this.txPort.BackColor = System.Drawing.Color.White;
			this.txPort.Location = new System.Drawing.Point(96, 112);
			this.txPort.Name = "txPort";
			this.txPort.ReadOnly = true;
			this.txPort.Size = new System.Drawing.Size(48, 20);
			this.txPort.TabIndex = 28;
			this.txPort.Text = "txPort";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 16);
			this.label2.TabIndex = 27;
			this.label2.Text = "Port:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(16, 176);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(78, 16);
			this.label10.TabIndex = 32;
			this.label10.Text = "Last ping time:";
			// 
			// txPingTime
			// 
			this.txPingTime.BackColor = System.Drawing.Color.White;
			this.txPingTime.Location = new System.Drawing.Point(96, 176);
			this.txPingTime.Name = "txPingTime";
			this.txPingTime.ReadOnly = true;
			this.txPingTime.Size = new System.Drawing.Size(144, 20);
			this.txPingTime.TabIndex = 31;
			this.txPingTime.Text = "txPingTime";
			// 
			// tabAdvanced
			// 
			this.tabAdvanced.Controls.Add(this.label12);
			this.tabAdvanced.Controls.Add(this.label11);
			this.tabAdvanced.Controls.Add(this.label6);
			this.tabAdvanced.Controls.Add(this.txOS);
			this.tabAdvanced.Controls.Add(this.txArch);
			this.tabAdvanced.Controls.Add(this.txMaxCPU);
			this.tabAdvanced.Controls.Add(this.txNumCPUs);
			this.tabAdvanced.Controls.Add(this.label8);
			this.tabAdvanced.Controls.Add(this.txMaxDisk);
			this.tabAdvanced.Controls.Add(this.label7);
			this.tabAdvanced.Controls.Add(this.label4);
			this.tabAdvanced.Controls.Add(this.label5);
			this.tabAdvanced.Location = new System.Drawing.Point(4, 22);
			this.tabAdvanced.Name = "tabAdvanced";
			this.tabAdvanced.Size = new System.Drawing.Size(328, 318);
			this.tabAdvanced.TabIndex = 1;
			this.tabAdvanced.Text = "Advanced";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(248, 114);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(24, 16);
			this.label12.TabIndex = 35;
			this.label12.Text = "MB.";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(248, 82);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(29, 16);
			this.label11.TabIndex = 34;
			this.label11.Text = "Mhz.";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 16);
			this.label6.TabIndex = 29;
			this.label6.Text = "Max. CPU:";
			// 
			// txOS
			// 
			this.txOS.BackColor = System.Drawing.Color.White;
			this.txOS.Location = new System.Drawing.Point(112, 48);
			this.txOS.Name = "txOS";
			this.txOS.ReadOnly = true;
			this.txOS.Size = new System.Drawing.Size(200, 20);
			this.txOS.TabIndex = 26;
			this.txOS.Text = "txOS";
			// 
			// txArch
			// 
			this.txArch.BackColor = System.Drawing.Color.White;
			this.txArch.Location = new System.Drawing.Point(112, 16);
			this.txArch.Name = "txArch";
			this.txArch.ReadOnly = true;
			this.txArch.Size = new System.Drawing.Size(200, 20);
			this.txArch.TabIndex = 24;
			this.txArch.Text = "txArch";
			// 
			// txMaxCPU
			// 
			this.txMaxCPU.BackColor = System.Drawing.Color.White;
			this.txMaxCPU.Location = new System.Drawing.Point(112, 80);
			this.txMaxCPU.Name = "txMaxCPU";
			this.txMaxCPU.ReadOnly = true;
			this.txMaxCPU.Size = new System.Drawing.Size(128, 20);
			this.txMaxCPU.TabIndex = 28;
			this.txMaxCPU.Text = "txMaxCPU";
			// 
			// txNumCPUs
			// 
			this.txNumCPUs.BackColor = System.Drawing.Color.White;
			this.txNumCPUs.Location = new System.Drawing.Point(112, 144);
			this.txNumCPUs.Name = "txNumCPUs";
			this.txNumCPUs.ReadOnly = true;
			this.txNumCPUs.Size = new System.Drawing.Size(40, 20);
			this.txNumCPUs.TabIndex = 32;
			this.txNumCPUs.Text = "txNumCPUs";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(16, 144);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(59, 16);
			this.label8.TabIndex = 33;
			this.label8.Text = "# of CPUs:";
			// 
			// txMaxDisk
			// 
			this.txMaxDisk.BackColor = System.Drawing.Color.White;
			this.txMaxDisk.Location = new System.Drawing.Point(112, 112);
			this.txMaxDisk.Name = "txMaxDisk";
			this.txMaxDisk.ReadOnly = true;
			this.txMaxDisk.Size = new System.Drawing.Size(128, 20);
			this.txMaxDisk.TabIndex = 30;
			this.txMaxDisk.Text = "txMaxDisk";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(16, 112);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(75, 16);
			this.label7.TabIndex = 31;
			this.label7.Text = "Max. Storage:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(68, 16);
			this.label4.TabIndex = 25;
			this.label4.Text = "Architecture:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 16);
			this.label5.TabIndex = 27;
			this.label5.Text = "Operating System:";
			// 
			// tabPerf
			// 
			this.tabPerf.Controls.Add(this.panel1);
			this.tabPerf.Location = new System.Drawing.Point(4, 22);
			this.tabPerf.Name = "tabPerf";
			this.tabPerf.Size = new System.Drawing.Size(328, 318);
			this.tabPerf.TabIndex = 2;
			this.tabPerf.Text = "Performance";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.plotSurface);
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(312, 304);
			this.panel1.TabIndex = 28;
			// 
			// plotSurface
			// 
			this.plotSurface.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.plotSurface.AutoScaleAutoGeneratedAxes = true;
			this.plotSurface.AutoScaleTitle = true;
			this.plotSurface.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.plotSurface.DateTimeToolTip = false;
			this.plotSurface.Legend = null;
			this.plotSurface.LegendZOrder = -1;
			this.plotSurface.Location = new System.Drawing.Point(2, 2);
			this.plotSurface.Name = "plotSurface";
			this.plotSurface.Padding = 0;
			this.plotSurface.RightMenu = null;
			this.plotSurface.ShowCoordinates = true;
			this.plotSurface.Size = new System.Drawing.Size(304, 296);
			this.plotSurface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			this.plotSurface.TabIndex = 24;
			this.plotSurface.Text = "plotSurface2D1";
			this.plotSurface.Title = "";
			this.plotSurface.TitleFont = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.plotSurface.XAxis1 = null;
			this.plotSurface.XAxis2 = null;
			this.plotSurface.YAxis1 = null;
			this.plotSurface.YAxis2 = null;
			// 
			// tmRefreshSystem
			// 
			this.tmRefreshSystem.Interval = 2000;
			this.tmRefreshSystem.Tick += new System.EventHandler(this.tmRefreshSystem_Tick);
			// 
			// ExecutorProperties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 389);
			this.Name = "ExecutorProperties";
			this.Text = "Executor Properties";
			this.tabs.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabAdvanced.ResumeLayout(false);
			this.tabPerf.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Graph Stuff

		//For the summary graph
		private ArrayList x1 = new ArrayList();
		private ArrayList y1 = new ArrayList();
		private ArrayList y2 = new ArrayList();
		private double xVal = -1;
		private LinePlot lineUsage = new LinePlot();
		private PlotSurface2D plotSurface;
		private Timer tmRefreshSystem;
		private Panel panel1;
		private LinePlot lineAvail = new LinePlot();
		//
		
		private void InitSystemPlot()
		{
			try
			{
				plotSurface.Clear();
				this.plotSurface.RightMenu = PlotSurface2D.DefaultContextMenu;

				plotSurface.Add( lineAvail );
				plotSurface.Add( lineUsage );

				plotSurface.PlotBackColor = plotSurface.BackColor;
				plotSurface.SmoothingMode = SmoothingMode.AntiAlias;

				plotSurface.Title = "CPU Power - Availability & Usage";
				plotSurface.TitleFont = new Font(new FontFamily("Microsoft Sans Serif" ), 6.5f, FontStyle.Regular);

				plotSurface.XAxis1.WorldMin = -60.0f;
				plotSurface.XAxis1.WorldMax = 0.0f;
				//plotSurface.XAxis1.Label = "Seconds";
				//plotSurface.XAxis1.LabelFont = new Font(new FontFamily("Microsoft Sans Serif" ), 6.0f, FontStyle.Regular);
				//plotSurface.XAxis1.TickTextFont = new Font(new FontFamily("Microsoft Sans Serif" ), 6.0f, FontStyle.Regular);

				plotSurface.YAxis1.WorldMin = 0.0;
				plotSurface.YAxis1.WorldMax= 100.0;
				//plotSurface.YAxis1.Label = "Power [%]";
				//plotSurface.YAxis1.LabelFont = new Font(new FontFamily("Microsoft Sans Serif" ), 6.0f, FontStyle.Regular);
				//plotSurface.YAxis1.TickTextFont = new Font(new FontFamily("Microsoft Sans Serif" ), 6.0f, FontStyle.Regular);

				Grid gridPlotSurface = new Grid();
				gridPlotSurface.HorizontalGridType = Grid.GridType.None;
				gridPlotSurface.VerticalGridType = Grid.GridType.Fine;
				gridPlotSurface.MajorGridPen.Color = Color.DarkGray;
				plotSurface.Add(gridPlotSurface);

				//				plotSurface.Legend = new Legend();
				//				plotSurface.Legend.Font = new Font(new FontFamily("Microsoft Sans Serif" ), 6.0f, FontStyle.Regular);
				//				plotSurface.Legend.NeverShiftAxes = false;
				//				plotSurface.Legend.AttachTo( NPlot.PlotSurface2D.XAxisPosition.Top , NPlot.PlotSurface2D.YAxisPosition.Right);
				//				plotSurface.Legend.HorizontalEdgePlacement = Legend.Placement.Inside;
				//				plotSurface.Legend.VerticalEdgePlacement = Legend.Placement.Inside;

				//lineAvail.Label = "usage";
				lineAvail.Pen   = new Pen(Color.LightBlue, 1.7f);

				//lineUsage.Label = "avail";
				lineUsage.Pen   = new Pen(Color.LightGreen, 1.7f);

				plotSurface.AddInteraction(new PlotSurface2D.Interactions.HorizontalDrag());
				plotSurface.AddInteraction(new PlotSurface2D.Interactions.VerticalDrag());
				plotSurface.AddInteraction(new PlotSurface2D.Interactions.AxisDrag(true));
				
				plotSurface.PlotBackColor = Color.Black;
				plotSurface.BackColor = SystemColors.Control;
				plotSurface.XAxis1.Color = Color.Black;
				plotSurface.YAxis1.Color = Color.Black;

				plotSurface.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Couldnot initialize graph. Error: "+ex.Message,"Console Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
			}
		}

		private void RefreshSystemPlot()
		{
			try
			{				
				SystemSummary summary = console.Manager.Admon_GetSystemSummary(console.Credentials);

				if (summary == null)
				{
					logger.Debug("Summary is null!");
				}
				else
				{
					xVal++;
	           
					x1.Add(xVal);

					y1.Add(Convert.ToDouble(summary.PowerUsage));
					y2.Add(Convert.ToDouble(summary.PowerAvailable));

					if (x1.Count > 31)
					{
						x1.RemoveAt(0);
						y1.RemoveAt(0);
						y2.RemoveAt(0);
					}
	          
	        
					int npt=31;
					int []xTime  = new int[npt];
					double []yAvail = new double[npt];
					double []yUsage = new double[npt];

					for (int i=0; i<x1.Count; i++)
					{
						int x2 = ((((31 - x1.Count) + i)) * 2) - 60;
						xTime[i] = x2;
						yAvail[i] = (double) y1[i];
						yUsage[i] = (double) y2[i];
					}

					lineAvail.AbscissaData = xTime;
					lineAvail.OrdinateData = yAvail;

					lineUsage.AbscissaData = xTime;
					lineUsage.OrdinateData = yUsage;

					plotSurface.Refresh();
					
				}
			}
			catch (Exception ex)
			{
				logger.Error("Could not refresh system. Error: ",ex);
			}
		}


		private void tmRefreshSystem_Tick(object sender, EventArgs e)
		{
			RefreshData(null);
			RefreshSystemPlot();
		}

		#endregion

		private void RefreshData(ExecutorStorageView ex)
		{

			if (ex==null)
				return;

			txId.Text = ex.ExecutorId;
			lbName.Text = ex.HostName;

			this.Text = ex.HostName + " Properties";

			txPort.Text = ex.Port.ToString();
			txUsername.Text = ex.Username;

			chkConnected.Checked = ex.Connected;
			chkDedicated.Checked = ex.Dedicated;

			txArch.Text = ex.Architecture;
			txOS.Text = ex.Os;

			txMaxCPU.Text = ex.MaxCpu.ToString();
			txMaxDisk.Text = ex.MaxDisk.ToString();
			txNumCPUs.Text = ex.NumberOfCpu.ToString();
			
			txPingTime.Text = GetDiff(ex.PingTime);
		}

		public void SetData(ExecutorStorageView ex)
		{
			RefreshData(ex);
			InitSystemPlot();
			RefreshSystemPlot();
			tmRefreshSystem.Enabled = true;
		}

		private string GetDiff(DateTime d)
		{
			string diff = "unknown";
			double difference = Utils.DateDiff(DateTimeInterval.Minute,DateTime.Now, d);
			if (difference > 0)
			{
				diff = difference.ToString("F") + " mins. ago";
			}
			return diff;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

