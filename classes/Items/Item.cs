using System;
using System.Collections.Concurrent;
using Mountain.classes.dataobjects;

namespace Mountain.classes.Items {

    [Serializable] public class Item : Identity {
        public bool magical { get; set; }
        public bool holdable { get; set; }
        public bool breakable { get; set; }
        public bool consumable { get; set; }
        public int value { get; set; }

        public Item() {
            ClassType = classObjectType.item;
            Name = "new item";
            Description = "new generic unknown item";
        }       
    }

    public class ItemContainer : Item {
        protected ConcurrentBag<Item> items;

        public ItemContainer(string name, string description) {
            base.ItemType = itemType.container;
            this.items = new ConcurrentBag<Item>(); 
        }
        protected string Save(string txt) {
            return txt;
        }
        protected string Load(string txt) {
            return txt;
        }

    }
    class ItemWeapon : Item {
    }
    class ItemMoney : Item {
    }
    class ItemText : Item {
    }
    class ItemConsumable : Item {
    }
    class ItemClothing : Item {
    }
    class ItemValuables : Item {
    }

}
