using System;
using System.Xml;
using System.Xml.Serialization;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;

namespace Mountain.classes {

    [Serializable] public class Exit : Identity {
        [XmlIgnore] public Room Owner { get; set; }
        [XmlIgnore] public Room Link { get; set; }
        [XmlIgnore] public Area LinkArea;
        public Location Linkage {
            get { return new Location(Owner); }
            set {
                if (value.Room != null) {
                    LinkArea = value.Room.Location.Area;
                    Link = value.Room;
                }
            }
        }
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
            Linkage = new Location();
            ClassType = classObjectType.exit;
            Name = null;
        }

        public Exit ShallowCopy() {
            Exit other = (Exit)MemberwiseClone();
            return other;
        }

        public override string ToString() {
            return Name;
        }

        public void Update(ExitData data) {
            Name = data.Name;
            Description = data.Description;
            Link = data.Linkage.Room;
            LinkArea = data.Linkage.Area;
            if(data.ID.HasValue) ID = (Guid)data.ID;
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
            Xml.createNode("Name", Name, writer);
            Xml.createNode("Description", Description, writer);
            Xml.createNode("DoorLabel", DoorLabel, writer);
            writer = Linkage.SaveXml(writer);
            writer.WriteEndElement();
            return writer;
        }
    }
}