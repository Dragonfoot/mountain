using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class TcpServer {
        public int Connections { get; private set; }
        protected AutoResetEvent connectionWaitHandle;
        TcpListener tcpListener;
        World world;
        FormInterface form;

        public TcpServer(World world, FormInterface form) {
            this.world = world;
            connectionWaitHandle = new AutoResetEvent(false);
            this.form = form;
        }


        public void StartServer(int port) {
            if (tcpListener != null) {
                tcpListener.Stop();
                tcpListener = null;
            }
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(HandleAsyncConnection, tcpListener);
        }
        protected void HandleAsyncConnection(IAsyncResult result) {
            TcpListener listener = (TcpListener)result.AsyncState;
            TcpClient client = listener.EndAcceptTcpClient(result);
            connectionWaitHandle.Set(); //Inform the main thread this connection is now handled
            tcpListener.BeginAcceptTcpClient(HandleAsyncConnection, listener);
            this.world.Logins.Add(new Login(client, form));
           // client.Close();
        }


        public void Cancel() {
        }

    }
}
