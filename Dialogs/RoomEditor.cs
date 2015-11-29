using System.Windows.Forms;
using Mountain.classes;

namespace Mountain.Dialogs {

    public partial class RoomEditor : Form {
        public Room Room;
        public ApplicationSettings settings;

        #region Constructor
        public RoomEditor(Room roomToEdit, ApplicationSettings appSettings) {
            InitializeComponent();
            Room = roomToEdit.ShallowCopy();  // copy the room to edit so we can back out without corrupting original 
            settings = appSettings;
            roomNameTextBox.Text = Room.Name;
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
            Exit exit = (Exit)exitListBox.SelectedItem;
         
        }

        // end: room exits listbox
        #endregion
    }
}
