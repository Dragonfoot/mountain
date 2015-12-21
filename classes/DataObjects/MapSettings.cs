using System.Drawing;
namespace Mountain.classes.dataobjects {

    public class MapSettings {
        public Color Color { get; set; }
        public Location WorldGrid, AreaGrid;

        public MapSettings(int index) {
            Color = Color.FromKnownColor((KnownColor)index);
            WorldGrid = new Location();
            AreaGrid = new Location();
        }
    }

    public struct Location {
        public int row, col;
    }
}
