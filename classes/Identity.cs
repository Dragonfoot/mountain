using System;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {


    public class Identity {
        public string Name { get; set; }
        public string Description;
        public Guid ID { get; set; }
        public itemType ItemType { get; set; }
        public classType ClassType { get; set; }

        public Identity() {
            this.ClassType = classType.identity;
            this.ItemType = itemType.unknown;
        }
        public Identity(classType classType, Guid id, string name, string description) {
            // check for valid parameters, throw exception
            // 
        }

    }
}
