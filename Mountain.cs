using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mountain.classes;

namespace Mountain {
    public partial class Mountain : Form {
        protected List<World> worlds;
        protected World world;
        public Room room;

        public Mountain() {
            //this.world = new World(string.Empty);

            InitializeComponent();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e) {
            // this.world.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
            //this.world.Save(string.Empty);
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
            Console.DataSource = null;
            Console.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e) {
            // look at room
            if (this.room != null) {
                Console.DataSource = null;
                Console.Items.Clear();
                Console.Items.AddRange(this.room.View());
            }
        }

        private void button5_Click_1(object sender, EventArgs e) { // start
            //create world and start listener
            if (world == null) {
                world = BuildWorld(Console);
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            //stop server
        }

        private World BuildWorld(ListBox console) {
            World world = new World(console);
            return world;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e) {
            AreaForm areaForm = new AreaForm();
            DialogResult dialogresult = areaForm.ShowDialog();
            if (dialogresult == DialogResult.OK) {
            } else if (dialogresult == DialogResult.Cancel) {
            }
            areaForm.Dispose();
        }
    }

}
