
namespace Mountain.classes.dataobjects {

    public class ObjectAttributes {
        public bool AdminOnly { get; set; }
        public bool Repairable { get; set; }
        public int Value { get; set; }
        public int Level { get; set; }
    }

    public class ExitAttributes : ObjectAttributes {
        public bool Hidden { get; set; }
        public bool Findable { get; set; }
        public bool Lockable { get; set; }
        public bool Pickable { get; set; }
        public string Label { get; set; }
    }
}
