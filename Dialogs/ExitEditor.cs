using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Mountain.classes;
using Mountain.classes.dataobjects;

namespace Mountain.Dialogs {

    public partial class ExitEditor : Form {
        Exit Exit;
        Area SelectedArea;

        public ExitEditor(Exit exit) {
            InitializeComponent();
            Exit = exit;
            currentRoomTextBox.Text = exit.Owner.Name;
            currentDoorLabelTextBox.Text = exit.DoorLabel;

            if (GBL.Settings.World.Areas.Any()) {
                areaComboBox.Items.AddRange(GBL.Settings.World.Areas.Select(x => x.Name).ToArray());
                areaComboBox.SelectedIndex = 0;
              /*  if (SelectedArea.Rooms.Any()) {
                    if (roomListBox.Items.Count > 0) roomListBox.SelectedIndex = 0;
                }*/
            }
        }

        private void areaComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            string name = areaComboBox.SelectedItem.ToString();
            SelectedArea = GBL.Settings.World.Areas.Find(area => area.Name == (string)areaComboBox.SelectedItem);
            roomListBox.Items.Clear();
            roomListBox.Items.AddRange(SelectedArea.Rooms.Where(room => room.Name != Exit.Owner.Name).ToArray());

        }
    }
}
