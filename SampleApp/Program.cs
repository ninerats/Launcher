using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SampleApp.Launcher;

namespace SampleApp
{
    static class Program
    {
        public static VersionManager VersionManager { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (CheckForUpgrades()) return;
            Start();
        }

        private static bool CheckForUpgrades()
        {
            var launcherRoot = ConfigurationManager.AppSettings["launcherRootPath"];
            VersionManager = new VersionManager(Path.Combine(launcherRoot, "SampleApp"));
            var scanResult = VersionManager.Scan();
            if (!scanResult.Success)
            {
                MessageBox.Show(string.Format("Lancher failed:\r\n{0}", scanResult));
                Start();
                return true;
            }
            if (!VersionManager.IsSupported(Versions.ThisVersion))
            {
                var askResult = NewVersionForm.AskToUpgrade(Application.ProductName, Versions.ThisVersion,
                    VersionManager.LatestStableVersion);
                if (askResult.Success)
                {
                    if (askResult.Value == DialogResult.OK)
                    {
                        var lancher = new Lancher(launcherRoot);
                        lancher.Upgrade(Application.ProductName, VersionManager.LatestStableVersion.Version.ToString());
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            if (!VersionManager.IsCurrent(Versions.ThisVersion))
            {
                var askResult = NewVersionForm.AskToUpgrade(Application.ProductName, Versions.ThisVersion,
                    VersionManager.LatestStableVersion);
                if (askResult.Success)
                {
                    if (askResult.Value == DialogResult.OK)
                    {
                        var lancher = new Lancher(launcherRoot);
                        lancher.Upgrade(Application.ProductName, VersionManager.LatestStableVersion.Version.ToString());
                        return true;
                    }
                }
            }
            return false;
        }

        private static void Start()
        {
           
            Application.Run(new AppMainForm());
        }
    }
}
