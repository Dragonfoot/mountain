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
        ApplicationSettings settings;
        public ExitEditor(Exit exit, ApplicationSettings appSettings) {
            InitializeComponent();
            Exit = exit;
            settings = appSettings;
        }
    }
}
