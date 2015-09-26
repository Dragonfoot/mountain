using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.classes.Interfaces;

namespace Mountain.classes {

    enum ItemType { unknown = 1, weapon, armour, money, consumable, clothing, valuables, text, container };

    class Item : BaseObject {
        protected ItemType type = ItemType.unknown;
        protected bool magical = false;

        public Item() {
            base.name = "new item";
            base.description = "new item";
        }

        protected virtual string Save(string txt) {  // unclear yet which way to go, chain top down or bottom up, too early
            // txt.builderthingie.add(closing xml);
            return txt;
        }
        protected virtual string Load(string txt) {
            return string.Empty;
        }
    }

    class ItemContainer : Item {
        protected BlockingCollection<Item> items;

        public ItemContainer(string name, string description) {
            this.items = new BlockingCollection<Item>(); // not sure on threading needs yet
            base.type = ItemType.container;
        }
        protected override string Save(string txt) {
            //do something with txt
            return base.Save(txt);
        }
        protected override string Load(string txt) {
            return base.Load(txt);
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
