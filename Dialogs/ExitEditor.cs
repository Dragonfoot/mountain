using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Mountain.classes;
using Mountain.classes.dataobjects;

namespace Mountain.Dialogs {

    public partial class ExitEditor : Form {
        public Exit Exit;
        Area SelectedArea;

        public ExitEditor(Exit exit) {
            InitializeComponent();
            Exit = exit.ShallowCopy();
            currentRoomTextBox.Text = exit.Owner.Name;

            if (Common.Settings.World.Areas.Any()) {
                areaComboBox.Items.AddRange(Common.Settings.World.Areas.Select(x => x.Name).ToArray());
                areaComboBox.SelectedIndex = 0;
              /*  if (SelectedArea.Rooms.Any()) {
                    if (roomListBox.Items.Count > 0) roomListBox.SelectedIndex = 0;
                }*/
            }
        }

        private void areaComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            string name = areaComboBox.SelectedItem.ToString();
            SelectedArea = Common.Settings.World.Areas.Find(area => area.Name == (string)areaComboBox.SelectedItem);
            roomListBox.Items.Clear();
            roomListBox.Items.Add("None");
            roomListBox.Items.AddRange(SelectedArea.Rooms.Where(room => room.Name != Exit.Owner.Name).ToArray());
            if (roomListBox.Items.Count > 0) roomListBox.SelectedIndex = 0;
        }

        private void roomListBox_SelectedIndexChanged(object sender, EventArgs e) {
            string name = linkRoomTextBox.Text = roomListBox.Items[roomListBox.SelectedIndex].ToString();
            if (name != "None") {
                Room room = Common.Settings.World.GetRoomByName(name);
                linkDoorLabelTextBox.Text = room.Name;
            }
        }
    }
}
