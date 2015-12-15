using System.Xml;
using System.ComponentModel;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;

namespace Mountain.classes {

    public class Exit : Identity {
        [Browsable(false)]
        public Room Owner { get; set; }
        [Browsable(false)]
        public Room Room { get; set; }  // points to
        [Browsable(false)]
        public Area Area;               // room it points to is in
        public string DoorLabel { get; set; }
        public bool Open { get; set; }
        public bool Lockable { get; set; }
        public bool Visible { get; set; }
        public bool Breakable { get; set; }
        public bool Repairable { get; set; }
        [Browsable(true)]
        public exitType ExitType { get; set; }
        public lockType LockType { get; set; }
        public doorType DoorType { get; set; }
        public exitRestrictions Restrictions { get; set; }  //http://geekswithblogs.net/BlackRabbitCoder/archive/2010/07/22/c-fundamentals-combining-enum-values-with-bit-flags.aspx
        private string roomName, areaName;

        public Exit() {
            ClassType = classObjectType.exit;
            Name = null;
            Visible = true;
            Open = true;
            ExitType = exitType.door;
            LockType = lockType.none;
            DoorType = doorType.open;
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