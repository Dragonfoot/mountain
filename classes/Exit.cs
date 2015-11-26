using System;
using System.Xml.Serialization;
using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes {

    public class Exit : Identity {
        [XmlIgnore] public Room parent { get; set; }
        [XmlIgnore] public Room link { get; set; }
        public LinkToID LinkID;
        public bool Open;
        public bool Lockable;
        public bool Visible;
        public bool Pickable;
        public bool Breakable;
        public bool Repairable;
        public exitType ExitType; 
        public lockType LockType;
        public doorType DoorType;
        public exitRestrictionType Restrictions;  //http://geekswithblogs.net/BlackRabbitCoder/archive/2010/07/22/c-fundamentals-combining-enum-values-with-bit-flags.aspx
        
        public Exit() {
            ClassType = classObjectType.exit;
            Name = null;
        }

        public void Update(ExitData data) {
            Name = data.Name;
            Description = data.Description;
            LinkID = data.LinkToRoomID;
            if(data.ID.HasValue) ID = (Guid)data.ID;
            if(data.DoorType.HasValue) DoorType = (doorType)data.DoorType;
            if(data.LockType.HasValue) LockType = (lockType)data.LockType;
            if(data.Restrictions.HasValue) Restrictions = (exitRestrictionType)data.Restrictions;
            if(data.ExitType.HasValue) ExitType = (exitType)data.ExitType;
            if(data.Open.HasValue) Open = (bool)data.Open;
            if(data.Lockable.HasValue) Lockable = (bool)data.Lockable;
            if(data.Visible.HasValue) Visible = (bool)data.Visible;
            if(data.Pickable.HasValue) Pickable = (bool)data.Pickable;
            if(data.Breakable.HasValue) Breakable = (bool)data.Breakable;
            if(data.Repairable.HasValue) Repairable = (bool)data.Repairable;
        }
    }

}