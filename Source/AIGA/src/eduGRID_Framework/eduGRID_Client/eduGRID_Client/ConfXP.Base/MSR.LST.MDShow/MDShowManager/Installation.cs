using System;
using System.IO;
using System.Collections;
using System.Configuration.Install;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MSR.LST.MDShow
{
    [RunInstaller(true)]
    public class Installation : Installer
    {

        public override void Install (IDictionary savedState)
        {

            // First, uninstall in case we weren't uninstalled cleanly before
            IDictionary state = new Hashtable();
            Uninstall(state);
            if (state.Count != 0)
                Commit(state);
            state = null;

            base.Install(savedState);

            MDShowEventLog.Install();

            string oldDirectory = Directory.GetCurrentDirectory();
            FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().Location);
            Directory.SetCurrentDirectory(fi.Directory.FullName);

            try
            {
                RegisterCxpRtpFilters();
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show("Unable to find CxpRtpFilters.ax in the local directory.","File not found");
            }

            try
            {
                RegisterScreenScraperFilter();
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show("Unable to find ScreenScraperFilter.ax in the local directory.","File not found");
            }

            Directory.SetCurrentDirectory(oldDirectory);
        }

        public override void Uninstall (IDictionary savedState)
        {
            string oldDirectory = Directory.GetCurrentDirectory();
            FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().Location);
            Directory.SetCurrentDirectory(fi.Directory.FullName);

            try
            {
                UnregisterCxpRtpFilters();
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show("Unable to find CxpRtpFilters.ax in the local directory.","File not found");
            }

            try
            {
                UnregisterScreenScraperFilter();
            }
            catch (DllNotFoundException)
            {
                MessageBox.Show("Unable to find ScreenScraperFilter.ax in the local directory.","File not found");
            }

            Directory.SetCurrentDirectory(oldDirectory);

            MDShowEventLog.Uninstall();

            if (savedState.Count != 0)
                base.Uninstall(savedState);
        }

        [DllImport("CxpRtpFilters.ax", EntryPoint="DllRegisterServer")]
        private static extern void RegisterCxpRtpFilters();

        [DllImport("CxpRtpFilters.ax", EntryPoint="DllUnregisterServer")]
        private static extern void UnregisterCxpRtpFilters();

        [DllImport("ScreenScraperFilter.ax", EntryPoint="DllRegisterServer")]
        private static extern void RegisterScreenScraperFilter();

        [DllImport("ScreenScraperFilter.ax", EntryPoint="DllUnregisterServer")]
        private static extern void UnregisterScreenScraperFilter();
    }
}
