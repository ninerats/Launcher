using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Craftsmaneer.Lang;

namespace SampleApp.Launcher
{
    public class Versions
    {

        public static string GetVersionText()
        {

            return string.Format("{0}  v. {1}", Application.ProductName, ThisVersion);
        }
        public static Version ThisVersion
        {
            get
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return new Version(fvi.FileVersion);

            }
        }



    }

    /// <summary>
    /// tracks all the versions of a specific app.
    /// </summary>
    public class VersionManager
    {
        /// <summary>
        /// the path to the root folder of the app in the Lancher directory.
        /// </summary>
        private readonly string _appRootPath;

        private Dictionary<string, AppVersion> _appVersions;
        public AppVersion LatestStableVersion { get; private set; }
        public AppVersion InitialVersion { get; private set; }
        public AppVersion LowestSupportedVersion { get; private set; }

        public VersionManager(string appRootPath)
        {
            _appRootPath = appRootPath;

        }

        public ReturnValue Scan()
        {
            return ReturnValue.Wrap(() =>
            {


                var subdirs = new DirectoryInfo(_appRootPath).GetDirectories();
                _appVersions = new Dictionary<string, AppVersion>();
                foreach (var subdir in subdirs)
                {
                    var relNotesPath = Path.Combine(subdir.FullName, "release_notes.txt");
                    var ver = new AppVersion()
                    {
                        BasePath = subdir.FullName,
                        PublishDate = subdir.CreationTime,
                        ReleaseNotes = File.Exists(relNotesPath) ? File.ReadAllText(relNotesPath) : string.Empty,
                        Version = new Version(subdir.Name)
                    };
                    _appVersions.Add(ver.Version.ToString(), ver);
                }

                var versionConfigPath = Path.Combine(_appRootPath, "versions.xml");
                if (File.Exists(versionConfigPath))
                {

                    var verInfoRoot = XDocument.Load(versionConfigPath).Element("LauncherApp");
                    LatestStableVersion = _appVersions[verInfoRoot.Element("LatestStableVersion").Value];
                    LowestSupportedVersion = _appVersions[verInfoRoot.Element("LowestSupportedVersion").Value];
                    InitialVersion = _appVersions[verInfoRoot.Element("InitialVersion").Value];
                }
                else
                {
                    LatestStableVersion = _appVersions.Values.Last();
                    InitialVersion = _appVersions.Values.First();
                    LowestSupportedVersion = InitialVersion;
                }
            }, "Scanning App");
        }


        /// <summary>
        /// true if the currently running app's version is >= the latest stable version.
        /// </summary>
        /// <param name="thisVersion"></param>
        /// <returns></returns>
        public bool IsCurrent(Version thisVersion)
        {
            return (thisVersion >= LatestStableVersion.Version);
        }





        public bool IsSupported(Version thisVersion)
        {
            return (thisVersion >= LowestSupportedVersion.Version);
        }
    }

    /// <summary>
    /// information about a particular app version.
    /// </summary>
    public struct AppVersion
    {
        public bool Equals(AppVersion other)
        {
            return Equals(Version, other.Version);
        }

        public override int GetHashCode()
        {
            return (Version != null ? Version.GetHashCode() : 0);
        }

        public Version Version { get; set; }
        public DateTime PublishDate { get; set; }
        public string BasePath { get; set; }
        public string ReleaseNotes { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is AppVersion && Equals((AppVersion)obj);
        }
    }
}
