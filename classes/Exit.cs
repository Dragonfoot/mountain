using System;
using System.Xml;
using System.Xml.Serialization;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;

namespace Mountain.classes {

    [Serializable] public class Exit : Identity {
        [XmlIgnore] public Room Owner { get; set; }
        [XmlIgnore] public Room Room { get; set; }
        [XmlIgnore] public Area Area;
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
        
        public Exit() {
            ClassType = classObjectType.exit;
            Name = null;
        }

        public Exit ShallowCopy() {
            Exit other = (Exit)MemberwiseClone();
            return other;
        }

        public override string ToString() {
            return DoorLabel;
        }

        public void Update(ExitData data) {
            Name = data.Name;
            Description = data.Description;
            Room = data.Room;
            Area = data.Area;
            if(data.DoorType.HasValue) DoorType = (doorType)data.DoorType;
            if(data.LockType.HasValue) LockType = (lockType)data.LockType;
            if(data.Restrictions.HasValue) Restrictions = (exitRestrictions)data.Restrictions;
            if(data.ExitType.HasValue) ExitType = (exitType)data.ExitType;
            if(data.Open.HasValue) Open = (bool)data.Open;
            if(data.Lockable.HasValue) Lockable = (bool)data.Lockable;
            if(data.Visible.HasValue) Visible = (bool)data.Visible;
            if(data.Pickable.HasValue) Pickable = (bool)data.Pickable;
            if(data.Breakable.HasValue) Breakable = (bool)data.Breakable;
            if(data.Repairable.HasValue) Repairable = (bool)data.Repairable;
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
    }
}