using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {


    public class Identity {
        private Guid id;
        public string Name { get; set; }
        protected string description;

        public itemType ItemType { get; set; }
        public classType ClassType { get; set; }
        protected Guid ID { 
            get { return id; } 
            set { this.id = (value == Guid.Empty) ? new Guid() : value; } 
        }

        public Identity() {
            this.ID = Guid.Empty;
            this.ClassType = classType.identity;
        }
        public Identity(classType classType, Guid id, string name, string description) {
            // check for valid parameters, throw exception
            // 
        }

    }
}
