using System.Collections.Concurrent;
using Mountain.classes.helpers;
using Mountain.classes.Items;

namespace Mountain.classes.mobs {

    public class Underling : Identity { //mob precursor
        public RoomID roomID { get; set; } 
        public ConcurrentBag<Item> Inventory { get; set; }
        public delegate void CommandHandler(object myObject, string message); // plugin hook
        public CommandHandler Commands;
        public int Health { get; set; }           
        public int Level { get; set; }

        public Underling() {
            ClassType = classType.mob;
            Name = "Underling";
            Description = "This is a new underling";
            Inventory = new ConcurrentBag<Item>();
            Health = 10;
            Level = 1;
        }
    }
}
