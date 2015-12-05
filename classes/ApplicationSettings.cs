using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using Mountain.Properties;
using Mountain.classes.collections;
using Mountain.classes.dataobjects;
using Mountain.classes.tcp;
using Mountain.classes.functions;

namespace Mountain.classes {

    [Serializable] public class ApplicationSettings {
        [XmlIgnore] public RegisteredUsers RegisteredUsers { get; set; }
        [XmlIgnore] public List<Connection> Logins { get; set; }
        [XmlIgnore] public World World;
        [XmlIgnore] public Players Players { get; set; }
        [XmlIgnore] public Room TheVoid { get; set; }
        [XmlIgnore] public string AppDirectory { get; private set; }
        [XmlIgnore] public string PlayersDirectory { get { return AppDirectory + Settings.Default.PlayersDirectory; } }
        [XmlIgnore] public string BaseDirectory { get { return AppDirectory + Settings.Default.WorldsDirectory; } }
        [XmlIgnore] public string RegisteredUsersAccounts { get { return Settings.Default.RegisteredAccounts; } }
        [XmlIgnore] public string LastSavedWorld { get { return Settings.Default.LastSavedWorld; } set { Settings.Default.LastSavedWorld = value; } }
        [XmlIgnore] public string LastLoadedWorld { get { return Settings.Default.LastLoadedWorld; } set { Settings.Default.LastLoadedWorld = value; } }
        [XmlIgnore] public string BuildDirectory { get { return AppDirectory + Settings.Default.BuildDirectory; } }
        [XmlIgnore] public string RoomBuildDirectory { get { return AppDirectory + Settings.Default.RoomBuildDirectory; } }
        [XmlIgnore] public string WorldBuildDirectory { get { return AppDirectory + Settings.Default.WorldBuildDirectory; } }
        [XmlIgnore] public string ItemBuildDirectory { get { return AppDirectory + Settings.Default.ItemBuildDirectory; } }
        [XmlIgnore] public string AreaBuildDirectory { get { return AppDirectory + Settings.Default.AreaBuildDirectory; } }
        [XmlIgnore] public string ExitBuildDirectory { get { return AppDirectory + Settings.Default.ExitBuildDirectory; } }
        [XmlIgnore] public string TemplateDirectory { get { return AppDirectory + Settings.Default.TemplateDirectory; } }
        [XmlIgnore] public string WorldTemplateDirectory { get { return AppDirectory + Settings.Default.WorldTemplateDirectory; } }
        [XmlIgnore] public string AreaTemplateDirectory { get { return AppDirectory + Settings.Default.AreaTemplateDirectory; } }
        [XmlIgnore] public string RoomTemplateDirectory { get { return AppDirectory + Settings.Default.RoomTemplateDirectory; } }
        [XmlIgnore] public string ExitTemplateDirectory { get { return AppDirectory + Settings.Default.ExitTemplateDirectory; } }
        [XmlIgnore] public string ItemTemplateDirectory { get { return AppDirectory + Settings.Default.ItemTemplateDirectory; } }
        [XmlIgnore] public MessageQueue SystemMessageQueue;
        [XmlIgnore] public SystemEventQueue SystemEventQueue;
        protected FCT factory;

        public ApplicationSettings(MessageQueue messageQueue, SystemEventQueue eventQueue) {
            InitializeSettings();
            factory = new FCT();
            SystemMessageQueue = messageQueue;
            SystemEventQueue = eventQueue;
            Logins = new List<Connection>();
            RegisteredUsers = new RegisteredUsers();
            Players = new Players();
            LoadRegistryAccounts();
        }

        private void LoadRegistryAccounts() {
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
            connection.Room = TheVoid;
            string file = PlayersDirectory + "\\" + connection.Name + "_test.xml";
            factory.LoadPlayerFromFile(connection, connection.Name, file);
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
            if (!Directory.Exists(PlayersDirectory)) { Directory.CreateDirectory(PlayersDirectory); }
            string file = BaseDirectory + "\\" + RegisteredUsersAccounts;
         //   if (!File.Exists(file)) {
                XML.ReCreateRegistryAccounts(file);
          //  }
        }
    }

}

