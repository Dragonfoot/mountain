using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    class Linkage : BaseObject {
        protected RoomPointer x;
        protected RoomPointer y;

        public RoomPointer X {
            get {
                return this.x;
            }
            set {
                this.x = value;
            }
        }

        public Linkage() {
        }
    }

    class RoomPointer {
        protected string label;
        protected Guid roomID;

        public string Label {
            get {
                return this.label;
            }
            set {
                this.label = value;
            }
        }
        public Guid RoomID {
            get {
                return this.roomID;
            }
            set {
                this.roomID = value;
            }
        }

        public RoomPointer() {
        }
    }

}
