using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class Server {

        public int Port {
            get; set;
            }
        public List<Task> Logins {
            get; set;
            }
        public List<Task> Clients {
            get; set;
            }
        TcpListener listener;
        TcpClient client;
        object Activelock;

        public Server(int port) {
            Logins=new List<Task>();
            Clients=new List<Task>();
            Activelock=new object();
            if (port<0) {
                this.Port=8090;
                }
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancel = cancellationTokenSource.Token;

            listener=new TcpListener(IPAddress.Any, Port);
            listener.Start();
            var task = AcceptClientsAsync(listener, cancel);
            }

        public async Task AcceptClientsAsync(TcpListener listener, CancellationToken cancel) {
            await Task.Yield();
            while (!cancel.IsCancellationRequested) {
                var tcpClient = await listener.AcceptTcpClientAsync();
                var task = HandleClientAsync(client, cancel);
                if (task.IsFaulted)
                    task.Wait();
                }
            }

        public async Task HandleClientAsync(TcpClient client, CancellationToken cancel) {
            await Task.Yield();
            var local = client.Client.LocalEndPoint.ToString();
            // Console.WriteLine("Connected " + local);
            StreamReader sr = null;
            StreamWriter sw = null;
            try {
                var stream = client.GetStream();
                sr=new StreamReader(stream, Encoding.UTF8);
                sw=new StreamWriter(stream, Encoding.UTF8);
                while (!cancel.IsCancellationRequested&&client.Connected) {
                    //sr = new StreamReader(stream, Encoding.UTF8);
                    //sw = new StreamWriter(stream, Encoding.UTF8);

                    var msg = await sr.ReadLineAsync();
                    ;

                    if (msg==null)
                        continue;

                    //_inMessages.Increment();
                    // _inBytes.IncrementBy(msg.Length);

                    await sw.WriteLineAsync(msg);
                    await sw.FlushAsync();

                    // _outMessages.Increment();
                    // _outBytes.IncrementBy(msg.Length);

                    }
                }
            catch (Exception aex) {
                var ex = aex.GetBaseException();
                Console.WriteLine("Client error: "+ex.Message);
                }
            finally {
                //  Connected--;
                if (sr!=null)
                    sr.Dispose();

                if (sw!=null)
                    sw.Dispose();
                }
            Console.WriteLine("Disconnected "+local);
            }

        public void Send(Player player, string text) {

            }

        }

    }

/*
 * server object
 *  
 * declare properties
 * parse the programs passed command line arguments
 * assign passed params to the port listener
 * start the port listener
 * begin our main loop 
 *      if a connection is detected
 *          call login function passing the connection socket
 *          if the login is a regular user, create a player and load the users saved data for it
 *          if the login is a new user, create a player and pass it to the creation function
 *          if we have a successfully created player, add it to the worlds player list.
 *      if a command to quit the program is detected then exit the loop
 * end loop
 * clean up memory
 * close the program
*/

/*
 * login function
 *      assign passed parameters
 *      send welcome message to user
 *      assign user message with request for login data
 *      loop
 *          send user message
 *          wait for user input
 *          do password check on user input
 *          if no password or no username, set user message with error and request for username and password / ask if this is a new player
 *          if response is new player, call create new user
 *          if login successful, end loop, else set user message with error
 *      end loop
 *      return user data packet
 * end login function
 * 
 */
