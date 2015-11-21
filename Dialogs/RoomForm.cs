using System;
using System.Windows.Forms;
using Mountain.classes;

namespace Mountain.Dialogs {

    public partial class RoomForm : Form {
        private ApplicationSettings settings;
        public Room roomEdits;
        private Room room;
        bool nameChanged, descriptionChanged;
        string name, description;

        public RoomForm(Room room, ApplicationSettings settings) {
            InitializeComponent();
            this.room = room;
            this.settings = settings;
            name = nameTextBox.Text = room.Name;
            areaLabel.Text = room.Area.Name;
            description = descriptionTextBox.Text = room.Description;
            guidLabel.Text = room.ID.ToString();
            CheckAttributes();
        }      

        private void CheckAttributes() {
            EventArgs e = new EventArgs();
            restrictionCheckBox_CheckedChanged(restrictionCheckBox, e);
            directionalCheckBox_CheckedChanged(directionalCheckBox, e);
            doorCheckBox_CheckedChanged(doorCheckBox, e);
            openCheckBox_CheckedChanged(openCheckBox, e);
            hiddenCheckBox_CheckedChanged(hiddenCheckBox, e);
        }
        private void directionalCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                ((CheckBox)sender).Text = "Directional Label";
                directionTextBox.Visible = false;
                directionalComboBox.Visible = true;
            } else {
                ((CheckBox)sender).Text = "Informational Label";
                directionalComboBox.Visible = false;
                directionTextBox.Visible = true;
            }
        }

        private void doorCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked)
                ((CheckBox)sender).Text = "Has Door";
            else
                ((CheckBox)sender).Text = "No Door";
        }

        private void restrictionCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                ((CheckBox)sender).Text = "Restrictions";
                restrictionsComboBox.Visible = true;
            } else {
                ((CheckBox)sender).Text = "No Restrictions";
                restrictionsComboBox.Visible = false;
            }
        }

        private void openCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (openCheckBox.Checked)
                openCheckBox.Text = "Closed";
            else
                openCheckBox.Text = "Opened";
        }

        private void hiddenCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (hiddenCheckBox.Checked)
                hiddenCheckBox.Text = "Hidden";
            else
                hiddenCheckBox.Text = "Visible";
        }


    }
}
