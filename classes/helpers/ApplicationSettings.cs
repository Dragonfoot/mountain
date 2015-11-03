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
        public List<Account> Users;
        public string AppDirectory { get; private set; }
        public string WorldDirectory { get { return AppDirectory + Settings.Default.WorldDirectory; } }
        public string UsersXML { get { return Settings.Default.UserFile; } }

        public ApplicationSettings() {
            InitializeSettings();
            Users = new List<Account>();
            LoadAllUserAccounts();
        }

        private void LoadAllUserAccounts() {
            var doc = XDocument.Load(WorldDirectory + "\\" + UsersXML);
            var users = from item in doc.Descendants("Account")
                       select new {
                           name = item.Element("Name").Value,
                           password = item.Element("Password").Value,
                           email = item.Element("Email").Value,
                           filename = item.Element("FileName").Value,
                           administrator = item.Element("Administrator").Value
                       };
            foreach (var user in users) {
                Account info = new Account();
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
           // if (!File.Exists(file)){  // remove comments after debugging
                XmlHelper.ReCreateUserXmlFile(file);
           // }
        }
    }


}

