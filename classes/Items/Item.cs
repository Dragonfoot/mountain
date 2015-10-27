using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Mountain.classes.helpers;
using System.Threading.Tasks;

namespace Mountain.classes.Items {

    public class Item : Identity {
        protected itemType type = itemType.unknown;
        protected bool magical = false;

        public Item() {
            Name = "new item";
            base.ClassType = classType.item;
            base.ItemType = itemType.unknown;
            base.description = "new generic unknown item type";
        }       
    }

    public class ItemContainer : Item {
        protected ConcurrentBag<Item> items;

        public ItemContainer(string name, string description) {
            base.type = itemType.container;
            this.items = new ConcurrentBag<Item>(); // not sure on threading needs yet
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
