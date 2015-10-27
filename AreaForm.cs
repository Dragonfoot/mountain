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
using Mountain.classes.helpers;

namespace Mountain {
    public partial class AreaForm : Form {
        public AreaForm() {
            InitializeComponent();
            List<Room> rooms = new List<Room>();
        }

        private void ok_Button_Click(object sender, EventArgs e) {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.ok_Button_Click(this, e);
        }
    }
}
