
using System.Collections.Generic;
using Mountain.classes.tcp;

namespace Mountain.classes.collections {

    public class Players : IEnumerable<Connection> {
        private List<Connection> List;
        public delegate void AddHandler(object myObject, Connection player);
        public event AddHandler OnPlayerAdded;
        public int Count { get { return List.Count; } }

        public delegate void RemoveHandler(object myObject, Connection player);
        public event RemoveHandler OnPlayerRemoved;

        public Players() {
            List = new List<Connection>();
        }

        public void Add(Connection player) {
            List.Add(player);
            if (OnPlayerAdded != null )
                OnPlayerAdded(this, player);
        }

        public void Remove(string name) {
            int index = GetIndex(name);
            Connection loggingOut = List[index];
            List.RemoveAt(index);
            if (OnPlayerRemoved != null )
                OnPlayerRemoved(this, loggingOut);
        }

        public Connection [] ToArray() {
            return List.ToArray();
        }

        public bool Exists(string name) {
            return List.Exists(player => player.Account.Name == name);
        }

        private int GetIndex(string name) {
            return List.FindIndex(player => player.Account.Name == name);
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
