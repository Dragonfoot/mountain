using System.Drawing;
namespace Mountain.classes.dataobjects {

    public class MapSettings {
        public int ColorIndex { get; set; }

        public Location WorldGrid, AreaGrid;

        public MapSettings(int index) {
            ColorIndex = index;
            WorldGrid = new Location();
            AreaGrid = new Location();
        }
    }

    public struct Location {
        public int row, col;
    }
}
