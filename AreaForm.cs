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
        private ApplicationSettings settings;
        public Area area;

        public AreaForm(Area area) {
            this.area = area;
            InitializeComponent();
            settings = new ApplicationSettings(null);
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
            area = Build.AdminArea();
            DisplayArea();
            RefreshRooms();
        }
        
        private void CreateDefaultArea() {
         /*   area.Name = "Default New Area";
            Room areaHub = new Room();
            areaHub.SetName("Area Transit Room");
            areaHub.Description = "A hub station between Administration Control Center and area";

            Room TransitHub = CreateTransitHubRoom("Transit Hub", new RoomID(Guid.NewGuid(), "Transit Hub"));
            Exit exit = new Exit();
            exit.linkTo = areaHub.RoomID;
            exit.Name = "Central";
            exit.linkTo.Name = "To Area Hub";

            areaHub.AddExit(exit);
            area.Rooms.Add(areaHub);
            area.Rooms.Add(TransitHub);*/
        }


        private Room BuildRoom(string name, string description) { // stub - move to static builder class in helpers
           Room room = new Room(name); 
            room.Description = description;
            return room;
        }

       private Exit BuildExit() { // stub - move to static builder class in helpers
            Exit exit = new Exit();
            return exit;
       }

        private Room BuildVoid() { // stub - move to static builder class in helpers
            string voidDesciption = "You find youself weightlessly floating in some kind of silent, lonely, dark, " +
                "endless, and as many other voidy words there might be.. space.";
            Room room = BuildRoom("Void", voidDesciption);
            return room;
        }






        private void ok_Button_Click(object sender, EventArgs e) {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.ok_Button_Click(this, e);
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            saveAreaFileDialog.InitialDirectory = settings.BaseDirectory;
            if (saveAreaFileDialog.ShowDialog() == DialogResult.OK) {
                XmlHelper.ObjectToXml(area.Rooms, saveAreaFileDialog.FileName);
            }
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

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            CreateDefaultAdminArea();
            RefreshRooms();
        }
    }
}
