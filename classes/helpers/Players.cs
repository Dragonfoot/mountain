using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class Players {
        private List<Player> List;
        public delegate void AddHandler(object myObject, Player player);
        public event AddHandler OnPlayerAdded;

        public delegate void RemoveHandler(object myObject, Player player);
        public event RemoveHandler OnPlayerRemoved;

        public Players() {
            List = new List<Player>();
        }
        public void Add(Player player) {
            List.Add(player);
            OnPlayerAdded(this, player);
        }
        public void Remove(string name) {
            int index = GetIndex(name);
            Player loggingOut = List[index];
            List.RemoveAt(index);
            OnPlayerRemoved(this, loggingOut);
        }
        public int Count() {
            return List.Count;
        }
        private int GetIndex(string name) {
            return List.FindIndex(player => player.Name == name);
        }

        public void Shutdown() { 
            List.ForEach(player => {
                player.Shutdown();  //send shutdown message, save, close connection
            });
            List.RemoveRange(0, List.Count);
        }
        public void Broadcast() {
            // foreach player in players, send message
        }
    }
}
