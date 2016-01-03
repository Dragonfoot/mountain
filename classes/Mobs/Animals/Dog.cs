using Mountain.classes.dataobjects;
using Mountain.classes.Items;

namespace Mountain.classes.mobs.animals {

    public class Dog : Mob {

        public Dog() {
            Name = "Dog";
            Description = "A quick energetic mutt.";
            Inventory.Add(new Collar());
        }
    }

    public class Collar : Clothing {
        public equipmentLocation locationHook;
        public Collar() {
            locationHook = equipmentLocation.neck;
            value = 5;
            protection = 1;
            Name = "Collar";
            Description = "Simple leather collar";
        }
    }
}
