using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq.Expressions;

namespace Mountain.classes.collections {

    [XmlRoot("Area")]
    public class Rooms : IEnumerable<Room> {
        [XmlArray("Rooms")] public List<Room> List { get; set; }
        [XmlIgnore] public Area Area { get; set; }
        [XmlIgnore] public int Count { get { return List.Count; } }

        public Rooms(Area area) {
            List = new List<Room>();
            Area = area;
        }

        public void Add(Room room) {
            List.Add(room);
        }        
       // public Room Find(Expression<Func<Room, bool>> predicate) {
       //     return List.Find(predicate);
       // }

        public Room FindTag(string tagname) {
            return List.Find(room => room.Tag == tagname);
        }

        public Room FindName(string name) {
            return List.Find(room => room.Name.StartsWith(name));
        }

        public IEnumerator<Room> GetEnumerator() {
            return List.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
