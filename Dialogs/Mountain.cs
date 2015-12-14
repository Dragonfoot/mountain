using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Mountain.classes;
using Mountain.classes.tcp;
using Mountain.classes.functions;
using Mountain.classes.collections;
using Mountain.classes.dataobjects;

namespace Mountain.Dialogs {

    public partial class Mountain : Form, IDisposable {
        protected MessageQueue MessageQueue;
        protected SystemEventQueue SystemEventQueue;
        protected World world;
        protected Area SelectedArea;
        protected Room SelectedRoom;
        protected int Connections;

        public Mountain() {
            MessageQueue = new MessageQueue();
            SystemEventQueue = new SystemEventQueue();
            Common.Settings = new ApplicationSettings(MessageQueue, SystemEventQueue);
            MessageQueue.Tag = "System";
            InitializeComponent();
            MessageQueue.OnMessageReceived += Messages_OnMessageReceived;
            SystemEventQueue.OnEventReceived += Events_OnEventReceived;
            world = BuildWorldAdminSection();
            Common.Settings.World = world;
            // todo: load last saved world else load default world, if no default, build basic default area
            world.StartAcceptingConnections(world.Port);
            if (world.portListener.Active()) {
                listenerCheckBox.BackColor = System.Drawing.Color.GreenYellow;
                connectionPoller.Enabled = true;
                Console.Items.Add("System: Server has started.");
            }
            SetEditor();
            SyncControls();
        }

        private void SetEditor() {
            if (SelectedRoom == null) SelectedRoom = Common.Settings.TheVoid;
            roomNameButton.Text = SelectedRoom.Name;
            roomDescriptionRichTextBox.Clear();
            roomDescriptionRichTextBox.AppendText(SelectedRoom.Description);
            ToolStripButton exitsLabel = new ToolStripButton("Exits:");
            exitsLabel.AutoToolTip = false;
            exitsLabel.Height = 16;
            exitsLabel.Margin = new Padding(6,0,0,0);

            ToolStrip strip = new ToolStrip();
            strip.Renderer = new ToolStripOverride();
            strip.GripStyle = ToolStripGripStyle.Hidden;
            strip.BackColor = System.Drawing.Color.Black;
            strip.Height = 20;
            strip.Margin = new Padding(0);
            strip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            strip.CanOverflow = false;
            exitLayoutPanel.Controls.Clear();
            strip.Items.Add(exitsLabel);
            foreach (Exit exit in SelectedRoom.Exits) {
                ToolStripSplitButton button = new ToolStripSplitButton(exit.ToString());
                button.AutoToolTip = false;
                button.Height = 16;
                button.Margin = new Padding(0);
                button.DropDownItems.Add("GoTo");
                button.DropDownItems.Add("Rename");
                button.DropDownItems.Add("Remove");
                strip.Items.Add(button);
            }
            exitLayoutPanel.Controls.Add(strip);
        }

        private void SyncControls() {
            if (areaComboBox.Items.Contains(SelectedRoom.Area.Name)) {
                areaComboBox.SelectedIndex = areaComboBox.Items.IndexOf(SelectedRoom.Area.Name);
                roomsListBox.SelectedIndex = roomsListBox.Items.IndexOf(SelectedRoom.Name);
            }
        }

        private void Events_OnEventReceived(object myObject, SystemEventPacket eventPacket) {
            try {
                SystemEventPacket packet = SystemEventQueue.Pop();
                if (packet == null) packet = eventPacket;
                switch (packet.eventType) {
                    case EventType.connect: Connections++; break;
                    case EventType.disconnect:
                        int index = connectedListBox.FindString(packet.Client.Name);
                        Invoke((MethodInvoker)delegate { connectedListBox.Items.RemoveAt(index); });
                        Connections--;
                        break;
                    case EventType.login:
                        string newPlayer = packet.Client.Name + " : " + packet.Client.IPAddress.ToString() + ":" + packet.Client.Port.ToString();
                        Invoke((MethodInvoker)delegate { connectedListBox.Items.Add(newPlayer); });
                        break;
                }

                Invoke((MethodInvoker)delegate {
                    connectedLabel.Text = Connections.ToString();
                    Console.Items.Add("Event: " + packet.message);
                });
            } catch (Exception e) {
                Invoke((MethodInvoker)delegate {
                    Console.Items.Add("Event Error: " + e.ToString());
                });
            }
        }

        private void Messages_OnMessageReceived(object myObject, string msg) {
            try {
                string message = MessageQueue.Pop();
                if (message == null) message = msg;

                Invoke((MethodInvoker)delegate {
                    Console.Items.Add("Message: " + message);
                });
            } catch (Exception e) {
                Invoke((MethodInvoker)delegate {
                    Console.Items.Add("Message Error: " + e.ToString());
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
                Console.Items.Add("System: Server is already running.");
            } else listenerCheckBox.BackColor = System.Drawing.Color.Red;

        }

        private void button6_Click(object sender, EventArgs e) { //stop server
            //    world.Shutdown();
            //   world = null;
            Console.Items.Add("System: Shutdown not implemented."); // settings.players each player disconnect/save
        }

        private World BuildWorldAdminSection() {
            if (world != null) { world = null; }
            try {
                world = new World();
                if(world.Areas.Any()) areaComboBox.Items.AddRange(world.Areas.Select(x => x.Name).ToArray());
                areaComboBox.SelectedIndex = 0;
                if (SelectedArea != null) {
                    if (SelectedArea.Rooms.Any()) {
                        if (roomsListBox.Items.Count > 0) roomsListBox.SelectedIndex = 0;
                    }
                }
            } catch (Exception e) {
                Console.Items.Add("Error: " + e.ToString());
            }
            return world;
        }

        private void areaForm_Button_Click(object sender, EventArgs e) {
            AreaForm areaForm = new AreaForm(new Area());
            DialogResult dialogresult = areaForm.ShowDialog();
            if (dialogresult == DialogResult.OK) {
                world.Areas.Add(areaForm.area);
                Common.Settings.TheVoid = areaForm.area.Rooms.FindTag("Void");
                areaComboBox.Items.AddRange(world.Areas.Select(x => x.Name).ToArray());
                areaComboBox.SelectedIndex = 0;
            } else {
                if (dialogresult == DialogResult.Cancel) {
                    //
                }
            }
            areaForm.Dispose();
        }

        private void areaComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            string name = areaComboBox.SelectedItem.ToString();
            SelectedArea = world.Areas.Find(area => area.Name == (string)areaComboBox.SelectedItem);
            roomsListBox.Items.Clear();
            roomsListBox.Items.AddRange(SelectedArea.Rooms.Select(room => room.Name).ToArray());
            SelectedRoom = SelectedArea.Rooms.List[0];
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
          /*  string file = Common.Settings.BaseDirectory + "\\" + world.Name + "test.xml";
            TextWriter txtWriter = new StreamWriter(file);
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(World));
                xmlSerializer.Serialize(txtWriter, world);
                logRichTextBox.AppendText(world.Name + " Saved.");
            } catch (Exception ex) {
                Common.Settings.SystemMessageQueue.Push(ex.ToString());
            } finally {
                txtWriter.Close();
            }*/
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
         /*   string name = "mountain";
            string file = Common.Settings.BaseDirectory + "\\" + name + "test.xml";
            TextReader txtReader = new StreamReader(file);
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(World));
                // World loadWorld = new World(settings);
                world.Areas.Clear();
                world = (World)xmlSerializer.Deserialize(txtReader);
                world.portListener.StartServer(9080);
                logRichTextBox.AppendText(world.Name + " Loaded.");
            } catch (Exception ex) {
                Common.Settings.SystemMessageQueue.Push(ex.ToString());
            } finally {
                txtReader.Close();
            }*/
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
            SetEditor();
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
        //    string xml = SelectedArea.ToXml();
            Console.Items.Clear();
        //    logRichTextBox.AppendText(xml);
        }

        private void connectionPoller_Tick(object sender, EventArgs e) {
            CheckConnections();
        }

        private void CheckConnections() {
            List<Connection> RemoveList = new List<Connection>();
            foreach (Connection player in Common.Settings.Players) {
                if (player.Connected) continue;
                RemoveList.Add(player);
            }
            foreach (Connection player in RemoveList) {
                Common.Settings.Players.Remove(player.Name, "Lost connection.");
                player.Room.Players.Remove(player.Name);
                SystemEventPacket packet = new SystemEventPacket(EventType.disconnect, player.Name + " lost connection.");
                Common.Settings.SystemEventQueue.Push(packet);
                player.Shutdown();
                player.Dispose();
            }
        }

        private void NewContextMenuItem_Click(object sender, EventArgs e) {
            Room newRoom = new Room("New Room", "This is the new room description", SelectedArea);
            RoomEditor roomEdit = new RoomEditor(newRoom);
            DialogResult dialogresult = roomEdit.ShowDialog();
            if (dialogresult == DialogResult.OK) {
                Function.UpdateRoomEdits(roomEdit.Room, newRoom);
                SelectedArea.Rooms.Add(newRoom);
                roomsListBox.Items.Clear();
                roomsListBox.Items.AddRange(SelectedArea.Rooms.Select(room => room.Name).ToArray());
            }
            roomEdit.Dispose();
        }

        private void button2_Click(object sender, EventArgs e) {
            world.SaveXml(@"/testWorld.xml");
        }

        private void loadXmlButton_Click(object sender, EventArgs e) {
            world.LoadXml(@"/testWorld.xml");
        }

        public new void Dispose() {
            MessageQueue.OnMessageReceived -= Messages_OnMessageReceived;
            SystemEventQueue.OnEventReceived -= Events_OnEventReceived;
            base.Dispose();
        }

        private void commandsTextBox_TextChanged(object sender, EventArgs e) {

        }

        private void commandsTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {

            }
        }

        private void roomDescriptionRichTextBox_ContentsResized(object sender, ContentsResizedEventArgs e) {
            roomDescriptionRichTextBox.Height = e.NewRectangle.Height + 5;
        }
        
    }
    public class ToolStripOverride : ToolStripProfessionalRenderer {
        public ToolStripOverride() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) {
            if (!e.Item.Selected) {
                base.OnRenderButtonBackground(e);
            } else {
                Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
                e.Graphics.FillRectangle(Brushes.DarkCyan, rectangle);
                e.Graphics.DrawRectangle(Pens.DarkCyan, rectangle);
            }
        }
    }
}
        
    


