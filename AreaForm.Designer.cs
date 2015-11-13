namespace Mountain {
    partial class AreaForm {
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
            this.viewListBox = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.areaGroupBox = new System.Windows.Forms.GroupBox();
            this.areaDescriptionLabel = new System.Windows.Forms.Label();
            this.areaNameTextBox = new System.Windows.Forms.TextBox();
            this.areaDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.RoomListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.areaMenuStrip = new System.Windows.Forms.MenuStrip();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAreaFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.areaGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.areaMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewListBox
            // 
            this.viewListBox.FormattingEnabled = true;
            this.viewListBox.Location = new System.Drawing.Point(6, 19);
            this.viewListBox.Name = "viewListBox";
            this.viewListBox.Size = new System.Drawing.Size(401, 290);
            this.viewListBox.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 315);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(401, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(673, 474);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ok_Button_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(755, 474);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.areaGroupBox);
            this.panel1.Controls.Add(this.RoomListBox);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(13, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 423);
            this.panel1.TabIndex = 5;
            // 
            // areaGroupBox
            // 
            this.areaGroupBox.Controls.Add(this.areaDescriptionLabel);
            this.areaGroupBox.Controls.Add(this.areaNameTextBox);
            this.areaGroupBox.Controls.Add(this.areaDescriptionTextBox);
            this.areaGroupBox.Location = new System.Drawing.Point(18, 18);
            this.areaGroupBox.Name = "areaGroupBox";
            this.areaGroupBox.Size = new System.Drawing.Size(416, 109);
            this.areaGroupBox.TabIndex = 3;
            this.areaGroupBox.TabStop = false;
            this.areaGroupBox.Text = "Area";
            this.areaGroupBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.areaGroupBox_MouseClick);
            // 
            // areaDescriptionLabel
            // 
            this.areaDescriptionLabel.Location = new System.Drawing.Point(6, 19);
            this.areaDescriptionLabel.Name = "areaDescriptionLabel";
            this.areaDescriptionLabel.Size = new System.Drawing.Size(401, 78);
            this.areaDescriptionLabel.TabIndex = 3;
            this.areaDescriptionLabel.Text = "areaDescriptonLabel";
            this.areaDescriptionLabel.Click += new System.EventHandler(this.descriptionLabel_Click);
            // 
            // areaNameTextBox
            // 
            this.areaNameTextBox.Location = new System.Drawing.Point(0, 0);
            this.areaNameTextBox.Name = "areaNameTextBox";
            this.areaNameTextBox.Size = new System.Drawing.Size(100, 20);
            this.areaNameTextBox.TabIndex = 1;
            this.areaNameTextBox.Visible = false;
            this.areaNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.areaNameTextBox_KeyPress);
            this.areaNameTextBox.LostFocus += new System.EventHandler(this.areaNameTextBox_Lost_Focus);
            // 
            // areaDescriptionTextBox
            // 
            this.areaDescriptionTextBox.Location = new System.Drawing.Point(6, 19);
            this.areaDescriptionTextBox.Multiline = true;
            this.areaDescriptionTextBox.Name = "areaDescriptionTextBox";
            this.areaDescriptionTextBox.Size = new System.Drawing.Size(401, 78);
            this.areaDescriptionTextBox.TabIndex = 2;
            this.areaDescriptionTextBox.Text = "Area Description";
            this.areaDescriptionTextBox.Visible = false;
            this.areaDescriptionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.areaDescriptionTextBox_KeyPress);
            this.areaDescriptionTextBox.LostFocus += new System.EventHandler(this.areaDescriptionTextBox_Lost_Focus);
            // 
            // RoomListBox
            // 
            this.RoomListBox.FormattingEnabled = true;
            this.RoomListBox.Location = new System.Drawing.Point(453, 18);
            this.RoomListBox.Name = "RoomListBox";
            this.RoomListBox.ScrollAlwaysVisible = true;
            this.RoomListBox.Size = new System.Drawing.Size(390, 394);
            this.RoomListBox.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.viewListBox);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(18, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 279);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Room View";
            // 
            // areaMenuStrip
            // 
            this.areaMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.areaMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.areaMenuStrip.Name = "areaMenuStrip";
            this.areaMenuStrip.Size = new System.Drawing.Size(884, 24);
            this.areaMenuStrip.TabIndex = 6;
            this.areaMenuStrip.Text = "menuStrip1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsTemplateToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.loadToolStripMenuItem.Text = "Area";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsTemplateToolStripMenuItem
            // 
            this.saveAsTemplateToolStripMenuItem.Name = "saveAsTemplateToolStripMenuItem";
            this.saveAsTemplateToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveAsTemplateToolStripMenuItem.Text = "Save toTemplate";
            // 
            // saveAreaFileDialog
            // 
            this.saveAreaFileDialog.DefaultExt = "xml";
            this.saveAreaFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*\"";
            this.saveAreaFileDialog.Title = "Save Area";
            // 
            // AreaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.areaMenuStrip);
            this.MainMenuStrip = this.areaMenuStrip;
            this.Name = "AreaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AreaForm";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.areaGroupBox.ResumeLayout(false);
            this.areaGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.areaMenuStrip.ResumeLayout(false);
            this.areaMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox viewListBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox areaGroupBox;
        private System.Windows.Forms.ListBox RoomListBox;
        private System.Windows.Forms.MenuStrip areaMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsTemplateToolStripMenuItem;
        private System.Windows.Forms.TextBox areaNameTextBox;
        private System.Windows.Forms.Label areaDescriptionLabel;
        private System.Windows.Forms.TextBox areaDescriptionTextBox;
        private System.Windows.Forms.SaveFileDialog saveAreaFileDialog;

    }
}