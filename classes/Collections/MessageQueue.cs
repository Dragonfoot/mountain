using System;
using System.Collections.Concurrent;
using Mountain.classes.dataobjects;

namespace Mountain.classes.collections {

    [Serializable] public class MessageQueue {
        private ConcurrentQueue<string> queue;
        public string Tag { get; set; }
        public delegate void MessageHandler(object myObject, string msg);
        public event MessageHandler OnMessageReceived;

        public MessageQueue() {
            queue = new ConcurrentQueue<string>();
        }

        public void Push(string message) {
            queue.Enqueue(message);
            try {
                OnMessageReceived(this, message);
            } catch (Exception e) {
                GBL.Settings.SystemMessageQueue.Push(Tag + ": " + e.ToString());
            }
        }

        public string Pop() {
            string message;
            return (queue.TryDequeue(out message)) ? message : string.Empty;
        }
    }

}
