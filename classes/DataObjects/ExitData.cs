﻿using System;
using System.Diagnostics;
using Mountain.classes.functions;
namespace Mountain.classes.dataobjects {

    public class ExitData {
        public exitType? ExitType = null;  // door, window, random, teleport, openSpace
        public lockType? LockType = null;
        public doorType? DoorType = null;
        public exitRestrictionType? Restrictions = null;
        public LinkToID LinkToRoomID = null;
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