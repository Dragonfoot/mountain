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
        protected World World;
        public Room room;

        public Client() {
            this.World = new World();
            this.World.Load(Properties.Settings.Default.LastWorldSaved);

            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e) {
            this.World.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.World.Save(string.Empty);
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
            Player player = new Player();
            player.Name = "Toetag";
            room.AddPlayer(player);

            button5_Click(this, e);
        }

        private void button4_Click(object sender, EventArgs e) {
            //clear room.. destroy
            this.room = null;
            listBox1.DataSource = null;
            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e) {
            // look at room
            if (this.room != null) {
                listBox1.DataSource = null;
                listBox1.Items.Clear();
                listBox1.Items.AddRange(this.room.View());
            }
        }
    }
}
