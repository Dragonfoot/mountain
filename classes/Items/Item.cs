using System.Collections.Concurrent;
using Mountain.classes.dataobjects;

namespace Mountain.classes.Items {

    public class Item : Identity {
        public bool magical { get; set; }
        public bool holdable { get; set; }
        public bool breakable { get; set; }
        public bool consumable { get; set; }
        public float protection { get; set; }
        public int value { get; set; }

        public Item() {
            ClassType = classObjectType.item;
            Name = "new item";
            Description = "new generic item.";
        }       
    }

    public class ItemContainer : Item {
        public ConcurrentBag<Item> List;

        public ItemContainer(string name, string description) {
            ItemType = itemType.container;
            List = new ConcurrentBag<Item>(); 
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
            ItemType = itemType.clothing;
        }
    }

    public class Valuable : Item {
    }

}
