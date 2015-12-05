using System.Collections.Generic;
using System;
using Mountain.classes.tcp;

namespace Mountain.classes.collections {

    
    [Serializable] public class Players : IEnumerable<Connection> {
        [NonSerialized()] public List<Connection> List;
        public delegate void AddHandler(object myObject, Connection player, string message = "");
        public delegate void RemoveHandler(object myObject, Connection player, string message = "");
        public event AddHandler OnPlayerAdded;
        public event RemoveHandler OnPlayerRemoved;
        public int Count { get { return List.Count; } }

        public Players() {
            List = new List<Connection>();
        }

        public void Add(Connection player, string message = "") {
            List.Add(player);
            if (OnPlayerAdded != null ) OnPlayerAdded(this, player, message);
        }

        public void Remove(string name, string message = "") {
            int index = GetIndex(name);
            Connection player = List[index];
            List.RemoveAt(index);
            if (OnPlayerRemoved != null) OnPlayerRemoved(this, player, message);
        }

        public Connection GetPlayer(string name) {
            if (Exists(name)) {
                int index = GetIndex(name);
                return List[index];
            }
            return null;
        }

        public Connection [] ToArray() {
            return List.ToArray();
        }

        public bool Exists(string name) {
            return List.Exists(player => player.Name == name);
        }

        public int GetIndex(string name) {
            return List.FindIndex(player => player.Name == name);
        }

        public void Shutdown() { 
            List.ForEach(player => { player.Shutdown(); });  //send shutdown message, save, close connection
            List.RemoveRange(0, List.Count);
            // https://github.com/Reddit-Mud/RMUD/blob/master/NetworkModule/Clients.cs
        }

        public IEnumerator<Connection> GetEnumerator() {
            return List.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
