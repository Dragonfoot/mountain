using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.helpers;
using Mountain.classes.Items;

namespace Mountain.classes {

    public class Underling : Identity { //mob precursor
        public RoomID roomID { get; set; } 
        public ConcurrentBag<Item> Inventory { get; set; }
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
