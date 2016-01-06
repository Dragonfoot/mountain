using System;
using System.Xml;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.tcp;
using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes {

    public class World : Identity, IDisposable {
        public List<Area> Areas;
        public int Connections { get; private set; }
        public TcpServerListener portListener;
        public int Port;
        private CancellationTokenSource cancellationTokenSource;
        protected ListBox Console;

        public World() {
            InitializeSettings();
      /*      portListener.StartServer(Port);
            string lastworld = Global.Settings.LastSavedWorld;
            if (lastworld.IsNullOrWhiteSpace()) Load(null);
            else Load(null); */          
         //   StartHeart(); // activate world
        }        

        private void InitializeSettings() {
            ClassType = classObjectType.world;
            Common.Settings.Players.OnPlayerAdded += Players_OnPlayerAdded;
            Common.Settings.Players.OnPlayerRemoved += Players_OnPlayerRemoved;
            portListener = new TcpServerListener(this);
            Port = 8090;
            Areas = new List<Area>();
            Name = "Mountain";
            Description = "This world has been created by the Toetag Corporate Funding Group for your life's passionate pleasures. " +
                "Keep your new world growing with us. \r\n" +
                "Invest in Toetag Corporation's Life Insurance Policies and help make our gaming addition goals a viable solution. " +
                "Become a gold member of our growing centers of excellence, do the right thing, " +
                "donate your soul to our world class gaming society's Center of Excellence. You could win big!\r\n" +
                "Join today. (Please sign our body donor card and be entered in our annual Grisly Corpse Competition Awards ceremony. " +
                "You could win a place on the top shelf of our Achievements of Horror vault that houses the very best souls of our society's " +
                "most fascinating players.)\r\n";
            Areas.Add(Build.CreateAdminSection());
        }

        public void StartAcceptingConnections(int port = 8090) {
            portListener.StartServer(port);
        }

        void Players_OnPlayerRemoved(object myObject, Connection player, string message = "") {
           // throw new NotImplementedException("Player removed");
        }

        void Players_OnPlayerAdded(object myObject, Connection player, string message = "") {
           // throw new NotImplementedException("Player added");
        }      

        public void Shutdown() {
            Common.Settings.Players.Shutdown();
            StopHeart();
            portListener.StopServer();
        }

        public void Load(string world) { 
            if (!world.IsNullOrWhiteSpace()) {
            } else {
            }
        }
        
        public void Save(string filename) {
            throw new NotImplementedException("World Save");
        }

        public void SaveXml(string filename) {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            XmlTextWriter writer = new XmlTextWriter(path + filename, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Mountain");
            XML.createNode("World", Name, writer);
            XML.createNode("Description", Description, writer);
            XML.createNode("Port", Port.ToString(), writer);
            if (Areas.Count > 0) {
                writer.WriteStartElement("Areas");
                foreach (Area area in Areas) {
                    writer = area.SaveXml(writer);
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public void LoadXml(string filename) {
            if (Areas.Count > 0) Areas.Clear();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            XmlDocument doc = new XmlDocument();
            doc.Load(path + filename);
            XmlNode root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("Areas");
            foreach (XmlNode node in nodes) {
                Area newArea = new Area();
                newArea.LoadXml(node);
                Areas.Add(newArea);
            }
            foreach(Area area in Areas) {
                foreach(Room room in area.Rooms) {
                    foreach(Exit exit in room.Exits) {
                        exit.Validate();
                    }
                }
            }
        }

        private void StartHeart() {
            cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;
            foreach (Area area in Areas) {
                area.StartHeart();
            }
            var task = Task.Factory.StartNew(() => {
                while (true) {
                    cancellationToken.ThrowIfCancellationRequested();
                    // event ticks, 
                    // schedule checks, 
                    // update time,
                    // update weather.. 
                }
            }, cancellationToken);
            foreach (Area area in Areas) {
                area.StopHeart();
            }           
        }

        private void StopHeart() {
            if (cancellationTokenSource != null) {
                cancellationTokenSource.Cancel();
            }
        }

        public Area AreaByName(string name) {
            foreach(Area area in Areas) {
                if (area.Name == name) return area;
            }
            return null;
        }

        public Room RoomByName(string name) {
            foreach (Area area in Areas) {
                foreach (Room room in area.Rooms) {
                    if (room.Name == name) return room;                    
                }
            }
            return null;
        }

        public string AreaNameByRoomName(string name) {
            Room room = RoomByName(name);
            if (room == null) return null;
            return room.Area.Name;
        }

        public void Dispose() {
            Common.Settings.Players.OnPlayerAdded -= Players_OnPlayerAdded;
            Common.Settings.Players.OnPlayerRemoved -= Players_OnPlayerRemoved;
        }
    }
}

