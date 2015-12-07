using System;
using System.Xml;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;
using Mountain.classes.Items;
using Mountain.classes.mobs;
using Mountain.classes.collections;
using Mountain.classes.tcp;

namespace Mountain.classes {
    
    public class Room : Identity {
        public ConcurrentBag<Mob> Mobs { get; set; }
        public ConcurrentBag<Item> Items { get; set; }
        public Players Players { get; set; }
        public PlayerEventQueue Messages;
        public string shortDescription { get; set; }
        public Area Area;
        public roomType roomType { get; set; }
        public roomRestrictions roomRestrictons { get; set; }
        public roomConditions roomConditions { get; set; }
        public string Tag { get; set; }
        public List<Exit> Exits { get; set; }

        public Room(Area area) {
            InitializeRoom();
            Name = "New Room";
            Description = "This is a newly created room";
            Area = area;
        }
        public Room(string name, Area area) {
            InitializeRoom();
            Name = name;
            Description = Name + " is a newly created room";
            Area = area;
        }
        public Room(string name, string description, Area area) {
            InitializeRoom();
            Name = name;
            Description = description;
            Area = area;
        }
        public Room() {
        }

        public override string ToString() {
            return Name;
        }

        private void InitializeRoom() {
            ClassType = classObjectType.room;
            Exits = new List<Exit>();
            Players = new Players();
            Mobs = new ConcurrentBag<Mob>();
            Items = new ConcurrentBag<Item>();
            Messages = new PlayerEventQueue();            
            Messages.OnEventReceived += Messages_OnPlayerEventReceived;
            Players.OnPlayerAdded += Players_OnPlayerAdded;
            Players.OnPlayerRemoved += Players_OnPlayerRemoved;
        }

        private void Players_OnPlayerAdded(object myObject, Connection player, string message = "") {
            string name = player.Name;
            if (message == "") message = " just arrived.";
            foreach (Connection client in Players) {
                if (client != player) client.Send(player.Name.Ansi(Style.white) + message.Ansi(Style.white).NewLine());
                else SendCommand(player, "look");
            }
        }

        private void Players_OnPlayerRemoved(object myObject, Connection player, string message = "") {
            foreach (Connection Player in Players) {
                Player.Send(player.Name.Ansi(Style.white) + " goes to the " + message + ".".NewLine());
            }
        }

        private void SendCommand(Connection player, string command) {
            Task HandleMessage = new Task(() => player.Commands(player, command));
            HandleMessage.Start();
        }

        public string GetName() { return Name; }
        public string GetDesciption() { return Description; }
        public string GetExits() { return FUNC.GetNames(Exits.ToArray()); }
        public string GetMobs() { return FUNC.GetNames(Mobs.ToArray()); }
        public string GetPlayers() { return FUNC.GetNames(Players.ToArray()); }
        public string GetOtherPlayers(string name) { return FUNC.GetOtherNames(Players.ToArray(), name); }
        public string GetItems() { return FUNC.GetNames(Items.ToArray()); }

        private void Messages_OnPlayerEventReceived(object myObject, Packet packet) {
            Packet message = Messages.Pop(); 
            if (message == null) message = packet;
            GBL.Settings.SystemMessageQueue.Push("Room received: " + message);
        }        
        
        public void HeartBeat() {
            throw new NotImplementedException("Room beat");
        }

        public void AddExit(Exit exit) {
            exit.Owner = this;
            if (exit.Name == null) exit.Name = exit.DoorLabel;
            Exits.Add(exit);
        }

        public void CreateExit() {
            Exit exit = new Exit();
            exit.Name = this.Name + " Exit";
            exit.Description = Name + " exit is not yet linked to another room";
            exit.DoorLabel = Name + " Exit (unassigned)";
            exit.Open = false;
            exit.DoorType = doorType.none;
            AddExit(exit);
        }

        public void AddMob(Mob mob) {
            Mobs.Add(mob);
            // a mob just arrived...
        }

        public void AddPlayer(Connection player) {
            Players.Add(player);
            player.Room = this;
        }

        public void RemovePlayer(Connection player, string message) {
            Players.Remove(player.Name, message);
        }

        public XmlTextWriter SaveXml(XmlTextWriter writer) {
            writer.WriteStartElement("Room");
            XML.createNode("Name", Name, writer);
            XML.createNode("Description", Description, writer);
            XML.createNode("ShortDescription", shortDescription, writer);
            XML.createNode("Tag", Tag, writer);
            XML.createNode("AreaName", Area.Name, writer);
            XML.createNode("RoomName", Name, writer);
            if(Exits.Count > 0) {
                writer.WriteStartElement("Exits");
                foreach(Exit exit in Exits) {
                    writer = exit.SaveXml(writer);
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            return writer;
        }

        public void LoadXml(XmlNode node) {
            Name = node["Name"].InnerText;
            Description = node["Description"].InnerText;
            shortDescription = node["ShortDescription"].InnerText;
            Tag = node["Tag"].InnerText;
            string areaName = node["AreaName"].InnerText;
            XmlNodeList exits = node["Exits"].SelectNodes("Exit");
            foreach (XmlNode exit in exits) {
                Exit newExit = new Exit();
                newExit.LoadXml(exit);
                Exits.Add(newExit);
            }
            // read in exits...
        }

        public string[] View() {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> view = new List<string>();
            view.Add(Name);
            view.Add("");
            view.Add(Description);
            view.Add("");
            if (Exits.Any()) { // add color coding's
                stringBuilder.Append("Exits: " + FUNC.GetNames(Exits.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Mobs.Any()) {
                stringBuilder.Append("Mobs: " + FUNC.GetNames(Mobs.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Players.Any()) {
                stringBuilder.Append("Players: " + FUNC.GetNames(Players.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Items.Any()) {
                // items on floor; need to search for duplicates, pronouns, etc., and display them in friendly grammar form
                // You see (an) orange, 23 pumpkin seed(s), (a) hungry cat, Toetag('s) nose.
            }
            return view.ToArray();
        }   
             
        protected void Save() {
            throw new NotImplementedException("Room save");
        }

        protected void Load() {
            throw new NotImplementedException("Room load");
        }

        public Room ShallowCopy() {
            Room roomCopy = (Room) MemberwiseClone();
            Array exitsCopy = Exits.ToArray();
            roomCopy.Exits.Clear();
            if (exitsCopy.Length > 0) foreach(Exit exitCopy in exitsCopy) roomCopy.Exits.Add(exitCopy.ShallowCopy());
            return roomCopy;
        }
    }
}
