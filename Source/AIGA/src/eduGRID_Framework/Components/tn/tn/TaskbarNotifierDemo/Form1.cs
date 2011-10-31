using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CustomUIControls;

namespace TaskbarNotifierDemo
{
	/// <summary>
	/// Description résumée de Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button ButtonShowPopup1;
		private System.Windows.Forms.Button ButtonShowPopup2;
		private System.Windows.Forms.Button ButtonShowPopup3;		// Added Rev 002
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox checkBoxSelectionRectangle;
		private System.Windows.Forms.TextBox textBoxTitle;
		private System.Windows.Forms.TextBox textBoxContent;
		private System.Windows.Forms.TextBox textBoxDelayShowing;
		private System.Windows.Forms.TextBox textBoxDelayStaying;
		private System.Windows.Forms.TextBox textBoxDelayHiding;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox checkBoxTitleClickable;
		private System.Windows.Forms.CheckBox checkBoxContentClickable;
		private System.Windows.Forms.CheckBox checkBoxCloseClickable;
		private System.Windows.Forms.CheckBox checkBoxReShowOnMouseOver;		// Added Rev 002
		private System.Windows.Forms.CheckBox checkBoxKeepVisibleOnMouseOver;	// Added Rev 002
		TaskbarNotifier taskbarNotifier1;
		TaskbarNotifier taskbarNotifier2;
		TaskbarNotifier taskbarNotifier3;							// Added Rev 002

		public Form1()
		{
			//
			// Requis pour la prise en charge du Concepteur Windows Forms
			//
			InitializeComponent();

			
			textBoxContent.Text="This is a sample content, it can spread on multiple lines";
			textBoxTitle.Text="Title";
			textBoxDelayShowing.Text="500";
			textBoxDelayStaying.Text="3000";
			textBoxDelayHiding.Text="500";
			checkBoxSelectionRectangle.Checked=true;
			checkBoxTitleClickable.Checked=false;
			checkBoxContentClickable.Checked=true;
			checkBoxCloseClickable.Checked=true;
			checkBoxKeepVisibleOnMouseOver.Checked = true;		// Added Rev 002
			checkBoxReShowOnMouseOver.Checked = false;			// Added Rev 002

			taskbarNotifier1=new TaskbarNotifier();
			taskbarNotifier1.SetBackgroundBitmap(new Bitmap(GetType(),"skin.bmp"),Color.FromArgb(255,0,255));
			taskbarNotifier1.SetCloseBitmap(new Bitmap(GetType(),"close.bmp"),Color.FromArgb(255,0,255),new Point(127,8));
			taskbarNotifier1.TitleRectangle=new Rectangle(40,9,70,25);
			taskbarNotifier1.ContentRectangle=new Rectangle(8,41,133,68);
			taskbarNotifier1.TitleClick+=new EventHandler(TitleClick);
			taskbarNotifier1.ContentClick+=new EventHandler(ContentClick);
			taskbarNotifier1.CloseClick+=new EventHandler(CloseClick);

			taskbarNotifier2=new TaskbarNotifier();
			taskbarNotifier2.SetBackgroundBitmap(new Bitmap(GetType(),"skin2.bmp"),Color.FromArgb(255,0,255));
			taskbarNotifier2.SetCloseBitmap(new Bitmap(GetType(),"close2.bmp"),Color.FromArgb(255,0,255),new Point(300,74));
			taskbarNotifier2.TitleRectangle=new Rectangle(123,80,176,16);
			taskbarNotifier2.ContentRectangle=new Rectangle(116,97,197,22);
			taskbarNotifier2.TitleClick+=new EventHandler(TitleClick);
			taskbarNotifier2.ContentClick+=new EventHandler(ContentClick);
			taskbarNotifier2.CloseClick+=new EventHandler(CloseClick);

			// Added Rev 002
			taskbarNotifier3=new TaskbarNotifier();
			taskbarNotifier3.SetBackgroundBitmap(new Bitmap(GetType(),"skin3.bmp"),Color.FromArgb(255,0,255));
			taskbarNotifier3.SetCloseBitmap(new Bitmap(GetType(),"close.bmp"),Color.FromArgb(255,0,255),new Point(280,57));
			taskbarNotifier3.TitleRectangle=new Rectangle(150, 57, 125, 28);
			taskbarNotifier3.ContentRectangle=new Rectangle(75, 92, 215, 55);
			taskbarNotifier3.TitleClick+=new EventHandler(TitleClick);
			taskbarNotifier3.ContentClick+=new EventHandler(ContentClick);
			taskbarNotifier3.CloseClick+=new EventHandler(CloseClick);
		}

		/// <summary>
		/// Nettoyage des ressources utilisées.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.ButtonShowPopup1 = new System.Windows.Forms.Button();
			this.ButtonShowPopup2 = new System.Windows.Forms.Button();
			this.checkBoxSelectionRectangle = new System.Windows.Forms.CheckBox();
			this.textBoxTitle = new System.Windows.Forms.TextBox();
			this.textBoxContent = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxDelayShowing = new System.Windows.Forms.TextBox();
			this.textBoxDelayStaying = new System.Windows.Forms.TextBox();
			this.textBoxDelayHiding = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkBoxCloseClickable = new System.Windows.Forms.CheckBox();
			this.checkBoxContentClickable = new System.Windows.Forms.CheckBox();
			this.checkBoxTitleClickable = new System.Windows.Forms.CheckBox();
			this.ButtonShowPopup3 = new System.Windows.Forms.Button();
			this.checkBoxReShowOnMouseOver = new System.Windows.Forms.CheckBox();
			this.checkBoxKeepVisibleOnMouseOver = new System.Windows.Forms.CheckBox();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtonShowPopup1
			// 
			this.ButtonShowPopup1.Location = new System.Drawing.Point(8, 328);
			this.ButtonShowPopup1.Name = "ButtonShowPopup1";
			this.ButtonShowPopup1.Size = new System.Drawing.Size(88, 23);
			this.ButtonShowPopup1.TabIndex = 0;
			this.ButtonShowPopup1.Text = "Show popup 1";
			this.ButtonShowPopup1.Click += new System.EventHandler(this.ButtonShowPopup1_Click);
			// 
			// ButtonShowPopup2
			// 
			this.ButtonShowPopup2.Location = new System.Drawing.Point(108, 328);
			this.ButtonShowPopup2.Name = "ButtonShowPopup2";
			this.ButtonShowPopup2.Size = new System.Drawing.Size(88, 23);
			this.ButtonShowPopup2.TabIndex = 1;
			this.ButtonShowPopup2.Text = "Show popup 2";
			this.ButtonShowPopup2.Click += new System.EventHandler(this.ButtonShowPopup2_Click);
			// 
			// checkBoxSelectionRectangle
			// 
			this.checkBoxSelectionRectangle.Location = new System.Drawing.Point(128, 48);
			this.checkBoxSelectionRectangle.Name = "checkBoxSelectionRectangle";
			this.checkBoxSelectionRectangle.Size = new System.Drawing.Size(160, 16);
			this.checkBoxSelectionRectangle.TabIndex = 2;
			this.checkBoxSelectionRectangle.Text = "Show Selection Rectangle";
			// 
			// textBoxTitle
			// 
			this.textBoxTitle.Location = new System.Drawing.Point(64, 32);
			this.textBoxTitle.Name = "textBoxTitle";
			this.textBoxTitle.Size = new System.Drawing.Size(224, 20);
			this.textBoxTitle.TabIndex = 3;
			this.textBoxTitle.Text = "textBoxTitle";
			// 
			// textBoxContent
			// 
			this.textBoxContent.Location = new System.Drawing.Point(64, 64);
			this.textBoxContent.Name = "textBoxContent";
			this.textBoxContent.Size = new System.Drawing.Size(224, 20);
			this.textBoxContent.TabIndex = 4;
			this.textBoxContent.Text = "textBoxContent";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "Title";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Content";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(296, 88);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Text";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(208, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 13;
			this.label5.Text = "Delay Hiding";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(120, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 12;
			this.label4.Text = "Delay Staying";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 11;
			this.label3.Text = "Delay Showing";
			// 
			// textBoxDelayShowing
			// 
			this.textBoxDelayShowing.Location = new System.Drawing.Point(32, 152);
			this.textBoxDelayShowing.Name = "textBoxDelayShowing";
			this.textBoxDelayShowing.Size = new System.Drawing.Size(56, 20);
			this.textBoxDelayShowing.TabIndex = 10;
			this.textBoxDelayShowing.Text = "textBoxDelayShowing";
			// 
			// textBoxDelayStaying
			// 
			this.textBoxDelayStaying.Location = new System.Drawing.Point(128, 152);
			this.textBoxDelayStaying.Name = "textBoxDelayStaying";
			this.textBoxDelayStaying.Size = new System.Drawing.Size(56, 20);
			this.textBoxDelayStaying.TabIndex = 9;
			this.textBoxDelayStaying.Text = "textBoxDelayStaying";
			// 
			// textBoxDelayHiding
			// 
			this.textBoxDelayHiding.Location = new System.Drawing.Point(216, 152);
			this.textBoxDelayHiding.Name = "textBoxDelayHiding";
			this.textBoxDelayHiding.Size = new System.Drawing.Size(56, 20);
			this.textBoxDelayHiding.TabIndex = 8;
			this.textBoxDelayHiding.Text = "textBoxDelayHiding";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(8, 104);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(296, 88);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Animation Delays (ms)";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.checkBoxReShowOnMouseOver,
																					this.checkBoxKeepVisibleOnMouseOver,
																					this.checkBoxCloseClickable,
																					this.checkBoxContentClickable,
																					this.checkBoxTitleClickable,
																					this.checkBoxSelectionRectangle});
			this.groupBox3.Location = new System.Drawing.Point(8, 200);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(296, 120);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Options";
			// 
			// checkBoxCloseClickable
			// 
			this.checkBoxCloseClickable.Location = new System.Drawing.Point(16, 48);
			this.checkBoxCloseClickable.Name = "checkBoxCloseClickable";
			this.checkBoxCloseClickable.Size = new System.Drawing.Size(104, 16);
			this.checkBoxCloseClickable.TabIndex = 3;
			this.checkBoxCloseClickable.Text = "Close Clickable";
			// 
			// checkBoxContentClickable
			// 
			this.checkBoxContentClickable.Location = new System.Drawing.Point(128, 24);
			this.checkBoxContentClickable.Name = "checkBoxContentClickable";
			this.checkBoxContentClickable.Size = new System.Drawing.Size(112, 16);
			this.checkBoxContentClickable.TabIndex = 1;
			this.checkBoxContentClickable.Text = "Content Clickable";
			// 
			// checkBoxTitleClickable
			// 
			this.checkBoxTitleClickable.Location = new System.Drawing.Point(16, 24);
			this.checkBoxTitleClickable.Name = "checkBoxTitleClickable";
			this.checkBoxTitleClickable.Size = new System.Drawing.Size(96, 16);
			this.checkBoxTitleClickable.TabIndex = 0;
			this.checkBoxTitleClickable.Text = "Title Clickable";
			// 
			// ButtonShowPopup3
			// 
			this.ButtonShowPopup3.Location = new System.Drawing.Point(208, 328);
			this.ButtonShowPopup3.Name = "ButtonShowPopup3";
			this.ButtonShowPopup3.Size = new System.Drawing.Size(88, 23);
			this.ButtonShowPopup3.TabIndex = 20;
			this.ButtonShowPopup3.Text = "Show popup 3";
			this.ButtonShowPopup3.Click += new System.EventHandler(this.ButtonShowPopup3_Click);
			// 
			// checkBoxReShowOnMouseOver
			// 
			this.checkBoxReShowOnMouseOver.Location = new System.Drawing.Point(16, 92);
			this.checkBoxReShowOnMouseOver.Name = "checkBoxReShowOnMouseOver";
			this.checkBoxReShowOnMouseOver.Size = new System.Drawing.Size(268, 16);
			this.checkBoxReShowOnMouseOver.TabIndex = 7;
			this.checkBoxReShowOnMouseOver.Text = "Re-show when Mouse over window when hiding";
			// 
			// checkBoxKeepVisibleOnMouseOver
			// 
			this.checkBoxKeepVisibleOnMouseOver.Location = new System.Drawing.Point(16, 72);
			this.checkBoxKeepVisibleOnMouseOver.Name = "checkBoxKeepVisibleOnMouseOver";
			this.checkBoxKeepVisibleOnMouseOver.Size = new System.Drawing.Size(268, 16);
			this.checkBoxKeepVisibleOnMouseOver.TabIndex = 6;
			this.checkBoxKeepVisibleOnMouseOver.Text = "Keep Visible when Mouse over window";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(312, 357);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ButtonShowPopup3,
																		  this.groupBox3,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.textBoxDelayShowing,
																		  this.textBoxDelayStaying,
																		  this.textBoxDelayHiding,
																		  this.label2,
																		  this.label1,
																		  this.textBoxContent,
																		  this.textBoxTitle,
																		  this.ButtonShowPopup2,
																		  this.ButtonShowPopup1,
																		  this.groupBox1,
																		  this.groupBox2});
			this.Name = "Form1";
			this.Text = "C# TaskbarNotifier  Demo";
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		static bool IsNumeric(string str) 
		{
			if (str==null || str.Length==0)
				return false;
			foreach(char c in str) 
			{
				if (!Char.IsNumber(c)) 
				{
					return false;
				}
			}
			return true;
		}

		private void ButtonShowPopup1_Click(object sender, System.EventArgs e)
		{
			if (textBoxTitle.Text.Length==0 || textBoxContent.Text.Length==0)
			{
				MessageBox.Show("Enter a title and a content Text");
				return;
			}
			if (!IsNumeric(textBoxDelayShowing.Text) || !IsNumeric(textBoxDelayStaying.Text) || !IsNumeric(textBoxDelayHiding.Text))
			{
				MessageBox.Show("Enter valid Delays (integers)");
				return;
			}
			
			taskbarNotifier1.CloseClickable=checkBoxCloseClickable.Checked;
			taskbarNotifier1.TitleClickable=checkBoxTitleClickable.Checked;
			taskbarNotifier1.ContentClickable=checkBoxContentClickable.Checked;
			taskbarNotifier1.EnableSelectionRectangle=checkBoxSelectionRectangle.Checked;
			taskbarNotifier1.KeepVisibleOnMousOver=checkBoxKeepVisibleOnMouseOver.Checked;	// Added Rev 002
			taskbarNotifier1.ReShowOnMouseOver=checkBoxReShowOnMouseOver.Checked;			// Added Rev 002
			taskbarNotifier1.Show(textBoxTitle.Text,textBoxContent.Text,Int32.Parse(textBoxDelayShowing.Text),Int32.Parse(textBoxDelayStaying.Text),Int32.Parse(textBoxDelayHiding.Text));
		}

		private void ButtonShowPopup2_Click(object sender, System.EventArgs e)
		{
			if (textBoxTitle.Text.Length==0 || textBoxContent.Text.Length==0)
			{
				MessageBox.Show("Enter a title and a content Text");
				return;
			}
			if (!IsNumeric(textBoxDelayShowing.Text) || !IsNumeric(textBoxDelayStaying.Text) || !IsNumeric(textBoxDelayHiding.Text))
			{
				MessageBox.Show("Enter valid Delays (integers)");
				return;
			}
			
			taskbarNotifier2.CloseClickable=checkBoxCloseClickable.Checked;
			taskbarNotifier2.TitleClickable=checkBoxTitleClickable.Checked;
			taskbarNotifier2.ContentClickable=checkBoxContentClickable.Checked;
			taskbarNotifier2.EnableSelectionRectangle=checkBoxSelectionRectangle.Checked;
			taskbarNotifier2.KeepVisibleOnMousOver=checkBoxKeepVisibleOnMouseOver.Checked;	// Added Rev 002
			taskbarNotifier2.ReShowOnMouseOver=checkBoxReShowOnMouseOver.Checked;			// Added Rev 002
			taskbarNotifier2.Show(textBoxTitle.Text,textBoxContent.Text,Int32.Parse(textBoxDelayShowing.Text),Int32.Parse(textBoxDelayStaying.Text),Int32.Parse(textBoxDelayHiding.Text));
		}

		// Added Rev 002
		private void ButtonShowPopup3_Click(object sender, System.EventArgs e)
		{
			if (textBoxTitle.Text.Length==0 || textBoxContent.Text.Length==0)
			{
				MessageBox.Show("Enter a title and a content Text");
				return;
			}
			if (!IsNumeric(textBoxDelayShowing.Text) || !IsNumeric(textBoxDelayStaying.Text) || !IsNumeric(textBoxDelayHiding.Text))
			{
				MessageBox.Show("Enter valid Delays (integers)");
				return;
			}
			
			taskbarNotifier3.CloseClickable=checkBoxCloseClickable.Checked;
			taskbarNotifier3.TitleClickable=checkBoxTitleClickable.Checked;
			taskbarNotifier3.ContentClickable=checkBoxContentClickable.Checked;
			taskbarNotifier3.EnableSelectionRectangle=checkBoxSelectionRectangle.Checked;
			taskbarNotifier3.KeepVisibleOnMousOver=checkBoxKeepVisibleOnMouseOver.Checked;	// Added Rev 002
			taskbarNotifier3.ReShowOnMouseOver=checkBoxReShowOnMouseOver.Checked;			// Added Rev 002
			taskbarNotifier3.Show(textBoxTitle.Text,textBoxContent.Text,Int32.Parse(textBoxDelayShowing.Text),Int32.Parse(textBoxDelayStaying.Text),Int32.Parse(textBoxDelayHiding.Text));
		
		}

		void CloseClick(object obj,EventArgs ea)
		{
			MessageBox.Show("Closed was Clicked");
		}

		void TitleClick(object obj,EventArgs ea)
		{
			MessageBox.Show("Title was Clicked");
		}

		void ContentClick(object obj,EventArgs ea)
		{
			MessageBox.Show("Content was Clicked");
		}
	}
}
