using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Exit : Identity {
        public RoomID link { get; set; }

        public Exit() {
            ClassType = classType.exit;
            ItemType = itemType.unknown;
            link = new RoomID();
            Name = "New exit";
            Description = "This is a newly created exit";
        }

    }
}
