using Mountain.classes.dataobjects;
using System.ComponentModel;

namespace Mountain.classes {

    public class Identity {

        [CategoryAttribute("Identity"), ReadOnly(true)]
        public string Name { get; set; }
        [CategoryAttribute("Identity"), ReadOnly(true)]
        public string Description { get; set; }
        [CategoryAttribute("Identity"), ReadOnly(true)]
        public itemType ItemType { get; set; }
        [CategoryAttribute("Identity"), ReadOnly(true)]
        public classObjectType ClassType { get; set; }

        public Identity() {
        } 
    }
}
