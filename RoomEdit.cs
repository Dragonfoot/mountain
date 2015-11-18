using System;
using System.Windows.Forms;
using System.Linq;
using Mountain.classes;
using Mountain.classes.functions;

namespace Mountain {

    public partial class RoomEdit : Form {
        public Room room, roomEdits;
        ApplicationSettings settings;
        bool nameChanged, descriptionChanged;
        string name, description;

        private void roomNameTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            switch (e.KeyChar) {
                case (char)Keys.Return:
                    descriptionTextBox.Focus();
                    break;
                case (char)Keys.Escape:
                    roomNameTextBox.Text = room.Name;
                    roomNameTextBox.SelectAll();
                    break;
            }
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e) {
            if (descriptionTextBox.Text != description && descriptionChanged != true)
                descriptionChanged = true;
        }

        private void descriptionTextBox_Leave(object sender, EventArgs e) {
            if (descriptionChanged) {
                roomEdits.Description = descriptionTextBox.Text;
                descriptionChanged = false;
            }
        }

        private void roomNameTextBox_Enter(object sender, EventArgs e) {
            roomNameTextBox.SelectAll();
        }

        private void roomNameTextBox_Leave(object sender, EventArgs e) {
            if (nameChanged) {
                roomEdits.Name = roomNameTextBox.Text;
                nameChanged = false;
            }
        }

        private void roomNameTextBox_TextChanged(object sender, EventArgs e) {
            if (roomNameTextBox.Text != name && nameChanged != true)
                nameChanged = true;
        }

        public RoomEdit(Room room, ApplicationSettings settings) {
            InitializeComponent();
            this.name = room.Name;
            this.description = room.Description;
            this.room = room;
            this.roomNameTextBox.Text = room.Name;
            this.descriptionTextBox.Text = room.Description;
            this.roomEdits = Functions.CloneTheRoomToEdit(room, settings);
            exitsListBox.Items.AddRange(room.Exits.Select(exit => exit.Name).ToArray());
            this.settings = settings;
        }
    }
}
