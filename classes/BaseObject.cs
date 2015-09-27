using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mountain.classes {

    public enum objectType { baseObject, heart, player, room, mob, quest, timer, system, unknown };

    public class BaseObject {
        private Guid id;
        private objectType objectType;
        private string name;
        private string description;

        protected Guid ID {
            get {
                return this.id; // if objectType is derived and id is empty, throw exception here?
            }
            set {
                this.id = (value == Guid.Empty) ? new Guid() : value;
            }
        }
        protected string Name {
            get {
                return this.name;
            }
            set {
                this.name = value;
            }
        }
        protected string Description {
            get {
                return this.description;
            }
            set {
                this.description = value;
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
