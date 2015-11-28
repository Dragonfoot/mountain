
using System.Collections.Generic;
using System.Windows.Forms;
using Mountain.classes.functions;
using Mountain.classes;

namespace Mountain.Dialogs {

    public partial class RoomEditor : Form {
        public Room Room;
        public ApplicationSettings settings;

        #region Constructor
        public RoomEditor(Room roomToEdit, ApplicationSettings appSettings) {
            InitializeComponent();
            Room = roomToEdit.DeepCopy();  // copy the room to edit so we can back out without corrupting original 
            settings = appSettings;

            roomNameTextBox.Text = Room.Name;

            PopulateAreaComboBox();
            PopulateAreaRoomsComboBox();
            PopulateExitListBox();
        }
        #endregion


        #region areaComboBox
        // ************************************************************************************
        // begin: area combobox

        private void PopulateAreaComboBox() {
            areaNamesComboBox.DisplayMember = "Name";
            foreach (Area area in settings.world.Areas) {
                areaNamesComboBox.Items.Add(area);
            }
            if (settings.world.Areas.Count > 0) areaNamesComboBox.SelectedIndex = 0;
        }

        // end: area combobox
        #endregion


        #region areRoomComboBox
        // ************************************************************************************
        // begin: area rooms combobox

        private void PopulateAreaRoomsComboBox() {
            areaRoomNamesComboBox.DisplayMember = "Name";
            foreach (Room room in Room.Linkage.Area.Rooms) {
                areaRoomNamesComboBox.Items.Add(room);
            }
        }

        // end: area rooms combobox
        #endregion


        #region roomExitListbox
        // ************************************************************************************
        // begin: room exits listbox

        private void PopulateExitListBox() {
            exitListBox.Items.Clear();
            exitListBox.DisplayMember = "DoorLabel";
            foreach (Exit exit in Room.Exits) {
                exitListBox.Items.Add(exit);
            }
            if (Room.Exits.Count > 0) exitListBox.SelectedIndex = 0;
            Exit selectedExit = (Exit)exitListBox.SelectedItem;

            areaRoomNamesComboBox.SelectedIndex = areaRoomNamesComboBox.Items.IndexOf(exitLinkRoomNameTextBox.Text);
        }

        private void exitListBox_SelectedIndexChanged(object sender, System.EventArgs e) {
            //   KeyValuePair<Exit, string> listBoxItem = (KeyValuePair<Exit, string>) exitListBox.SelectedItem;
            Exit exit = (Exit)exitListBox.SelectedItem;
            exitLinkRoomNameTextBox.Text = exit.Linkage.Room.Name;
            exitLinkAreaNameTextBox.Text = exit.Linkage.Area.Name;

            //   areaRoomNamesComboBox.SelectedIndex = areaRoomNamesComboBox.Items.IndexOf(exit.Linkage.Room.Name);
            //   areaRoomNamesComboBox.SelectedIndex = areaRoomNamesComboBox.Items.IndexOf(exitLinkRoomNameTextBox.Text);
        }

        // end: room exits listbox
        #endregion


        #region exit LinkData
        // ************************************************************************************
        // begin: exit link data

        private void areaRoomNamesComboBox_SelectedIndexChanged(object sender, System.EventArgs e) {
            Exit exit = (Exit)exitListBox.SelectedItem;

            if (areaRoomNamesComboBox.SelectedIndex > -1) {
                exit.DoorLabel = exitLinkAreaNameTextBox.Text = areaRoomNamesComboBox.SelectedItem.ToString();

                Area area = (Area)areaNamesComboBox.SelectedItem;

                //      KeyValuePair<Room, string> roomItem = (KeyValuePair<Room, string>)
                Room room = exit.Link = area.Rooms.FindName(exit.DoorLabel);
                exit.LinkArea = area;

            }


        }

        // end: exit link data
        // ************************************************************************************
        #endregion

    }
}
