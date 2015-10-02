using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Exit : BaseObject {
        protected Linkage link;
        public string Name {
            get {
                return base.name;
            }
            set {
                base.name = value;
            }
        }

        public Exit() {
        }

    }
}
