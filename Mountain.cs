﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Mountain.classes;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Mountain.classes.helpers;
using Mountain.classes.collections;

namespace Mountain {

    public partial class Mountain : Form {
        protected ApplicationSettings settings;
        protected MessageQueue Messages;
        protected World world;

        public Mountain() {
            Messages = new MessageQueue(settings);
            Messages.Tag = "System";
            settings = new ApplicationSettings(Messages);
            InitializeComponent();
            Messages.OnMessageReceived += Messages_OnMessageReceived;
            world = BuildDefaultWorld();
            world.StartListen(world.Port);
            logRichTextBox.AppendText("Server has started\r\n");
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
            if (world != null) {
                world.StartListen(world.Port);
                Console.Items.Add("Server has started");
            } else {
                if (world.portListener.Active()) {
                    Console.Items.Add("Server is already running");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e) { //stop server
            //    world.Shutdown();
            //   world = null;
            Console.Items.Add("Shutdown not implemented yet"); // settings.players needs each player to disconnect/save
        }

        private World BuildDefaultWorld() {
            if (world != null) { world = null; }
            world = new World(settings);
            world.settings.Void = world.Areas[0].Rooms.Find(room => room.Name == "Void");
            areaListBox.Items.AddRange(world.Areas.Select(x => x.Name).ToArray());
            areaListBox.SelectedIndex = 0;
            return world;
        }

        private void areaForm_Button_Click(object sender, EventArgs e) {
            AreaForm areaForm = new AreaForm(new Area(), settings);
            DialogResult dialogresult = areaForm.ShowDialog();
            if (dialogresult == DialogResult.OK) {
                world.Areas.Add(areaForm.area);
                world.settings.Void = areaForm.area.Rooms.Find(room => room.Name == "Void");
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
            Area selectedArea = world.Areas.Find(area => area.Name == (string)areaListBox.SelectedItem);
            roomsListBox.Items.Clear();
            roomsListBox.Items.AddRange(selectedArea.Rooms.Select(room => room.Name).ToArray());
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
    }
}
        
    


