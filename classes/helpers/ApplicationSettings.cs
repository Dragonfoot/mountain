using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Mountain.Properties;

namespace Mountain.classes.helpers {

    public class ApplicationSettings {
        public List<UserInfo> Users;
        public string AppDirectory { get; private set; }
        public string WorldDirectory { get { return AppDirectory + Settings.Default.WorldDirectory; } }
        public string UsersXML { get { return Settings.Default.UserFile; } }

        public ApplicationSettings() {
            InitializeSettings();
            Users = new List<UserInfo>();
            LoadUsers();
        }

        private void LoadUsers() {
            var doc = XDocument.Load(WorldDirectory + "\\" + UsersXML);

            // Do a simple query and print the results to the console
            var users = from item in doc.Descendants("User")
                       select new {
                           name = item.Element("Name").Value,
                           password = item.Element("Password").Value,
                           email = item.Element("Email").Value,
                           filename = item.Element("FileName").Value,
                           administrator = item.Element("Administrator").Value
                       };
            foreach (var user in users) {
                UserInfo info = new UserInfo();
                info.Name = user.name;
                info.Password = user.password;
                info.Email = user.email;
                info.FileName = user.filename;
                info.Administrator = Convert.ToBoolean(user.administrator);
                Users.Add(info);
            }
        }

        public void InitializeSettings() {
            AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(WorldDirectory)) {
                Directory.CreateDirectory(WorldDirectory);
            }
            string file = WorldDirectory + "\\" + UsersXML;
           // if (!File.Exists(file)){
                XmlHelper.ReCreateUserXmlFile(file);
           // }
        }
    }


}

