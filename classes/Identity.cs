using System;
using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes {

    [Serializable()]
    public class Identity {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ID { get; set; }
        public itemType ItemType { get; set; }
        public classObjectType ClassType { get; set; }

        public Identity() {
            this.ClassType = classObjectType.unknown;
            this.ItemType = itemType.none;
            ID = Guid.NewGuid();
        }
        
        public string ToXml() {
            return XmlHelper.ObjectToBasicXml(this);
        }

    }
}
