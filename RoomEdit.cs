using System;
using System.Windows.Forms;
using System.Linq;
using Mountain.classes;
using Mountain.classes.handlers;

namespace Mountain {

    public partial class RoomEdit : Form {
        Room room, roomCopy;
        ApplicationSettings settings;

        public RoomEdit(Room room, ApplicationSettings settings) {
            InitializeComponent();
            this.room = room;
            this.roomCopy = Functions.CopyRoom(room, settings);
            this.roomNameTextBox.Text = room.Name;
            this.descriptionTextBox.Text = room.Description;
            exitsListBox.Items.AddRange(room.Exits.Select(exit => exit.Name).ToArray());
            this.settings = settings;
        }
    }
}
