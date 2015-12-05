using System;
using System.Linq;
using System.Collections.Generic;
using Mountain.classes.dataobjects;

namespace Mountain.classes.functions {

    public static class FUNC {

        public static string FormatStringArray(Array list) {
            string names = string.Empty;
            int i = 0;
            foreach (string item in list) {
                names += item;
                if (i != list.Length) { names += ", "; }
                if (i == list.Length) { names += "."; }
            }
            return names;
        }

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

        public static IEnumerable<T> GetValues<T>() { // loop through enums: var values = GetValues<Foos>();
            return (T[])Enum.GetValues(typeof(T));
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
            foreach (Identity item in list) {
                string[] names = item.ToString().Split(' ');
                foreach (string part in names) {
                    if (part.StartsWith(name, StringComparison.OrdinalIgnoreCase)) return true;
                }
            }
            return false;
        }
        
        public static void UpdateRoomEdits(Room fromRoom, Room toRoom) {
            toRoom.Name = fromRoom.Name;
            toRoom.Description = fromRoom.Description;
            if (toRoom.Exits.Any()) { toRoom.Exits.Clear(); }
            if (fromRoom.Exits.Any()) {
                foreach (Exit fromExit in fromRoom.Exits) {
                    Exit toExit = new Exit();
                    toExit.ID = fromExit.ID;
                    toExit.Name = fromExit.Name;
                    toExit.Description = fromExit.Description;
                    toExit.Owner = fromExit.Owner;
                    toExit.Linkage = new Location(fromExit.Linkage.Room);
                    toRoom.AddExit(toExit);
                }
            }
        }
    }
}
