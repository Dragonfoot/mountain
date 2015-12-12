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
            this.editorLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.roomNameButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.roomDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.exitLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.exitsLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.editorConsole = new System.Windows.Forms.RichTextBox();
            this.mobsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.permMobLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.areaComboBox = new System.Windows.Forms.ComboBox();
            this.commandsTextBox = new System.Windows.Forms.TextBox();
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
            this.Console = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listenerCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.startServer = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.connectedListBox = new System.Windows.Forms.ListBox();
            this.connectedLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.connectionPoller = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.loadXmlButton = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            this.editorLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.exitLayoutPanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.mobsLayoutPanel.SuspendLayout();
            this.permMobLayoutPanel.SuspendLayout();
            this.RoomContextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.menuStrip.Size = new System.Drawing.Size(1096, 24);
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
            this.panel2.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel2.Controls.Add(this.editorLayoutPanel);
            this.panel2.Controls.Add(this.areaComboBox);
            this.panel2.Controls.Add(this.commandsTextBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.roomsListBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(203, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(881, 385);
            this.panel2.TabIndex = 2;
            // 
            // editorLayoutPanel
            // 
            this.editorLayoutPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.editorLayoutPanel.Controls.Add(this.roomNameButton);
            this.editorLayoutPanel.Controls.Add(this.flowLayoutPanel1);
            this.editorLayoutPanel.Controls.Add(this.exitLayoutPanel);
            this.editorLayoutPanel.Controls.Add(this.flowLayoutPanel2);
            this.editorLayoutPanel.Controls.Add(this.mobsLayoutPanel);
            this.editorLayoutPanel.Controls.Add(this.permMobLayoutPanel);
            this.editorLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.editorLayoutPanel.ForeColor = System.Drawing.SystemColors.Window;
            this.editorLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.editorLayoutPanel.Name = "editorLayoutPanel";
            this.editorLayoutPanel.Size = new System.Drawing.Size(696, 353);
            this.editorLayoutPanel.TabIndex = 2;
            // 
            // roomNameButton
            // 
            this.roomNameButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.roomNameButton.FlatAppearance.BorderSize = 0;
            this.roomNameButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roomNameButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.roomNameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roomNameButton.Location = new System.Drawing.Point(3, 0);
            this.roomNameButton.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.roomNameButton.Name = "roomNameButton";
            this.roomNameButton.Size = new System.Drawing.Size(693, 23);
            this.roomNameButton.TabIndex = 0;
            this.roomNameButton.Text = "Room:Name";
            this.roomNameButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roomNameButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.roomDescriptionRichTextBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 26);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(690, 30);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // roomDescriptionRichTextBox
            // 
            this.roomDescriptionRichTextBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.roomDescriptionRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.roomDescriptionRichTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.roomDescriptionRichTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.roomDescriptionRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.roomDescriptionRichTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.roomDescriptionRichTextBox.Name = "roomDescriptionRichTextBox";
            this.roomDescriptionRichTextBox.ReadOnly = true;
            this.roomDescriptionRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.roomDescriptionRichTextBox.Size = new System.Drawing.Size(690, 30);
            this.roomDescriptionRichTextBox.TabIndex = 1;
            this.roomDescriptionRichTextBox.Text = "";
            this.roomDescriptionRichTextBox.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.roomDescriptionRichTextBox_ContentsResized);
            // 
            // exitLayoutPanel
            // 
            this.exitLayoutPanel.Controls.Add(this.exitsLabel);
            this.exitLayoutPanel.Location = new System.Drawing.Point(3, 59);
            this.exitLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.exitLayoutPanel.Name = "exitLayoutPanel";
            this.exitLayoutPanel.Size = new System.Drawing.Size(693, 26);
            this.exitLayoutPanel.TabIndex = 2;
            // 
            // exitsLabel
            // 
            this.exitsLabel.AutoSize = true;
            this.exitsLabel.Location = new System.Drawing.Point(3, 6);
            this.exitsLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.exitsLabel.Name = "exitsLabel";
            this.exitsLabel.Size = new System.Drawing.Size(32, 13);
            this.exitsLabel.TabIndex = 0;
            this.exitsLabel.Text = "Exits:";
            this.exitsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.editorConsole);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 88);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(693, 157);
            this.flowLayoutPanel2.TabIndex = 20;
            // 
            // editorConsole
            // 
            this.editorConsole.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.editorConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.editorConsole.ForeColor = System.Drawing.SystemColors.Window;
            this.editorConsole.Location = new System.Drawing.Point(3, 3);
            this.editorConsole.Name = "editorConsole";
            this.editorConsole.Size = new System.Drawing.Size(687, 162);
            this.editorConsole.TabIndex = 0;
            this.editorConsole.Text = "";
            // 
            // mobsLayoutPanel
            // 
            this.mobsLayoutPanel.Controls.Add(this.label7);
            this.mobsLayoutPanel.Location = new System.Drawing.Point(3, 248);
            this.mobsLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.mobsLayoutPanel.Name = "mobsLayoutPanel";
            this.mobsLayoutPanel.Size = new System.Drawing.Size(693, 26);
            this.mobsLayoutPanel.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Generated Mobs:";
            // 
            // permMobLayoutPanel
            // 
            this.permMobLayoutPanel.Controls.Add(this.label6);
            this.permMobLayoutPanel.Location = new System.Drawing.Point(3, 274);
            this.permMobLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.permMobLayoutPanel.Name = "permMobLayoutPanel";
            this.permMobLayoutPanel.Size = new System.Drawing.Size(693, 26);
            this.permMobLayoutPanel.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Permanent Mobs:";
            // 
            // areaComboBox
            // 
            this.areaComboBox.FormattingEnabled = true;
            this.areaComboBox.Location = new System.Drawing.Point(708, 29);
            this.areaComboBox.Name = "areaComboBox";
            this.areaComboBox.Size = new System.Drawing.Size(162, 21);
            this.areaComboBox.TabIndex = 20;
            this.areaComboBox.SelectedIndexChanged += new System.EventHandler(this.areaComboBox_SelectedIndexChanged);
            // 
            // commandsTextBox
            // 
            this.commandsTextBox.Location = new System.Drawing.Point(3, 360);
            this.commandsTextBox.Name = "commandsTextBox";
            this.commandsTextBox.Size = new System.Drawing.Size(696, 20);
            this.commandsTextBox.TabIndex = 1;
            this.commandsTextBox.TextChanged += new System.EventHandler(this.commandsTextBox_TextChanged);
            this.commandsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.commandsTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(712, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Areas";
            // 
            // roomsListBox
            // 
            this.roomsListBox.ContextMenuStrip = this.RoomContextMenu;
            this.roomsListBox.FormattingEnabled = true;
            this.roomsListBox.Location = new System.Drawing.Point(708, 67);
            this.roomsListBox.Name = "roomsListBox";
            this.roomsListBox.Size = new System.Drawing.Size(162, 82);
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
            this.label3.Location = new System.Drawing.Point(712, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Area Rooms";
            // 
            // Console
            // 
            this.Console.BackColor = System.Drawing.SystemColors.Window;
            this.Console.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Console.FormattingEnabled = true;
            this.Console.HorizontalScrollbar = true;
            this.Console.Location = new System.Drawing.Point(203, 437);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(699, 121);
            this.Console.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listenerCheckBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.startServer);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(55, 410);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(969, 450);
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
            this.groupBox2.Location = new System.Drawing.Point(13, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 348);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connections";
            // 
            // connectedListBox
            // 
            this.connectedListBox.FormattingEnabled = true;
            this.connectedListBox.Location = new System.Drawing.Point(11, 40);
            this.connectedListBox.Name = "connectedListBox";
            this.connectedListBox.Size = new System.Drawing.Size(152, 290);
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
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Connected";
            // 
            // connectionPoller
            // 
            this.connectionPoller.Interval = 5000;
            this.connectionPoller.Tick += new System.EventHandler(this.connectionPoller_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(969, 480);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Xml Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // loadXmlButton
            // 
            this.loadXmlButton.Location = new System.Drawing.Point(969, 510);
            this.loadXmlButton.Name = "loadXmlButton";
            this.loadXmlButton.Size = new System.Drawing.Size(75, 23);
            this.loadXmlButton.TabIndex = 19;
            this.loadXmlButton.Text = "Load Xml";
            this.loadXmlButton.UseVisualStyleBackColor = true;
            this.loadXmlButton.Click += new System.EventHandler(this.loadXmlButton_Click);
            // 
            // Mountain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 570);
            this.Controls.Add(this.Console);
            this.Controls.Add(this.loadXmlButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.button1);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Mountain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mountain";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.editorLayoutPanel.ResumeLayout(false);
            this.editorLayoutPanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.exitLayoutPanel.ResumeLayout(false);
            this.exitLayoutPanel.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.mobsLayoutPanel.ResumeLayout(false);
            this.mobsLayoutPanel.PerformLayout();
            this.permMobLayoutPanel.ResumeLayout(false);
            this.permMobLayoutPanel.PerformLayout();
            this.RoomContextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TextBox commandsTextBox;
        private System.Windows.Forms.ListBox Console;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
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
        private System.Windows.Forms.Button loadXmlButton;
        private System.Windows.Forms.ComboBox areaComboBox;
        private System.Windows.Forms.FlowLayoutPanel editorLayoutPanel;
        private System.Windows.Forms.Button roomNameButton;
        private System.Windows.Forms.FlowLayoutPanel exitLayoutPanel;
        private System.Windows.Forms.Label exitsLabel;
        private System.Windows.Forms.FlowLayoutPanel permMobLayoutPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel mobsLayoutPanel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox editorConsole;
        private System.Windows.Forms.RichTextBox roomDescriptionRichTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
    }

