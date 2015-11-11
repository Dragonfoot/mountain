using System.Collections.Concurrent;
using Mountain.classes.dataobjects;

namespace Mountain.classes.collections {

    public class PlayerEventQueue {
        public string Tag { get; set; }
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
