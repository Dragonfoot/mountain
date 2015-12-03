using System;

namespace Mountain.classes.dataobjects {

    [Serializable] public class ExitData {
        public exitType? ExitType = null;  // door, window, random, teleport, openSpace
        public lockType? LockType = null;
        public doorType? DoorType = null;
        public exitRestrictions? Restrictions = null;
        public Location Linkage = null;
        public string Name = null;
        public string Description = null;
        public Guid? ID = null;
        public bool? Open = null;
        public bool? Lockable = null;
        public bool? Visible = null;
        public bool? Pickable = null;
        public bool? Breakable = null;
        public bool? Repairable = null;
        
        public ExitData() {
        }
    }
}
