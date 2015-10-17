using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class Dummy : BaseObject {
        protected int health;
        public int Health {
            get {
                return this.health;
            }
        }
        public Dummy() {
            this.health = 10;
        }

        public virtual void MoveTo(Room room) {
        }

        public virtual void TakeHit(int amount) {
        }

        public virtual void RandomPickup() {
        }

        public void Flee() {
            // get all room exits this dummy can flee to
            // get random room from list
            // get random success/fail/type of fail.. of flee attempt
            // if successful flee send flee message to room queue, MoveTo(randomRoom)
            // else send flubbed the flee message to room queue.
        }

        public virtual void StartPlayerFight(List<Character> players, List<Dummy> mobs) {
        }
    }
}
