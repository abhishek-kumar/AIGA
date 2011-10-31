#region Alchemi copyright and license notice

/*
* Alchemi [.NET Grid Computing Framework]
* http://www.alchemi.net
*
* Title			:	SysPerfForm.cs
* Project		:	Alchemi Console
* Created on	:	Sep 2006
* Copyright		:	Copyright © 2006 The University of Melbourne
*					This technology has been developed with the support of 
*					the Australian Research Council and the University of Melbourne
*					research grants as part of the Gridbus Project
*					within GRIDS Laboratory at the University of Melbourne, Australia.
* Author         :  Krishna Nadiminti (kna@csse.unimelb.edu.au) and Rajkumar Buyya (raj@csse.unimelb.edu.au)
* License        :  GPL
*					This program is free software; you can redistribute it and/or 
*					modify it under the terms of the GNU General Public
*					License as published by the Free Software Foundation;
*					See the GNU General Public License 
*					(http://www.gnu.org/copyleft/gpl.html) for more details.
*
*/ 
#endregion

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Alchemi.Core;
using Alchemi.Core.Manager.Storage;
using NPlot;
using PlotSurface2D = NPlot.Windows.PlotSurface2D;

namespace Alchemi.Console
{
	/// <summary>
	/// Summary description for SysPerfForm.
	/// </summary>
	public class SysPerfForm : Form
	{
		private IContainer components;

		// Create a logger for use in this class
		private static readonly Logger logger = new Logger();

		//For the summary graph
		private ArrayList x1 = new ArrayList();
		private ArrayList y1 = new ArrayList();
		private ArrayList y2 = new ArrayList();
		private double xVal = -1;
		private LinePlot lineUsage = new LinePlot();
		private LinePlot lineAvail = new LinePlot();
		//
		private PlotSurface2D plotSurface;
		//
		private Panel panelGraph;
		private Panel panelSummaryLabels;
		private Label lbTotalPowerUsage;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label lbNumExec;
		private Label lbRunningJobs;
		private Label lbRunningApps;
		private Label label1;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label lbCurPowerUsage;
		private Label lbCurPowerAvail;
		private Timer tmRefreshSystem;
		private Panel panelPlotContainer;
		private Label lbMaxPowerAvail;

		private ConsoleNode console = null;

		public SysPerfForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			InitSystemPlot();
		}

		public SysPerfForm(ConsoleNode console): this()
		{
			this.console = console;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panelGraph = new System.Windows.Forms.Panel();
			this.panelPlotContainer = new System.Windows.Forms.Panel();
			this.plotSurface = new NPlot.Windows.PlotSurface2D();
			this.panelSummaryLabels = new System.Windows.Forms.Panel();
			this.lbCurPowerAvail = new System.Windows.Forms.Label();
			this.lbCurPowerUsage = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lbRunningApps = new System.Windows.Forms.Label();
			this.lbRunningJobs = new System.Windows.Forms.Label();
			this.lbNumExec = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lbTotalPowerUsage = new System.Windows.Forms.Label();
			this.lbMaxPowerAvail = new System.Windows.Forms.Label();
			this.tmRefreshSystem = new System.Windows.Forms.Timer(this.components);
			this.panelGraph.SuspendLayout();
			this.panelPlotContainer.SuspendLayout();
			this.panelSummaryLabels.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelGraph
			// 
			this.panelGraph.AutoScroll = true;
			this.panelGraph.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panelGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelGraph.Controls.Add(this.panelPlotContainer);
			this.panelGraph.Controls.Add(this.panelSummaryLabels);
			this.panelGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelGraph.Location = new System.Drawing.Point(0, 0);
			this.panelGraph.Name = "panelGraph";
			this.panelGraph.Size = new System.Drawing.Size(864, 581);
			this.panelGraph.TabIndex = 5;
			// 
			// panelPlotContainer
			// 
			this.panelPlotContainer.Controls.Add(this.plotSurface);
			this.panelPlotContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelPlotContainer.Location = new System.Drawing.Point(0, 96);
			this.panelPlotContainer.Name = "panelPlotContainer";
			this.panelPlotContainer.Size = new System.Drawing.Size(860, 481);
			this.panelPlotContainer.TabIndex = 2;
			// 
			// plotSurface
			// 
			this.plotSurface.AutoScaleAutoGeneratedAxes = false;
			this.plotSurface.AutoScaleTitle = false;
			this.plotSurface.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.plotSurface.Cursor = System.Windows.Forms.Cursors.Cross;
			this.plotSurface.DateTimeToolTip = false;
			this.plotSurface.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plotSurface.Legend = null;
			this.plotSurface.LegendZOrder = -1;
			this.plotSurface.Location = new System.Drawing.Point(0, 0);
			this.plotSurface.Name = "plotSurface";
			this.plotSurface.Padding = 10;
			this.plotSurface.RightMenu = null;
			this.plotSurface.ShowCoordinates = true;
			this.plotSurface.Size = new System.Drawing.Size(860, 481);
			this.plotSurface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			this.plotSurface.TabIndex = 0;
			this.plotSurface.Title = "";
			this.plotSurface.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
			this.plotSurface.XAxis1 = null;
			this.plotSurface.XAxis2 = null;
			this.plotSurface.YAxis1 = null;
			this.plotSurface.YAxis2 = null;
			// 
			// panelSummaryLabels
			// 
			this.panelSummaryLabels.AutoScroll = true;
			this.panelSummaryLabels.AutoScrollMargin = new System.Drawing.Size(5, 5);
			this.panelSummaryLabels.AutoScrollMinSize = new System.Drawing.Size(300, 50);
			this.panelSummaryLabels.BackColor = System.Drawing.SystemColors.Highlight;
			this.panelSummaryLabels.Controls.Add(this.lbCurPowerAvail);
			this.panelSummaryLabels.Controls.Add(this.lbCurPowerUsage);
			this.panelSummaryLabels.Controls.Add(this.label7);
			this.panelSummaryLabels.Controls.Add(this.label6);
			this.panelSummaryLabels.Controls.Add(this.label5);
			this.panelSummaryLabels.Controls.Add(this.label1);
			this.panelSummaryLabels.Controls.Add(this.lbRunningApps);
			this.panelSummaryLabels.Controls.Add(this.lbRunningJobs);
			this.panelSummaryLabels.Controls.Add(this.lbNumExec);
			this.panelSummaryLabels.Controls.Add(this.label4);
			this.panelSummaryLabels.Controls.Add(this.label3);
			this.panelSummaryLabels.Controls.Add(this.label2);
			this.panelSummaryLabels.Controls.Add(this.lbTotalPowerUsage);
			this.panelSummaryLabels.Controls.Add(this.lbMaxPowerAvail);
			this.panelSummaryLabels.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelSummaryLabels.Location = new System.Drawing.Point(0, 0);
			this.panelSummaryLabels.Name = "panelSummaryLabels";
			this.panelSummaryLabels.Size = new System.Drawing.Size(860, 96);
			this.panelSummaryLabels.TabIndex = 1;
			// 
			// lbCurPowerAvail
			// 
			this.lbCurPowerAvail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbCurPowerAvail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbCurPowerAvail.Location = new System.Drawing.Point(696, 8);
			this.lbCurPowerAvail.Name = "lbCurPowerAvail";
			this.lbCurPowerAvail.Size = new System.Drawing.Size(152, 23);
			this.lbCurPowerAvail.TabIndex = 13;
			this.lbCurPowerAvail.Text = "-";
			this.lbCurPowerAvail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCurPowerUsage
			// 
			this.lbCurPowerUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbCurPowerUsage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbCurPowerUsage.Location = new System.Drawing.Point(696, 33);
			this.lbCurPowerUsage.Name = "lbCurPowerUsage";
			this.lbCurPowerUsage.Size = new System.Drawing.Size(152, 23);
			this.lbCurPowerUsage.TabIndex = 12;
			this.lbCurPowerUsage.Text = "-";
			this.lbCurPowerUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label7.Location = new System.Drawing.Point(568, 33);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 23);
			this.label7.TabIndex = 11;
			this.label7.Text = "Current Power Usage";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label6.Location = new System.Drawing.Point(568, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 23);
			this.label6.TabIndex = 10;
			this.label6.Text = "Current Power Available";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label5.Location = new System.Drawing.Point(288, 33);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "Total Power Usage";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Location = new System.Drawing.Point(288, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Max. Power Available";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbRunningApps
			// 
			this.lbRunningApps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbRunningApps.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbRunningApps.Location = new System.Drawing.Point(160, 33);
			this.lbRunningApps.Name = "lbRunningApps";
			this.lbRunningApps.Size = new System.Drawing.Size(112, 23);
			this.lbRunningApps.TabIndex = 7;
			this.lbRunningApps.Text = "-";
			this.lbRunningApps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbRunningJobs
			// 
			this.lbRunningJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbRunningJobs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbRunningJobs.Location = new System.Drawing.Point(160, 56);
			this.lbRunningJobs.Name = "lbRunningJobs";
			this.lbRunningJobs.Size = new System.Drawing.Size(112, 23);
			this.lbRunningJobs.TabIndex = 6;
			this.lbRunningJobs.Text = "-";
			this.lbRunningJobs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbNumExec
			// 
			this.lbNumExec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbNumExec.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbNumExec.Location = new System.Drawing.Point(160, 8);
			this.lbNumExec.Name = "lbNumExec";
			this.lbNumExec.Size = new System.Drawing.Size(112, 23);
			this.lbNumExec.TabIndex = 5;
			this.lbNumExec.Text = "-";
			this.lbNumExec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point(8, 56);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "No. of running Threads/Jobs";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Location = new System.Drawing.Point(8, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(106, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "No. of Executors";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label2.Location = new System.Drawing.Point(8, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "No. of running Applications";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbTotalPowerUsage
			// 
			this.lbTotalPowerUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTotalPowerUsage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbTotalPowerUsage.Location = new System.Drawing.Point(408, 33);
			this.lbTotalPowerUsage.Name = "lbTotalPowerUsage";
			this.lbTotalPowerUsage.Size = new System.Drawing.Size(152, 23);
			this.lbTotalPowerUsage.TabIndex = 1;
			this.lbTotalPowerUsage.Text = "-";
			this.lbTotalPowerUsage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbMaxPowerAvail
			// 
			this.lbMaxPowerAvail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbMaxPowerAvail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbMaxPowerAvail.Location = new System.Drawing.Point(408, 8);
			this.lbMaxPowerAvail.Name = "lbMaxPowerAvail";
			this.lbMaxPowerAvail.Size = new System.Drawing.Size(152, 23);
			this.lbMaxPowerAvail.TabIndex = 0;
			this.lbMaxPowerAvail.Text = "-";
			this.lbMaxPowerAvail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tmRefreshSystem
			// 
			this.tmRefreshSystem.Interval = 2000;
			this.tmRefreshSystem.Tick += new System.EventHandler(this.tmRefreshSystem_Tick);
			// 
			// SysPerfForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(864, 581);
			this.Controls.Add(this.panelGraph);
			this.Name = "SysPerfForm";
			this.Text = "System Performance Monitor";
			this.panelGraph.ResumeLayout(false);
			this.panelPlotContainer.ResumeLayout(false);
			this.panelSummaryLabels.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		#region "Init-system Plot"
		
		public void InitSystemPlot()
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
				//plotSurface.TitleFont = new Font(new FontFamily("Microsoft Sans Serif" ), 9.75f, FontStyle.Bold);

				plotSurface.XAxis1.WorldMin = -60.0f;
				plotSurface.XAxis1.WorldMax = 0.0f;
				plotSurface.XAxis1.Label = "Seconds";
				//plotSurface.XAxis1.LabelFont = new Font(new FontFamily("Microsoft Sans Serif" ), 9.75f, FontStyle.Bold);
				//plotSurface.XAxis1.TickTextFont = new Font(new FontFamily("Microsoft Sans Serif" ), 9.75f, FontStyle.Bold);

				plotSurface.YAxis1.WorldMin = 0.0;
				plotSurface.YAxis1.WorldMax= 100.0;
				plotSurface.YAxis1.Label = "Power [%]";
				//plotSurface.YAxis1.LabelFont = new Font(new FontFamily("Microsoft Sans Serif" ), 9.75f, FontStyle.Bold);
				//plotSurface.YAxis1.TickTextFont = new Font(new FontFamily("Microsoft Sans Serif" ), 9.75f, FontStyle.Bold);

				Grid gridPlotSurface = new Grid();
				gridPlotSurface.HorizontalGridType = Grid.GridType.None;
				gridPlotSurface.VerticalGridType = Grid.GridType.Fine;
				gridPlotSurface.MajorGridPen.Color = Color.DarkGray;
				plotSurface.Add(gridPlotSurface);

				plotSurface.Legend = new Legend();
				plotSurface.Legend.NeverShiftAxes = false;
				plotSurface.Legend.AttachTo( NPlot.PlotSurface2D.XAxisPosition.Bottom , NPlot.PlotSurface2D.YAxisPosition.Left);
				plotSurface.Legend.HorizontalEdgePlacement = Legend.Placement.Inside;
				plotSurface.Legend.VerticalEdgePlacement = Legend.Placement.Inside;

				lineAvail.Label = "usage";
				lineAvail.Pen   = new Pen(Color.Crimson, 2.0f);

				lineUsage.Label = "avail";
				lineUsage.Pen   = new Pen(Color.SteelBlue, 2.0f);

				plotSurface.AddInteraction(new PlotSurface2D.Interactions.HorizontalDrag());
				plotSurface.AddInteraction(new PlotSurface2D.Interactions.VerticalDrag());
				plotSurface.AddInteraction(new PlotSurface2D.Interactions.AxisDrag(true));
				
				plotSurface.PlotBackColor = Color.White;
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
		
		#endregion
	
		#region "System Summary Graph" 
		
		public void ShowSystem()
		{
			RefreshSystemPlot();
			tmRefreshSystem.Enabled = true;
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
					this.lbMaxPowerAvail.Text =  summary.MaxPower.ToString();
					this.lbTotalPowerUsage.Text = summary.PowerTotalUsage.ToString();
					
					this.lbCurPowerAvail.Text = summary.PowerAvailable.ToString()+ " %";
					this.lbCurPowerUsage.Text = summary.PowerUsage.ToString() + " %";
					
					this.lbNumExec.Text = summary.TotalExecutors.ToString();
					this.lbRunningApps.Text = summary.UnfinishedApps.ToString();
					this.lbRunningJobs.Text = summary.UnfinishedThreads.ToString();
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

		#endregion

		private void tmRefreshSystem_Tick(object sender, EventArgs e)
		{
			RefreshSystemPlot();
		}
	}
}
