using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Mountain.classes.dataobjects;
using Mountain.classes.handlers;
using Mountain.classes.functions;

namespace Mountain.classes.tcp {

    [XmlRoot("Player")] public class Connection : IDisposable {
        private StateObject state { get; set; }
        [XmlIgnore] public TcpClient Socket { get; set; }
        [XmlIgnore] public IPAddress IPAddress;
        [XmlIgnore] public int Port;
        [XmlIgnore] public ApplicationSettings settings;
        [XmlIgnore] public Stack<string> StringStack;
        [XmlIgnore] public CommandHandler Commands;
        [XmlIgnore] public Room Room { get; set; }
        [XmlIgnore] public bool Connected { get {
                bool read = Socket.Client.Poll(500, SelectMode.SelectRead);
                bool status = (Socket.Client.Available == 0);
                return !(read & status);
            }
        }
        private LoginHandler LoginHandler;   // login functions
        private PlayerHandler PlayerHandler; // player functions
        public Account Account { get; set; }
        public Stats Stats { get; set; }
        public Equipment Equipment { get; set; }
        private readonly ManualResetEvent MessageReceivedDone;
        private readonly ManualResetEvent MessageSentDone;
        public delegate void CommandHandler(object myObject, string message);

        public Connection(TcpClient socket, ApplicationSettings appSettings) {
            Socket = socket;
            this.IPAddress = ((IPEndPoint)socket.Client.RemoteEndPoint).Address;
            this.Port = ((IPEndPoint)socket.Client.RemoteEndPoint).Port;
            settings = appSettings;
            Account = new Account();
            Stats = new Stats();
            Equipment = new Equipment();
            StringStack = new Stack<string>();
            MessageReceivedDone = new ManualResetEvent(false);
            MessageSentDone = new ManualResetEvent(false);
            state = new StateObject((socket));
            LoginHandler = new LoginHandler(this, settings);
            StartReceiving();
        }
        
        public Connection() {
            // for xml serialization only
        }
        protected void StartReceiving() {
            SystemEventPacket packet = new SystemEventPacket(EventType.connection, "New Connection begun from " + this.IPAddress.ToString(), this);
            settings.SystemEventQueue.Push(packet);
            try {
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ReceiveCallback, state);
            }
            catch (Exception e) {
                settings.SystemMessageQueue.Push("Connection closed: " + e.ToString());               
            }
        }

        public void ReceiveCallback(IAsyncResult ar) {
            try {
                if (state.Socket.Client == null)
                    return;
                int read = state.Socket.Client.EndReceive(ar); 
                if (read > 0) {
                    string incomingMessage = Encoding.ASCII.GetString(state.Buffer, 0, read).StripNewLine();
                    Task HandleMessage = new Task(() => Commands(this, incomingMessage)); // setup thread for dispatching incoming
                    MessageReceivedDone.Set(); 
                    HandleMessage.Start(); // start processing message - in thread
                }
                try {
                    state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, ReceiveCallback, state); // wait for next
                } catch (SocketException se) {
                    return;
                }
            }
            catch (SocketException e) {
                settings.SystemMessageQueue.Push("CC0: " + e.ToString());
            }
            catch (ObjectDisposedException e) {
                settings.SystemMessageQueue.Push("CC1: " + e.ToString());
            }
            catch (Exception e) {
                settings.SystemMessageQueue.Push("CC2: " + e.ToString());
            }
        }

        public void StartLogin() {
            Commands = LoginHandler.OnMessageReceived; // load the login dispatch handler
            LoginHandler.Start(); //
        }

        public void StartPlayer() { // swap out login for player dispatcher handler
            Room = settings.TheVoid;
            PlayerHandler = new PlayerHandler(this, settings);
            Commands = PlayerHandler.OnPlayerMessageReceived;
            LoginHandler = null;
            settings.TheVoid.AddPlayer(this);
        }

        private void SetRoom(Room room) {
            Room = room;
            Account.RoomID = room.RoomID;
            Account.Room = room;
        }

        public void Send(string data, bool indent = true) {
            if (indent) { data = data.Indent(); }
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            try {
                if (state.Socket.Client == null)
                    return;
                state.Socket.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, SendCallback, state);
            } catch (SocketException se) {
                return;
            }
        }

        private void SendCallback(IAsyncResult ar) {
            if (state.Socket.Client == null)
                return;
            try {
                int bytesSent = state.Socket.Client.EndSend(ar);
                MessageSentDone.Set(); // tell parent thread we are good to go
            }
            catch (Exception e) {
                settings.SystemMessageQueue.Push("CC3: " + e.ToString());
            }
        }

        public void Shutdown() {
           // Send("Shutdown process... now.".Color(Ansi.yellow), false);
            Socket.Client.Shutdown(SocketShutdown.Both);
            Socket.Close();
            Save();
        }
        public void Dispose() {
            Socket.Close();
            if(Socket.Client != null) Socket.Client.Dispose();
        }
        protected void Save() {
            string file = settings.PlayersDirectory + "\\" + Account.Name + "_test.xml";
            TextWriter txtWriter = new StreamWriter(file);
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Connection));
                xmlSerializer.Serialize(txtWriter, this);
            } catch (Exception ex) {
                settings.SystemMessageQueue.Push(ex.ToString());
            } finally {
                txtWriter.Close();
            }
        }

        protected bool Load() {
            //throw new NotImplementedException();            
            return false;
        }    

    }

    // data container passed between threads
    public class StateObject {  
        private const int BUFFER_SIZE = 1024;
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public TcpClient Socket { get; set; }
        public StateObject(TcpClient workSocket) {
            Socket = workSocket;
        }
    }
}
