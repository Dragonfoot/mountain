using System;
using System.Xml;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.tcp;
using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes {

    [Serializable] public class World : Identity {
        public int Port;
        [XmlArray("Areas")] public List<Area> Areas;
        [XmlIgnore] public TcpServerListener portListener;
        [XmlIgnore] public int Connections { get; private set; }
   //     [XmlIgnore] public Area Administration;
        protected ListBox Console;
        private CancellationTokenSource cancellationTokenSource;

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
            GBL.Settings.Players.OnPlayerAdded += Players_OnPlayerAdded;
            GBL.Settings.Players.OnPlayerRemoved += Players_OnPlayerRemoved;
            portListener = new TcpServerListener(this);
            Port = 8090;
            Areas = new List<Area>();
            CreateAdminSection();
        }

        public void AcceptConnections(int port = 8090) {
            portListener.StartServer(port);
        }

        void Players_OnPlayerRemoved(object myObject, Connection player, string message = "") {
           // throw new NotImplementedException("Player removed");
        }

        void Players_OnPlayerAdded(object myObject, Connection player, string message = "") {
           // throw new NotImplementedException("Player added");
        }

        public void Reload() {
          //  throw new NotImplementedException("World Reload");
        }

        public void Clear() {
           // throw new NotImplementedException("World Clear");
        }

        public void Shutdown() {
            GBL.Settings.Players.Shutdown();
            StopHeart();
            portListener.StopServer();
        }

        public void Load(string world) { 
            if (!world.IsNullOrWhiteSpace()) {
            } else {
            }
        }

        public void CreateAdminSection() {
            Name = "Mountain";
            Description = "This world has been created by the Toetag Corporate Funding Group for your life's passionate pleasures. " +
                "Keep your new world growing with us. \r\n" +
                "Invest in Toetag Corporation's Life Insurance Policies and help make our gaming addition goals a viable solution. " +
                "Become a gold member of our growing centers of excellence, do the right thing, " +
                "donate your soul to our world class gaming society's Center of Excellence. You could win big!\r\n" +
                "Join today. (Please sign our body donor card and be entered in our annual Grisly Corpse Competition Awards ceremony. " +
                "You could win a place on the top shelf of our Achievements of Horror vault that houses the very best souls of our society's " +
                "most fascinating players.)\r\n";

            Area Administration = new Area();
            Administration.Name = "Administration Complex";
            Administration.Description = "One of this worlds most extraordinary wonders. Top minds from all the major centers reside here. " +
               "Houses the most advanced technological and military equipment available rivaling even Mount Cascade Fortress on " +
               "Tavastazia's bloodless moon.";

            Room control;
            string name = "Control Center";
            string description = "You see the nerve center of world operations unfold around you. Computer stations line most of the walks with white clad technicians " +
                "murmuring with headsets, adjusting controls, issuing quiet command. Sensor arrays, blinking routing screens, schedulers dimly glowing " +
                "above them, monitoring every aspect of this worlds events and activities. Off to your left, a long line of office doors, " +
                "uniformed guards challenging, filtering, and recording the movement of staff and visitors alike.";

            control = Build.NewRoom(name, description, Administration);
            control.Tag = "Administration";
            control.roomType = roomType.admin | roomType.healing;
            control.roomRestrictons = roomRestrictions.fighting | roomRestrictions.taunting;
            control.roomConditions = roomConditions.magic | roomConditions.lawful;

            Room transit; 
            name = "Transit Hub";
            description = "Administration Transit Hub Main Entrance";

            transit = Build.NewRoom(name, description, Administration);
            transit.Tag = "Administration";
            transit.roomType = roomType.path | roomType.shop | roomType.leveling;
            transit.roomRestrictons = roomRestrictions.magic | roomRestrictions.mindpower | roomRestrictions.fighting;
            transit.roomConditions = roomConditions.magic;

            Room Void;
            name = "The Void";
            description = "You find yourself weightlessly floating in some kind of silent, lonely, dark, " +
                "endless, - and as many other voidy spacy words there might be.. - space.";
            Void = Build.NewRoom(name, description, Administration);
            GBL.Settings.TheVoid = Void;
            Void.Tag = "Void";
            Void.roomType = roomType.outdoor;
            Void.roomRestrictons = roomRestrictions.fighting | roomRestrictions.magic | roomRestrictions.mindpower | roomRestrictions.stealing;

            Build.LinkTwoRooms(Void, transit);
            Build.LinkTwoRooms(transit, control);
            Build.LinkTwoRooms(control, Void);

            Administration.Rooms.Add(control);
            Administration.Rooms.Add(Void);
            Administration.Rooms.Add(transit);
            Areas.Add(Administration);
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
            writer.WriteStartElement("World");
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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            XmlDocument doc = new XmlDocument();
            doc.Load(path + filename);
            XmlNode root = doc.DocumentElement;
            // parse through..
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

        public Room GetRoomByName(string name) {
            foreach (Area area in Areas) {
                foreach (Room room in area.Rooms) {
                    if (room.Name == name) return room;                    
                }
            }
            return null;
        }

        public string GetAreaNameByRoomName(string name) {
            Room room = GetRoomByName(name);
            if (room == null) return null;
            return room.Area.Name;
        }
    }
}

