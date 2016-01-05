using Mountain.classes.dataobjects;
using Mountain.classes.Items;

namespace Mountain.classes.mobs.mammals {

    public class Canine : Mob {

        public Canine(string name = null, string description = null) {
            Name = (name == null) ? "Canine" : name;
            Description = (description == null ) ? "A quick energetic mutt." : description;
        }
    }

    public class Collar : Clothing {
        public equipmentLocation locationHook;
        public Collar() {
            locationHook = equipmentLocation.neck;
            value = 5;
            protection = 0.5f;
            Name = "Spiked Collar";
            Description = "Thick leather collar with embedded spikes encircling it.";
        }
    }
}
