using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Craftsmaneer.Lang;

namespace Launcher
{
    class Program
    {
        public static int MaxAttempts { get { return 3; }}
        /// <summary>
        /// command line = "launcher action value"
        /// where actions are:
        ///   - launch {path to app}
        ///   - upgrade {path to app} {appName} {version}
        /// 
        /// </summary>
        /// <param name="args"></param>
        static int Main(string[] args)
        {

            var result = ReturnValue.Wrap(() =>
            {
                Log(String.Join(" ", args));
                var cmd = (args[0].ToLower());
                if (cmd == "launch")
                {
                    CheckResult(Launch(args[1]));
                }
                else if (cmd == "upgrade")
                {
                    CheckResult(Upgrade(args[1], args[2], args[3]));
                }
                else if (cmd == "upgradeandlaunch")
                {
                    CheckResult(Upgrade(args[1], args[2], args[3]));
                    CheckResult(Launch(string.Format(@"{0}\{1}.exe",args[1], args[2] )));
                }
                else
                {
                    Contract.Assert(false);
                    InvalidCommand(cmd);

                }

            }, "Launcher Main");
            if (result.Success) return 0;
            Log(result);
            return 1;
        }

        private static void CheckResult(ReturnValue launchResult)
        {
            if (!launchResult.Success)
            {
              //  Log(launchResult);
                launchResult.AbortOnFail();
            }
        }

        private static void Log(ReturnValue result)
        {
            Log(result.ToString());
        }

        private static void Log(string msg)
        {
            File.AppendAllText("launcher.log", string.Format("{0}\t{1}\r\n", DateTime.Now, msg));
        }

        private static void InvalidCommand(string cmd)
        {
            var msg = string.Format("'{0}' is not a valid command.", cmd);
            throw new ArgumentException(msg);
        }

        private static ReturnValue Upgrade(string appPath, string appName, string version)
        {
            return ReturnValue.Wrap(() =>
            {
                var sourceFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, appName, version);
                if (!Directory.Exists(sourceFolder))
                {
                    throw new DirectoryNotFoundException(string.Format("source app folder '{0}' not found", sourceFolder));
                }

                if (!Directory.Exists(appPath))
                {
                    throw new DirectoryNotFoundException(string.Format("target app folder '{0}' not found", sourceFolder));
                }
                var attempt = 1;
                var success = false;
                while (attempt <= MaxAttempts && (!success))
                {
                    Log(string.Format("Upgrade attempt #{0}..",attempt));
                    success = AttemptUpgrade(sourceFolder, appPath);
                    Thread.Sleep(1000);
                    attempt++;
                }
                if (attempt > MaxAttempts) ReturnValue.Abort(string.Format("Unable to Upgrade after {0} attempts.", MaxAttempts));
                Log("Upgrade sucessful.");

            }, string.Format("Upgrading {0} to {1}, {2}", appPath, appName, version));

        }

      

        private static bool AttemptUpgrade(string sourceFolder, string appPath )
        {
            var result = ReturnValue.Wrap(() =>
            {
             ClearDirectory(appPath);
                CopyDirectory(sourceFolder, appPath);
            }, "");
            return result.Success;

        }

        private static void CopyDirectory(string source, string dest)
        {
            if (!Directory.Exists(dest))
            {
                Directory.CreateDirectory(dest);
            }
            foreach (var subdir in new DirectoryInfo(source).GetDirectories())
            {
                CopyDirectory(subdir.FullName, Path.Combine(dest, subdir.Name));
            }
            foreach (var file in new DirectoryInfo(source).GetFiles())
            {
                file.CopyTo(Path.Combine(dest, file.Name), true);
            }
        }

        private static void ClearDirectory(string appPath)
        {
            foreach (var subdir in new DirectoryInfo(appPath).GetDirectories())
            {
                subdir.Delete(true);
            }
            foreach (var file in new DirectoryInfo(appPath).GetFiles())
            {
                file.Delete();
            }
        }

        /// <summary>
        /// starts an app with the given path.
        /// </summary>
        /// <param name="appPath"></param>
        /// <returns></returns>
        public static ReturnValue Launch(string appPath)
        {
            return ReturnValue.Wrap(() =>
            {

                if (!File.Exists(appPath)) throw new FileNotFoundException("File not found", appPath);
                var wd = new FileInfo(appPath).DirectoryName;

                var startInfo = new ProcessStartInfo(appPath)
                {
                    WorkingDirectory = wd,
                    UseShellExecute = true
                };
                Process.Start(startInfo);
                Log(string.Format("Launched app {0}.",appPath));
            }, string.Format("Launching {0}", appPath));
        }
    }
}
