using System;
using System.Linq;
using System.Windows.Forms;
using Mountain.classes;
using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.Dialogs {

    public partial class AreaForm : Form {
        public Area area;

        public AreaForm(Area area) {
            this.area = area;
            InitializeComponent();
            DisplayArea();
            RefreshRooms();
        }

        private void DisplayArea() {
            areaGroupBox.Text = area.Name;
            areaDescriptionLabel.Text = area.Description;
        }

        private void RefreshRooms() {
            RoomListBox.Items.Clear();
            if (area.Rooms.Any()) {
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

        private void ok_Button_Click(object sender, EventArgs e) {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            ok_Button_Click(this, e);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            saveAreaFileDialog.InitialDirectory = GBL.Settings.BaseDirectory;
            if (saveAreaFileDialog.ShowDialog() == DialogResult.OK) 
                XML.ObjectToXml(area.Rooms, saveAreaFileDialog.FileName);            
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
            if (e.KeyChar == (char)13) areaDescriptionTextBox_Lost_Focus(sender, new EventArgs());            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e) {
            CreateDefaultAdminArea();
            RefreshRooms();
        }        
    }
}
