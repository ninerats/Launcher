using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Craftsmaneer.Lang;
using SampleApp.Launcher;

namespace SampleApp
{
    public partial class NewVersionForm : Form
    {
        public NewVersionForm()
        {
            InitializeComponent();
        }

        public static ReturnValue<DialogResult> AskToUpgrade(string appName, Version thisVersion, AppVersion targetVersion)
        {
            return ReturnValue<DialogResult>.Wrap(() =>
            {

           
            var form = new NewVersionForm
            {
                txtYourVersion = {Text = thisVersion.ToString()},
                txtLatestVersion = {Text = targetVersion.Version.ToString()},
                
            };
            ReturnValue.Wrap ( () => form.Text =   form.Text.Replace("{app}", appName)); //.LogOnFail();
            var ans = form.ShowDialog();
            return ans;
            },string.Format("Showing NewVersionForm for app {0}, this version = '{1}', target version = '{2}'",appName,thisVersion,targetVersion));
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
