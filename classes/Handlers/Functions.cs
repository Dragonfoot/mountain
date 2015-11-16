using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.handlers {

    public static class Functions {

        public static string GetNames(Array list) {
            string names = string.Empty;
            int i = 1;
            foreach (Identity item in list) {
                names = names + item.Name;
                if (i != list.Length) { names = names + ", "; }
                if (i == list.Length) { names = names + "."; }
                i++;
            }
            return names;
        }

        public static Room CloneRoomEdit(Room room, ApplicationSettings settings) {
            Room copy = new Room(room.Name, room.Description, settings);
            copy.RoomID = room.RoomID;
            if (room.Exits.Count > 0) {
                foreach (Exit exit in room.Exits) {
                    Exit exitCopy = new Exit();
                    exitCopy.ID = exit.ID;
                    exitCopy.Name = exit.Name;
                    exitCopy.Description = exit.Description;
                    exitCopy.link = exit.link;
                    exitCopy.LinkToRoomID = exit.LinkToRoomID;
                    exitCopy.LinkToRoomName = exit.LinkToRoomName;
                    exitCopy.Attributes = exit.Attributes;
                    copy.Exits.Add(exitCopy);
                }
            }
            return copy;
        }
        public static void SetRoomEdits(Room fromRoom, Room toRoom) {
            toRoom.Name = fromRoom.Name;
            toRoom.Description = fromRoom.Description;
            if(toRoom.Exits.Count > 0) {
                toRoom.Exits.Clear();
                foreach (Exit fromExit in fromRoom.Exits) {
                    Exit toExit = new Exit();
                    toExit.ID = fromExit.ID;
                    toExit.Name = fromExit.Name;
                    toExit.Description = fromExit.Description;
                    toExit.link = fromExit.link;
                    toExit.LinkToRoomID = fromExit.LinkToRoomID;
                    toExit.LinkToRoomName = fromExit.LinkToRoomName;
                    toExit.Attributes = fromExit.Attributes;
                    toRoom.Exits.Add(toExit);

                }
            }
        }
    }
}
