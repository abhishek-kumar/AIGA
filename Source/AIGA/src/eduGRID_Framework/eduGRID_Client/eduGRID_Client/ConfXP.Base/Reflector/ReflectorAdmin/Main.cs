using System;
using System.Windows.Forms;
using System.Threading;

namespace Reflector
{
    public class ReflectorAdmin
    {
        private NotifyIcon sysTrayIcon;
        private ContextMenu iconMenu;
        private MenuItem menuOpen;
        private MenuItem menuExit;
        private static Thread t;
        private static MainForm mainForm;
        
        public ReflectorAdmin()
        {
            // MenuItem
            menuOpen = new MenuItem("Open", new EventHandler(menuOpen_Click));
            menuExit = new MenuItem("Exit", new EventHandler(menuExit_Click));

            //
            // ContextMenu
            //
            iconMenu = new ContextMenu();
            iconMenu.MenuItems.Add(menuOpen);
            iconMenu.MenuItems.Add(menuExit);

            //
            // NotifyIcon
            //
            sysTrayIcon = new NotifyIcon();
            sysTrayIcon.ContextMenu = iconMenu;
            sysTrayIcon.Icon = new System.Drawing.Icon("reflector.ico");
            sysTrayIcon.Text = "ConferenceXP Reflector Service Administration";
            sysTrayIcon.Visible = true;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            t = new Thread(new ThreadStart(FormProc));
            t.Start();

            ReflectorAdmin admin = new ReflectorAdmin();
            Application.Run();
        }

        private static void FormProc()
        {
            mainForm = new MainForm();
            Application.Run(mainForm);
        }

        private void menuOpen_Click(object sender, System.EventArgs e)
        {
            if (t.IsAlive)
            {
                mainForm.WindowState = FormWindowState.Normal;
                mainForm.Activate();
                mainForm.Show();
            }
            else
            {
                t = new Thread(new ThreadStart(FormProc));
                t.Start();
            }
        }

        private void menuExit_Click(object sender, System.EventArgs e)
        {
            sysTrayIcon.Dispose();  
            Application.Exit();
        }
    }
}
