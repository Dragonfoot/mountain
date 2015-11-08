using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class PlayerEventQueue {
        private ConcurrentQueue<PlayerEventPacket> queue;
        public delegate void EventHandler(object myObject, PlayerEventPacket packet);
        public event EventHandler OnEventReceived;

        public PlayerEventQueue() {
            queue = new ConcurrentQueue<PlayerEventPacket>();
        }

        public void Push(PlayerEventPacket packet) {
            queue.Enqueue(packet);
            OnEventReceived(this, packet);
        }
        public PlayerEventPacket Pop() {
            PlayerEventPacket packet;
            return (queue.TryDequeue(out packet)) ? packet : null;
        }

    }

    public class GeneralEventQueue {
    }
}
