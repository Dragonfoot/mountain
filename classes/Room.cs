using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mountain.classes.helpers;
using Mountain.classes.Items;

namespace Mountain.classes {

    public class Room : Identity {
        [XmlIgnore]
        public ConcurrentBag<Mob> Mobs { get; set; }
        [XmlIgnore]
        public ConcurrentBag<Item> Items { get; set; }
        [XmlIgnore]
        public List<Player> Players { get; set; }
        [XmlIgnore]
        public RoomID RoomID;
        [XmlArray("Exits")]
        public List<Exit> Exits { get; set; }
        protected GeneralEventQueue Events;
        [XmlIgnore]
        public PlayerEventQueue Messages;

        public Room() {
            InitializeRoom();
            Name = "New Room";
            Description = "This is a newly created room";
            RoomID = new RoomID(ID, Name);
        }
        public Room(string name) {
            InitializeRoom();
            RoomID = new RoomID(ID, Name);
            SetName(name);
            Description = Name + " is a newly created room";
        }
        public Room(string name, string description) {
            InitializeRoom();
            RoomID = new RoomID(ID, name);
            SetName(name);
            Description = description;
        }
        public void SetName(string name) {
            Name = name;
            this.RoomID.Name = name;
        }

        private void InitializeRoom() {
            ClassType = classType.room;
            Exits = new List<Exit>();
            Players = new List<Player>();
            Mobs = new ConcurrentBag<Mob>();
            Items = new ConcurrentBag<Item>();
            Events = new GeneralEventQueue();
            Messages = new PlayerEventQueue();
            Messages.OnEventReceived += Messages_OnPlayerEventReceived;
        }

        private void Messages_OnPlayerEventReceived(object myObject, PlayerEventPacket packet) {
            Packet message = Messages.Pop(); 
            if (message == null) message = packet;
            switch (packet.verb) {
                case "say":
                    if (!packet.parameter.HasLastCharPunctuation()) { packet.parameter += "."; }
                    foreach (Player player in Players) {
                        if (player.Name == packet.player.Name) {
                            player.Send("You say, \"" + packet.parameter + "\"".NewLine().Color(Ansi.white), true);
                        }
                        else {
                            player.Send(packet.player.Name + " says, \"" + packet.parameter + "\"".NewLine().Color(Ansi.white), true);
                        }
                    }
                    break;
            }
        }        
        
        public void HeartBeat() {
            throw new NotImplementedException("Room beat");
        }

        public void AddExit(Exit exit) {
            this.Exits.Add(exit);
        }
        public void AddMob(Mob mob) {
            this.Mobs.Add(mob);
        }
        public void AddPlayer(Player player) {
            this.Players.Add(player);
            player.RoomID = RoomID;
        }

        public string SaveXML() { 
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(Room));
            TextWriter writer = new StringWriter();
            try {
                serializer.Serialize(writer, this, emptyNamepsaces);
            } catch (Exception e) {
                return e.ToString();
            }             
            return writer.ToString();
        }

        public string[] View() {
            StringBuilder stringBuilder = new StringBuilder();
            List<string> view = new List<string>();
            view.Add(Name);
            view.Add("");
            view.Add(Description);
            view.Add("");
            if (Exits.Count > 0) { // add color coding's
                stringBuilder.Append("Exits: " + Functions.GetNames(Exits.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Mobs.Count > 0) {
                stringBuilder.Append("Mobs: " + Functions.GetNames(Mobs.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Players.Count > 0) {
                stringBuilder.Append("Players: " + Functions.GetNames(Players.ToArray()));
                view.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            if (Items.Count > 0) {
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

        public void Show(Player player) {

        }
        
    }
}
