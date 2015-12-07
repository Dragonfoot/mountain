using Mountain.classes.dataobjects;

namespace Mountain.classes {

    public class Identity {
        public string Name { get; set; }
        public string Description { get; set; }
        public itemType ItemType { get; set; }
        public classObjectType ClassType { get; set; }

        public Identity() {
            ClassType = classObjectType.unknown;
            ItemType = itemType.none;
        } 
    }
}
