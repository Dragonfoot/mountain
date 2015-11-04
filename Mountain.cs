using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
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
        protected List<World> worlds;
        protected World world;
        public Room room;

        public Mountain() {
            settings = new ApplicationSettings();
            InitializeComponent();
            BuildWorld();
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
            if (this.room != null) {this.room = null;}
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

        private void serverStart(object sender, EventArgs e) { // start
            //create world and start listener
            if (world == null) {
                world = BuildWorld();
            }
        }

        private void button6_Click(object sender, EventArgs e) {
            //stop server
        }

        private World BuildWorld() {
            if (world != null) { world = null; }
            world = new World(settings);
            world.Name = "Grumpy Mountain";
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

        private void button3_Click(object sender, EventArgs e) {
        }
        private void button2_Click(object sender, EventArgs e) {
            if (this.room != null) {
                richTextBox.AppendText(this.room.SaveXML());
            }
        }
        private string viewXml(object item) {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(item.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings)) {
                serializer.Serialize(writer, item, emptyNamepsaces);
                return stream.ToString();
            }
        }
        private void CreateUserFile() {
            XDocument d = new XDocument(
                new XElement("Users",
                new XElement("User",
                new XElement("Name", "admin"),
                new XElement("Password", "password")
                ))
                );
           // d.Declaration = new XDeclaration("1.0", "utf-8", "true");

         //   d.Save("test.xml");
            richTextBox.Clear();
            richTextBox.AppendText(d.ToString());
        }
    

        private void userButton_Click(object sender, EventArgs e) {
           // CreateUserFile();

        }

        private void configButton_Click(object sender, EventArgs e) {
            richTextBox.Clear();
            richTextBox.AppendText(settings.AppDirectory);
        }
    }
}
