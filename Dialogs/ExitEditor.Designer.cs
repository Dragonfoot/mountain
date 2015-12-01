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
            this.roomLabel = new System.Windows.Forms.Label();
            this.roomListBox = new System.Windows.Forms.ListBox();
            this.areaComboBox = new System.Windows.Forms.ComboBox();
            this.returnLinkCheckBox = new System.Windows.Forms.CheckBox();
            this.currentDoorLabelTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkDoorLabelTextBox = new System.Windows.Forms.TextBox();
            this.currentRoomTextBox = new System.Windows.Forms.TextBox();
            this.linkRoomTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomLabel
            // 
            this.roomLabel.AutoSize = true;
            this.roomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.roomLabel.Location = new System.Drawing.Point(40, 13);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(115, 18);
            this.roomLabel.TabIndex = 0;
            this.roomLabel.Text = "Current Room";
            // 
            // roomListBox
            // 
            this.roomListBox.FormattingEnabled = true;
            this.roomListBox.Location = new System.Drawing.Point(150, 72);
            this.roomListBox.Name = "roomListBox";
            this.roomListBox.Size = new System.Drawing.Size(121, 121);
            this.roomListBox.TabIndex = 1;
            // 
            // areaComboBox
            // 
            this.areaComboBox.FormattingEnabled = true;
            this.areaComboBox.Location = new System.Drawing.Point(150, 43);
            this.areaComboBox.Name = "areaComboBox";
            this.areaComboBox.Size = new System.Drawing.Size(121, 21);
            this.areaComboBox.TabIndex = 2;
            this.areaComboBox.SelectedIndexChanged += new System.EventHandler(this.areaComboBox_SelectedIndexChanged);
            // 
            // returnLinkCheckBox
            // 
            this.returnLinkCheckBox.AutoSize = true;
            this.returnLinkCheckBox.Location = new System.Drawing.Point(169, 19);
            this.returnLinkCheckBox.Name = "returnLinkCheckBox";
            this.returnLinkCheckBox.Size = new System.Drawing.Size(81, 17);
            this.returnLinkCheckBox.TabIndex = 3;
            this.returnLinkCheckBox.Text = "Return Link";
            this.returnLinkCheckBox.UseVisualStyleBackColor = true;
            // 
            // currentDoorLabelTextBox
            // 
            this.currentDoorLabelTextBox.Location = new System.Drawing.Point(15, 72);
            this.currentDoorLabelTextBox.Name = "currentDoorLabelTextBox";
            this.currentDoorLabelTextBox.Size = new System.Drawing.Size(119, 20);
            this.currentDoorLabelTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Door Label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(209, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "<--->";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(311, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Link To Room";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Door Label";
            // 
            // linkDoorLabelTextBox
            // 
            this.linkDoorLabelTextBox.Location = new System.Drawing.Point(287, 72);
            this.linkDoorLabelTextBox.Name = "linkDoorLabelTextBox";
            this.linkDoorLabelTextBox.Size = new System.Drawing.Size(119, 20);
            this.linkDoorLabelTextBox.TabIndex = 8;
            // 
            // currentRoomTextBox
            // 
            this.currentRoomTextBox.Location = new System.Drawing.Point(15, 17);
            this.currentRoomTextBox.Name = "currentRoomTextBox";
            this.currentRoomTextBox.Size = new System.Drawing.Size(119, 20);
            this.currentRoomTextBox.TabIndex = 10;
            // 
            // linkRoomTextBox
            // 
            this.linkRoomTextBox.Location = new System.Drawing.Point(287, 16);
            this.linkRoomTextBox.Name = "linkRoomTextBox";
            this.linkRoomTextBox.Size = new System.Drawing.Size(119, 20);
            this.linkRoomTextBox.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.currentRoomTextBox);
            this.panel1.Controls.Add(this.linkRoomTextBox);
            this.panel1.Controls.Add(this.roomListBox);
            this.panel1.Controls.Add(this.areaComboBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.returnLinkCheckBox);
            this.panel1.Controls.Add(this.linkDoorLabelTextBox);
            this.panel1.Controls.Add(this.currentDoorLabelTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(17, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 210);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.roomLabel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 269);
            this.panel2.TabIndex = 13;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(308, 290);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(390, 290);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // ExitEditor
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(489, 319);
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

        private System.Windows.Forms.Label roomLabel;
        private System.Windows.Forms.ListBox roomListBox;
        private System.Windows.Forms.ComboBox areaComboBox;
        private System.Windows.Forms.CheckBox returnLinkCheckBox;
        private System.Windows.Forms.TextBox currentDoorLabelTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox linkDoorLabelTextBox;
        private System.Windows.Forms.TextBox currentRoomTextBox;
        private System.Windows.Forms.TextBox linkRoomTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}