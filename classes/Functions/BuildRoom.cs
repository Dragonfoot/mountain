using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes.functions {

    public static class BuildRoom {

        public static Room WithReturnLink(roomType type, Room linkage) {
            Room room = Type(type, linkage.Area);
            Build.LinkTwoRooms(room, linkage);
            return room;
        }

        public static Room Type(roomType type, Area area) {
            Room room = new Room(area);
            switch (type) {
                case roomType.road:
                    room.roomType = roomType.road; // set up possible speed limits, healing rates, leveling restrictions...
                    break;
                case roomType.path:
                    room.roomType = roomType.path;
                    break;
                case roomType.street:
                    room.roomType = roomType.street;
                    break;
                case roomType.healing:
                    room.roomType = roomType.healing;
                    break;
                case roomType.home:
                    room.roomType = roomType.home;
                    break;
                case roomType.leveling:
                    room.roomType = roomType.leveling;
                    break;
                case roomType.pawn:
                    room.roomType = roomType.pawn;
                    break;
                case roomType.shop:
                    room.roomType = roomType.shop;
                    break;
                case roomType.sewer:
                    room.roomType = roomType.sewer;
                    break;
                case roomType.vault:
                    room.roomType = roomType.vault;
                    break;
                default:
                    room.roomType = roomType.none;
                    break;
            }
            return room;

        }
    }
}
