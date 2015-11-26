using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mountain.classes.controls {

    public partial class CheckEnum : CheckedListBox {
        private static Filter filter = null;

        public CheckEnum() {
            InitializeComponent();
            if (filter == null) {
                filter = new Filter();
                Application.AddMessageFilter(filter);
            }
            filter.MouseDown += new Filter.LeftButtonDown(filter_MouseDown);
            filter.KeyUp += new Filter.KeyPressUp(filter_KeyUp);
        }

        private void filter_KeyUp(IntPtr target) {
            if (!target.Equals(IntPtr.Zero)) {
                if (PanelVisible) {
                    if (!IsTargetMine(target)) {
                        ToggleVisibility();
                    }
                }
            }
        }

        private bool IsTargetMine(IntPtr target) {
            return IsTargetMine(this, target);
        }

        private bool IsTargetMine(Control ctl, IntPtr target) {
            foreach (Control child in ctl.Controls) {
                if (child.Handle.Equals(target)) {
                    return true;
                } else if (child.HasChildren) {
                    bool result = IsTargetMine(child, target);
                    if (result) {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool PanelVisible {
            get { return Visible; }
        }

        private void filter_MouseDown() {
            if (PanelVisible) {
                if (!RectangleToScreen(ClientRectangle).Contains(Cursor.Position)) { 
                    ToggleVisibility();
                }
            }             
        }       

        private void ToggleVisibility() {
            if (PanelVisible) {
                Visible = false;
            } else {
                Visible = true;
            }
        }

        public new void Dispose() {
            Application.RemoveMessageFilter(filter);
            base.Dispose();
        }

        private class Filter : IMessageFilter {

            public delegate void LeftButtonDown();
            public event LeftButtonDown MouseDown;

            public delegate void KeyPressUp(IntPtr target);
            public event KeyPressUp KeyUp;

            private const int WM_KEYUP = 0x101;
            private const int WM_LBUTTONDOWN = 0x201;

            bool IMessageFilter.PreFilterMessage(ref Message m) {
                switch (m.Msg) {
                    // raise our KeyUp() event whenever a key is released in our app
                    case WM_KEYUP:
                        if (KeyUp != null) {
                            KeyUp(m.HWnd);
                        }
                        break;

                    // raise our MouseDown() event whenever the mouse is left clicked somewhere in our app
                    case WM_LBUTTONDOWN:
                        if (MouseDown != null) {
                            MouseDown();
                        }
                        break;
                }
                return false;
            }
        }
    }
}

