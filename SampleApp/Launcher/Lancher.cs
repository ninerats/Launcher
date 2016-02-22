using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Craftsmaneer.Lang;

namespace SampleApp.Launcher
{
    public class Lancher
    {
        /// <summary>
        /// bath to the base directory for the launcher application.
        /// </summary>
        private readonly string _rootPath;

        public Lancher(string rootPath)
        {
            _rootPath = rootPath;
        }

        /// <summary>
        /// replaces the running app with the specified version.
        /// </summary>

        /// <returns></returns>
        public ReturnValue Upgrade(string appName, string  targetVersion)
        {
            return ReturnValue.Wrap(() =>
            {
                var launcherExePath = Path.Combine(_rootPath, "Launcher.exe");

                if (!File.Exists(launcherExePath)) throw new FileNotFoundException("Launcher.exe not folder in folder", _rootPath);


                var startInfo = new ProcessStartInfo(launcherExePath)
                {
                    WorkingDirectory = _rootPath,
                    UseShellExecute = true,
                    Arguments = string.Format("upgradeAndLaunch {0} {1} {2}",AppDomain.CurrentDomain.BaseDirectory, appName, targetVersion)
                };
                Debug.WriteLine(string.Format("path: {0}", startInfo.FileName));
                Debug.WriteLine(string.Format("args: {0}", string.Join(" ", startInfo.Arguments)));
                Process.Start(startInfo);
            }, string.Format("Upgrading app '{0}' to version '{1}'", appName,targetVersion));
        }
    }
}
