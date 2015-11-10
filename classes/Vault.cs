using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.classes.helpers;
using Mountain.classes.Items;

namespace Mountain.classes {

    public class Vault : Identity {
        protected int pin;
        protected Connection Owner;
        protected int gold;
        protected ConcurrentBag<Item> items; // limit
        protected ConcurrentBag<ItemContainer> containers;  //limit, additional might be had on quests/levels/etc

        public Vault() {
            base.ClassType = classType.item;
            base.ItemType = itemType.container;
            items = new ConcurrentBag<Item>();
            containers = new ConcurrentBag<ItemContainer>();
        }
    }

}
