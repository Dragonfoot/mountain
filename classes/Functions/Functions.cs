using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Mountain.classes.functions {

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

        public static int GetSameNameCount(Array list, string name) {
            int i = 0;
            foreach(Identity item in list) {
                if (item.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)) { i++; }
            }
            return i;
        }

        public static string GetOtherNames(Array list, string name) {
            string names = string.Empty;
            int i = 1;
            foreach (Identity item in list) {
                if(item.Name == name) { i++; continue; }
                names = names + item.Name;
                if (i != list.Length) { names = names + ", "; }
                if (i == list.Length) { names = names + "."; }
                i++;
            }
            return names;
        }

        public static bool HasNameThatStartsWith(Array list, string name) {
            foreach(Identity item in list) {
                if (item.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public static Room CloneTheRoomToEdit(Room room, ApplicationSettings settings) {
            Room clone = new Room(room.Name, room.Description, settings);
            clone.RoomID = room.RoomID;
            if (room.Exits.Count > 0) {
                foreach (Exit exit in room.Exits) {
                    Exit clonedExit = new Exit();
                    clonedExit.ID = exit.ID;
                    clonedExit.Name = exit.Name;
                    clonedExit.Description = exit.Description;
                    clonedExit.link = exit.link;
                    clonedExit.LinkToRoomID = exit.LinkToRoomID;
                    clonedExit.LinkToRoomName = exit.LinkToRoomName;
                    clonedExit.Attributes = exit.Attributes;
                    clone.Exits.Add(clonedExit);
                }
            }
            return clone;
        }

        public static void UpdateRoomEdits(Room fromRoom, Room toRoom) {
            toRoom.Name = fromRoom.Name;
            toRoom.Description = fromRoom.Description;
            if (toRoom.Exits.Count > 0) { toRoom.Exits.Clear(); }
            if (fromRoom.Exits.Count > 0) {
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
