using System;
using System.Collections.Concurrent;

namespace Mountain.classes.collections {

    public class MessageQueue {
        private ConcurrentQueue<string> queue;
        public string Tag { get; set; }
        public delegate void MessageHandler(object myObject, string msg);
        public event MessageHandler OnMessageReceived;
        public ApplicationSettings settings;

        public MessageQueue(ApplicationSettings appSettings) {
            settings = appSettings;
            queue = new ConcurrentQueue<string>();
        }

        public void Push(string message) {
            queue.Enqueue(message);
            try {
                OnMessageReceived(this, message);
            } catch (Exception e) {
                settings.SystemMessageQueue.Push(Tag + ": " + e.ToString());
            }
        }

        public string Pop() {
            string message;
            return (queue.TryDequeue(out message)) ? message : string.Empty;
        }
    }

}
