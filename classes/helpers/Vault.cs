using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class Vault : BaseObject {
        protected int pin;
        protected Player Owner;
        protected int gold;
        protected List<Item> items; // limited
        protected List<ItemContainer> containers;  //number limited, additional on quests/levels/etc

        public Vault() {
        }
    }

}
