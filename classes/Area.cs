using System;
using System.Xml;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;
using Mountain.classes.collections;

namespace Mountain.classes {

    public class Area : Identity {
        public Rooms Rooms { get; private set; }
        public areaType Type { get; set; }
        public MapSettings MapSettings { get; set; }
        public AreaSettings Settings;
        private CancellationTokenSource cancellationTokenSource;

        public Area() {
            ClassType = classObjectType.area;
            Rooms = new Rooms(this);
            if (Common.Settings.World != null) {
                MapSettings = new MapSettings(Common.Settings.World.Areas.Count);
            }else {
                MapSettings = new MapSettings(0);
            }
            Name = "new area";
            Description = "new area";
            Settings = new AreaSettings();
            cancellationTokenSource = new CancellationTokenSource();
        }

        public Area(string name, string description) {
            Rooms = new Rooms(this);
            MapSettings = new MapSettings(Common.Settings.World.Areas.Count);
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
            throw new NotImplementedException("Area Load (xml filename)");
        }

        public void Save(string filename) {
            throw new NotImplementedException("Area Save(xml filename)");
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
            Name = node.FirstChild["Name"].InnerText;
            Description = node.FirstChild["Description"].InnerText;
            XmlNodeList rooms = node.FirstChild["Rooms"].SelectNodes("Room");
            foreach(XmlNode room in rooms) {
                Room newRoom = new Room();
                newRoom.LoadXml(room, this);
                Rooms.Add(newRoom);
            }
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

    public class AreaSettings {
        public areaRestrictions Restrictions { get; set; }
        public bool Active { get; set; }

        public AreaSettings() {
            Restrictions = new areaRestrictions();
            Restrictions = areaRestrictions.skillLevel | areaRestrictions.classOf;
            Restrictions.Add(areaRestrictions.skillLevel);
            Active = false;
        }
        public XmlTextWriter SaveXml(XmlTextWriter writer) {
            writer.WriteStartElement("Settings");
            XML.createNode("Active", Active.ToString(), writer);

            writer.WriteStartElement("Restrictions");
            writer.WriteEndElement();
            
            writer.WriteEndElement();
            return writer;
        }
    }


}
