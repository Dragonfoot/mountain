using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mountain.classes;

namespace Mountain {
    public partial class Client:Form {

        protected World World;

        public Client() {
            this.World = new World();
            this.World.Load();

            InitializeComponent();
            }
        }
    }
