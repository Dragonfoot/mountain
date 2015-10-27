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

namespace Mountain.classes {

    public class TcpServer {
        public int Connections { get; private set; }
        protected AutoResetEvent connectionWaitHandle;
        TcpListener tcpListener;
        ListBox console;
        World world;

        public TcpServer(World world, ListBox console) {
            this.world = world;
            connectionWaitHandle = new AutoResetEvent(false);
            this.console = console;          
        }

        public void StartServer(int port) {
            if (tcpListener != null) {
                tcpListener.Stop();
                tcpListener = null;
            }
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(HandleAsyncConnection, tcpListener);



            //    console.Items.Add("Service listening at " + tcpListener.LocalEndpoint.ToString());
            //   PollClients(tcpListener);
        }

        protected void HandleAsyncConnection(IAsyncResult result) {
            TcpListener listener = (TcpListener)result.AsyncState;
            TcpClient client = listener.EndAcceptTcpClient(result);
            connectionWaitHandle.Set(); //Inform the main thread this connection is now handled
            tcpListener.BeginAcceptTcpClient(HandleAsyncConnection, listener);
            this.world.Logins.Add(new ClientConnection(client));

            //... Use your TcpClient here
            // create login object
            // start client reader


           // client.Close();
        }


        public void Cancel() {
        }

        public void HandleClient(TcpClient client) {
            Connections++;
            var local = client.Client.LocalEndPoint.ToString();
            console.Items.Add("Connected " + local);
            StreamReader sr = null;
            StreamWriter sw = null;
            try {
                var stream = client.GetStream();
                sr = new StreamReader(stream, Encoding.ASCII);
                sw = new StreamWriter(stream, Encoding.ASCII);
                while (client.Connected) {
                    //sr = new StreamReader(stream, Encoding.UTF8);
                    //sw = new StreamWriter(stream, Encoding.UTF8);

                    var msg = sr.ReadLineAsync(); ;

                    if (msg == null)
                        continue;


                    sw.WriteLine(msg);
                    sw.FlushAsync();

                }
            } catch (Exception aex) {
                var ex = aex.GetBaseException();
                console.Items.Add("Client error: " + ex.Message);
            } finally {
                Connections--;
                if (sr != null)
                    sr.Dispose();

                if (sw != null)
                    sw.Dispose();
            }
            console.Items.Add("Disconnected " + local);
        }

    }
}
