using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Mountain.Properties;

namespace Mountain.classes.helpers {

    public class appSettings {
        public string AppDirectory { get; private set; }
        public string UsersXML {
            get {
                return Settings.Default.UserFile;
            }
        }
        public string WorldDirectory {
            get {
                return AppDirectory + Settings.Default.WorldFiles;
            }
        }

        public appSettings() {
            InitializeSettings();
            if (!Directory.Exists(WorldDirectory)) {
                Directory.CreateDirectory(WorldDirectory);
            }

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appData2 = AppDomain.CurrentDomain.BaseDirectory;
        }
        public void InitializeSettings() {
            AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (Settings.Default.UserFile.IsNullOrWhiteSpace()) {
                Settings.Default.UserFile = "world/Users.xml";
            }
            if (Settings.Default.WorldFiles.IsNullOrWhiteSpace()) {
                Settings.Default.WorldFiles = "world";
            }
        }
    }
}

