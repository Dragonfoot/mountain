using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Exit : Identity {
        
        public RoomID linkTo { get; set; }

        public Exit() {
            ClassType = classType.exit;
            ItemType = itemType.unknown;
            linkTo = new RoomID();
            Name = "New exit";
            Description = "This is a newly created exit";
        }

    }
}
