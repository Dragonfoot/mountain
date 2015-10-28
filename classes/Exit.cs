using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Exit : Identity {
        public Linkage link { get; set; }

        public Exit() {
            this.ID = Guid.NewGuid();
            this.Name = "New exit";
            this.Description = "This is a newly created exit";
            this.ClassType = classType.exit;
            this.ItemType = itemType.unknown;
        }

    }
}
