using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using BT.Sdk.Components;

namespace eduGRIDSMS
{
    public partial class Form1 : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            smsOneWay1.SendMessage("hello from myself!", "919823981721");

            
        }
    }
}