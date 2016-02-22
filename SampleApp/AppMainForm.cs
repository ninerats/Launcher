using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SampleApp.Launcher;

namespace SampleApp
{
    public partial class AppMainForm : Form
    {
        
        public AppMainForm()
        {
            InitializeComponent();
            Text = Versions.GetVersionText();
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void cmdCheckForLatest_Click(object sender, EventArgs e)
        {
            if (Program.VersionManager.IsCurrent(Versions.ThisVersion))
            {
                MessageBox.Show("You are on the most current version.");

            }
            else
            {
                NewVersionForm.AskToUpgrade(Application.ProductName, Versions.ThisVersion,
                    Program.VersionManager.LatestStableVersion);
            }
        }
    }
}
