namespace Mountain {
    partial class RoomEdit {
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
            this.roomEditMenuStrip = new System.Windows.Forms.MenuStrip();
            this.roomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.itemsListBox = new System.Windows.Forms.ListBox();
            this.mobsListBox = new System.Windows.Forms.ListBox();
            this.exitsListBox = new System.Windows.Forms.ListBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.roomEditMenuStrip.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // roomEditMenuStrip
            // 
            this.roomEditMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomToolStripMenuItem});
            this.roomEditMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.roomEditMenuStrip.Name = "roomEditMenuStrip";
            this.roomEditMenuStrip.Size = new System.Drawing.Size(486, 24);
            this.roomEditMenuStrip.TabIndex = 0;
            this.roomEditMenuStrip.Text = "menuStrip1";
            // 
            // roomToolStripMenuItem
            // 
            this.roomToolStripMenuItem.Name = "roomToolStripMenuItem";
            this.roomToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.roomToolStripMenuItem.Text = "Room";
            // 
            // mainPanel
            // 
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPanel.Controls.Add(this.descriptionLabel);
            this.mainPanel.Controls.Add(this.itemsListBox);
            this.mainPanel.Controls.Add(this.mobsListBox);
            this.mainPanel.Controls.Add(this.exitsListBox);
            this.mainPanel.Controls.Add(this.NameLabel);
            this.mainPanel.Controls.Add(this.descriptionTextBox);
            this.mainPanel.Location = new System.Drawing.Point(12, 39);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(461, 370);
            this.mainPanel.TabIndex = 1;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.descriptionLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.descriptionLabel.Location = new System.Drawing.Point(33, 39);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(177, 129);
            this.descriptionLabel.TabIndex = 4;
            this.descriptionLabel.Click += new System.EventHandler(this.descriptionLabel_Click);
            // 
            // itemsListBox
            // 
            this.itemsListBox.FormattingEnabled = true;
            this.itemsListBox.Location = new System.Drawing.Point(246, 193);
            this.itemsListBox.Name = "itemsListBox";
            this.itemsListBox.Size = new System.Drawing.Size(168, 147);
            this.itemsListBox.TabIndex = 3;
            // 
            // mobsListBox
            // 
            this.mobsListBox.FormattingEnabled = true;
            this.mobsListBox.Location = new System.Drawing.Point(246, 21);
            this.mobsListBox.Name = "mobsListBox";
            this.mobsListBox.Size = new System.Drawing.Size(168, 147);
            this.mobsListBox.TabIndex = 2;
            // 
            // exitsListBox
            // 
            this.exitsListBox.FormattingEnabled = true;
            this.exitsListBox.Location = new System.Drawing.Point(33, 193);
            this.exitsListBox.Name = "exitsListBox";
            this.exitsListBox.Size = new System.Drawing.Size(177, 147);
            this.exitsListBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(30, 21);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(66, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Room Name";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(33, 39);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(177, 129);
            this.descriptionTextBox.TabIndex = 5;
            this.descriptionTextBox.Visible = false;
            this.descriptionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.descriptionTextBox_KeyPress);
            this.descriptionTextBox.LostFocus += new System.EventHandler(this.descriptionTextBox_Lost_Focus);
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(306, 415);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(388, 415);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // RoomEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 448);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.roomEditMenuStrip);
            this.MainMenuStrip = this.roomEditMenuStrip;
            this.Name = "RoomEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RoomEdit";
            this.roomEditMenuStrip.ResumeLayout(false);
            this.roomEditMenuStrip.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip roomEditMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem roomToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ListBox itemsListBox;
        private System.Windows.Forms.ListBox mobsListBox;
        private System.Windows.Forms.ListBox exitsListBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox descriptionTextBox;
    }
}