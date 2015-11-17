using System;
using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes {

    public class Identity {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ID { get; set; }
        public itemType ItemType { get; set; }
        public classType ClassType { get; set; }

        public Identity() {
            this.ClassType = classType.unknown;
            this.ItemType = itemType.none;
            ID = Guid.NewGuid();
        }
        
        public string ToXml() {
            string result = XmlHelper.ObjectToBasicXml(this);
            return result;
        }

    }
}
