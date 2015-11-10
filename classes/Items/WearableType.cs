
using Mountain.classes.helpers;

namespace Mountain.classes.Items {

    public class WearableType : Item {
        public int BreakingPoint { get; set; }
        public int Protection { get; set; }
        public int Value { get; set; }
        public bool Repairable { get; private set; }
        public bool Breakable { get; private set; }
        public equipmentLocation locationHook { get; set; }

        public WearableType() {
            ItemType = itemType.equipment;
            Repairable = true;
            Breakable = true;
            Description = "generic wearable base object";
        }

    }
}
