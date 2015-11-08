using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Mountain.classes;
using Mountain.classes.helpers;

namespace Mountain {

    public partial class Mountain : Form {
        protected ApplicationSettings settings;
        protected MessageQueue Messages;
        protected World world;

        public Mountain() {
            settings = new ApplicationSettings(Messages);
            InitializeComponent();
            Messages = new MessageQueue();
            this.Messages.OnMessageReceived += Messages_OnMessageReceived;
            world = BuildEmptyWorld();
            Console.Items.Add("Server has started");
        }

        private void Messages_OnMessageReceived(object myObject, string msg) {
            string message = Messages.Pop();
            if (message==null)  message = msg;
            Console.Items.Add(message);
        }

        private void exitProgram_ToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
            //this.world.Save(string.Empty);
        }
        
        private void serverStart(object sender, EventArgs e) { // start
            //create world and start listener
            if (world == null) {
                world = BuildEmptyWorld();
                Console.Items.Add("Server has started");
            } else {
                Console.Items.Add("Server is already running");
            }
        }

        private void button6_Click(object sender, EventArgs e) { //stop server
        //    world.Shutdown();
         //   world = null;
            Console.Items.Add("Shutdown not implemented yet"); // settings.players needs each player to disconnect/save
        }

        private World BuildEmptyWorld() {
            if (world != null) { world = null; }
            world = new World(settings);
            world.Name = "Mountain";
            return world;
        }

        private void areaForm_Button_Click(object sender, EventArgs e) { 
            AreaForm areaForm = new AreaForm(new Area());
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
    }
}
