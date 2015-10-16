using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mountain.classes;

namespace Mountain {
    public partial class Client : Form {
        protected List<World> worlds;
        protected World world;
        public Room room;

        public Client() {
            this.world = new World(Properties.Settings.Default.LastWorldSaved);

            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e) {
            this.world.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.world.Save(string.Empty);
        }

        // room testing
        private void button1_Click(object sender, EventArgs e) {
            // create room
            if (this.room != null) {
                this.room = null;
            }
            this.room = new Room();
            Exit exit = new Exit();
            exit.Name = "South";
            room.AddExit(exit);
            exit = new Exit();
            exit.Name = "East";
            room.AddExit(exit);
            Mob mob = new Mob();
            mob.Name = "farmerClive";
            room.AddMob(mob);
            mob = new Mob();
            mob.Name = "bullyboy";
            room.AddMob(mob);

            button5_Click(this, e); // look at room
        }

        private void button4_Click(object sender, EventArgs e) {
            //destroy room
            this.room = null;
            listBox.DataSource = null;
            listBox.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e) {
            // look at room
            if (this.room != null) {
                listBox.DataSource = null;
                listBox.Items.Clear();
                listBox.Items.AddRange(this.room.View());
            }
        }

        private void button5_Click_1(object sender, EventArgs e) { // start
            //create world and start listener
            if (world == null) {
                this.BuildWorld();
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            //stop server
        }

        private World BuildWorld() {
            World world = new World("");
            return world;
        }
    }
}
