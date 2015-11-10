using System;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Identity {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ID { get; set; }
        public itemType ItemType { get; set; }
        public classType ClassType { get; set; }

        public Identity() {
            this.ClassType = classType.unknown;
            this.ItemType = itemType.unknown;
            ID = Guid.NewGuid();
        }

    }
}
