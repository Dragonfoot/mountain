namespace Mountain.Dialogs {
    partial class ExitEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.roomListBox = new System.Windows.Forms.ListBox();
            this.areaComboBox = new System.Windows.Forms.ComboBox();
            this.returnLinkCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.linkDoorLabelTextBox = new System.Windows.Forms.TextBox();
            this.currentRoomTextBox = new System.Windows.Forms.TextBox();
            this.linkRoomTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomListBox
            // 
            this.roomListBox.FormattingEnabled = true;
            this.roomListBox.Location = new System.Drawing.Point(12, 107);
            this.roomListBox.Name = "roomListBox";
            this.roomListBox.Size = new System.Drawing.Size(121, 121);
            this.roomListBox.TabIndex = 1;
            this.roomListBox.SelectedIndexChanged += new System.EventHandler(this.roomListBox_SelectedIndexChanged);
            // 
            // areaComboBox
            // 
            this.areaComboBox.FormattingEnabled = true;
            this.areaComboBox.Location = new System.Drawing.Point(12, 85);
            this.areaComboBox.Name = "areaComboBox";
            this.areaComboBox.Size = new System.Drawing.Size(121, 21);
            this.areaComboBox.TabIndex = 2;
            this.areaComboBox.SelectedIndexChanged += new System.EventHandler(this.areaComboBox_SelectedIndexChanged);
            // 
            // returnLinkCheckBox
            // 
            this.returnLinkCheckBox.AutoSize = true;
            this.returnLinkCheckBox.Location = new System.Drawing.Point(18, 234);
            this.returnLinkCheckBox.Name = "returnLinkCheckBox";
            this.returnLinkCheckBox.Size = new System.Drawing.Size(103, 17);
            this.returnLinkCheckBox.TabIndex = 3;
            this.returnLinkCheckBox.Text = "Has Return Link";
            this.returnLinkCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Door Label";
            // 
            // linkDoorLabelTextBox
            // 
            this.linkDoorLabelTextBox.Location = new System.Drawing.Point(12, 59);
            this.linkDoorLabelTextBox.Name = "linkDoorLabelTextBox";
            this.linkDoorLabelTextBox.Size = new System.Drawing.Size(121, 20);
            this.linkDoorLabelTextBox.TabIndex = 8;
            // 
            // currentRoomTextBox
            // 
            this.currentRoomTextBox.Location = new System.Drawing.Point(31, 10);
            this.currentRoomTextBox.Name = "currentRoomTextBox";
            this.currentRoomTextBox.Size = new System.Drawing.Size(121, 20);
            this.currentRoomTextBox.TabIndex = 10;
            // 
            // linkRoomTextBox
            // 
            this.linkRoomTextBox.Location = new System.Drawing.Point(12, 15);
            this.linkRoomTextBox.Name = "linkRoomTextBox";
            this.linkRoomTextBox.Size = new System.Drawing.Size(121, 20);
            this.linkRoomTextBox.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.linkRoomTextBox);
            this.panel1.Controls.Add(this.roomListBox);
            this.panel1.Controls.Add(this.areaComboBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.returnLinkCheckBox);
            this.panel1.Controls.Add(this.linkDoorLabelTextBox);
            this.panel1.Location = new System.Drawing.Point(17, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 297);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.currentRoomTextBox);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(191, 355);
            this.panel2.TabIndex = 13;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(30, 376);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(108, 376);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Create Return Link";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ExitEditor
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(217, 404);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.panel2);
            this.Name = "ExitEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exit Editor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox roomListBox;
        private System.Windows.Forms.ComboBox areaComboBox;
        private System.Windows.Forms.CheckBox returnLinkCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox linkDoorLabelTextBox;
        private System.Windows.Forms.TextBox currentRoomTextBox;
        private System.Windows.Forms.TextBox linkRoomTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button button1;
    }
}