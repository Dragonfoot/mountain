using System.Xml;
using System.ComponentModel;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;
using Mountain.classes.controls;

namespace Mountain.classes {

    [DefaultPropertyAttribute("DoorLabel")]
    public class Exit : Identity {
        [Browsable(false)]
        public Room Owner { get; set; }
        [Browsable(false)]
        public Room Room { get; set; }  // points to
        [Browsable(false)]
        public Area Area;               // room it points to is in
        [CategoryAttribute("\t Exit Settings"), Description("Name the player will see as the exit to leave from.")]
        public string DoorLabel { get; set; }
        [Category("\t Exit Settings"), Description("Can the player normally see the exit.")]
        public bool Visible { get; set; }
        [Category("\t Exit Settings"), Description("Is the door something that can be broken down.")]
        public bool Breakable { get; set; }
        [Category("\t Exit Settings"), Description("What type of physical exit is this.")]
        public exitType ExitType { get; set; }
        [Category("Exit Attributes"), Description("What lock type, if any, does it use.")]
        [Editor(typeof(FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public lockType LockType { get; set; }
        [Category("Exit Attributes"), Description("What type of door, if any, this is.")]
        [Editor(typeof(FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public doorType DoorType { get; set; }
        [Category("Exit Attributes"), Description("Player restrictions to access this exit.")]
        [Editor(typeof(FlagsEnumEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public exitRestrictions Restrictions { get; set; }  //http://geekswithblogs.net/BlackRabbitCoder/archive/2010/07/22/c-fundamentals-combining-enum-values-with-bit-flags.aspx
        private string roomName, areaName;

        public Exit() {
            ClassType = classObjectType.exit;
            Name = null;
            Visible = true;
            ExitType = exitType.door;
            LockType = lockType.key | lockType.pickable;
            DoorType = doorType.locking;
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