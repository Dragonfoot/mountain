using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Mountain.classes.helpers;
using System.Threading.Tasks;

namespace Mountain.classes.Items {

    public class Item : Identity {
        protected bool magical;

        public Item() {
            base.ClassType = classType.item;
            Name = "new item";
            base.Description = "new generic unknown item type";
        }       
    }

    public class ItemContainer : Item {
        protected ConcurrentBag<Item> items;

        public ItemContainer(string name, string description) {
            base.ItemType = itemType.container;
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
