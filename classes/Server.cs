using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Mountain.classes {

    class Server {
        protected int port;
        TcpListener listener;
        TcpClient client;
        IPAddress ipAddress;
        public int Port {
            get {
                return this.port;
            }
            set {
                this.port = value;
            }
        }
        public Server() {
            ipAddress = IPAddress.Parse("127.0.0.1");
            int port = 8090;
            //     TcpClient client = listener.AcceptSocket();
        }
        public void Start() {
            listener = new TcpListener(ipAddress, port);
            listener.Start();
            Console.WriteLine("The Server has started on port " + port.ToString());
        }
        public void Stop() {
            //close all open connections
            listener.Stop();
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
 *          if no password or no username, set user message with error and request for username and password or new player
 *          if response is nw player, call create new user
 *          if login successful, end loop
 *      end loop
 *      return user packet
 * end login function
 * 
 */
