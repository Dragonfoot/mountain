using Mountain.classes.dataobjects;
using Mountain.classes.Items;

namespace Mountain.classes.mobs.mammal {

    public class Canine : Mob {

        public Canine(string name = null, string description = null) {
            Name = (name == null) ? "Canine" : name;
            Description = (description == null ) ? "A quick energetic mutt." : description;
            Inventory.Add(new Collar());
        }
    }

    public class Collar : Clothing {
        public equipmentLocation locationHook;
        public Collar() {
            locationHook = equipmentLocation.neck;
            value = 5;
            protection = 0.5f;
            Name = "Collar";
            Description = "Simple leather collar";
        }
    }
}
