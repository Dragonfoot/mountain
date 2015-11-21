using System;
using System.Windows.Forms;
using Mountain.classes;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;

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
            var values = Functions.GetValues<restrictionType>();
            foreach (restrictionType value in values) {
                RestrictionsCheckedListBox.Items.Add(value);
            }
            lockTypeComboBox.DataSource = Enum.GetValues(typeof(lockType));
            directionalComboBox.DataSource = Enum.GetValues(typeof(direction));
            CheckAttributes();
        }

        private void CheckAttributes() {
            EventArgs e = new EventArgs();
            //restrictionCheckBox_CheckedChanged(restrictionCheckBox, e);
            directionalCheckBox_CheckedChanged(directionalCheckBox, e);
            doorCheckBox_CheckedChanged(doorCheckBox, e);
            openCheckBox_CheckedChanged(openCheckBox, e);
            hiddenCheckBox_CheckedChanged(hiddenCheckBox, e);
            restrictionCheckBox_CheckedChanged(restrictionCheckBox, e);
            hasLockCheckBox_CheckedChanged(hasLockCheckBox, e);
        }
        private void directionalCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                ((CheckBox)sender).Text = "Direction";
                directionTextBox.Visible = false;
                directionalComboBox.Visible = true;
            } else {
                ((CheckBox)sender).Text = "Name";
                directionalComboBox.Visible = false;
                directionTextBox.Visible = true;
            }
        }

        private void doorCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                ((CheckBox)sender).Text = "Door";
                openCheckBox.Visible = true;
                hasLockCheckBox.Visible = true;
            } else {
                ((CheckBox)sender).Text = "Doorless";
                openCheckBox.Visible = false;
                hasLockCheckBox.Visible = false;
            }
        }

        private void restrictionCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                ((CheckBox)sender).Text = "Restricted";
                RestrictionsCheckedListBox.Visible = true;
            } else {
                ((CheckBox)sender).Text = "Open Access";
                RestrictionsCheckedListBox.Visible = false;
            }
        }

        private void hasLockCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                ((CheckBox)sender).Text = "Lock";
                lockTypeComboBox.Visible = true;
            } else {
                ((CheckBox)sender).Text = "No Lock";
                lockTypeComboBox.Visible = false;
            }
        }

        private void lockTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            lockType selectedType;
            Enum.TryParse<lockType>(lockTypeComboBox.SelectedValue.ToString(), out selectedType);
            int index = lockTypeComboBox.SelectedIndex;
        }

        private void directionalComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            direction selectedDirection;
            Enum.TryParse<direction>(lockTypeComboBox.SelectedValue.ToString(), out selectedDirection);
            int index = directionalComboBox.SelectedIndex;

        }

        private void openCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (openCheckBox.Checked)
                openCheckBox.Text = "Closed";
            else
                openCheckBox.Text = "Open";
        }

        private void hiddenCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (hiddenCheckBox.Checked)
                hiddenCheckBox.Text = "Hidden";
            else
                hiddenCheckBox.Text = "Visible";
        }


    }
}
