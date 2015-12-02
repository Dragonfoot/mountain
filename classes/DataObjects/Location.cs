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
        public string DoorLabel { get; set; }

        public Location(string doorLabel, Room room)  {
            if (room.Location != null) Area = room.Location.Area;
            Room = room;
            DoorLabel = doorLabel;
        }

        public Location ShallowCopy() {
            return (Location)MemberwiseClone();
        }

        public Location() {
        }

        public XmlTextWriter SaveXml(XmlTextWriter writer) {
            writer.WriteStartElement("Location");
            XmlHelper.createNode("AreaName", AreaName, writer);
            XmlHelper.createNode("RoomName", RoomName, writer);
            XmlHelper.createNode("DoorLabel", DoorLabel, writer);
            writer.WriteEndElement();
            return writer;
        }
    }
}
