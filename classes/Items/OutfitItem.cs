using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes.Items {

    public class OutfitItem : Item {
        public int BreakingPoint { get; set; }
        public int Protection { get; set; }
        public int Value { get; set; }
        public bool Repairable { get; private set; }
        public bool Breakable { get; private set; }

        public OutfitItem() {
            ItemType = itemType.equipment;
            Repairable = true;
            Breakable = true;
            description = "generic usable equipment";
        }

    }
}
