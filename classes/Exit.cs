using System;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
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
            Name = "Exit";
            Visible = true;
            ExitType = exitType.door;
            LockType = lockType.key | lockType.pickable;
            DoorType = doorType.locking;
        }

        public Exit ShallowCopy() {
            return (Exit) MemberwiseClone();
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
            XML.createNode("Visible", Convert.ToString(Visible), writer);
            XML.createNode("Breakable", Convert.ToString(Breakable), writer);
            XML.createNode("ExitType", Enum.GetName(typeof(exitType), ExitType), writer);
            List<string> locks = getLockTypeFlags(LockType);
            if (locks.Count > 0) {
                writer.WriteStartElement("Lock");
                foreach (string name in locks) {
                    XML.createNode("LockType", name, writer);
                }
                writer.WriteEndElement();
            }
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
            Visible = Convert.ToBoolean(node["Visible"].InnerText);
            Breakable = Convert.ToBoolean(node["Breakable"].InnerText);
            ExitType = (exitType)Enum.Parse(typeof(exitType), node["ExitType"].InnerText);
            var lockNode = node.SelectSingleNode("Lock");
            if (lockNode != null) {
                LockType = new lockType();
                XmlNodeList locks = node["Lock"].SelectNodes("LockType");
                foreach (XmlNode locktype in locks) {
                    LockType |= (lockType)Enum.Parse(typeof(lockType), locktype.InnerText);
                }
            }
        }

        public void Validate() {
            Area = Common.Settings.World.GetAreaByName(areaName);
            Room = Common.Settings.World.GetRoomByName(roomName);
        }

        private List<string> getLockTypeFlags(lockType value) {
            List<string> list = new List<string>();
            foreach(Enum locktype in Enum.GetValues(typeof(lockType))) {
                if (value.HasFlag(locktype)) {
                    list.Add(Enum.GetName(typeof(lockType), locktype));
                }
            }
            return list;
        }
    }
}