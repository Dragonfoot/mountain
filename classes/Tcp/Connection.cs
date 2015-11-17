using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Mountain.classes.dataobjects;
using Mountain.classes.handlers;
using Mountain.classes.functions;

namespace Mountain.classes.tcp {

    public class Connection {
        private StateObject state { get; set; }
        public TcpClient Socket { get; set; }
        public ApplicationSettings settings;
        private LoginHandler LoginHandler;   // login functions
        private PlayerHandler PlayerHandler; // player functions
     //   private AdminHandler AdminHandler; // to-do admin functions
        public CommandHandler Commands;
        public Account Account { get; set; }
        public Room Room { get; set; }
        private readonly ManualResetEvent MessageReceivedDone;
        private readonly ManualResetEvent MessageSentDone;
        public delegate void CommandHandler(object myObject, string message);

        public Connection(TcpClient socket, ApplicationSettings appSettings) {
            Socket = socket;
            settings = appSettings;
            Account = new Account();
            MessageReceivedDone = new ManualResetEvent(false);
            MessageSentDone = new ManualResetEvent(false);
            state = new StateObject((socket));
            LoginHandler = new LoginHandler(this, settings);
            StartReceiving();
        }

        protected void StartReceiving() {
            try {
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ReceiveCallback, state);
            }
            catch (Exception e) {
                settings.SystemMessageQueue.Push("Connection closed: " + e.ToString());               
            }
        }
        public void ReceiveCallback(IAsyncResult ar) {
            try {
                int read = state.Socket.Client.EndReceive(ar); // get number of bytes read in
                if (read > 0) {
                    string incomingMessage = Encoding.ASCII.GetString(state.Buffer, 0, read).StripNewLine();
                    Task HandleMessage = new Task(() => Commands(this, incomingMessage)); // setup thread for dispatcher
                    HandleMessage.Start(); // start thread
                    MessageReceivedDone.Set(); // tell calling thread we are now done here
                }
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, ReceiveCallback, state); // wait for next
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
            state.Socket.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, SendCallback, state);
        }

        private void SendCallback(IAsyncResult ar) { // delegate that runs once the send thread has finished
            try {
                int bytesSent = state.Socket.Client.EndSend(ar);
                MessageSentDone.Set(); // tell parent thread we are good to go
            }
            catch (Exception e) {
                settings.SystemMessageQueue.Push("CC3: " + e.ToString());
            }
        }

        public void Shutdown() {
            Send("Shutting down now.".Color(Ansi.yellow), false);
            Socket.Client.Shutdown(SocketShutdown.Both);
            Socket.Close();
            Save();
        }

        protected void Save() {
            //throw new NotImplementedException();
        }

        protected bool Load() {
            //throw new NotImplementedException();            
            return false;
        }
    }

    // data container that's passed between threads to maintain state
    public class StateObject {  
        private const int BUFFER_SIZE = 1024;
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public TcpClient Socket { get; set; }
        public StateObject(TcpClient workSocket) {
            Socket = workSocket;
        }
    }
}
