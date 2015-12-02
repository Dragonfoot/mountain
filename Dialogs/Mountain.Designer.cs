namespace Mountain.Dialogs {
    partial class Mountain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing&&(components!=null)) {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mountain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Console = new System.Windows.Forms.ListBox();
            this.logRichTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listenerCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.startServer = new System.Windows.Forms.Button();
            this.areaListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roomsListBox = new System.Windows.Forms.ListBox();
            this.RoomContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsTemplateContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MoveToAreaContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.connectedListBox = new System.Windows.Forms.ListBox();
            this.connectedLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.connectionPoller = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.RoomContextMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.commandsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1089, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem1.Text = "New";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem2.Text = "Load from Template";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitProgram_ToolStripMenuItem_Click);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.mobToolStripMenuItem,
            this.itemToolStripMenuItem,
            this.eventToolStripMenuItem,
            this.questToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.commandsToolStripMenuItem.Text = "Edit";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem3.Text = "Area";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.areaForm_Button_Click);
            // 
            // mobToolStripMenuItem
            // 
            this.mobToolStripMenuItem.Name = "mobToolStripMenuItem";
            this.mobToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.mobToolStripMenuItem.Text = "Mob";
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.itemToolStripMenuItem.Text = "Item";
            // 
            // eventToolStripMenuItem
            // 
            this.eventToolStripMenuItem.Name = "eventToolStripMenuItem";
            this.eventToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.eventToolStripMenuItem.Text = "Event";
            // 
            // questToolStripMenuItem
            // 
            this.questToolStripMenuItem.Name = "questToolStripMenuItem";
            this.questToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.questToolStripMenuItem.Text = "Quest";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.Console);
            this.panel2.Location = new System.Drawing.Point(257, 290);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(446, 268);
            this.panel2.TabIndex = 2;
            this.panel2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 233);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(443, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Console
            // 
            this.Console.FormattingEnabled = true;
            this.Console.HorizontalScrollbar = true;
            this.Console.Location = new System.Drawing.Point(3, 6);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(443, 225);
            this.Console.TabIndex = 0;
            // 
            // logRichTextBox
            // 
            this.logRichTextBox.Location = new System.Drawing.Point(257, 58);
            this.logRichTextBox.Name = "logRichTextBox";
            this.logRichTextBox.Size = new System.Drawing.Size(446, 232);
            this.logRichTextBox.TabIndex = 10;
            this.logRichTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listenerCheckBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.startServer);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(22, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(99, 133);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // listenerCheckBox
            // 
            this.listenerCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.listenerCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listenerCheckBox.Checked = true;
            this.listenerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.listenerCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.listenerCheckBox.Location = new System.Drawing.Point(70, 19);
            this.listenerCheckBox.Name = "listenerCheckBox";
            this.listenerCheckBox.Size = new System.Drawing.Size(16, 16);
            this.listenerCheckBox.TabIndex = 16;
            this.listenerCheckBox.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(55, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "8090";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(11, 95);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "Stop";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // startServer
            // 
            this.startServer.Location = new System.Drawing.Point(11, 66);
            this.startServer.Name = "startServer";
            this.startServer.Size = new System.Drawing.Size(75, 23);
            this.startServer.TabIndex = 0;
            this.startServer.Text = "Start";
            this.startServer.UseVisualStyleBackColor = true;
            this.startServer.Click += new System.EventHandler(this.serverStart);
            // 
            // areaListBox
            // 
            this.areaListBox.FormattingEnabled = true;
            this.areaListBox.Location = new System.Drawing.Point(709, 58);
            this.areaListBox.Name = "areaListBox";
            this.areaListBox.Size = new System.Drawing.Size(171, 485);
            this.areaListBox.TabIndex = 12;
            this.areaListBox.SelectedIndexChanged += new System.EventHandler(this.areaListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(709, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Areas";
            // 
            // roomsListBox
            // 
            this.roomsListBox.ContextMenuStrip = this.RoomContextMenu;
            this.roomsListBox.FormattingEnabled = true;
            this.roomsListBox.Location = new System.Drawing.Point(886, 58);
            this.roomsListBox.Name = "roomsListBox";
            this.roomsListBox.Size = new System.Drawing.Size(185, 485);
            this.roomsListBox.TabIndex = 14;
            this.roomsListBox.SelectedIndexChanged += new System.EventHandler(this.roomsListBox_SelectedIndexChanged);
            this.roomsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.roomsListBox_MouseDoubleClick);
            this.roomsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.roomsListBox_MouseDown);
            // 
            // RoomContextMenu
            // 
            this.RoomContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewContextMenuItem,
            this.EditContextMenuItem,
            this.CopyContextMenuItem,
            this.PasteContextMenuItem,
            this.ClearContextMenuItem,
            this.toolStripSeparator2,
            this.LoadContextMenuItem,
            this.SaveAsContextMenuItem,
            this.SaveAsTemplateContextMenuItem,
            this.toolStripSeparator3,
            this.MoveToAreaContextMenuItem,
            this.RemoveContextMenuItem});
            this.RoomContextMenu.Name = "NewRoom";
            this.RoomContextMenu.Size = new System.Drawing.Size(155, 236);
            // 
            // NewContextMenuItem
            // 
            this.NewContextMenuItem.Name = "NewContextMenuItem";
            this.NewContextMenuItem.Size = new System.Drawing.Size(154, 22);
            this.NewContextMenuItem.Text = "New";
            this.NewContextMenuItem.Click += new System.EventHandler(this.NewContextMenuItem_Click);
            // 
            // EditContextMenuItem
            // 
            this.EditContextMenuItem.Name = "EditContextMenuItem";
            this.EditContextMenuItem.Size = new System.Drawing.Size(154, 22);
            this.EditContextMenuItem.Text = "Edit";
            this.EditContextMenuItem.Click += new System.EventHandler(this.EditRoomContextMenuItem_Click);
            // 
            // CopyContextMenuItem
            // 
            this.CopyContextMenuItem.Name = "CopyContextMenuItem";
            this.CopyContextMenuItem.Size = new System.Drawing.Size(154, 22);
            this.CopyContextMenuItem.Text = "Copy";
            // 
            // PasteContextMenuItem
            // 
            this.PasteContextMenuItem.Name = "PasteContextMenuItem";
            this.PasteContextMenuItem.Size = new System.Drawing.Size(154, 22);
            this.PasteContextMenuItem.Text = "Paste";
            // 
            // ClearContextMenuItem
            // 
            this.ClearContextMenuItem.Name = "ClearContextMenuItem";
            this.ClearContextMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ClearContextMenuItem.Text = "Clear";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // LoadContextMenuItem
            // 
            this.LoadContextMenuItem.Name = "LoadContextMenuItem";
            this.LoadContextMenuItem.Size = new System.Drawing.Size(154, 22);
            this.LoadContextMenuItem.Text = "Load";
            // 
            // SaveAsContextMenuItem
            // 
            this.SaveAsContextMenuItem.Name = "SaveAsContextMenuItem";
            this.SaveAsContextMenuItem.Size = new System.Drawing.Size(154, 22);
            this.SaveAsContextMenuItem.Text = "SaveAs";
            // 
            // SaveAsTemplateContextMenuItem
            // 
            this.SaveAsTemplateContextMenuItem.Name = "SaveAsTemplateContextMenuItem";
            this.SaveAsTemplateContextMenuItem.Size = new System.Drawing.Size(154, 22);
            this.SaveAsTemplateContextMenuItem.Text = "SaveToTemplate";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // MoveToAreaContextMenuItem
            // 
            this.MoveToAreaContextMenuItem.Name = "MoveToAreaContextMenuItem";
            this.MoveToAreaContextMenuItem.Size = new System.Drawing.Size(154, 22);
            this.MoveToAreaContextMenuItem.Text = "MoveTo";
            // 
            // RemoveContextMenuItem
            // 
            this.RemoveContextMenuItem.Name = "RemoveContextMenuItem";
            this.RemoveContextMenuItem.Size = new System.Drawing.Size(154, 22);
            this.RemoveContextMenuItem.Text = "Remove";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(886, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Rooms";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "AreaToXml";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.connectedListBox);
            this.groupBox2.Controls.Add(this.connectedLabel);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(22, 186);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 359);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connections";
            // 
            // connectedListBox
            // 
            this.connectedListBox.FormattingEnabled = true;
            this.connectedListBox.Location = new System.Drawing.Point(11, 40);
            this.connectedListBox.Name = "connectedListBox";
            this.connectedListBox.Size = new System.Drawing.Size(188, 303);
            this.connectedListBox.TabIndex = 2;
            // 
            // connectedLabel
            // 
            this.connectedLabel.AutoSize = true;
            this.connectedLabel.Location = new System.Drawing.Point(120, 19);
            this.connectedLabel.Name = "connectedLabel";
            this.connectedLabel.Size = new System.Drawing.Size(13, 13);
            this.connectedLabel.TabIndex = 1;
            this.connectedLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Currently Connected";
            // 
            // connectionPoller
            // 
            this.connectionPoller.Interval = 5000;
            this.connectionPoller.Tick += new System.EventHandler(this.connectionPoller_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(145, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Exit Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(145, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Exit Load";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Mountain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 570);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.roomsListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.areaListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logRichTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Mountain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mountain";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.RoomContextMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox Console;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.RichTextBox logRichTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button startServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mobToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questToolStripMenuItem;
        private System.Windows.Forms.ListBox areaListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox roomsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox listenerCheckBox;
        private System.Windows.Forms.ContextMenuStrip RoomContextMenu;
        private System.Windows.Forms.ToolStripMenuItem NewContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsTemplateContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MoveToAreaContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopyContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label connectedLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox connectedListBox;
        private System.Windows.Forms.Timer connectionPoller;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
    }

