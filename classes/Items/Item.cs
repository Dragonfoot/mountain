using System.Collections.Concurrent;
using Mountain.classes.dataobjects;

namespace Mountain.classes.Items {

    public class Item : Identity {
        public bool magical { get; set; }
        public bool holdable { get; set; }
        public bool breakable { get; set; }
        public bool consumable { get; set; }
        public int protection { get; set; }
        public int value { get; set; }

        public Item() {
            ClassType = classObjectType.item;
            Name = "new item";
            Description = "new generic item.";
        }       
    }

    public class ItemContainer : Item {
        protected ConcurrentBag<Item> items;

        public ItemContainer(string name, string description) {
            base.ItemType = itemType.container;
            this.items = new ConcurrentBag<Item>(); 
        }

    }
    public class Weapon : Item {
    }
    public class Money : Item {
    }
    public class Note : Item {
    }
    public class Consumable : Item {
    }

    public class Clothing : Item {
        public Clothing() {
            base.ItemType = itemType.clothing;
        }
    }

    public class Valuable : Item {
    }

}
