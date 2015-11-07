using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Exit : Identity {
        
        public Room link { get; set; }

        public Exit() {
            ClassType = classType.exit;
            ItemType = itemType.unknown;
            Name = "New exit";
        }

    }
}
