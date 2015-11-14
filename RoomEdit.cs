using System;
using System.Windows.Forms;
using Mountain.classes;

namespace Mountain {

    public partial class RoomEdit : Form {
        Room room;
        ApplicationSettings settings;

        public RoomEdit(Room room, ApplicationSettings settings) {
            InitializeComponent();
            this.room = room;
            this.NameLabel.Text = room.Name;
            this.descriptionLabel.Text = room.Description;
            this.settings = settings;
        }

        private void descriptionLabel_Click(object sender, EventArgs e) {
            descriptionTextBox.Text = descriptionLabel.Text;
            descriptionTextBox.Visible = true;
            descriptionLabel.Visible = false;
            descriptionTextBox.Focus();
        }
        
        private void descriptionTextBox_Lost_Focus(object sender, EventArgs e) {
            descriptionLabel.Text = descriptionTextBox.Text;
            room.Description = descriptionTextBox.Text;
            descriptionTextBox.Visible = false;
            descriptionLabel.Visible = true;
        }

        private void descriptionTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                descriptionTextBox_Lost_Focus(sender, new EventArgs());
            }
        }
    }
}
