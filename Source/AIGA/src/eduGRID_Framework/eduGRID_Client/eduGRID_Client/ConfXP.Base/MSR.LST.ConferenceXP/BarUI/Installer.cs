using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Reflection;
using System.Windows.Forms;

namespace MSR.LST.ConferenceXP
{
    [RunInstaller(true)]
    public class Installer : System.Configuration.Install.Installer
    {
        public Installer() : base()
        {
            AssemblyInstaller ai = new AssemblyInstaller();
            ai.Assembly = Assembly.Load("Conference");
            Installers.Add(ai);

            AssemblyInstaller ai2 = new AssemblyInstaller();
            ai2.Assembly = Assembly.Load("LSTCommon");
            Installers.Add(ai2);
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install (stateSaver);

            if (MSR.LST.Net.FirewallUtility.HasSp2Firewall)
            {
                if (MSR.LST.Net.FirewallUtility.Sp2FirewallEnabled)
                {
                    MessageBox.Show(
                        "Installation will now set this application to \n"+
                        "work through your Windows XP firewall.",
                        "Firewall", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MSR.LST.Net.FirewallUtility.AddAppToSP2Firewall ("ConferenceXP Client",
                        Context.Parameters["assemblypath"], "*", true);
                }
            }
            else if (MSR.LST.Net.FirewallUtility.OldFirewallEnabled)
            {
                MessageBox.Show(
                    "If your computer has a firewall enabled, it could not \n"+
                    "be found.  You must add an exception for ConferenceXP to \n"+
                    "your firewall's exception list to allow it to work properly.",
                    "Firewall Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall (savedState);

            if (MSR.LST.Net.FirewallUtility.HasSp2Firewall)
            {
                MSR.LST.Net.FirewallUtility.RemoveAppFromSP2Firewall (Context.Parameters["assemblypath"]);
            }
        }
    }
}