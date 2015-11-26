using Mountain.classes.dataobjects;
namespace Mountain.classes.dataobjects {

    public class ObjectAttributes {
        public bool AdminOnly { get; set; }
        public bool Repairable { get; set; }
        public int Weight { get; set; }
        public string Tag { get; set; }
    }

    public class ExitAttributes : ObjectAttributes {
        public bool Visible { get; set; }
        public bool HasLock { get; set; }
        public bool Door { get; set; }
        public bool Open { get; set; }

       // public bool Pickable { get; set; }
       // public bool Findable { get; set; }
    }
}
