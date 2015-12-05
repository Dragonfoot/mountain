using System.Windows.Forms;
using Mountain.classes;

namespace Mountain.Dialogs {

    public partial class RoomEditor : Form {
        public Room Room;
        public Exit SelectedExit;
        private bool nameChanged, descriptionChanged;
        private string name, description;

        #region Constructor
        public RoomEditor(Room roomToEdit) {
            InitializeComponent();
            Room = roomToEdit.ShallowCopy();  // copy the room to edit so we can back out without corrupting original 
            name = roomNameTextBox.Text = Room.Name;
            description = descriptionTextBox.Text = Room.Description;
            shortTextBox.Text = Room.shortDescription;
            PopulateExitListBox();
        }
        #endregion

        #region roomExitListbox
        // ************************************************************************************
        // begin: room exits listbox

        private void PopulateExitListBox() {
            exitListBox.Items.Clear();
            exitListBox.DisplayMember = "DoorLabel";
            foreach (Exit exit in Room.Exits) exitListBox.Items.Add(exit);
            if (Room.Exits.Count > 0) exitListBox.SelectedIndex = 0;
            Exit selectedExit = (Exit)exitListBox.SelectedItem;
        }

        private void exitListBox_SelectedIndexChanged(object sender, System.EventArgs e) {
            SelectedExit = (Exit)exitListBox.SelectedItem;         
        }
        private void exitListBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right) return;
            var index = exitListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                exitListBox.SelectedIndex = index;
                SelectedExit = Room.Exits.Find(exit => exit == (Exit)exitListBox.SelectedItem);
                for (int i = 0; i <= exitContextMenu.Items.Count - 1; i++) {
                    exitContextMenu.Items[i].Enabled = true;
                }
                exitContextMenu.Show(Cursor.Position);
            } else {
                exitListBox.SelectedIndex = -1;
                for (int i = 0; i <= exitContextMenu.Items.Count - 1; i++) {
                    if (i == 0) continue;
                    exitContextMenu.Items[i].Enabled = false;
                }
            }
        }
        private void exitListBox_MouseDoubleClick(object sender, MouseEventArgs e) {
            var index = exitListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                exitListBox.SelectedIndex = index;
                SelectedExit = Room.Exits.Find(exit => exit == (Exit)exitListBox.SelectedItem);
                editToolStripMenuItem_Click(sender, e);
            } else {
                exitListBox.SelectedIndex = -1;
                // NewRoomContextMenuItem_Click(...
            }
        }

        // end: room exits listbox
        #endregion

        #region Exit Context Menu

        private void editToolStripMenuItem_Click(object sender, System.EventArgs e) {
            if (nameChanged) {
                Room.Name = roomNameTextBox.Text;
                nameChanged = false;
            }
            ExitEditor exitEdit = new ExitEditor(SelectedExit);
            DialogResult dialogresult = exitEdit.ShowDialog();
            if (dialogresult == DialogResult.OK) {
                //    Functions.UpdateRoomEdits(roomEditForm.roomEdits, SelectedRoom);
                //    exitListBox.Items.Clear();
                //    exitListBox.Items.AddRange(SelectedArea.Rooms.Select(room => room.Name).ToArray());
            }
            exitEdit.Dispose();
        }
        private void addToolStripMenuItem_Click(object sender, System.EventArgs e) {
            if (nameChanged) {
                Room.Name = roomNameTextBox.Text;
                nameChanged = false;
            }
            Exit exit = new Exit();
            exit.Area = Room.Area;
            exit.Owner = Room;
            exit.DoorLabel = Room.Name;
            ExitEditor exitEdit = new ExitEditor(exit);
            DialogResult dialogresult = exitEdit.ShowDialog();
            if (dialogresult == DialogResult.OK) {
                //    Functions.UpdateRoomEdits(roomEditForm.roomEdits, SelectedRoom);
                //    exitListBox.Items.Clear();
                //    exitListBox.Items.AddRange(SelectedArea.Rooms.Select(room => room.Name).ToArray());
            }
            exitEdit.Dispose();
        }

        #endregion

        #region Room Name

        private void roomNameTextBox_Leave(object sender, System.EventArgs e) {
            if (nameChanged) {
                Room.Name = roomNameTextBox.Text;
                nameChanged = false;
            }
        }
        private void roomNameTextBox_Enter(object sender, System.EventArgs e) {
            roomNameTextBox.SelectAll();
        }
        private void roomNameTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            switch (e.KeyChar) {
                case (char)Keys.Return:
                    nameChanged = true;
                    descriptionTextBox.Focus();
                    break;
                case (char)Keys.Escape:
                    nameChanged = false;
                    roomNameTextBox.Text = Room.Name;
                    roomNameTextBox.SelectAll();
                    break;
                default:
                    nameChanged = true;
                    break;
            }
        }
        private void roomNameTextBox_TextChanged(object sender, System.EventArgs e) {
            if (roomNameTextBox.Text != name && nameChanged != true)
                nameChanged = true;
        }

        #endregion

        #region Room Description

        private void descriptionTextBox_TextChanged(object sender, System.EventArgs e) {
            if (descriptionTextBox.Text != description && descriptionChanged != true)
                descriptionChanged = true;
        }

        private void descriptionTextBox_Leave(object sender, System.EventArgs e) {
            if (descriptionChanged) {
                Room.Description = descriptionTextBox.Text;
                descriptionChanged = false;
            }
        }


        #endregion
    }
}
