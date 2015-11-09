using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class MessageQueue {
        private ConcurrentQueue<string> queue;
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
                //if (OnMessageReceived != null)
                    OnMessageReceived(this, message);
              //  else
               //     "MessageQueue: OnMessageReceived Handler is null.");
            } catch (Exception e) {
                settings.SystemMessageQueue.Push(e.ToString());
            }
        }
        public string Pop() {
            string message;
            return (queue.TryDequeue(out message)) ? message : string.Empty;
        }
    }


    public class BaseMessageQueue : MessageQueue {
        public BaseMessageQueue(ApplicationSettings appSettings) : base(appSettings) {
        }
    }
}
