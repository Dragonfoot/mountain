using System.Collections.Concurrent;
using Mountain.classes.tcp;
using Mountain.classes.Items;
using Mountain.classes.dataobjects;

namespace Mountain.classes.collections {

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
