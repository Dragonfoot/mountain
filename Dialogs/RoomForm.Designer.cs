using Mountain.classes.controls;


namespace Mountain.Dialogs {

    partial class RoomForm {
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitsGroupBox = new System.Windows.Forms.GroupBox();
            this.exitLinkToAreaComboBox = new System.Windows.Forms.ComboBox();
            this.exitLinkToRoomComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.exitLinkTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.exitListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.exitDoorDirectionTextBox = new System.Windows.Forms.TextBox();
            this.exitDoorDirectionalComboBox = new System.Windows.Forms.ComboBox();
            this.exitDoorLockTypeComboBox = new System.Windows.Forms.ComboBox();
            this.exitDoorRestrictionCheckBox = new System.Windows.Forms.CheckBox();
            this.exitDoorDirectionalCheckBox = new System.Windows.Forms.CheckBox();
            this.exitDoorHasLockCheckBox = new System.Windows.Forms.CheckBox();
            this.exitDoorCheckBox = new System.Windows.Forms.CheckBox();
            this.openCheckBox = new System.Windows.Forms.CheckBox();
            this.exitHiddenDoorCheckBox = new System.Windows.Forms.CheckBox();
            this.identityGroupBox = new System.Windows.Forms.GroupBox();
            this.roomTraitsCheckBox = new System.Windows.Forms.CheckBox();
            this.roomLimitCheckBox = new System.Windows.Forms.CheckBox();
            this.roomTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.roomLimitsTextBox = new System.Windows.Forms.TextBox();
            this.roomTypeTextBox = new System.Windows.Forms.TextBox();
            this.shortDescriptonTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tagTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.areaLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.buildMenuStrip = new System.Windows.Forms.MenuStrip();
            this.buildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pawnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.templateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.exitContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.templateToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.roomTypeCheckEnum = new CheckEnum();
            this.panel1.SuspendLayout();
            this.exitsGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.identityGroupBox.SuspendLayout();
            this.buildMenuStrip.SuspendLayout();
            this.exitContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.exitsGroupBox);
            this.panel1.Controls.Add(this.identityGroupBox);
            this.panel1.Location = new System.Drawing.Point(24, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 395);
            this.panel1.TabIndex = 0;
            // 
            // exitsGroupBox
            // 
            this.exitsGroupBox.Controls.Add(this.exitLinkToAreaComboBox);
            this.exitsGroupBox.Controls.Add(this.exitLinkToRoomComboBox);
            this.exitsGroupBox.Controls.Add(this.label3);
            this.exitsGroupBox.Controls.Add(this.exitLinkTypeComboBox);
            this.exitsGroupBox.Controls.Add(this.label5);
            this.exitsGroupBox.Controls.Add(this.label4);
            this.exitsGroupBox.Controls.Add(this.exitListBox);
            this.exitsGroupBox.Controls.Add(this.groupBox2);
            this.exitsGroupBox.Location = new System.Drawing.Point(427, 16);
            this.exitsGroupBox.Name = "exitsGroupBox";
            this.exitsGroupBox.Size = new System.Drawing.Size(422, 360);
            this.exitsGroupBox.TabIndex = 1;
            this.exitsGroupBox.TabStop = false;
            this.exitsGroupBox.Text = "Exits";
            // 
            // exitLinkToAreaComboBox
            // 
            this.exitLinkToAreaComboBox.FormattingEnabled = true;
            this.exitLinkToAreaComboBox.Location = new System.Drawing.Point(243, 59);
            this.exitLinkToAreaComboBox.Name = "exitLinkToAreaComboBox";
            this.exitLinkToAreaComboBox.Size = new System.Drawing.Size(161, 21);
            this.exitLinkToAreaComboBox.TabIndex = 12;
            // 
            // exitLinkToRoomComboBox
            // 
            this.exitLinkToRoomComboBox.FormattingEnabled = true;
            this.exitLinkToRoomComboBox.Location = new System.Drawing.Point(243, 89);
            this.exitLinkToRoomComboBox.Name = "exitLinkToRoomComboBox";
            this.exitLinkToRoomComboBox.Size = new System.Drawing.Size(161, 21);
            this.exitLinkToRoomComboBox.TabIndex = 11;
            this.exitLinkToRoomComboBox.SelectedIndexChanged += new System.EventHandler(this.exitLinkToRoomComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "To Room";
            // 
            // exitLinkTypeComboBox
            // 
            this.exitLinkTypeComboBox.FormattingEnabled = true;
            this.exitLinkTypeComboBox.Location = new System.Drawing.Point(243, 29);
            this.exitLinkTypeComboBox.Name = "exitLinkTypeComboBox";
            this.exitLinkTypeComboBox.Size = new System.Drawing.Size(161, 21);
            this.exitLinkTypeComboBox.TabIndex = 9;
            this.exitLinkTypeComboBox.Text = "Exit Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Link Area";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Exit Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitListBox
            // 
            this.exitListBox.FormattingEnabled = true;
            this.exitListBox.Location = new System.Drawing.Point(17, 28);
            this.exitListBox.Name = "exitListBox";
            this.exitListBox.Size = new System.Drawing.Size(164, 82);
            this.exitListBox.TabIndex = 3;
            this.exitListBox.SelectedIndexChanged += new System.EventHandler(this.exitListBox_SelectedIndexChanged);
            this.exitListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exitListBox_MouseDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.exitDoorDirectionTextBox);
            this.groupBox2.Controls.Add(this.exitDoorDirectionalComboBox);
            this.groupBox2.Controls.Add(this.exitDoorLockTypeComboBox);
            this.groupBox2.Controls.Add(this.exitDoorRestrictionCheckBox);
            this.groupBox2.Controls.Add(this.exitDoorDirectionalCheckBox);
            this.groupBox2.Controls.Add(this.exitDoorHasLockCheckBox);
            this.groupBox2.Controls.Add(this.exitDoorCheckBox);
            this.groupBox2.Controls.Add(this.openCheckBox);
            this.groupBox2.Controls.Add(this.exitHiddenDoorCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(17, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 219);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attributes";
            // 
            // exitDoorDirectionTextBox
            // 
            this.exitDoorDirectionTextBox.Location = new System.Drawing.Point(142, 43);
            this.exitDoorDirectionTextBox.Name = "exitDoorDirectionTextBox";
            this.exitDoorDirectionTextBox.Size = new System.Drawing.Size(117, 20);
            this.exitDoorDirectionTextBox.TabIndex = 19;
            // 
            // exitDoorDirectionalComboBox
            // 
            this.exitDoorDirectionalComboBox.FormattingEnabled = true;
            this.exitDoorDirectionalComboBox.Location = new System.Drawing.Point(163, 43);
            this.exitDoorDirectionalComboBox.Name = "exitDoorDirectionalComboBox";
            this.exitDoorDirectionalComboBox.Size = new System.Drawing.Size(70, 21);
            this.exitDoorDirectionalComboBox.TabIndex = 17;
            this.exitDoorDirectionalComboBox.Text = "Direction";
            this.exitDoorDirectionalComboBox.Visible = false;
            this.exitDoorDirectionalComboBox.SelectedIndexChanged += new System.EventHandler(this.directionalComboBox_SelectedIndexChanged);
            // 
            // exitDoorLockTypeComboBox
            // 
            this.exitDoorLockTypeComboBox.FormattingEnabled = true;
            this.exitDoorLockTypeComboBox.Location = new System.Drawing.Point(194, 22);
            this.exitDoorLockTypeComboBox.Name = "exitDoorLockTypeComboBox";
            this.exitDoorLockTypeComboBox.Size = new System.Drawing.Size(65, 21);
            this.exitDoorLockTypeComboBox.TabIndex = 16;
            this.exitDoorLockTypeComboBox.Text = "Lock Type";
            this.exitDoorLockTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.lockTypeComboBox_SelectedIndexChanged);
            // 
            // exitDoorRestrictionCheckBox
            // 
            this.exitDoorRestrictionCheckBox.AutoSize = true;
            this.exitDoorRestrictionCheckBox.Location = new System.Drawing.Point(14, 67);
            this.exitDoorRestrictionCheckBox.Name = "exitDoorRestrictionCheckBox";
            this.exitDoorRestrictionCheckBox.Size = new System.Drawing.Size(121, 17);
            this.exitDoorRestrictionCheckBox.TabIndex = 15;
            this.exitDoorRestrictionCheckBox.Text = "Unrestricted Access";
            this.exitDoorRestrictionCheckBox.UseVisualStyleBackColor = true;
            this.exitDoorRestrictionCheckBox.CheckedChanged += new System.EventHandler(this.restrictionCheckBox_CheckedChanged);
            // 
            // exitDoorDirectionalCheckBox
            // 
            this.exitDoorDirectionalCheckBox.AutoSize = true;
            this.exitDoorDirectionalCheckBox.Location = new System.Drawing.Point(84, 46);
            this.exitDoorDirectionalCheckBox.Name = "exitDoorDirectionalCheckBox";
            this.exitDoorDirectionalCheckBox.Size = new System.Drawing.Size(52, 17);
            this.exitDoorDirectionalCheckBox.TabIndex = 14;
            this.exitDoorDirectionalCheckBox.Text = "Label";
            this.exitDoorDirectionalCheckBox.UseVisualStyleBackColor = true;
            this.exitDoorDirectionalCheckBox.CheckedChanged += new System.EventHandler(this.directionalCheckBox_CheckedChanged);
            // 
            // exitDoorHasLockCheckBox
            // 
            this.exitDoorHasLockCheckBox.AutoSize = true;
            this.exitDoorHasLockCheckBox.Location = new System.Drawing.Point(143, 24);
            this.exitDoorHasLockCheckBox.Name = "exitDoorHasLockCheckBox";
            this.exitDoorHasLockCheckBox.Size = new System.Drawing.Size(67, 17);
            this.exitDoorHasLockCheckBox.TabIndex = 10;
            this.exitDoorHasLockCheckBox.Text = "No Lock";
            this.exitDoorHasLockCheckBox.UseVisualStyleBackColor = true;
            this.exitDoorHasLockCheckBox.CheckedChanged += new System.EventHandler(this.hasLockCheckBox_CheckedChanged);
            // 
            // exitDoorCheckBox
            // 
            this.exitDoorCheckBox.AutoSize = true;
            this.exitDoorCheckBox.Location = new System.Drawing.Point(14, 21);
            this.exitDoorCheckBox.Name = "exitDoorCheckBox";
            this.exitDoorCheckBox.Size = new System.Drawing.Size(67, 17);
            this.exitDoorCheckBox.TabIndex = 9;
            this.exitDoorCheckBox.Text = "Doorless";
            this.exitDoorCheckBox.UseVisualStyleBackColor = true;
            this.exitDoorCheckBox.CheckedChanged += new System.EventHandler(this.doorCheckBox_CheckedChanged);
            // 
            // openCheckBox
            // 
            this.openCheckBox.AutoSize = true;
            this.openCheckBox.Location = new System.Drawing.Point(84, 23);
            this.openCheckBox.Name = "openCheckBox";
            this.openCheckBox.Size = new System.Drawing.Size(52, 17);
            this.openCheckBox.TabIndex = 8;
            this.openCheckBox.Text = "Open";
            this.openCheckBox.UseVisualStyleBackColor = true;
            this.openCheckBox.CheckedChanged += new System.EventHandler(this.openExitDoorCheckBox_CheckedChanged);
            // 
            // exitHiddenDoorCheckBox
            // 
            this.exitHiddenDoorCheckBox.AutoSize = true;
            this.exitHiddenDoorCheckBox.Location = new System.Drawing.Point(14, 44);
            this.exitHiddenDoorCheckBox.Name = "exitHiddenDoorCheckBox";
            this.exitHiddenDoorCheckBox.Size = new System.Drawing.Size(56, 17);
            this.exitHiddenDoorCheckBox.TabIndex = 6;
            this.exitHiddenDoorCheckBox.Text = "Visible";
            this.exitHiddenDoorCheckBox.UseVisualStyleBackColor = true;
            this.exitHiddenDoorCheckBox.CheckedChanged += new System.EventHandler(this.hiddenExitDoorCheckBox_CheckedChanged);
            // 
            // identityGroupBox
            // 
            this.identityGroupBox.Controls.Add(this.roomTraitsCheckBox);
            this.identityGroupBox.Controls.Add(this.roomLimitCheckBox);
            this.identityGroupBox.Controls.Add(this.roomTypeCheckBox);
            this.identityGroupBox.Controls.Add(this.roomTypeCheckEnum);
            this.identityGroupBox.Controls.Add(this.textBox2);
            this.identityGroupBox.Controls.Add(this.roomLimitsTextBox);
            this.identityGroupBox.Controls.Add(this.roomTypeTextBox);
            this.identityGroupBox.Controls.Add(this.shortDescriptonTextBox);
            this.identityGroupBox.Controls.Add(this.label9);
            this.identityGroupBox.Controls.Add(this.tagTextBox);
            this.identityGroupBox.Controls.Add(this.label2);
            this.identityGroupBox.Controls.Add(this.areaLabel);
            this.identityGroupBox.Controls.Add(this.descriptionLabel);
            this.identityGroupBox.Controls.Add(this.descriptionTextBox);
            this.identityGroupBox.Controls.Add(this.label1);
            this.identityGroupBox.Controls.Add(this.nameTextBox);
            this.identityGroupBox.Location = new System.Drawing.Point(17, 16);
            this.identityGroupBox.Name = "identityGroupBox";
            this.identityGroupBox.Size = new System.Drawing.Size(395, 360);
            this.identityGroupBox.TabIndex = 0;
            this.identityGroupBox.TabStop = false;
            this.identityGroupBox.Text = "Identity";
            // 
            // roomTraitsCheckBox
            // 
            this.roomTraitsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.roomTraitsCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.roomTraitsCheckBox.FlatAppearance.BorderSize = 2;
            this.roomTraitsCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.roomTraitsCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.roomTraitsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.roomTraitsCheckBox.Location = new System.Drawing.Point(221, 140);
            this.roomTraitsCheckBox.Name = "roomTraitsCheckBox";
            this.roomTraitsCheckBox.Size = new System.Drawing.Size(41, 24);
            this.roomTraitsCheckBox.TabIndex = 25;
            this.roomTraitsCheckBox.Text = "Traits";
            this.roomTraitsCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.roomTraitsCheckBox.UseVisualStyleBackColor = false;
            this.roomTraitsCheckBox.CheckedChanged += new System.EventHandler(this.roomTraitsCheckBox_CheckedChanged);
            // 
            // roomLimitCheckBox
            // 
            this.roomLimitCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.roomLimitCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.roomLimitCheckBox.FlatAppearance.BorderSize = 2;
            this.roomLimitCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.roomLimitCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.roomLimitCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.roomLimitCheckBox.Location = new System.Drawing.Point(221, 115);
            this.roomLimitCheckBox.Name = "roomLimitCheckBox";
            this.roomLimitCheckBox.Size = new System.Drawing.Size(41, 24);
            this.roomLimitCheckBox.TabIndex = 20;
            this.roomLimitCheckBox.Text = "Limits";
            this.roomLimitCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.roomLimitCheckBox.UseVisualStyleBackColor = false;
            this.roomLimitCheckBox.CheckedChanged += new System.EventHandler(this.roomLimitCheckBox_CheckedChanged);
            // 
            // roomTypeCheckBox
            // 
            this.roomTypeCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.roomTypeCheckBox.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.roomTypeCheckBox.FlatAppearance.BorderSize = 2;
            this.roomTypeCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.roomTypeCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.roomTypeCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.roomTypeCheckBox.Location = new System.Drawing.Point(221, 90);
            this.roomTypeCheckBox.Name = "roomTypeCheckBox";
            this.roomTypeCheckBox.Size = new System.Drawing.Size(41, 24);
            this.roomTypeCheckBox.TabIndex = 20;
            this.roomTypeCheckBox.Text = "Type";
            this.roomTypeCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.roomTypeCheckBox.UseVisualStyleBackColor = false;
            this.roomTypeCheckBox.CheckedChanged += new System.EventHandler(this.roomTypeCheckBox_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(266, 142);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(108, 20);
            this.textBox2.TabIndex = 22;
            // 
            // roomLimitsTextBox
            // 
            this.roomLimitsTextBox.Location = new System.Drawing.Point(266, 117);
            this.roomLimitsTextBox.Name = "roomLimitsTextBox";
            this.roomLimitsTextBox.Size = new System.Drawing.Size(108, 20);
            this.roomLimitsTextBox.TabIndex = 21;
            // 
            // roomTypeTextBox
            // 
            this.roomTypeTextBox.Location = new System.Drawing.Point(266, 92);
            this.roomTypeTextBox.Name = "roomTypeTextBox";
            this.roomTypeTextBox.Size = new System.Drawing.Size(108, 20);
            this.roomTypeTextBox.TabIndex = 20;
            this.roomTypeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.roomTypeTextBox_KeyDown);
            this.roomTypeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.roomTypeTextBox_KeyPress);
            this.roomTypeTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.roomTypeTextBox_MouseDown);
            // 
            // shortDescriptonTextBox
            // 
            this.shortDescriptonTextBox.Location = new System.Drawing.Point(14, 257);
            this.shortDescriptonTextBox.Multiline = true;
            this.shortDescriptonTextBox.Name = "shortDescriptonTextBox";
            this.shortDescriptonTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.shortDescriptonTextBox.Size = new System.Drawing.Size(188, 52);
            this.shortDescriptonTextBox.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Short Description";
            // 
            // tagTextBox
            // 
            this.tagTextBox.Location = new System.Drawing.Point(14, 327);
            this.tagTextBox.Name = "tagTextBox";
            this.tagTextBox.Size = new System.Drawing.Size(188, 20);
            this.tagTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tag";
            // 
            // areaLabel
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.Location = new System.Drawing.Point(17, 17);
            this.areaLabel.Name = "areaLabel";
            this.areaLabel.Size = new System.Drawing.Size(60, 13);
            this.areaLabel.TabIndex = 8;
            this.areaLabel.Text = "Area Name";
            this.areaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(17, 74);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 3;
            this.descriptionLabel.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.AcceptsReturn = true;
            this.descriptionTextBox.Location = new System.Drawing.Point(14, 88);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(188, 150);
            this.descriptionTextBox.TabIndex = 2;
            this.descriptionTextBox.TextChanged += new System.EventHandler(this.descriptionTextBox_TextChanged);
            this.descriptionTextBox.Leave += new System.EventHandler(this.roomDescriptionTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(14, 50);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(188, 20);
            this.nameTextBox.TabIndex = 0;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            this.nameTextBox.Enter += new System.EventHandler(this.nameTextBox_Enter);
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            this.nameTextBox.Leave += new System.EventHandler(this.nameTextBox_Leave);
            // 
            // buildMenuStrip
            // 
            this.buildMenuStrip.Enabled = false;
            this.buildMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildToolStripMenuItem});
            this.buildMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.buildMenuStrip.Name = "buildMenuStrip";
            this.buildMenuStrip.Size = new System.Drawing.Size(922, 24);
            this.buildMenuStrip.TabIndex = 1;
            this.buildMenuStrip.Text = "menuStrip1";
            // 
            // buildToolStripMenuItem
            // 
            this.buildToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem1,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.buildToolStripMenuItem.Name = "buildToolStripMenuItem";
            this.buildToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.buildToolStripMenuItem.Text = "Build";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roomToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // roomToolStripMenuItem
            // 
            this.roomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.healingToolStripMenuItem,
            this.shopToolStripMenuItem,
            this.pawnToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.roomToolStripMenuItem.Name = "roomToolStripMenuItem";
            this.roomToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.roomToolStripMenuItem.Text = "Room";
            // 
            // healingToolStripMenuItem
            // 
            this.healingToolStripMenuItem.Name = "healingToolStripMenuItem";
            this.healingToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.healingToolStripMenuItem.Text = "Healing";
            // 
            // shopToolStripMenuItem
            // 
            this.shopToolStripMenuItem.Name = "shopToolStripMenuItem";
            this.shopToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.shopToolStripMenuItem.Text = "Shop";
            // 
            // pawnToolStripMenuItem
            // 
            this.pawnToolStripMenuItem.Name = "pawnToolStripMenuItem";
            this.pawnToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.pawnToolStripMenuItem.Text = "Pawn";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 6);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.templateToolStripMenuItem,
            this.fromAreaToolStripMenuItem,
            this.fromWorldToolStripMenuItem});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // templateToolStripMenuItem
            // 
            this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
            this.templateToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.templateToolStripMenuItem.Text = "Template";
            // 
            // fromAreaToolStripMenuItem
            // 
            this.fromAreaToolStripMenuItem.Name = "fromAreaToolStripMenuItem";
            this.fromAreaToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fromAreaToolStripMenuItem.Text = "From Area";
            // 
            // fromWorldToolStripMenuItem
            // 
            this.fromWorldToolStripMenuItem.Name = "fromWorldToolStripMenuItem";
            this.fromWorldToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fromWorldToolStripMenuItem.Text = "From World";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.templateToolStripMenuItem1,
            this.toAreaToolStripMenuItem,
            this.toWorldToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.fileToolStripMenuItem1.Text = "File";
            // 
            // templateToolStripMenuItem1
            // 
            this.templateToolStripMenuItem1.Name = "templateToolStripMenuItem1";
            this.templateToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.templateToolStripMenuItem1.Text = "Template";
            // 
            // toAreaToolStripMenuItem
            // 
            this.toAreaToolStripMenuItem.Name = "toAreaToolStripMenuItem";
            this.toAreaToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.toAreaToolStripMenuItem.Text = "To Area";
            // 
            // toWorldToolStripMenuItem
            // 
            this.toWorldToolStripMenuItem.Name = "toWorldToolStripMenuItem";
            this.toWorldToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.toWorldToolStripMenuItem.Text = "To World";
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(726, 449);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(807, 449);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // exitContextMenu
            // 
            this.exitContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem1});
            this.exitContextMenu.Name = "exitContextMenu";
            this.exitContextMenu.Size = new System.Drawing.Size(114, 76);
            this.exitContextMenu.Text = "Exit";
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.newToolStripMenuItem1.Text = "New";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem2.Text = "Remove";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem2,
            this.templateToolStripMenuItem2});
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // fileToolStripMenuItem2
            // 
            this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            this.fileToolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.fileToolStripMenuItem2.Text = "To File";
            // 
            // templateToolStripMenuItem2
            // 
            this.templateToolStripMenuItem2.Name = "templateToolStripMenuItem2";
            this.templateToolStripMenuItem2.Size = new System.Drawing.Size(133, 22);
            this.templateToolStripMenuItem2.Text = "As Template";
            // 
            // roomTypeCheckEnum
            // 
            this.roomTypeCheckEnum.CheckOnClick = true;
            this.roomTypeCheckEnum.FormattingEnabled = true;
            this.roomTypeCheckEnum.Location = new System.Drawing.Point(266, 243);
            this.roomTypeCheckEnum.Name = "roomTypeCheckEnum";
            this.roomTypeCheckEnum.Size = new System.Drawing.Size(108, 94);
            this.roomTypeCheckEnum.TabIndex = 24;
            this.roomTypeCheckEnum.ThreeDCheckBoxes = true;
            this.roomTypeCheckEnum.Visible = false;
            this.roomTypeCheckEnum.VisibleChanged += new System.EventHandler(this.roomTypeCheckEnum_VisibleChanged);
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(922, 479);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buildMenuStrip);
            this.MainMenuStrip = this.buildMenuStrip;
            this.Name = "RoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RoomForm";
            this.panel1.ResumeLayout(false);
            this.exitsGroupBox.ResumeLayout(false);
            this.exitsGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.identityGroupBox.ResumeLayout(false);
            this.identityGroupBox.PerformLayout();
            this.buildMenuStrip.ResumeLayout(false);
            this.buildMenuStrip.PerformLayout();
            this.exitContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip buildMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem buildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toWorldToolStripMenuItem;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolStripMenuItem healingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pawnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.GroupBox exitsGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox identityGroupBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label areaLabel;
        private System.Windows.Forms.CheckBox exitHiddenDoorCheckBox;
        private System.Windows.Forms.CheckBox openCheckBox;
        private System.Windows.Forms.CheckBox exitDoorCheckBox;
        private System.Windows.Forms.CheckBox exitDoorHasLockCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox exitListBox;
        private System.Windows.Forms.CheckBox exitDoorDirectionalCheckBox;
        private System.Windows.Forms.ComboBox exitLinkToAreaComboBox;
        private System.Windows.Forms.ComboBox exitLinkToRoomComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox exitLinkTypeComboBox;
        private System.Windows.Forms.ComboBox exitDoorLockTypeComboBox;
        private System.Windows.Forms.CheckBox exitDoorRestrictionCheckBox;
        private System.Windows.Forms.ComboBox exitDoorDirectionalComboBox;
        private System.Windows.Forms.TextBox exitDoorDirectionTextBox;
        private System.Windows.Forms.ContextMenuStrip exitContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox tagTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox shortDescriptonTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox roomTypeTextBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox roomLimitsTextBox;
        private CheckEnum roomTypeCheckEnum;
        private System.Windows.Forms.CheckBox roomTraitsCheckBox;
        private System.Windows.Forms.CheckBox roomLimitCheckBox;
        private System.Windows.Forms.CheckBox roomTypeCheckBox;
    }
}