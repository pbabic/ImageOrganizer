using System;

namespace ImageOrganizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDestination = new System.Windows.Forms.Button();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.chkIncludeSubfolders = new System.Windows.Forms.CheckBox();
            this.btnSource = new System.Windows.Forms.Button();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbNameExists = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRename = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkMove = new System.Windows.Forms.CheckBox();
            this.btnDefault = new System.Windows.Forms.Button();
            this.txtExtensions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCustom3 = new System.Windows.Forms.TextBox();
            this.txtCustom2 = new System.Windows.Forms.TextBox();
            this.txtCustom1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.chkFindCameraData = new System.Windows.Forms.CheckBox();
            this.cmbThirdLevelFolder = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbSecondLevelFolder = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFirstLevelFolder = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payPayDonationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnDestination);
            this.groupBox1.Controls.Add(this.txtDestination);
            this.groupBox1.Controls.Add(this.chkIncludeSubfolders);
            this.groupBox1.Controls.Add(this.btnSource);
            this.groupBox1.Controls.Add(this.txtSource);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(826, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(797, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(797, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnDestination
            // 
            this.btnDestination.Location = new System.Drawing.Point(756, 69);
            this.btnDestination.Margin = new System.Windows.Forms.Padding(2);
            this.btnDestination.Name = "btnDestination";
            this.btnDestination.Size = new System.Drawing.Size(38, 19);
            this.btnDestination.TabIndex = 6;
            this.btnDestination.Text = "...";
            this.btnDestination.UseVisualStyleBackColor = true;
            this.btnDestination.Click += new System.EventHandler(this.BtnDestination_Click);
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(128, 68);
            this.txtDestination.Margin = new System.Windows.Forms.Padding(2);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.ReadOnly = true;
            this.txtDestination.Size = new System.Drawing.Size(624, 21);
            this.txtDestination.TabIndex = 5;
            // 
            // chkIncludeSubfolders
            // 
            this.chkIncludeSubfolders.AutoSize = true;
            this.chkIncludeSubfolders.Checked = true;
            this.chkIncludeSubfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeSubfolders.Location = new System.Drawing.Point(646, 37);
            this.chkIncludeSubfolders.Margin = new System.Windows.Forms.Padding(2);
            this.chkIncludeSubfolders.Name = "chkIncludeSubfolders";
            this.chkIncludeSubfolders.Size = new System.Drawing.Size(131, 17);
            this.chkIncludeSubfolders.TabIndex = 4;
            this.chkIncludeSubfolders.Text = "Include subfolders";
            this.chkIncludeSubfolders.UseVisualStyleBackColor = true;
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(756, 14);
            this.btnSource.Margin = new System.Windows.Forms.Padding(2);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(38, 19);
            this.btnSource.TabIndex = 3;
            this.btnSource.Text = "...";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.BtnSource_Click);
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(128, 13);
            this.txtSource.Margin = new System.Windows.Forms.Padding(2);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(624, 21);
            this.txtSource.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(5, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Destination folder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source folder:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbNameExists);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbRename);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkMove);
            this.groupBox2.Controls.Add(this.btnDefault);
            this.groupBox2.Controls.Add(this.txtExtensions);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 145);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(826, 148);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File options";
            // 
            // cmbNameExists
            // 
            this.cmbNameExists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNameExists.FormattingEnabled = true;
            this.cmbNameExists.Location = new System.Drawing.Point(377, 109);
            this.cmbNameExists.Margin = new System.Windows.Forms.Padding(2);
            this.cmbNameExists.Name = "cmbNameExists";
            this.cmbNameExists.Size = new System.Drawing.Size(368, 21);
            this.cmbNameExists.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(363, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "If file with the same name already exists in destination folder:";
            // 
            // cmbRename
            // 
            this.cmbRename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRename.FormattingEnabled = true;
            this.cmbRename.Location = new System.Drawing.Point(155, 78);
            this.cmbRename.Margin = new System.Windows.Forms.Padding(2);
            this.cmbRename.Name = "cmbRename";
            this.cmbRename.Size = new System.Drawing.Size(590, 21);
            this.cmbRename.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rename destination file:";
            // 
            // chkMove
            // 
            this.chkMove.AutoSize = true;
            this.chkMove.Location = new System.Drawing.Point(8, 51);
            this.chkMove.Margin = new System.Windows.Forms.Padding(2);
            this.chkMove.Name = "chkMove";
            this.chkMove.Size = new System.Drawing.Size(193, 17);
            this.chkMove.TabIndex = 3;
            this.chkMove.Text = "Move files from source folder";
            this.chkMove.UseVisualStyleBackColor = true;
            this.chkMove.CheckedChanged += new System.EventHandler(this.chkMove_CheckedChanged);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(756, 20);
            this.btnDefault.Margin = new System.Windows.Forms.Padding(2);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(65, 21);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.BtnDefault_Click);
            // 
            // txtExtensions
            // 
            this.txtExtensions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExtensions.Location = new System.Drawing.Point(260, 21);
            this.txtExtensions.Margin = new System.Windows.Forms.Padding(2);
            this.txtExtensions.Name = "txtExtensions";
            this.txtExtensions.Size = new System.Drawing.Size(485, 21);
            this.txtExtensions.TabIndex = 1;
            this.txtExtensions.Text = "JPG,JPEG,BMP,PNG";
            this.txtExtensions.LostFocus += new System.EventHandler(this.TxtExtension_Validate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Extensions (leave empty for all file types):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCustom3);
            this.groupBox3.Controls.Add(this.txtCustom2);
            this.groupBox3.Controls.Add(this.txtCustom1);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.chkFindCameraData);
            this.groupBox3.Controls.Add(this.cmbThirdLevelFolder);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cmbSecondLevelFolder);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.cmbFirstLevelFolder);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 312);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(826, 213);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create destination folders";
            // 
            // txtCustom3
            // 
            this.txtCustom3.Location = new System.Drawing.Point(335, 95);
            this.txtCustom3.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustom3.Name = "txtCustom3";
            this.txtCustom3.Size = new System.Drawing.Size(442, 21);
            this.txtCustom3.TabIndex = 12;
            this.txtCustom3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustom1_KeyPress);
            // 
            // txtCustom2
            // 
            this.txtCustom2.Location = new System.Drawing.Point(335, 57);
            this.txtCustom2.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustom2.Name = "txtCustom2";
            this.txtCustom2.Size = new System.Drawing.Size(442, 21);
            this.txtCustom2.TabIndex = 10;
            this.txtCustom2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustom1_KeyPress);
            // 
            // txtCustom1
            // 
            this.txtCustom1.Location = new System.Drawing.Point(335, 22);
            this.txtCustom1.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustom1.Name = "txtCustom1";
            this.txtCustom1.Size = new System.Drawing.Size(442, 21);
            this.txtCustom1.TabIndex = 8;
            this.txtCustom1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustom1_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Location = new System.Drawing.Point(19, 148);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(786, 46);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Example";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(776, 21);
            this.textBox1.TabIndex = 0;
            // 
            // chkFindCameraData
            // 
            this.chkFindCameraData.AutoSize = true;
            this.chkFindCameraData.Location = new System.Drawing.Point(19, 124);
            this.chkFindCameraData.Margin = new System.Windows.Forms.Padding(2);
            this.chkFindCameraData.Name = "chkFindCameraData";
            this.chkFindCameraData.Size = new System.Drawing.Size(488, 17);
            this.chkFindCameraData.TabIndex = 6;
            this.chkFindCameraData.Text = "For non image files take camera data from first image file within the same folder" +
    "";
            this.chkFindCameraData.UseVisualStyleBackColor = true;
            // 
            // cmbThirdLevelFolder
            // 
            this.cmbThirdLevelFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThirdLevelFolder.FormattingEnabled = true;
            this.cmbThirdLevelFolder.Location = new System.Drawing.Point(104, 95);
            this.cmbThirdLevelFolder.Margin = new System.Windows.Forms.Padding(2);
            this.cmbThirdLevelFolder.Name = "cmbThirdLevelFolder";
            this.cmbThirdLevelFolder.Size = new System.Drawing.Size(227, 21);
            this.cmbThirdLevelFolder.TabIndex = 5;
            this.cmbThirdLevelFolder.SelectedIndexChanged += new System.EventHandler(this.cmbThirdLevelFolder_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 95);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Third level:";
            // 
            // cmbSecondLevelFolder
            // 
            this.cmbSecondLevelFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSecondLevelFolder.FormattingEnabled = true;
            this.cmbSecondLevelFolder.Location = new System.Drawing.Point(104, 57);
            this.cmbSecondLevelFolder.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSecondLevelFolder.Name = "cmbSecondLevelFolder";
            this.cmbSecondLevelFolder.Size = new System.Drawing.Size(227, 21);
            this.cmbSecondLevelFolder.TabIndex = 3;
            this.cmbSecondLevelFolder.SelectedIndexChanged += new System.EventHandler(this.cmbSecondLevelFolder_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 60);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Second level:";
            // 
            // cmbFirstLevelFolder
            // 
            this.cmbFirstLevelFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFirstLevelFolder.FormattingEnabled = true;
            this.cmbFirstLevelFolder.Location = new System.Drawing.Point(104, 22);
            this.cmbFirstLevelFolder.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFirstLevelFolder.Name = "cmbFirstLevelFolder";
            this.cmbFirstLevelFolder.Size = new System.Drawing.Size(227, 21);
            this.cmbFirstLevelFolder.TabIndex = 1;
            this.cmbFirstLevelFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFirstLevelFolder_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "First level:";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(727, 531);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 49);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(852, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.payPayDonationToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // payPayDonationToolStripMenuItem
            // 
            this.payPayDonationToolStripMenuItem.Name = "payPayDonationToolStripMenuItem";
            this.payPayDonationToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.payPayDonationToolStripMenuItem.Text = "PayPay donation";
            this.payPayDonationToolStripMenuItem.Click += new System.EventHandler(this.payPayDonationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(29, 549);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(357, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "If you find application useful please consider paypal donation";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(852, 594);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Babo Image Organizer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.CheckBox chkIncludeSubfolders;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDestination;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbRename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkMove;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.TextBox txtExtensions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNameExists;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox chkFindCameraData;
        private System.Windows.Forms.ComboBox cmbThirdLevelFolder;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbSecondLevelFolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFirstLevelFolder;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payPayDonationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtCustom3;
        private System.Windows.Forms.TextBox txtCustom2;
        private System.Windows.Forms.TextBox txtCustom1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

