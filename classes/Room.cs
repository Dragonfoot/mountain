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
    
    public class Room : Identity, IDisposable {
        public ConcurrentBag<Mob> Mobs { get; set; }
        public ConcurrentBag<Item> Items { get; set; }
        public PlayerEventQueue Messages;
        public List<Exit> Exits { get; set; }
        public Players Players { get; set; }
        public Area Area { get; set; }
        public roomType roomType { get; set; }
        public roomRestrictions roomRestrictons { get; set; }
        public roomConditions roomConditions { get; set; }
        public string shortDescription { get; set; }
        public string Tag { get; set; }

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
            InitializeRoom();
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
        public string GetExits() { return Function.GetNames(Exits.ToArray()); }
        public string GetMobs() { return Function.GetNames(Mobs.ToArray()); }
        public string GetPlayers() { return Function.GetNames(Players.ToArray()); }
        public string GetOtherPlayers(string name) { return Function.GetOtherNames(Players.ToArray(), name); }
        public string GetItems() { return Function.GetNames(Items.ToArray()); }

        private void Messages_OnPlayerEventReceived(object myObject, Packet packet) {
            Packet message = Messages.Pop(); 
            if (message == null) message = packet;
            Common.Settings.SystemMessageQueue.Push("Room received: " + message);
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
            Exit exit = new Exit() {
                Name = this.Name + " Exit",
                Description = Name + " exit is not yet linked to another room",
                DoorLabel = Name + " Exit (unassigned)",
                DoorType = doorType.none
            };
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

        public void LoadXml(XmlNode node, Area area) {
            Name = node["Name"].InnerText;
            Description = node["Description"].InnerText;
            shortDescription = node["ShortDescription"].InnerText;
            Tag = node["Tag"].InnerText;
            Area = area;
            var exitsNode = node.SelectSingleNode("Exits");
            if (exitsNode != null) {
                XmlNodeList exits = node["Exits"].SelectNodes("Exit");
                foreach (XmlNode exit in exits) {
                    Exit newExit = new Exit();
                    newExit.LoadXml(exit, this);
                    Exits.Add(newExit);
                }
            }
        }

        public string[] View() {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> view = new List<string>();
            view.Add(Name);
            view.Add("");
            view.Add(Description);
            view.Add("");
            if (Exits.Any()) {
                stringBuilder.Append("Exits: " + Function.GetNames(Exits.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Mobs.Any()) {
                stringBuilder.Append("Mobs: " + Function.GetNames(Mobs.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Players.Any()) {
                stringBuilder.Append("Players: " + Function.GetNames(Players.ToArray()));
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

        public void Dispose() {
            Messages.OnEventReceived -= Messages_OnPlayerEventReceived;
            Players.OnPlayerAdded -= Players_OnPlayerAdded;
            Players.OnPlayerRemoved -= Players_OnPlayerRemoved;
        }
    }
}
