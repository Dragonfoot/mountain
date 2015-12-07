using System;
using System.Windows.Forms;

namespace Mountain.classes.controls {

    public partial class CheckEnum : CheckedListBox {
        private static MessageHook Hook = null;

        public CheckEnum() {
            InitializeComponent();
            if (Hook == null) {
                Hook = new MessageHook();
                Application.AddMessageFilter(Hook);
            }
            Hook.MouseDown += new MessageHook.LeftButtonDown(Hook_MouseDown);
            Hook.KeyUp += new MessageHook.KeyPressUp(Hook_KeyUp);
        }

        private void Hook_KeyUp(IntPtr focusedControl) {
            if (!focusedControl.Equals(IntPtr.Zero)) if (Visible) if (!IsSelf(focusedControl)) Visible = false;            
        }

        private bool IsSelf(IntPtr clickedControl) {
            return IsSelf(this, clickedControl);
        }

        private bool IsSelf(Control control, IntPtr clickedControl) {
            foreach (Control childControl in control.Controls) {    // overkill, no child controls at this point
                if (childControl.Handle.Equals(clickedControl)) return true;
                else if (childControl.HasChildren) {                // recursive check
                    bool result = IsSelf(childControl, clickedControl);
                    if (result) return true;                    
                }
            }
            return false;
        }

        private void Hook_MouseDown() {
            if (Visible) if (!RectangleToScreen(ClientRectangle).Contains(Cursor.Position)) Visible = false;
        }

        public new void Dispose() {
            Application.RemoveMessageFilter(Hook);
            base.Dispose();
        }

        private class MessageHook : IMessageFilter {
            private const int WM_LBUTTONDOWN = 0x201;
            private const int WM_KEYUP = 0x101;

            public delegate void LeftButtonDown();
            public delegate void KeyPressUp(IntPtr target);
            public event LeftButtonDown MouseDown;
            public event KeyPressUp KeyUp;

            bool IMessageFilter.PreFilterMessage(ref Message message) {
                switch (message.Msg) {
                    case WM_KEYUP: if (KeyUp != null) KeyUp(message.HWnd); break;
                    case WM_LBUTTONDOWN: if (MouseDown != null) MouseDown(); break;
                }
                return false;
            }
        }
    }
}

