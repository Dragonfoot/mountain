﻿using System;
using System.Xml;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Mountain.classes.dataobjects;
using Mountain.classes.handlers;
using Mountain.classes.functions;

namespace Mountain.classes.tcp {

    public class Connection : Identity, IDisposable {
        public TcpClient Socket;
        public StateObject State;
        public ManualResetEvent MessageReceivedDone, MessageSentDone;
        public IPAddress IPAddress;
        public int Port;

        public Room Room;
        public string Password, Email;
        public bool Administrator;
        public Stats Stats { get; set; }
        public Equipment Equipment { get; set; }

        public delegate void CommandHandler(object myObject, string message);
        public CommandHandler Commands;
        public Stack<string> ResponseStack;
        private LoginDispatcher LoginDispatcher;   // login functions
        private PlayerDispatcher PlayerDispatcher; // player functions

        public Connection(TcpClient socket) {
            Socket = socket;
            IPAddress = ((IPEndPoint)socket.Client.RemoteEndPoint).Address;
            Port = ((IPEndPoint)socket.Client.RemoteEndPoint).Port;
            Stats = new Stats();
            Equipment = new Equipment();
            ResponseStack = new Stack<string>();
            MessageReceivedDone = new ManualResetEvent(false);
            MessageSentDone = new ManualResetEvent(false);
            State = new StateObject((socket));
            LoginDispatcher = new LoginDispatcher(this);
            StartReceiving();
        }

        public bool Connected {
            get {
                bool read = Socket.Client.Poll(500, SelectMode.SelectRead);
                bool status = (Socket.Client.Available == 0);
                return !(read & status);
            }
        }

        protected void StartReceiving() {
            SystemEventPacket packet = new SystemEventPacket(EventType.connect, "New Connection begun from " + this.IPAddress.ToString(), this);
            Common.Settings.SystemEventQueue.Push(packet);
            try {
                State.Socket.Client.BeginReceive(State.Buffer, 0, State.Buffer.Length, SocketFlags.None, ReceiveCallback, State);
            } catch (Exception e) {
                Common.Settings.SystemMessageQueue.Push("Connection closed: " + e.ToString());
            }
        }

        public void ReceiveCallback(IAsyncResult ar) {
            try {
                if (State.Socket.Client == null) return;
                int read = State.Socket.Client.EndReceive(ar);
                if (read > 0) {
                    string incomingMessage = Encoding.ASCII.GetString(State.Buffer, 0, read).StripNewLine();
                    Task HandleMessage = new Task(() => Commands(this, incomingMessage)); // setup thread for dispatching incoming
                    MessageReceivedDone.Set();
                    HandleMessage.Start(); // start processing message - (in separate thread)
                }
                try {
                    State.Socket.Client.BeginReceive(State.Buffer, 0, State.Buffer.Length, 0, ReceiveCallback, State); // wait for next
                } catch (Exception ex) when (ex is SocketException || ex is NullReferenceException) {
                    if (ex is NullReferenceException) return; // eat exceptions as connection has terminated in other thread
                }
            } catch (SocketException e) {
                Common.Settings.SystemMessageQueue.Push("Socket Exception: " + e.ToString());
            } catch (ObjectDisposedException e) {
                Common.Settings.SystemMessageQueue.Push("Object Disposed Exception: " + e.ToString());
            } catch (Exception e) {
                Common.Settings.SystemMessageQueue.Push("Connection Exception: " + e.ToString());
            }
        }

        public void StartLogin() {
            Commands = LoginDispatcher.OnMessageReceived;
            LoginDispatcher.Start();
        }

        public void StartPlayer() {
            LoginDispatcher = null;
            PlayerDispatcher = new PlayerDispatcher(this);
            Commands = PlayerDispatcher.OnPlayerMessageReceived;
            SystemEventPacket packet = new SystemEventPacket(EventType.login, this.Name + " has entered the world.", this);
            Common.Settings.SystemEventQueue.Push(packet);
            if (Room == null) SetRoom(null);
            Room.AddPlayer(this);
        }

        private void SetRoom(Room room) {
            if (room == null) room = Common.Settings.TheVoid;
        }

        public void Send(string data, bool indent = true) {
            if (indent) data = data.Indent();
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            try {
                if (State.Socket.Client == null) return;
                State.Socket.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, SendCallback, State);
            } catch (SocketException) {
                return;
            }
        }

        private void SendCallback(IAsyncResult ar) {
            if (State.Socket.Client == null) return;
            try {
                int bytesSent = State.Socket.Client.EndSend(ar);
                MessageSentDone.Set(); // tell parent thread we're finished
            } catch (Exception e) {
                Common.Settings.SystemMessageQueue.Push("CC3: " + e.ToString());
            }
        }

        public void Shutdown() {
            Socket.Client.Shutdown(SocketShutdown.Both);
            Socket.Close();
            SaveXml();
        }

        public void Dispose() {
            Socket.Close();
            if (Socket.Client != null) Socket.Client.Dispose();
        }

        public void SaveXml() {
            string path = Common.Settings.PlayersDirectory + @"\";
            XmlTextWriter writer = new XmlTextWriter(path + Name + "test.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Player");
            XML.createNode("Name", Name, writer);
            XML.createNode("Email", Email, writer);
            XML.createNode("Password", Password, writer);
            XML.createNode("Administrator", Administrator.ToString(), writer);
            XML.createNode("Room", Room.Name, writer);
            XML.createNode("Area", Room.Area.Name, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        public void LoadXml(string filename) {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            Room = Common.Settings.World.RoomByName(doc.DocumentElement.SelectSingleNode("Room").InnerText);
        }
    }    

    
    public class StateObject {  
        private const int Buffer_Size = 1024;
        public byte[] Buffer = new byte[Buffer_Size];
        public TcpClient Socket { get; set; }
        public StateObject(TcpClient workSocket) {
            Socket = workSocket;
        }
    }
}
