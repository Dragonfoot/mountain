using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mountain.classes {

    public enum objectType { baseObject, heart, player, room, mob, quest, timer, system, exit, item, unknown };

    public class BaseObject {
        private Guid id;
        protected objectType objectType;
        protected string name;
        protected string description;

        protected Guid ID {
            get {
                return this.id;
            }
            set {
                this.id = (value == Guid.Empty) ? new Guid() : value;
            }
        }

        public objectType ObjectType {
            get {
                return this.objectType;
            }
            set {
                this.objectType = value;
            }
        }

        public BaseObject() {
            this.name = "new object";
            this.description = "new description";
            this.id = Guid.Empty;
            this.objectType = objectType.baseObject;
        }
        public BaseObject(objectType obj, Guid id, string name, string description) {
            // check for valid parameters, throw exception
            // 
        }

    }
}
