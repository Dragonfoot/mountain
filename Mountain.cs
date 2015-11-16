using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Mountain.classes;
using System.IO;
using System.Xml.Serialization;
using Mountain.classes.collections;
using Mountain.classes.handlers;

namespace Mountain {

    public partial class Mountain : Form {
        protected ApplicationSettings settings;
        protected MessageQueue Messages;
        protected World world;
        protected Area SelectedArea;
        protected Room SelectedRoom;

        public Mountain() {
            Messages = new MessageQueue(settings);
            Messages.Tag = "System";
            settings = new ApplicationSettings(Messages);
            InitializeComponent();
            Messages.OnMessageReceived += Messages_OnMessageReceived;
            world = BuildDefaultWorld();
            world.StartListen(world.Port);
            if (world.portListener.Active()) {
                listenerCheckBox.BackColor = System.Drawing.Color.GreenYellow;
                logRichTextBox.AppendText("Server has started\r\n");
            }
        }

        private void Messages_OnMessageReceived(object myObject, string msg) {
            try {
                string message = Messages.Pop();
                if (message == null)
                    message = msg;
                this.Invoke((MethodInvoker)delegate {
                    logRichTextBox.AppendText(">>>" + message + "\r\n");
                    logRichTextBox.ScrollToCaret();
                });
            } catch (Exception e) {
                this.Invoke((MethodInvoker)delegate {
                    logRichTextBox.AppendText(">>>" + e.ToString() + "\r\n");
                    logRichTextBox.ScrollToCaret();
                });
            }
        }

        private void exitProgram_ToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
            //this.world.Save(string.Empty);
        }

        private void serverStart(object sender, EventArgs e) { // start
            if (world.portListener.Active()) {
                listenerCheckBox.BackColor = System.Drawing.Color.GreenYellow;
                Console.Items.Add("Server is already running");
            } else {
                listenerCheckBox.BackColor = System.Drawing.Color.Red;
            }
        }

        private void button6_Click(object sender, EventArgs e) { //stop server
            //    world.Shutdown();
            //   world = null;
            Console.Items.Add("Shutdown not implemented yet"); // settings.players needs each player to disconnect/save
        }

        private World BuildDefaultWorld() {
            if (world != null) { world = null; }
            try {
                world = new World(settings);
                if (world.Areas.Count > 0) {
                    world.settings.TheVoid = world.Areas[0].Rooms.Find(room => room.Tag == "Void");
                    areaListBox.Items.AddRange(world.Areas.Select(x => x.Name).ToArray());
                    areaListBox.SelectedIndex = 0;
                    if(SelectedArea.Rooms.Count > 0) {
                        if(roomsListBox.Items.Count > 0) roomsListBox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception e) {
                logRichTextBox.AppendText(">>> " + e.ToString());
            }
            return world;
        }

        private void areaForm_Button_Click(object sender, EventArgs e) {
            AreaForm areaForm = new AreaForm(new Area(), settings);
            DialogResult dialogresult = areaForm.ShowDialog();
            if (dialogresult == DialogResult.OK) {
                world.Areas.Add(areaForm.area);
                world.settings.TheVoid = areaForm.area.Rooms.Find(room => room.Tag == "Void");
                areaListBox.Items.AddRange(world.Areas.Select(x => x.Name).ToArray());
                areaListBox.SelectedIndex = 0;
            } else {
                if (dialogresult == DialogResult.Cancel) {

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
            string file = settings.BaseDirectory + "\\" + world.Name + "test.xml";
            TextWriter txtWriter = new StreamWriter(file);
            //    XmlHelper.ObjectToXml(world.Areas, file, settings);
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(World));
                xmlSerializer.Serialize(txtWriter, world);
                logRichTextBox.AppendText(world.Name + " Saved.");
            } catch (Exception ex) {
                settings.SystemMessageQueue.Push(ex.ToString());
            } finally {
                txtWriter.Close();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            string file = settings.BaseDirectory + "\\" + world.Name + "test.xml";
            TextReader txtReader = new StreamReader(file);
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(World));
                World loadWorld = new World(settings);
                    loadWorld = (World)xmlSerializer.Deserialize(txtReader);
                loadWorld.portListener.StartServer(9080);
                logRichTextBox.AppendText(world.Name + " Loaded.");
            } catch (Exception ex) {
                settings.SystemMessageQueue.Push(ex.ToString());
            } finally {
                txtReader.Close();
            }
        }

        private void roomsListBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right)
                return;
            var index = roomsListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                roomsListBox.SelectedIndex = index;
                SelectedRoom = SelectedArea.Rooms.Find(room => room.Name == (string)roomsListBox.SelectedItem);
                for (int i = 0; i <= RoomContextMenu.Items.Count - 1; i++) {                    
                    RoomContextMenu.Items[i].Enabled = true;
                }
                RoomContextMenu.Show(Cursor.Position);
            } else {
                roomsListBox.SelectedIndex = -1;
                for(int i = 0; i<= RoomContextMenu.Items.Count - 1; i++) {
                    if (i == 0)
                        continue;
                    RoomContextMenu.Items[i].Enabled = false;
                }
            }
        }

        private void EditRoomContextMenuItem_Click(object sender, EventArgs e) {
            RoomEdit roomEditForm = new RoomEdit(SelectedRoom, settings);
            DialogResult dialogresult = roomEditForm.ShowDialog();
            if (dialogresult == DialogResult.OK) {
                Functions.SetRoomEdits(roomEditForm.roomEdits, SelectedRoom);
                roomsListBox.Items.Clear();
                roomsListBox.Items.AddRange(SelectedArea.Rooms.Select(room => room.Name).ToArray());
            } 
            roomEditForm.Dispose();
        }

        private void roomsListBox_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedRoom = SelectedArea.Rooms.Find(room => room.Name == (string)roomsListBox.SelectedItem);
        }

        private void roomsListBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            var index = roomsListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                roomsListBox.SelectedIndex = index;
                SelectedRoom = SelectedArea.Rooms.Find(room => room.Name == (string)roomsListBox.SelectedItem);
                EditRoomContextMenuItem_Click(sender, e);
            } else {
                roomsListBox.SelectedIndex = -1;
                // NewRoomContextMenuItem_Click(...
            }

        }
    }
}
        
    


