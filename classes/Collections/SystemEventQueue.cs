using System.Collections.Concurrent;
using Mountain.classes.dataobjects;

namespace Mountain.classes.collections {

    public class SystemEventQueue {
        public string Tag { get; set; }
        private ConcurrentQueue<SystemEventPacket> queue;
        public delegate void EventHandler(object myObject, SystemEventPacket packet);
        public event EventHandler OnEventReceived;

        public SystemEventQueue() {
            queue = new ConcurrentQueue<SystemEventPacket>();
        }

        public void Push(SystemEventPacket packet) {
            queue.Enqueue(packet);
            OnEventReceived(this, packet);
        }
        public SystemEventPacket Pop() {
            SystemEventPacket packet;
            return (queue.TryDequeue(out packet)) ? packet : null;
        }

    }
}
