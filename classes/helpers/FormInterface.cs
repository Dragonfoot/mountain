using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class FormInterface {
        protected Form form;
        public ListBox console { get; set; }

        public FormInterface(Form form) {
            this.form = form;
        }
    }
}
