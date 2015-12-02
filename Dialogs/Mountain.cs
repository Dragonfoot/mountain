using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using Mountain.classes;
using Mountain.classes.tcp;
using Mountain.classes.functions;
using Mountain.classes.collections;
using Mountain.classes.dataobjects;

namespace Mountain.Dialogs {

    public partial class Mountain : Form {
        protected MessageQueue MessageQueue;
        protected SystemEventQueue SystemEventQueue;
        protected World world;
        protected Area SelectedArea;
        protected Room SelectedRoom;
        protected int Connections;

        public Mountain() {
            Global.Settings = new ApplicationSettings(MessageQueue, SystemEventQueue);
            MessageQueue = new MessageQueue();
            SystemEventQueue = new SystemEventQueue();
            MessageQueue.Tag = "System";
            InitializeComponent();
            MessageQueue.OnMessageReceived += Messages_OnMessageReceived;
            SystemEventQueue.OnEventReceived += Events_OnEventReceived;
            world = BuildDefaultWorld();
            Global.Settings.world = world;
            world.StartListen(world.Port);
            if (world.portListener.Active()) {
                listenerCheckBox.BackColor = System.Drawing.Color.GreenYellow;
                logRichTextBox.AppendText("Server has started\r\n");
            }
            connectionPoller.Enabled = true;
        }

        private void Events_OnEventReceived(object myObject, SystemEventPacket eventPacket) {
            try {
                SystemEventPacket packet = this.SystemEventQueue.Pop();
                if (packet == null) packet = eventPacket;
                switch (packet.eventType) {
                    case EventType.connection: Connections++; break;
                    case EventType.disconnected:
                        int index = connectedListBox.FindString(packet.Client.Account.Name);
                        Invoke((MethodInvoker)delegate { connectedListBox.Items.RemoveAt(index); });
                        Connections--;
                        break;
                    case EventType.login:
                        string newPlayer = packet.Client.Account.Name + " : " + packet.Client.IPAddress.ToString() + ":" + packet.Client.Port.ToString();
                        Invoke((MethodInvoker)delegate { connectedListBox.Items.Add(newPlayer); });
                        break;
                }

                Invoke((MethodInvoker)delegate {
                    connectedLabel.Text = Connections.ToString();
                    logRichTextBox.AppendText(">>>" + packet.message + "\r\n");
                    logRichTextBox.ScrollToCaret();
                });
            } catch (Exception e) {
                Invoke((MethodInvoker)delegate {
                    logRichTextBox.AppendText(">>>" + e.ToString() + "\r\n");
                    logRichTextBox.ScrollToCaret();
                });
            }
        }

        private void Messages_OnMessageReceived(object myObject, string msg) {
            try {
                string message = MessageQueue.Pop();
                if (message == null) message = msg;

                Invoke((MethodInvoker)delegate {
                    logRichTextBox.AppendText(">>>" + message + "\r\n");
                    logRichTextBox.ScrollToCaret();
                });
            } catch (Exception e) {
                Invoke((MethodInvoker)delegate {
                    logRichTextBox.AppendText(">>>" + e.ToString() + "\r\n");
                    logRichTextBox.ScrollToCaret();
                });
            }
        }

        private void exitProgram_ToolStripMenuItem_Click(object sender, EventArgs e) {
            world.Shutdown();
            Close();
            //this.world.Save(string.Empty);
        }

        private void serverStart(object sender, EventArgs e) { // start
            if (world.portListener.Active()) {
                listenerCheckBox.BackColor = System.Drawing.Color.GreenYellow;
                Console.Items.Add("Server is already running");
            } else listenerCheckBox.BackColor = System.Drawing.Color.Red;

        }

        private void button6_Click(object sender, EventArgs e) { //stop server
            //    world.Shutdown();
            //   world = null;
            Console.Items.Add("Shutdown not implemented quite yet"); // settings.players needs each player to disconnect/save
        }

        private World BuildDefaultWorld() {
            if (world != null) { world = null; }
            try {
                world = new World();
                if (world.Areas.Any()) {
                    areaListBox.Items.AddRange(world.Areas.Select(x => x.Name).ToArray());
                    areaListBox.SelectedIndex = 0;
                    if (SelectedArea.Rooms.Any()) {
                        if (roomsListBox.Items.Count > 0) roomsListBox.SelectedIndex = 0;
                    }
                }
            } catch (Exception e) {
                logRichTextBox.AppendText(">>> " + e.ToString());
            }
            return world;
        }

        private void areaForm_Button_Click(object sender, EventArgs e) {
            AreaForm areaForm = new AreaForm(new Area());
            DialogResult dialogresult = areaForm.ShowDialog();
            if (dialogresult == DialogResult.OK) {
                world.Areas.Add(areaForm.area);
                Global.Settings.TheVoid = areaForm.area.Rooms.FindTag("Void");
                areaListBox.Items.AddRange(world.Areas.Select(x => x.Name).ToArray());
                areaListBox.SelectedIndex = 0;
            } else {
                if (dialogresult == DialogResult.Cancel) {
                    //
                }
            }
            areaForm.Dispose();
        }

        private void areaListBox_SelectedIndexChanged(object sender, EventArgs e) {
            string name = areaListBox.SelectedItem.ToString();
            SelectedArea = world.Areas.Find(area => area.Name == (string)areaListBox.SelectedItem);
            roomsListBox.Items.Clear();
            roomsListBox.Items.AddRange(SelectedArea.Rooms.Select(room => room.Name).ToArray());
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            string file = Global.Settings.BaseDirectory + "\\" + world.Name + "test.xml";
            TextWriter txtWriter = new StreamWriter(file);
            //XmlHelper.ObjectToXml(world.Areas, file, settings);
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(World));
                xmlSerializer.Serialize(txtWriter, world);
                logRichTextBox.AppendText(world.Name + " Saved.");
            } catch (Exception ex) {
                Global.Settings.SystemMessageQueue.Push(ex.ToString());
            } finally {
                txtWriter.Close();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            string name = "mountain";
            string file = Global.Settings.BaseDirectory + "\\" + name + "test.xml";
            TextReader txtReader = new StreamReader(file);
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(World));
                // World loadWorld = new World(settings);
                world.Areas.Clear();
                world = (World)xmlSerializer.Deserialize(txtReader);
                world.portListener.StartServer(9080);
                logRichTextBox.AppendText(world.Name + " Loaded.");
            } catch (Exception ex) {
                Global.Settings.SystemMessageQueue.Push(ex.ToString());
            } finally {
                txtReader.Close();
            }
        }

        private void roomsListBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right) return;
            var index = roomsListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                roomsListBox.SelectedIndex = index;
                SelectedRoom = SelectedArea.Rooms.FindName((string)roomsListBox.SelectedItem);
                for (int i = 0; i <= RoomContextMenu.Items.Count - 1; i++) {
                    RoomContextMenu.Items[i].Enabled = true;
                }
                RoomContextMenu.Show(Cursor.Position);
            } else {
                roomsListBox.SelectedIndex = -1;
                for (int i = 0; i <= RoomContextMenu.Items.Count - 1; i++) {
                    if (i == 0) continue;
                    RoomContextMenu.Items[i].Enabled = false;
                }
            }
        }

        private void EditRoomContextMenuItem_Click(object sender, EventArgs e) {
            RoomEditor roomEdit = new RoomEditor(SelectedRoom);
            DialogResult dialogresult = roomEdit.ShowDialog();
            if (dialogresult == DialogResult.OK) {
                //    Functions.UpdateRoomEdits(roomEditForm.roomEdits, SelectedRoom);
                //    roomsListBox.Items.Clear();
                //    roomsListBox.Items.AddRange(SelectedArea.Rooms.Select(room => room.Name).ToArray());
            }
            roomEdit.Dispose();
        }

        private void roomsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedRoom = SelectedArea.Rooms.FindName((string)roomsListBox.SelectedItem);
        }

        private void roomsListBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            var index = roomsListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                roomsListBox.SelectedIndex = index;
                SelectedRoom = SelectedArea.Rooms.FindName((string)roomsListBox.SelectedItem);
                EditRoomContextMenuItem_Click(sender, e);
            } else {
                roomsListBox.SelectedIndex = -1;
                // NewRoomContextMenuItem_Click(...
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            string xml = SelectedArea.ToXml();
            logRichTextBox.Clear();
            logRichTextBox.AppendText(xml);
        }

        private void connectionPoller_Tick(object sender, EventArgs e) {
            CheckConnections();
        }

        private void CheckConnections() {
            List<Connection> RemoveList = new List<Connection>();
            foreach (Connection player in Global.Settings.Players) {
                if (player.Connected) continue;
                RemoveList.Add(player);
            }
            foreach (Connection player in RemoveList) {
                Global.Settings.Players.Remove(player.Account.Name, "Lost connection.");
                player.Location.Room.Players.Remove(player.Account.Name);
                SystemEventPacket packet = new SystemEventPacket(EventType.disconnected, player.Account.Name + " lost connection.");
                Global.Settings.SystemEventQueue.Push(packet);
                player.Shutdown();
                player.Dispose();
            }
        }

        private void NewContextMenuItem_Click(object sender, EventArgs e) {
            Room newRoom = new Room("New Room", "This is the new room description", SelectedArea);
            RoomEditor roomEdit = new RoomEditor(newRoom);
            DialogResult dialogresult = roomEdit.ShowDialog();
            if (dialogresult == DialogResult.OK) {
                Functions.UpdateRoomEdits(roomEdit.Room, newRoom);
                SelectedArea.Rooms.Add(newRoom);
                roomsListBox.Items.Clear();
                roomsListBox.Items.AddRange(SelectedArea.Rooms.Select(room => room.Name).ToArray());
            }
            roomEdit.Dispose();
        }

    }
}
        
    


