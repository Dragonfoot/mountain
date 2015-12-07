using System;
using System.Collections.Concurrent;
using Mountain.classes.dataobjects;
using Mountain.classes.Items;

namespace Mountain.classes.mobs {

    public class Underling : Identity { // mob precursor
        public Room Room; 
        public ConcurrentBag<Item> Inventory { get; set; }
        public delegate void CommandHandler(object myObject, string message);
        public CommandHandler Commands;
        public int Health { get; set; }           
        public int Level { get; set; }

        public Underling() {
            ClassType = classObjectType.mob;
            Name = "Underling";
            Description = "This is a new underling";
            Inventory = new ConcurrentBag<Item>();
            Health = 10;
            Level = 1;
        }
    }
}
