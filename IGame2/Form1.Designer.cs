﻿namespace IGame2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.assBtn = new System.Windows.Forms.Button();
            this.controlBar = new System.Windows.Forms.Panel();
            this.miniBtn = new System.Windows.Forms.Label();
            this.maxiBtn = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Label();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.settingsMenu = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showHideHot = new System.Windows.Forms.CheckBox();
            this.checkKeys = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.basePane = new System.Windows.Forms.Panel();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.gameLibrary = new System.Windows.Forms.Panel();
            this.addBtn = new System.Windows.Forms.Button();
            this.libraryBtn = new System.Windows.Forms.Button();
            this.controlBar.SuspendLayout();
            this.settingsMenu.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.basePane.SuspendLayout();
            this.SuspendLayout();
            // 
            // assBtn
            // 
            this.assBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.assBtn.FlatAppearance.BorderSize = 0;
            this.assBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.assBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.assBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.assBtn.Location = new System.Drawing.Point(19, 16);
            this.assBtn.Name = "assBtn";
            this.assBtn.Size = new System.Drawing.Size(224, 23);
            this.assBtn.TabIndex = 6;
            this.assBtn.Text = "Associate Filetype";
            this.assBtn.UseVisualStyleBackColor = false;
            this.assBtn.Click += new System.EventHandler(this.assBtn_Click);
            // 
            // controlBar
            // 
            this.controlBar.BackColor = System.Drawing.Color.Black;
            this.controlBar.Controls.Add(this.miniBtn);
            this.controlBar.Controls.Add(this.maxiBtn);
            this.controlBar.Controls.Add(this.closeBtn);
            this.controlBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBar.Location = new System.Drawing.Point(0, 0);
            this.controlBar.Name = "controlBar";
            this.controlBar.Size = new System.Drawing.Size(1118, 37);
            this.controlBar.TabIndex = 1;
            // 
            // miniBtn
            // 
            this.miniBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.miniBtn.AutoSize = true;
            this.miniBtn.BackColor = System.Drawing.Color.Transparent;
            this.miniBtn.Font = new System.Drawing.Font("Arial Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miniBtn.Location = new System.Drawing.Point(1006, 4);
            this.miniBtn.Name = "miniBtn";
            this.miniBtn.Size = new System.Drawing.Size(30, 32);
            this.miniBtn.TabIndex = 3;
            this.miniBtn.Text = "─";
            this.miniBtn.Click += new System.EventHandler(this.miniBtn_Click);
            // 
            // maxiBtn
            // 
            this.maxiBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxiBtn.AutoSize = true;
            this.maxiBtn.BackColor = System.Drawing.Color.Transparent;
            this.maxiBtn.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxiBtn.Location = new System.Drawing.Point(1044, 7);
            this.maxiBtn.Name = "maxiBtn";
            this.maxiBtn.Size = new System.Drawing.Size(31, 29);
            this.maxiBtn.TabIndex = 2;
            this.maxiBtn.Text = "□";
            this.maxiBtn.Click += new System.EventHandler(this.maxiBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.AutoSize = true;
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.Location = new System.Drawing.Point(1083, 7);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(23, 29);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "X";
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(1012, 23);
            // 
            // settingsMenu
            // 
            this.settingsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsMenu.AutoScroll = true;
            this.settingsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.settingsMenu.Controls.Add(this.panel4);
            this.settingsMenu.Controls.Add(this.panel3);
            this.settingsMenu.Controls.Add(this.label2);
            this.settingsMenu.Location = new System.Drawing.Point(10, 97);
            this.settingsMenu.Name = "settingsMenu";
            this.settingsMenu.Size = new System.Drawing.Size(1097, 667);
            this.settingsMenu.TabIndex = 2;
            this.settingsMenu.TabStop = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.assBtn);
            this.panel4.Location = new System.Drawing.Point(7, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1083, 605);
            this.panel4.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.groupBox1.Controls.Add(this.showHideHot);
            this.groupBox1.Controls.Add(this.checkKeys);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(19, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(549, 79);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key Hook";
            // 
            // showHideHot
            // 
            this.showHideHot.AutoSize = true;
            this.showHideHot.Location = new System.Drawing.Point(12, 48);
            this.showHideHot.Name = "showHideHot";
            this.showHideHot.Size = new System.Drawing.Size(255, 20);
            this.showHideHot.TabIndex = 8;
            this.showHideHot.Text = "Enable Show/Hide Hotkey (NumLock)";
            this.showHideHot.UseVisualStyleBackColor = true;
            this.showHideHot.CheckedChanged += new System.EventHandler(this.showHideHot_CheckedChanged);
            // 
            // checkKeys
            // 
            this.checkKeys.AutoSize = true;
            this.checkKeys.Location = new System.Drawing.Point(12, 22);
            this.checkKeys.Name = "checkKeys";
            this.checkKeys.Size = new System.Drawing.Size(148, 20);
            this.checkKeys.TabIndex = 7;
            this.checkKeys.Text = "Enable Global Keys";
            this.checkKeys.UseVisualStyleBackColor = true;
            this.checkKeys.CheckedChanged += new System.EventHandler(this.checkKeys_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Location = new System.Drawing.Point(3, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1091, 2);
            this.panel3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Settings";
            // 
            // basePane
            // 
            this.basePane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.basePane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.basePane.Controls.Add(this.settingsBtn);
            this.basePane.Controls.Add(this.panel1);
            this.basePane.Controls.Add(this.refreshBtn);
            this.basePane.Controls.Add(this.gameLibrary);
            this.basePane.Controls.Add(this.addBtn);
            this.basePane.Controls.Add(this.libraryBtn);
            this.basePane.Location = new System.Drawing.Point(10, 66);
            this.basePane.Name = "basePane";
            this.basePane.Size = new System.Drawing.Size(1097, 706);
            this.basePane.TabIndex = 0;
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackColor = System.Drawing.Color.Transparent;
            this.settingsBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("settingsBtn.BackgroundImage")));
            this.settingsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.settingsBtn.FlatAppearance.BorderSize = 0;
            this.settingsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.settingsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBtn.ForeColor = System.Drawing.Color.White;
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.Location = new System.Drawing.Point(365, 2);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(112, 23);
            this.settingsBtn.TabIndex = 7;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = false;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel1.Location = new System.Drawing.Point(1072, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 639);
            this.panel1.TabIndex = 0;
            // 
            // refreshBtn
            // 
            this.refreshBtn.BackColor = System.Drawing.Color.Transparent;
            this.refreshBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("refreshBtn.BackgroundImage")));
            this.refreshBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.refreshBtn.FlatAppearance.BorderSize = 0;
            this.refreshBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.refreshBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.ForeColor = System.Drawing.Color.White;
            this.refreshBtn.Image = ((System.Drawing.Image)(resources.GetObject("refreshBtn.Image")));
            this.refreshBtn.Location = new System.Drawing.Point(247, 2);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(112, 23);
            this.refreshBtn.TabIndex = 5;
            this.refreshBtn.Text = "Refresh List";
            this.refreshBtn.UseVisualStyleBackColor = false;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // gameLibrary
            // 
            this.gameLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameLibrary.AutoScroll = true;
            this.gameLibrary.Location = new System.Drawing.Point(0, 32);
            this.gameLibrary.Name = "gameLibrary";
            this.gameLibrary.Size = new System.Drawing.Size(1097, 639);
            this.gameLibrary.TabIndex = 1;
            this.gameLibrary.TabStop = true;
            this.gameLibrary.Paint += new System.Windows.Forms.PaintEventHandler(this.gameLibrary_Paint);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.Transparent;
            this.addBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addBtn.BackgroundImage")));
            this.addBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addBtn.FlatAppearance.BorderSize = 0;
            this.addBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.addBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addBtn.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Image = ((System.Drawing.Image)(resources.GetObject("addBtn.Image")));
            this.addBtn.Location = new System.Drawing.Point(129, 2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(112, 23);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add Game";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // libraryBtn
            // 
            this.libraryBtn.BackColor = System.Drawing.Color.Transparent;
            this.libraryBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("libraryBtn.BackgroundImage")));
            this.libraryBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.libraryBtn.FlatAppearance.BorderSize = 0;
            this.libraryBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.libraryBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.libraryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.libraryBtn.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libraryBtn.ForeColor = System.Drawing.Color.White;
            this.libraryBtn.Image = ((System.Drawing.Image)(resources.GetObject("libraryBtn.Image")));
            this.libraryBtn.Location = new System.Drawing.Point(11, 2);
            this.libraryBtn.Name = "libraryBtn";
            this.libraryBtn.Size = new System.Drawing.Size(112, 23);
            this.libraryBtn.TabIndex = 3;
            this.libraryBtn.Text = "Library";
            this.libraryBtn.UseVisualStyleBackColor = false;
            this.libraryBtn.Click += new System.EventHandler(this.libraryBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1118, 784);
            this.Controls.Add(this.basePane);
            this.Controls.Add(this.controlBar);
            this.Controls.Add(this.settingsMenu);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "IGame2";
            this.controlBar.ResumeLayout(false);
            this.controlBar.PerformLayout();
            this.settingsMenu.ResumeLayout(false);
            this.settingsMenu.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.basePane.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel basePane;
        private System.Windows.Forms.Panel controlBar;
        private System.Windows.Forms.Panel gameLibrary;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.Button libraryBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label maxiBtn;
        private System.Windows.Forms.Label closeBtn;
        private System.Windows.Forms.Label miniBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button assBtn;
        private System.Windows.Forms.Panel settingsMenu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkKeys;
        private System.Windows.Forms.CheckBox showHideHot;
    }
}

