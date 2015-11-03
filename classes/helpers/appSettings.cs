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
                return AppDirectory + Settings.Default.WorldDirectory;
            }
        }
        public appSettings() {
            InitializeSettings();
            if (!Directory.Exists(WorldDirectory)) {
                Directory.CreateDirectory(WorldDirectory);
            }
        }
        public void InitializeSettings() {
            AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = WorldDirectory + "\\" + UsersXML;
            if (!File.Exists(file)){
                ReCreateUserXmlFile(file);
            }
        }
        public void ReCreateUserXmlFile(string path) {
            User user = new User();
            user.SetName("Admin");
            user.SetPassword("Admin");
            user.AddWorld("Admin");
            XmlHelper.ObjectToXml(user, path);
        }
    }
}

