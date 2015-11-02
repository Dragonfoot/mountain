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
        public List<Mob> Mobs { get; set; }
        [XmlIgnore]
        public ConcurrentBag<Item> Items { get; set; }
        public List<Exit> Exits { get; set; }
        [XmlIgnore]
        public List<Player> Players { get; set; }

        protected ConcurrentQueue<Packet> events;
        protected ConcurrentQueue<Packet> msgs;
        protected ConcurrentQueue<Packet> innerQueue;

        public Room() {
            base.ClassType = classType.room;
            this.Exits = new List<Exit>();
            this.Players = new List<Player>();
            this.Mobs = new List<Mob>();
            this.Items = new ConcurrentBag<Item>();
            this.events = new ConcurrentQueue<Packet>();
            this.msgs = new ConcurrentQueue<Packet>();
            this.innerQueue = new ConcurrentQueue<Packet>();
            this.ID = Guid.NewGuid();
            this.Name = "New Room";
            this.Description = "This is a newly created room";
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
        
        public void AddExit(Exit exit) {
            this.Exits.Add(exit);
        }
        public void AddMob(Mob mob) {
            this.Mobs.Add(mob);
        }
        public void AddPlayer(Player player) {
            this.Players.Add(player);
        }

        public string SaveXML() { // only public properties are serialized, use [XmlIgnore] attributes before any not required
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
        /*        
        private string viewXml(object item) {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(item.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings)) {
                serializer.Serialize(writer, item, emptyNamepsaces);
                return stream.ToString();
            }
        }
        protected bool Save() {
            return false;
        }
        protected bool Load() {
            return false;
        }
        protected Packet PopQueue() {
            return new Packet(this, packetType.data, new DataPacket());
        }
        protected void PushQueue(Packet p) {
        }
        */
    }
}
