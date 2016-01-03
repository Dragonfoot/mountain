using System.Collections.Concurrent;
using Mountain.classes.dataobjects;
using Mountain.classes.Items;

namespace Mountain.classes.mobs {

    public class Underling : Identity { // mob precursor
        public Room Room; 
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Intellegence { get; set; }          
        public int Level { get; set; }

        public ConcurrentBag<Item> Inventory { get; set; }
        public delegate void CommandHandler(object myObject, string message);
        public CommandHandler Commands;

        public Underling() {
            ClassType = classObjectType.mob;
            Name = "Underling";
            Description = "This is a new Underling.";
            Inventory = new ConcurrentBag<Item>();
            Health = 10;
            Strength = 5;
            Intellegence = 5;
            Level = 1;
        }
    }
}
