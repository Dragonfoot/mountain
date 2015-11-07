using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Mountain.Properties;

namespace Mountain.classes.helpers {

    public class ApplicationSettings {
        [XmlIgnore]
        public List<Account> RegisteredUsers { get; set; }
        [XmlIgnore]
        public List<Login> Logins { get; set; }
        [XmlIgnore]
        public Players Players { get; set; }
        [XmlIgnore]
        public string AppDirectory { get; private set; }
        [XmlIgnore]
        public string BaseDirectory { get { return AppDirectory + Settings.Default.WorldDirectory; } }
        [XmlIgnore]
        public string RegisteredUsersAccounts { get { return Settings.Default.RegisteredAccounts; } }
        [XmlIgnore]
        public string LastSavedWorld { get { return Settings.Default.LastSavedWorld; } set { Settings.Default.LastSavedWorld = value; } }
        [XmlIgnore]
        public string BuildDirectory { get { return AppDirectory + Settings.Default.BuildDirectory; } }
        private MessageQueue SystemMessageQueue;

        public ApplicationSettings(MessageQueue systemQueue) {
            InitializeSettings();
            if(systemQueue != null) SystemMessageQueue = systemQueue;
            Logins = new List<Login>();
            RegisteredUsers = new List<Account>();
            Players = new Players();
            LoadAllUserAccounts();
        }
        private void LoadAllUserAccounts() {
            var doc = XDocument.Load(BaseDirectory + "\\" + RegisteredUsersAccounts);
            var users = from item in doc.Descendants("Account")
                        select new {
                            name = item.Element("Name").Value,
                            password = item.Element("Password").Value,
                            email = item.Element("Email").Value,
                            filename = item.Element("FileName").Value,
                            administrator = item.Element("Administrator").Value
                        };
            foreach (var user in users) {
                Account account = new Account();
                account.Name = user.name;
                account.Password = user.password;
                account.Email = user.email;
                account.FileName = user.filename;
                account.Administrator = Convert.ToBoolean(user.administrator);
                RegisteredUsers.Add(account);
            }
        }

        public void ConvertLoginToPlayer(Account user) {
            Login newUser = Logins.Find(x => x.ID == user.ID);
            if (newUser != null) {
                Player newPlayer = new Player(newUser.ClientSocket, user);
                Players.Add(newPlayer);
                // add player to room once we have a default world to work in
            }
        }

        public void InitializeSettings() {
            AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(BaseDirectory)) {
                Directory.CreateDirectory(BaseDirectory);
            }
            if (!Directory.Exists(BuildDirectory)) {
                Directory.CreateDirectory(BuildDirectory);
            }

            string file = BaseDirectory + "\\" + RegisteredUsersAccounts;
            if (!File.Exists(file)){ 
                XmlHelper.ReCreateDefaultUserXmlFile(file);
            }
        }
    }


}

