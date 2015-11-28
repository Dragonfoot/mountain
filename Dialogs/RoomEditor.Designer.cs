namespace Mountain.Dialogs {
    partial class RoomEditor {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exitLinkAreaNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.exitLinkRoomNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exitListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.areaNamesComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.areaRoomNamesComboBox = new System.Windows.Forms.ComboBox();
            this.roomNameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.exitLinkAreaNameTextBox);
            this.panel1.Controls.Add(this.exitLinkRoomNameTextBox);
            this.panel1.Controls.Add(this.descriptionTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.areaNamesComboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.areaRoomNamesComboBox);
            this.panel1.Controls.Add(this.roomNameTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 265);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.exitListBox);
            this.panel2.Location = new System.Drawing.Point(366, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(159, 124);
            this.panel2.TabIndex = 12;
            // 
            // exitLinkAreaNameTextBox
            // 
            this.exitLinkAreaNameTextBox.Location = new System.Drawing.Point(537, 37);
            this.exitLinkAreaNameTextBox.Name = "exitLinkAreaNameTextBox";
            this.exitLinkAreaNameTextBox.Size = new System.Drawing.Size(131, 20);
            this.exitLinkAreaNameTextBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Room Exits";
            // 
            // exitLinkRoomNameTextBox
            // 
            this.exitLinkRoomNameTextBox.Location = new System.Drawing.Point(537, 79);
            this.exitLinkRoomNameTextBox.Name = "exitLinkRoomNameTextBox";
            this.exitLinkRoomNameTextBox.Size = new System.Drawing.Size(131, 20);
            this.exitLinkRoomNameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(541, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Room Linked To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(541, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Area Link Is In";
            // 
            // exitListBox
            // 
            this.exitListBox.FormattingEnabled = true;
            this.exitListBox.Location = new System.Drawing.Point(12, 21);
            this.exitListBox.Name = "exitListBox";
            this.exitListBox.Size = new System.Drawing.Size(131, 82);
            this.exitListBox.TabIndex = 2;
            this.exitListBox.SelectedIndexChanged += new System.EventHandler(this.exitListBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Worlds Area Names";
            // 
            // areaNamesComboBox
            // 
            this.areaNamesComboBox.FormattingEnabled = true;
            this.areaNamesComboBox.Location = new System.Drawing.Point(380, 173);
            this.areaNamesComboBox.Name = "areaNamesComboBox";
            this.areaNamesComboBox.Size = new System.Drawing.Size(131, 21);
            this.areaNamesComboBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Area Room Names";
            // 
            // areaRoomNamesComboBox
            // 
            this.areaRoomNamesComboBox.FormattingEnabled = true;
            this.areaRoomNamesComboBox.Location = new System.Drawing.Point(380, 214);
            this.areaRoomNamesComboBox.Name = "areaRoomNamesComboBox";
            this.areaRoomNamesComboBox.Size = new System.Drawing.Size(131, 21);
            this.areaRoomNamesComboBox.TabIndex = 7;
            this.areaRoomNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.areaRoomNamesComboBox_SelectedIndexChanged);
            // 
            // roomNameTextBox
            // 
            this.roomNameTextBox.Location = new System.Drawing.Point(31, 38);
            this.roomNameTextBox.Name = "roomNameTextBox";
            this.roomNameTextBox.Size = new System.Drawing.Size(161, 20);
            this.roomNameTextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(532, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(614, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(31, 82);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(161, 95);
            this.descriptionTextBox.TabIndex = 15;
            // 
            // RoomEditor
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(714, 313);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "RoomEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RoomEdit";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox exitListBox;
        private System.Windows.Forms.TextBox roomNameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox exitLinkRoomNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox exitLinkAreaNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox areaRoomNamesComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox areaNamesComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}