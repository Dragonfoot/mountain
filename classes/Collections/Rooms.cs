using System.Collections.Generic;
using Mountain.classes.functions;

namespace Mountain.classes.collections {

    public class Rooms : IEnumerable<Room> {
        public List<Room> List { get; set; }
        public Area Area { get; set; }
        public int Count { get { return List.Count; } }

        public Rooms(Area area) {
            List = new List<Room>();
            Area = area;
        }

        public void Add(Room room) {
            List.Add(room);
        } 
          
        public Room FindTag(string tagName) {
            return List.Find(room => room.Tag == tagName);
        }

        public Room FindName(string name) {
            if (name.IsNullOrWhiteSpace()) return null;
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
