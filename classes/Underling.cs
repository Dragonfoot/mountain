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
        public ConcurrentBag<Item> Inventory { get; set; }
        public int Health { get; set; }           
        public int Level { get; set; }

        public Underling() {
            base.ClassType = classType.underling;
            this.Inventory = new ConcurrentBag<Item>();
            this.Health = 10;
            this.Level = 1;
        }
    }
}
