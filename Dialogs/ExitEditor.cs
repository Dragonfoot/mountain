using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mountain.classes;

namespace Mountain.Dialogs {

    public partial class ExitEditor : Form {
        Exit Exit;
        Area SelectedArea;
        ApplicationSettings settings;

        public ExitEditor(Exit exit, ApplicationSettings appSettings) {
            InitializeComponent();
            Exit = exit;
            settings = appSettings;
            currentRoomTextBox.Text = exit.Owner.Name;
            currentDoorLabelTextBox.Text = exit.DoorLabel;

            if (settings.world.Areas.Any()) {
                areaComboBox.Items.AddRange(settings.world.Areas.Select(x => x.Name).ToArray());
                areaComboBox.SelectedIndex = 0;
              /*  if (SelectedArea.Rooms.Any()) {
                    if (roomListBox.Items.Count > 0) roomListBox.SelectedIndex = 0;
                }*/
            }
        }

        private void areaComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            string name = areaComboBox.SelectedItem.ToString();
            SelectedArea = settings.world.Areas.Find(area => area.Name == (string)areaComboBox.SelectedItem);
            roomListBox.Items.Clear();
            roomListBox.Items.AddRange(SelectedArea.Rooms.Where(room => room.Name != Exit.Owner.Name).ToArray());

        }
    }
}
