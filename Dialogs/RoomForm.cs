using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Mountain.classes;
using Mountain.classes.functions;
using Mountain.classes.dataobjects;

namespace Mountain.Dialogs {

    public partial class RoomForm : Form {
        private ApplicationSettings settings;
        public Room roomEdits;
        private Area area;
        private Exit SelectedExit;
        private List<CheckBox> roomCheckBoxList;
        bool nameChanged, descriptionChanged;
        string name, description;

        public RoomForm(Room room, ApplicationSettings settings) {
            InitializeComponent();

            roomEdits = Functions.CloneRoomToEdit(room, settings);
            roomCheckBoxList = new List<CheckBox>();
            roomCheckBoxList.Add(roomTypeCheckBox);
            roomCheckBoxList.Add(roomLimitCheckBox);
            roomCheckBoxList.Add(roomTraitsCheckBox);
            
            roomTypeCheckBox.Tag = roomItem.roomType;
            roomLimitCheckBox.Tag = roomItem.roomLimits;
            roomTraitsCheckBox.Tag = roomItem.roomTraits;
            
            this.settings = settings;
            roomTypeTextBox.Text = GetRoomTypeFlaggedList(roomItem.roomType);

            name = nameTextBox.Text = room.Name;
            area = room.Linkage.Area;
            areaLabel.Text = room.Linkage.Area.Name;
            description = descriptionTextBox.Text = room.Description;
            tagTextBox.Text = room.Tag;

            PopulateExitRestrictedCheckedComboBox(Enum.GetNames(typeof(exitRestrictionType)));
            PopulateExitListBox(room.Exits);
            PopulateAreaComboBox(settings.world.Areas.ToArray());
            PopulateRoomComboBox();

            PopulateRoomLimitsCheckedComboBox();
            PopulateRoomTraitsCheckedComboBox();

            exitLinkTypeComboBox.DataSource = Enum.GetValues(typeof(exitType));
            exitDoorLockTypeComboBox.DataSource = Enum.GetValues(typeof(lockType));
            exitDoorDirectionalComboBox.DataSource = Enum.GetValues(typeof(direction));
            exitLinkTypeComboBox.DataSource = Enum.GetValues(typeof(exitType));

            CheckAttributes();
        }

        private void CheckAttributes() {
            EventArgs e = new EventArgs();
            restrictionCheckBox_CheckedChanged(exitDoorRestrictionCheckBox, e);
            directionalCheckBox_CheckedChanged(exitDoorDirectionalCheckBox, e);
            doorCheckBox_CheckedChanged(exitDoorCheckBox, e);
            openExitDoorCheckBox_CheckedChanged(openCheckBox, e);
            hiddenExitDoorCheckBox_CheckedChanged(exitHiddenDoorCheckBox, e);
            restrictionCheckBox_CheckedChanged(exitDoorRestrictionCheckBox, e);
            hasLockCheckBox_CheckedChanged(exitDoorHasLockCheckBox, e);            
        }

        private void PopulateExitListBox(List<Exit> list) {
            foreach (Exit exit in list) exitListBox.Items.Add(exit.Name);            
            if (list.Count > 0) exitListBox.SelectedIndex = 0;
        }

        private string GetRoomTypeFlaggedList(roomItem roomItem) {
            List<string> names = new List<string>();
            Dictionary<int, string> dictionary;
            switch (roomItem) {
                case roomItem.roomType:
                    dictionary = Enum.GetValues(typeof(roomType)).Cast<roomType>().ToDictionary(t => (int)t, t => t.ToString());
                    int i = 0;
                    foreach (int key in dictionary.Keys) {
                        string name = dictionary[key];
                        if (roomEdits.roomType.HasFlag((roomType)key)) {
                            if (dictionary.Count > 1 && i == 0) {
                                i++;
                                continue;
                            }
                            names.Add(name);
                        }
                        i++;
                    }
                    break;
                case roomItem.roomLimits:
                    break;
                case roomItem.roomTraits:
                    break;
            }
            return Functions.FormatStringArray(names.ToArray());
        }

        private void PopulateRoomLimitsCheckedComboBox() {
          /*  Dictionary<int, string> dictionary = Enum.GetValues(typeof(roomRestrictionType)).Cast<roomRestrictionType>().ToDictionary(t => (int)t, t => t.ToString());
            int i = 0;
            foreach (int key in dictionary.Keys) {
                string name = dictionary[key];
                roomRestrictionsCheckedComboBox.Items.Add(name);
                if (room.roomRestrictons.HasFlag((roomRestrictionType)key)) {
                    roomRestrictionsCheckedComboBox.SetItemChecked(i, true);
                }
                i++;
            }
            if (roomRestrictionsCheckedComboBox.Items.Count > 1)
                roomRestrictionsCheckedComboBox.SetItemChecked(0, false);*/
        }

        private void PopulateRoomTraitsCheckedComboBox() {
      /*      Dictionary<int, string> dictionary = Enum.GetValues(typeof(roomConditionType)).Cast<roomConditionType>().ToDictionary(t => (int)t, t => t.ToString());
            int i = 0;
            foreach (int key in dictionary.Keys) {
                string name = dictionary[key];
                roomConditionsCheckedComboBox.Items.Add(name);
                if (room.roomConditions.HasFlag((roomConditionType)key)) {
                    roomConditionsCheckedComboBox.SetItemChecked(i, true);
                }
                i++;
            }
            if (roomConditionsCheckedComboBox.Items.Count > 1)
                roomConditionsCheckedComboBox.SetItemChecked(0, false);*/
        }

        private void PopulateExitRestrictedCheckedComboBox(Array enumList) {
        /*/    foreach (string item in enumList) {
                restrictedCheckedComboBox.Items.Add(item);
            }
            restrictedCheckedComboBox.SetItemChecked(0, true);*/
        }
        private void PopulateAreaComboBox(Array areaList) {
            exitLinkToAreaComboBox.Items.Add("None");
            foreach (Area area in areaList) {
                exitLinkToAreaComboBox.Items.Add(area.Name);
            }
            if (exitListBox.SelectedIndex > -1) {
                string exitName = exitListBox.Items[exitListBox.SelectedIndex].ToString();
                Exit exit = roomEdits.Exits.Find(e => e.Name == exitName);
                string areaName = exit.Linkage.Area.Name;
                int index = exitLinkToAreaComboBox.Items.IndexOf(areaName);
                if (index > -1) exitLinkToAreaComboBox.SelectedIndex = index;
                else exitLinkToAreaComboBox.SelectedIndex = 0;
            }
        }
        private void PopulateRoomComboBox() {
            exitLinkToRoomComboBox.Items.Add("None");
            if (exitLinkToAreaComboBox.Items.Count == 0 || exitLinkToAreaComboBox.SelectedIndex == -1) {
                exitLinkToAreaComboBox.SelectedIndex = 0;
                return;
            }
            string areaName = exitLinkToAreaComboBox.SelectedItem.ToString();
            if (areaName == "None") {
                exitLinkToAreaComboBox.SelectedIndex = 0;
                return;
            }
            Area area = settings.world.Areas.Find(name => name.Name == areaName);
            if (area == null) {
                exitLinkToAreaComboBox.SelectedIndex = 0;
                return;
            }
            foreach (Room room in area.Rooms) {
                exitLinkToRoomComboBox.Items.Add(room.Name);
            }
            if (exitListBox.SelectedIndex > -1) {
                if(SelectedExit == null) {
                    exitLinkToAreaComboBox.SelectedIndex = 0;
                    return;
                }
                int index = exitLinkToRoomComboBox.Items.IndexOf(SelectedExit.Owner.Name);  
                if (index > -1) exitLinkToRoomComboBox.SelectedIndex = index;
                else exitLinkToRoomComboBox.SelectedIndex = 0;
            }
        }

        private void directionalCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                ((CheckBox)sender).Text = "Direction";
                exitDoorDirectionTextBox.Visible = false;
                exitDoorDirectionalComboBox.Visible = true;
            } else {
                ((CheckBox)sender).Text = "Name";
                exitDoorDirectionalComboBox.Visible = false;
                exitDoorDirectionTextBox.Visible = true;
            }
        }

        private void doorCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                ((CheckBox)sender).Text = "Door";
                openCheckBox.Visible = true;
                exitDoorHasLockCheckBox.Visible = true;
            } else {
                ((CheckBox)sender).Text = "Doorless";
                openCheckBox.Visible = false;
                exitDoorHasLockCheckBox.Visible = false;
            }
        }

        private void restrictionCheckBox_CheckedChanged(object sender, EventArgs e) {
           /* if (((CheckBox)sender).Checked) {
                ((CheckBox)sender).Text = "Restricted";
                restrictedCheckedComboBox.Visible = true;
            } else {
                ((CheckBox)sender).Text = "Unrestricted Access";
                restrictedCheckedComboBox.Visible = false;
            }*/
        }

        private void hasLockCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (((CheckBox)sender).Checked) {
                ((CheckBox)sender).Text = "Lock";
                exitDoorLockTypeComboBox.Visible = true;
            } else {
                ((CheckBox)sender).Text = "No Lock";
                exitDoorLockTypeComboBox.Visible = false;
            }
        }

        private void lockTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            lockType selectedType;
            Enum.TryParse<lockType>(exitDoorLockTypeComboBox.SelectedValue.ToString(), out selectedType);
            int index = exitDoorLockTypeComboBox.SelectedIndex;
        }

        private void directionalComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            direction selectedDirection;
            Enum.TryParse<direction>(exitDoorLockTypeComboBox.SelectedValue.ToString(), out selectedDirection);
            int index = exitDoorDirectionalComboBox.SelectedIndex;

        }

        private void exitListBox_SelectedIndexChanged(object sender, EventArgs e) {
            SelectedExit = roomEdits.Exits.Find((room => room.Name == (string)exitListBox.SelectedItem));
        }

        private void exitListBox_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right) return;
            var index = exitListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                exitListBox.SelectedIndex = index;
                SelectedExit = roomEdits.Exits.Find((room => room.Name == (string)exitListBox.SelectedItem));
                for (int i = 0; i <= exitContextMenu.Items.Count - 1; i++) {
                    exitContextMenu.Items[i].Enabled = true;
                }
                exitContextMenu.Show(Cursor.Position);
            } else {
                exitListBox.SelectedIndex = -1;
                for (int i = 0; i <= exitContextMenu.Items.Count - 1; i++) {
                    if (i == 0)
                        continue;
                    exitContextMenu.Items[i].Enabled = false;
                }
                exitContextMenu.Show(Cursor.Position);
            }
        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            switch (e.KeyChar) {
                case (char)Keys.Return:
                    descriptionTextBox.Focus();
                    break;
                case (char)Keys.Escape:
                    nameTextBox.Text = roomEdits.Name;
                    nameTextBox.SelectAll();
                    break;
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e) {
            if (nameTextBox.Text != name && nameChanged != true)
                nameChanged = true;
        }

        private void nameTextBox_Leave(object sender, EventArgs e) {
            if (nameChanged) {
                roomEdits.Name = nameTextBox.Text;
                nameChanged = false;
            }
        }

        private void nameTextBox_Enter(object sender, EventArgs e) {
            nameTextBox.SelectAll();
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e) {
            if (descriptionTextBox.Text != description && descriptionChanged != true)
                descriptionChanged = true;
        }
       
        // RoomType CheckEnum events    

        private void roomTypeTextBox_KeyDown(object sender, KeyEventArgs e) {
            e.Handled = !e.Alt && !(e.KeyCode == Keys.Tab) &&
                !((e.KeyCode == Keys.Left) 
                || (e.KeyCode == Keys.Right) 
                || (e.KeyCode == Keys.Home) 
                || (e.KeyCode == Keys.End));
            base.OnKeyDown(e);
        }

        private void roomTypeTextBox_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
            base.OnKeyPress(e);
        }

        private void PressCheckBox(roomItem item) {
            foreach (CheckBox control in roomCheckBoxList) {
                if (((roomItem)control.Tag) == item)
                    control.Checked = true;
                else
                    control.Checked = false;
            }
        }
        
        private void roomTypeCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (roomTypeCheckBox.Checked) {
                PressCheckBox(roomItem.roomType);
                if (roomTypeCheckEnum.Visible) {
                    roomTypeCheckEnum.Visible = false;
                    GetRoomTypeFlaggedList(roomItem.roomType);
                    return;
                }

                Point showAt = roomTypeTextBox.Location;

                roomTypeCheckEnum.Items.Clear();
                Dictionary<int, string> dictionary = Enum.GetValues(typeof(roomType)).Cast<roomType>().ToDictionary(t => (int)t, t => t.ToString());
                int i = 0;
                foreach (int key in dictionary.Keys) {
                    string name = dictionary[key];
                    roomTypeCheckEnum.Items.Add(name);
                    if (roomEdits.roomType.HasFlag((roomType)key)) roomTypeCheckEnum.SetItemChecked(i, true);                    
                    i++;
                }

                GetRoomTypeFlaggedList(roomItem.roomType);

                if (roomTypeCheckEnum.Items.Count > 1) roomTypeCheckEnum.SetItemChecked(0, false);
                roomTypeCheckEnum.Height = roomTypeCheckEnum.Items.Count * 16 + 2;
                roomTypeCheckEnum.Location = showAt;
                roomTypeCheckEnum.Visible = true;
            }
        }

        private void roomLimitCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (roomLimitCheckBox.Checked) PressCheckBox(roomItem.roomLimits);
        }

        private void roomTraitsCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (roomTraitsCheckBox.Checked) PressCheckBox(roomItem.roomTraits);
        }

        // end ***********************************


        private void descriptionTextBox_Leave(object sender, EventArgs e) {
            if (descriptionChanged) {
                roomEdits.Description = descriptionTextBox.Text;
                descriptionChanged = false;
            }
        }

        private void exitLinkToRoomComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            Exit exit;
            string newRoomName = exitLinkToRoomComboBox.SelectedItem.ToString();
            if (newRoomName == "None") {
                SelectedExit.Linkage = new Linkage(newRoomName, null, null);
            } else {
                Room room = area.Rooms.First(r => r.Name == newRoomName);
                if (room != null)
                    SelectedExit.Linkage = new Linkage(room.Linkage.DoorLabel, room.Linkage.Area, room);
                else
                    SelectedExit.Linkage = new Linkage(newRoomName, null, null);
            }
            exit = roomEdits.Exits.Find(n => n.Name == SelectedExit.Name);
            exit.Linkage = new Linkage(SelectedExit.Linkage.DoorLabel, SelectedExit.Linkage.Area, SelectedExit.Linkage.Room);
        }

        private void roomTypeCheckEnum_VisibleChanged(object sender, EventArgs e) {
            if (!roomTypeCheckEnum.Visible) roomTypeCheckBox.Checked = false;
        }

        private void exitLinkToRoomComboBox_SelectionChangeCommitted(object sender, EventArgs e) {

        }

        private void openExitDoorCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (openCheckBox.Checked) openCheckBox.Text = "Closed";
            else openCheckBox.Text = "Open";
        }

        private void hiddenExitDoorCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (exitHiddenDoorCheckBox.Checked) exitHiddenDoorCheckBox.Text = "Hidden";
            else exitHiddenDoorCheckBox.Text = "Visible";
        }
    }
}
