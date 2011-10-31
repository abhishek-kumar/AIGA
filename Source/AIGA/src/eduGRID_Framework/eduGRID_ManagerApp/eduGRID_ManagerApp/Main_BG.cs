using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace eduGRID_ManagerApp
{
    public partial class Main_BG : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        //Declarations
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton MainState = null;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton PrevMainState = null;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton NextMainState = null;

        private double MainStateTransparency = 0; //percentage...double to allow fine granularity lol

        private Manager_Utilities.ManagerContainerWrapper[] ManagerCollection;
        private Manager_Utilities.ManagerContainerWrapper CurrentSelectedManagerWrapper=null;

        //constructor
        public Main_BG()
        {
            InitializeComponent();
            
        }

        //Functions
        private void ChangeState(ComponentFactory.Krypton.Toolkit.KryptonCheckButton CurrentButton, ComponentFactory.Krypton.Toolkit.KryptonCheckButton NextButton)
        {
            if(MainState!=null)
                PrevMainState = MainState;
            MainState = CurrentButton;
            NextMainState = NextButton; 
        }


        //Event Handlers
        #region Event Handlers for Main Form

        private void Form_Activated(object sender, EventArgs e)
        {
            
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (btn_connect.Checked)
            {
                ChangeState(btn_connect, null);

            }
            else
            {
                ChangeState(null, null);
                btn_Conn_1.Visible = false;
                btn_conn_2.Visible = false;
                btn_conn_3.Visible = false;
                btn_conn_4.Visible = false;
            }
            tmr_fade.Enabled = true;

        }


        private void ShowConnections(object sender, EventArgs e)
        {
            //Get the latest information to display here
            Refresh_managerlist();
            //create timer and add refreshmanager list to be put as event handler! (1 second)

            this.est_connections.BringToFront();
            this.est_connections.Visible = true;
            
            //resetting focus to be done
            listview_managers.Columns[0].Width = 40;
            listview_managers.Columns[1].Width = 237;
            listview_managers.Columns[2].Width = 53;
            listview_managers.Columns[3].Width = 94;

        }

        private void Refresh_managerlist()
        {
            //Manager_Utilities.ManagerContainerWrapper M;
            listview_managers.Items.Clear();
            ListViewItem L;
            int Sno = 0;
            if (ManagerCollection == null)
                return;
            foreach(Manager_Utilities.ManagerContainerWrapper M in ManagerCollection)
            {
                Sno++;
                L = listview_managers.Items.Add(Sno.ToString());
                L.SubItems.Add(M.ManagerName);
                if (M._container != null)
                    L.SubItems.Add(M._container.Config.OwnPort.ToString());
                else
                    L.SubItems.Add("-N/A-");

                if (M._container != null)
                    if (M._container.Started)
                        L.SubItems.Add("Running");
                    else
                        L.SubItems.Add("Stopped");
                else
                    L.SubItems.Add("UnInitialized");
            }
            
            //L = listview_managers.Items.Add("1");
            //L.SubItems.Add("some name");
            //L.SubItems.Add("12345");
        }

        private void FadeControlls(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            if ((MainState != null))
            {
                if (MainStateTransparency < 1)
                {
                    //fade in the options
                    MainStateTransparency += 0.1;
                    if (MainStateTransparency >= 1)
                    {
                        MainStateTransparency = 1;
                        tmr_fade.Enabled = false;

                        if (MainState.Name == "btn_connect")
                        {
                            btn_Conn_1.Visible = true;
                            btn_conn_2.Visible = true;
                            btn_conn_3.Visible = true;
                            btn_conn_4.Visible = true;
                        }
                    }
                }
                Point BTL = new Point(MainState.Left - 3, MainState.Top - 3);
                Point BTR = new Point(218, MainState.Top - 3);
                Point BBR = new Point(BTR.X, MainState.Top + MainState.Height + 3); ;
                Point BBL = new Point(BTL.X, BBR.Y);

                using (Brush backBrush = new SolidBrush(Color.FromArgb((int)(150 * (MainStateTransparency)), 100, 134, 142)))
                using (Pen borderPen = new Pen(Color.FromArgb((int)(254 * (MainStateTransparency)), 200, 234, 242), 2))
                using (Pen borderPenThin = new Pen(Color.FromArgb((int)(254 * (MainStateTransparency)), 0, 0, 0), 2))
                {
                    //Draw!
                    e.Graphics.FillRectangle(backBrush, new Rectangle(BTL, new Size(BTR.X - BTL.X, BBL.Y - BTL.Y)));
                    e.Graphics.FillRectangle(backBrush, new Rectangle(new Point(218, 313), new Size(428, 255)));
                    e.Graphics.DrawRectangle(borderPen, new Rectangle(new Point(218, 313), new Size(428, 255)));
                    e.Graphics.DrawRectangle(borderPenThin, new Rectangle(new Point(219, 314), new Size(426, 253)));
                }

            }
            else
            {
                //revert back to the very original (blank)
                if (MainStateTransparency > 0)
                {
                    //fade in the options
                    MainStateTransparency -= 0.1;
                    if (MainStateTransparency <= 0)
                    {
                        MainStateTransparency = 0;
                        //now for the next course of action for next paint event
                        MainState = NextMainState;
                        NextMainState = null;
                    }

                    Point BTL = new Point(PrevMainState.Left - 3, PrevMainState.Top - 3);
                    Point BTR = new Point(218, PrevMainState.Top - 3);
                    Point BBR = new Point(BTR.X, PrevMainState.Top + PrevMainState.Height + 3); ;
                    Point BBL = new Point(BTL.X, BBR.Y);

                    using (Brush backBrush = new SolidBrush(Color.FromArgb((int)(150 * (MainStateTransparency)), 100, 134, 142)))
                    using (Pen borderPen = new Pen(Color.FromArgb((int)(254 * (MainStateTransparency)), 200, 234, 242), 2))
                    using (Pen borderPenThin = new Pen(Color.FromArgb((int)(254 * (MainStateTransparency)), 0, 0, 0), 2))
                    {
                        //Draw!
                        e.Graphics.FillRectangle(backBrush, new Rectangle(BTL, new Size(BTR.X - BTL.X, BBL.Y - BTL.Y)));
                        e.Graphics.FillRectangle(backBrush, new Rectangle(new Point(218, 313), new Size(428, 255)));
                        e.Graphics.DrawRectangle(borderPen, new Rectangle(new Point(218, 313), new Size(428, 255)));
                        e.Graphics.DrawRectangle(borderPenThin, new Rectangle(new Point(219, 314), new Size(426, 253)));
                    }
                }
                else
                {
                    //draw the no focus display thingy
                }
                
            }
        }


        //Now the different sections of the form
        private void buttonSpecHeaderGroup1_Click(object sender, EventArgs e)
        {
            //hide the shown manager instances
            this.est_connections.Visible = false;
            //done!
            this.Refresh();
        }

        private void btn_est_Return_Click(object sender, EventArgs e)
        {
            //hide the shown manager instances
            this.est_connections.Visible = false;
            //done!
            this.Refresh();
        }
        
        private void listview_managers_ItemActivate(object sender, EventArgs e)
        {
            if(CurrentSelectedManagerWrapper==null)
                CurrentSelectedManagerWrapper = ManagerCollection[listview_managers.SelectedIndices[0]];

            DisplayManager();

        }

        #endregion


        private void Create_MWrapper(object sender, EventArgs e)
        {
            if (ManagerCollection != null)
                Array.Resize(ref ManagerCollection, ManagerCollection.Length + 1);
            else
                ManagerCollection = new Manager_Utilities.ManagerContainerWrapper[1];

            ManagerCollection[ManagerCollection.GetUpperBound(0)] = new Manager_Utilities.ManagerContainerWrapper();
            Manager_Utilities.ManagerContainerWrapper M = ManagerCollection[ManagerCollection.GetUpperBound(0)];


            {
                txDbServer.Text = M.Config.DbServer;
                txDbUsername.Text = M.Config.DbUsername;
                txDbPassword.Text = M.Config.DbPassword;
                txDbName.Text = M.Config.DbName;
                txOwnPort.Text = M.Config.OwnPort.ToString();
                //todo: more to be added for intermediate level manager
            }

            //initialize things for starting new manager!
            btn_Manager_Start.Enabled = true;
            btn_Manager_Stop.Enabled = false;
            btn_Manager_Reset.Enabled = true;

            PBar.Visible = false;
            CurrentSelectedManagerWrapper = ManagerCollection[ManagerCollection.GetUpperBound(0)];
            inspect_Manager.BringToFront();
            inspect_Manager.Visible = true;
            
        }
        

        private void DisplayManager()
        {
            //function assumes that currentselectedmanagerwrapper is set properly
            if (CurrentSelectedManagerWrapper != null)
            {
                if ((CurrentSelectedManagerWrapper._container!=null) && (CurrentSelectedManagerWrapper._container.Started))
                {
                    inspect_Manager.ValuesSecondary.Description = "Manager Started";

                    btn_Manager_Start.Enabled = false;
                    btn_Manager_Reset.Enabled = false;

                    btn_Manager_Stop.Enabled = true;
                    txDbServer.Enabled = false;
                    txDbServer.Text = CurrentSelectedManagerWrapper.Config.DbServer;

                    txDbUsername.Enabled = false;
                    txDbUsername.Text = CurrentSelectedManagerWrapper.Config.DbUsername;

                    txDbPassword.Enabled = false;
                    txDbPassword.Text = CurrentSelectedManagerWrapper.Config.DbPassword;

                    txDbName.Enabled = false;
                    txDbName.Text = CurrentSelectedManagerWrapper.Config.DbName;

                    txOwnPort.Enabled = false;
                    txOwnPort.Text = CurrentSelectedManagerWrapper.Config.OwnPort.ToString();

                    PBar.Visible = false;
                }
                else
                {
                    btn_Manager_Start.Enabled = true;
                    btn_Manager_Stop.Enabled = false;
                    btn_Manager_Reset.Enabled = true;

                    txDbServer.Enabled = true;
                    txDbServer.Text = CurrentSelectedManagerWrapper.Config.DbServer;

                    txDbUsername.Enabled = true;
                    txDbUsername.Text = CurrentSelectedManagerWrapper.Config.DbUsername;

                    txDbPassword.Enabled = true;
                    txDbPassword.Text = CurrentSelectedManagerWrapper.Config.DbPassword;

                    txDbName.Enabled = true;
                    txDbName.Text = CurrentSelectedManagerWrapper.Config.DbName;

                    txOwnPort.Enabled = true;
                    txOwnPort.Text = CurrentSelectedManagerWrapper.Config.OwnPort.ToString();
                    
                    PBar.Visible = false;

                }
                inspect_Manager.BringToFront();
                inspect_Manager.Visible = true;
                

            }
            else
            {
                Msgbox.ShowMsgbox("Uninitialized!", "This Manager Instance is not initialized, or was closed for an unknown reason. Would you like to start the instance?", "", "", "&OK");

            }
        }

        private void btn_Manager_Start_Click(object sender, EventArgs e)
        {
            //assumes the manager is not started...otherwise start button would be disabled.
            btn_Manager_Start.Enabled = false;
            btn_Manager_Stop.Enabled = false;
            btn_Manager_Reset.Enabled = false;

            inspect_Manager.ValuesSecondary.Description = "Starting Manager...";
            PBar.Value = 0;
            PBar.Show();

            if (CurrentSelectedManagerWrapper._container == null)
            {
                //this is also done in the constructor of the wrapper
                CurrentSelectedManagerWrapper._container = new Alchemi.Manager.ManagerContainer();
                CurrentSelectedManagerWrapper._container.RemotingConfigFile = "eduGRID_ManagerApp.exe.config";
                CurrentSelectedManagerWrapper._container.ReadConfig(false, AppDomain.CurrentDomain.BaseDirectory, "eduGRIDManager.config.xml");
                CurrentSelectedManagerWrapper.Config = CurrentSelectedManagerWrapper._container.Config;
            }
            {
                //note that dbtype is not being displayed...its type is retained as default
                CurrentSelectedManagerWrapper.Config.DbServer = txDbServer.Text;
                CurrentSelectedManagerWrapper.Config.DbUsername = txDbUsername.Text;
                CurrentSelectedManagerWrapper.Config.DbPassword = txDbPassword.Text;
                CurrentSelectedManagerWrapper.Config.DbName = txDbName.Text;
                CurrentSelectedManagerWrapper.Config.OwnPort = int.Parse(txOwnPort.Text);
                //todo: more to be added for intermediate level manager

                CurrentSelectedManagerWrapper.ManagerName = txtInstanceName.Text;
            }
            CurrentSelectedManagerWrapper._container.Config = CurrentSelectedManagerWrapper.Config;
            try
            {
                CurrentSelectedManagerWrapper._container.Start();
                inspect_Manager.ValuesSecondary.Description = "Manager Started";

                btn_Manager_Stop.Enabled = true;
                txDbServer.Enabled = false;
                txDbUsername.Enabled = false;
                txDbPassword.Enabled = false;
                txDbName.Enabled = false;
                txOwnPort.Enabled = false;
                PBar.Visible = false;
            }
            catch (Exception ex)
            {
                btn_Manager_Start.Enabled = true;
                btn_Manager_Reset.Enabled = true;
                Msgbox.ShowMsgbox("Could not start Manager!", ex.ToString(), "", "", "OK");
                inspect_Manager.ValuesSecondary.Description = "Could not start manager!";
            }
        }

        private void btn_Manager_Stop_Click(object sender, EventArgs e)
        {
            btn_Manager_Stop.Enabled = false;
            try
            {
                CurrentSelectedManagerWrapper._container.Stop();

                CurrentSelectedManagerWrapper._container = null;
                btn_Manager_Start.Enabled = true;
                btn_Manager_Reset.Enabled = true;

                txDbServer.Enabled = true;
                txDbUsername.Enabled = true;
                txDbPassword.Enabled = true;
                txDbName.Enabled = true;
                txOwnPort.Enabled = true;
            }
            catch (Exception ex)
            {
                btn_Manager_Stop.Enabled = true;
                Msgbox.ShowMsgbox("Error stopping manager", ex.ToString(), "", "", "OK :(");
            }
        }

        private void Mngr_instance_return_Click(object sender, EventArgs e)
        {
            inspect_Manager.Visible = false;
            CurrentSelectedManagerWrapper = null;
        }

        private void btn_conn_4_Click(object sender, EventArgs e)
        {
            btn_connect.Checked = false;
            btn_connect_Click(btn_connect, e);
        }

        private void TrayIconClick(object sender, EventArgs e)
        {
            this.CenterToScreen();
            this.Show();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND & (int)m.WParam == SC_CLOSE)
            {
                // 'x' button clicked .. minimise to system tray
                Hide();
                return;
            }
            base.WndProc(ref m);
        }

        private void controlManagersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrayIconClick(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            //Manager_Utilities.ManagerContainerWrapper M;
            if(ManagerCollection!=null)
            foreach (Manager_Utilities.ManagerContainerWrapper M in ManagerCollection)
            {
                try
                {
                    if (M._container != null)
                        M._container.Stop();
                }
                catch
                {
                    //there has been an error in stop routine...cant help have to close somehow
                    
                }
            }
            Application.Exit();

        }
        

       
        
    }
}