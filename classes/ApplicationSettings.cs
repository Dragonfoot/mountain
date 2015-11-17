using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using Mountain.Properties;
using Mountain.classes.collections;
using Mountain.classes.dataobjects;
using Mountain.classes.tcp;
using Mountain.classes.functions;

namespace Mountain.classes {

    public class ApplicationSettings {
        public RegisteredUsers RegisteredUsers { get; set; }
        public List<Connection> Logins { get; set; }
        public World world;
        public Players Players { get; set; }
        public Room TheVoid { get; set; }
        public string AppDirectory { get; private set; }
        public string BaseDirectory { get { return AppDirectory + Settings.Default.WorldsDirectory; } }
        public string RegisteredUsersAccounts { get { return Settings.Default.RegisteredAccounts; } }
        public string LastSavedWorld { get { return Settings.Default.LastSavedWorld; } set { Settings.Default.LastSavedWorld = value; } }
        public string LastLoadedWorld { get { return Settings.Default.LastLoadedWorld; } set { Settings.Default.LastLoadedWorld = value; } }
        public string BuildDirectory { get { return AppDirectory + Settings.Default.BuildDirectory; } }
        public string RoomBuildDirectory { get { return AppDirectory + Settings.Default.RoomBuildDirectory; } }
        public string WorldBuildDirectory { get { return AppDirectory + Settings.Default.WorldBuildDirectory; } }
        public string ItemBuildDirectory { get { return AppDirectory + Settings.Default.ItemBuildDirectory; } }
        public string AreaBuildDirectory { get { return AppDirectory + Settings.Default.AreaBuildDirectory; } }
        public string ExitBuildDirectory { get { return AppDirectory + Settings.Default.ExitBuildDirectory; } }
        public string TemplateDirectory { get { return AppDirectory + Settings.Default.TemplateDirectory; } }
        public string WorldTemplateDirectory { get { return AppDirectory + Settings.Default.WorldTemplateDirectory; } }
        public string AreaTemplateDirectory { get { return AppDirectory + Settings.Default.AreaTemplateDirectory; } }
        public string RoomTemplateDirectory { get { return AppDirectory + Settings.Default.RoomTemplateDirectory; } }
        public string ExitTemplateDirectory { get { return AppDirectory + Settings.Default.ExitTemplateDirectory; } }
        public string ItemTemplateDirectory { get { return AppDirectory + Settings.Default.ItemTemplateDirectory; } }
        public MessageQueue SystemMessageQueue;

        public ApplicationSettings(MessageQueue systemQueue) {
            InitializeSettings();
            if (systemQueue != null) SystemMessageQueue = systemQueue;
            Logins = new List<Connection>();
            RegisteredUsers = new RegisteredUsers();
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
                            administrator = item.Element("Administrator").Value
                        };
            foreach (var user in users) {
                Account account = new Account();
                account.Name = user.name;
                account.Password = user.password;
                account.Email = user.email;
                account.Administrator = Convert.ToBoolean(user.administrator);
                RegisteredUsers.Add(account);
            }
        }

        public void SwapLoginForPlayer(Connection connection) {
            Players.Add(connection);
            Logins.Remove(connection);
            connection.StartPlayer();
        }

        public void InitializeSettings() {
            AppDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(BaseDirectory)) { Directory.CreateDirectory(BaseDirectory); }
            if (!Directory.Exists(BuildDirectory)) { Directory.CreateDirectory(BuildDirectory); }
            if (!Directory.Exists(RoomBuildDirectory)) { Directory.CreateDirectory(RoomBuildDirectory); }
            if (!Directory.Exists(WorldBuildDirectory)) { Directory.CreateDirectory(WorldBuildDirectory); }
            if (!Directory.Exists(AreaBuildDirectory)) { Directory.CreateDirectory(AreaBuildDirectory); }
            if (!Directory.Exists(ExitBuildDirectory)) { Directory.CreateDirectory(ExitBuildDirectory); }
            if (!Directory.Exists(TemplateDirectory)) { Directory.CreateDirectory(TemplateDirectory); }
            if (!Directory.Exists(WorldTemplateDirectory)) { Directory.CreateDirectory(WorldTemplateDirectory); }
            if (!Directory.Exists(AreaTemplateDirectory)) { Directory.CreateDirectory(AreaTemplateDirectory); }
            if (!Directory.Exists(RoomTemplateDirectory)) { Directory.CreateDirectory(RoomTemplateDirectory); }
            if (!Directory.Exists(ExitTemplateDirectory)) { Directory.CreateDirectory(ExitTemplateDirectory); }
            if (!Directory.Exists(ItemTemplateDirectory)) { Directory.CreateDirectory(ItemTemplateDirectory); }
            string file = BaseDirectory + "\\" + RegisteredUsersAccounts;
         //   if (!File.Exists(file)) {
                XmlHelper.ReCreateDefaultUserXmlFile(file, this);
          //  }
        }
    }

}

