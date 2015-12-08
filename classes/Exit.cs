using System.Xml;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;

namespace Mountain.classes {

    public class Exit : Identity {
        public Room Owner { get; set; }
        public Room Room { get; set; }  // points to
        public Area Area;               // room it points to is in
        public string DoorLabel { get; set; }
        public bool Open;
        public bool Lockable;
        public bool Visible;
        public bool Pickable;
        public bool Breakable;
        public bool Repairable;
        public exitType ExitType; 
        public lockType LockType;
        public doorType DoorType;
        public exitRestrictions Restrictions;  //http://geekswithblogs.net/BlackRabbitCoder/archive/2010/07/22/c-fundamentals-combining-enum-values-with-bit-flags.aspx
        private string roomName, areaName;
        public Exit() {
            ClassType = classObjectType.exit;
            Name = null;
        }

        public Exit ShallowCopy() {
            Exit other = (Exit) MemberwiseClone();
            return other;
        }

        public override string ToString() {
            return DoorLabel;
        }

        public XmlTextWriter SaveXml(XmlTextWriter writer) {
            writer.WriteStartElement("Exit");
            XML.createNode("Name", Name, writer);
            XML.createNode("Description", Description, writer);
            XML.createNode("DoorLabel", DoorLabel, writer);
            XML.createNode("Room", Room.Name, writer);
            XML.createNode("Area", Area.Name, writer);
            writer.WriteEndElement();
            return writer;
        }

        public void LoadXml(XmlNode node, Room room) {
            Owner = room;
            Area = room.Area;
            Name = node["Name"].InnerText;
            Description = node["Description"].InnerText;
            DoorLabel = node["DoorLabel"].InnerText;
            roomName = node["Room"].InnerText;
            areaName = node["Area"].InnerText;
        }

        public void Validate() {
            Area = Common.Settings.World.GetAreaByName(areaName);
            Room = Common.Settings.World.GetRoomByName(roomName);
        }
    }
}