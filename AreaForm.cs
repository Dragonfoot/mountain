using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mountain.classes;
using Mountain.classes.helpers;

namespace Mountain {

    public partial class AreaForm : Form {
        private World world;
        private Area area;

        public AreaForm(World world) {
            InitializeComponent();
            this.world = world;
            area = new Area();
            if (world.Areas.Count > 0) {
                CreateDefaultArea();
            } else {
                CreateDefaultAdminArea();
            }
            DisplayArea();
            RefreshRooms();
        }

        private void DisplayArea() {
            areaGroupBox.Text = area.Name;
            areaDescriptionLabel.Text = area.Description;
        }
        private void RefreshRooms() {
            RoomListBox.Items.Clear();            
            if (area.Rooms.Count > 0) {
                foreach (Room room in area.Rooms) {
                    RoomListBox.Items.Add(room.Name);
                }
            }
        }

         

        private void CreateDefaultAdminArea() {
           // if (File.Exists("path to area template folder.adminTemplate.xml"){
            //    area.Load("adminTemplate.xml");
            //} else {

            area.Name = "Administration Complex";
            area.Description = "One of this worlds extraordinary wonders. It houses top minds from all the major worlds within our galaxy. " +
               "As well it houses the most advanced technological and military equipment available. All this in order to make this world " +
               "the leader in vital galactic government growth and management.";

            Room controlRoom = new Room();
            controlRoom.Name = "Administration Control Center";
            controlRoom.Description = "You see the nerve center of world operations unfold around you. Computer stations with white clad operators quietly " +
                "talking into headsets while they adjust controls and relay information, in a long line of cubicles fading into the distance on your " +
                "right. Radar and sonar sensors, routing maps and scheduling timers all glowing quietly above them. To your left are a long range of office " +
                "doors with armed guards filtering and recording those wanting accessing to each. ";

            Room TransitHub = CreateTransitHubRoom(controlRoom.Name + " transit station", controlRoom.RoomID);
            Exit exit = new Exit();
            exit.link = TransitHub.RoomID;
            exit.Name = "Transit Hub";
            exit.link.Name = "To World Areas";            

            controlRoom.AddExit(exit);
            area.Rooms.Add(controlRoom);
            area.Rooms.Add(TransitHub);
        }
        
        private void CreateDefaultArea() {
            area.Name = "Default New Area";
            Room areaHub = new Room();
            areaHub.Name = "Area Transit Room";
            areaHub.Description = "A hub station between Administration Control Center and area";

            Room TransitHub = CreateTransitHubRoom(areaHub.Name + " transit station", areaHub.RoomID);
            Exit exit = new Exit();
            exit.link = TransitHub.RoomID;
            exit.Name = "Transit Hub";
            exit.link.Name = "To World Areas";

            areaHub.AddExit(exit);
            area.Rooms.Add(areaHub);
            area.Rooms.Add(TransitHub);
        }

        private Room CreateTransitHubRoom(string Name, RoomID roomId) {
            Room hub = new Room(Name);
            hub.Description = "Area's transit point to Administration Transit Hub";

            Exit exit = new Exit();
            exit.Name = "Control Center";
            exit.link.Name = "To Administration Control Center";
            hub.Exits.Add(exit);
            return hub;
        }

        private void ok_Button_Click(object sender, EventArgs e) {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.ok_Button_Click(this, e);
        }

       

        private void areaNameTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                areaGroupBox.Text = areaNameTextBox.Text;
                areaNameTextBox.Visible = false;
            }
        }

        private void areaNameTextBox_Lost_Focus(object sender, EventArgs e) {
            areaGroupBox.Text = areaNameTextBox.Text;
            areaNameTextBox.Visible = false;
            area.Name = areaNameTextBox.Text;
        }

        private void areaDescriptionTextBox_Lost_Focus(object sender, EventArgs e) {
            areaDescriptionLabel.Text = areaDescriptionTextBox.Text;
            area.Description = areaDescriptionTextBox.Text;
            areaDescriptionTextBox.Visible = false;
            areaDescriptionLabel.Visible = true;
        }

        private void areaGroupBox_MouseClick(object sender, MouseEventArgs e) {
            areaNameTextBox.Text = areaGroupBox.Text;
            areaNameTextBox.Visible = true;
            areaNameTextBox.Focus();

        }

        private void descriptionPanel_MouseClick(object sender, MouseEventArgs e) {
            areaDescriptionTextBox.Visible = true;
        }

        private void descriptionLabel_Click(object sender, EventArgs e) {
            areaDescriptionTextBox.Text = areaDescriptionLabel.Text;
            areaDescriptionTextBox.Visible = true;
            areaDescriptionLabel.Visible = false;
            areaDescriptionTextBox.Focus();
        }

        private void areaDescriptionTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                areaDescriptionTextBox_Lost_Focus(sender, new EventArgs());
            }

        }
    }
}
