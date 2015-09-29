using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Mountain.classes {

    enum ItemType { unknown = 1, weapon, armour, money, consumable, clothing, valuables, text, container, ingredients };

    class Item : BaseObject {
        protected ItemType type = ItemType.unknown;
        protected bool magical = false;

        public Item() {
            base.name = "new item";
            base.description = "new item";
        }       
    }

    class ItemContainer : Item {
        protected BlockingCollection<Item> items;

        public ItemContainer(string name, string description) {
            this.items = new BlockingCollection<Item>(); // not sure on threading needs yet
            base.type = ItemType.container;
        }
        protected string Save(string txt) {
            return txt;
        }
        protected string Load(string txt) {
            return txt;
        }

    }

    class ItemArmor : Item {
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
