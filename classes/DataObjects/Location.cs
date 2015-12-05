using System;
using System.Xml;
using System.Xml.Serialization;
using Mountain.classes.functions;

namespace Mountain.classes.dataobjects {

    [Serializable] public class Location {
        [XmlIgnore] public Area Area { get; set; }
        [XmlIgnore] public Room Room { get; set; }
        public string AreaName { get { return Area.Name; } }
        public string RoomName { get { return Room.Name; } }

        public Location(Room room)  {
            if (room == null) room = Glb.Settings.TheVoid;
            if (room.Location != null) Area = room.Location.Area;
            Room = room;
        }

        public Location ShallowCopy() {
            return (Location)MemberwiseClone();
        }

        public Location() {
        }

        public XmlTextWriter SaveXml(XmlTextWriter writer) {
            writer.WriteStartElement("Location");
            Xml.createNode("AreaName", AreaName, writer);
            Xml.createNode("RoomName", RoomName, writer);
            writer.WriteEndElement();
            return writer;
        }
    }
}
