using System;
using System.Xml;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;
using Mountain.classes.collections;

namespace Mountain.classes {

    [Serializable][XmlRoot] public class Area : Identity {
        [XmlArray("Rooms")] public Rooms Rooms { get; private set; }
        [XmlIgnore] public bool Active { get; set; } 
        private CancellationTokenSource cancellationTokenSource;

        public Area() {
            ClassType = classObjectType.area;
            Name = "new area";
            Description = "new area";
            Active = true;
            cancellationTokenSource = new CancellationTokenSource();
            Rooms = new Rooms(this);
        }

        public Area(string name, string description) {
            Name = name;
            Description = description;
        }

        public void AddRoom(Room room) {
            room.Area = this;
            Rooms.Add(room);
        }

        public override string ToString() {
            return Name;
        }

        public void Load(string filename) {
            throw new NotImplementedException("Area Load (filename)");
        }

        public void Load() {
            throw new NotImplementedException("Area Load ()");
        }

        public void Save(string filename) {
            throw new NotImplementedException("Area Save(filename)");
        }

        public XmlTextWriter SaveXml(XmlTextWriter writer) {
            writer.WriteStartElement("Area");
            XML.createNode("Name", Name, writer);
            XML.createNode("Description", Description, writer);
            if (Rooms.Count > 0) {
                writer.WriteStartElement("Rooms");
                foreach (Room room in Rooms) {
                    writer = room.SaveXml(writer);
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            return writer;
        }

        public void LoadXml(XmlNode node) {

        }

        public void StopHeart() {
            cancellationTokenSource.Cancel(); // stop heartbeat
        }

        public void StartHeart() {
            cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = this.cancellationTokenSource.Token;
            var task = Task.Factory.StartNew(() => {
                while (true) {
                    cancellationToken.ThrowIfCancellationRequested();
                    foreach (Room room in Rooms) {
                        room.HeartBeat();
                    } 
                    // do schedule checks, 
                    // update time,
                    // other stuff
                }
            }, cancellationToken);
        }
    }

}
