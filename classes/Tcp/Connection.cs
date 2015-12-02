using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Mountain.classes.dataobjects;
using Mountain.classes.handlers;
using Mountain.classes.functions;

namespace Mountain.classes.tcp {

    [XmlRoot("Player")][Serializable] public class Connection : Identity, IDisposable {
        [XmlIgnore][NonSerialized()] public TcpClient Socket;
        [XmlIgnore][NonSerialized()] public Stack<string> ResponseStack;
        [XmlIgnore][NonSerialized()] public CommandHandler Commands;
        [XmlIgnore][NonSerialized()] public ManualResetEvent MessageReceivedDone;
        [XmlIgnore][NonSerialized()] public ManualResetEvent MessageSentDone;
        [XmlIgnore][NonSerialized()] public StateObject state;
        [XmlIgnore][NonSerialized()] public IPAddress IPAddress;
        [XmlIgnore][NonSerialized()] public int Port;
        [NonSerialized()] private LoginDispatcher LoginDispatcher;   // login functions
        [NonSerialized()] private PlayerDispatcher PlayerDispatcher; // player functions
        [XmlIgnore] public bool Connected { get {
                bool read = Socket.Client.Poll(500, SelectMode.SelectRead);
                bool status = (Socket.Client.Available == 0);
                return !(read & status);
            }
        }
        public Linkage Location { get { return location; } set { SetRoom(value.Room); } }
        public Account Account { get; set; }
        public Stats Stats { get; set; }
        public Equipment Equipment { get; set; }
        private Linkage location;
        public delegate void CommandHandler(object myObject, string message);

        public Connection(TcpClient socket) {
            Socket = socket;
            IPAddress = ((IPEndPoint)socket.Client.RemoteEndPoint).Address;
            Port = ((IPEndPoint)socket.Client.RemoteEndPoint).Port;
            Account = new Account();
            Stats = new Stats();
            Equipment = new Equipment();
            ResponseStack = new Stack<string>();
            MessageReceivedDone = new ManualResetEvent(false);
            MessageSentDone = new ManualResetEvent(false);
            state = new StateObject((socket));
            LoginDispatcher = new LoginDispatcher(this);
            StartReceiving();
        }
        
        public Connection() { // empty, for xml serialization
        }

        protected void StartReceiving() {
            SystemEventPacket packet = new SystemEventPacket(EventType.connection, "New Connection begun from " + this.IPAddress.ToString(), this);
            Global.Settings.SystemEventQueue.Push(packet);
            try {
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ReceiveCallback, state);
            }
            catch (Exception e) {
                Global.Settings.SystemMessageQueue.Push("Connection closed: " + e.ToString());               
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
                    HandleMessage.Start(); // start processing message - (in separate thread)
                }
                try {
                    state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, ReceiveCallback, state); // wait for next
                } catch (Exception ex) when (ex is SocketException || ex is NullReferenceException) {
                    if(ex is NullReferenceException) return;
                }
            }
            catch (SocketException e) {
                Global.Settings.SystemMessageQueue.Push("CC0: " + e.ToString());
            }
            catch (ObjectDisposedException e) {
                Global.Settings.SystemMessageQueue.Push("CC1: " + e.ToString());
            }
            catch (Exception e) {
                Global.Settings.SystemMessageQueue.Push("CC2: " + e.ToString());
            }
        }

        public void StartLogin() {
            Commands = LoginDispatcher.OnMessageReceived; 
            LoginDispatcher.Start(); 
        }

        public void StartPlayer() {
            PlayerDispatcher = new PlayerDispatcher(this);
            LoginDispatcher = null;
            Commands = PlayerDispatcher.OnPlayerMessageReceived;
            SystemEventPacket packet = new SystemEventPacket(EventType.login, this.Account.Name + " has entered the world.", this);
            Global.Settings.SystemEventQueue.Push(packet);
            Location.Room.AddPlayer(this);

        }

        private void SetRoom(Room room) {
            Account.Location = location = new Linkage(room.Name, room.Location.Area, room);
        }

        public void Send(string data, bool indent = true) {
            if (indent) data = data.Indent(); 
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            try {
                if (state.Socket.Client == null) return;
                state.Socket.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, SendCallback, state);
            } catch (SocketException) {
                return;
            }
        }

        private void SendCallback(IAsyncResult ar) {
            if (state.Socket.Client == null) return;
            try {
                int bytesSent = state.Socket.Client.EndSend(ar);
                MessageSentDone.Set(); // tell parent thread we're finished
            }
            catch (Exception e) {
                Global.Settings.SystemMessageQueue.Push("CC3: " + e.ToString());
            }
        }

        public void Shutdown() {
            Socket.Client.Shutdown(SocketShutdown.Both);
            Socket.Close();
            Save();
        }
        public void Dispose() {
            Socket.Close();
            if(Socket.Client != null) Socket.Client.Dispose();
        }
        protected void Save() {
            string file = Global.Settings.PlayersDirectory + "\\" + Account.Name + "_test.xml";
            TextWriter textWriter = new StreamWriter(file);
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Connection));
                xmlSerializer.Serialize(textWriter, this);
            } catch (Exception ex) {
                Global.Settings.SystemMessageQueue.Push(ex.ToString());
            } finally {
                textWriter.Close();
            }
            textWriter.Close();
        }


    }
    
    public class StateObject {  
        private const int BUFFER_SIZE = 1024;
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public TcpClient Socket { get; set; }
        public StateObject(TcpClient workSocket) {
            Socket = workSocket;
        }
    }
}
