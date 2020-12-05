namespace Server_manager
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.enterTab = new System.Windows.Forms.Button();
            this.CreateTab = new System.Windows.Forms.Button();
            this.userExistBox = new System.Windows.Forms.TextBox();
            this.existPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.messageExistLabel = new System.Windows.Forms.Label();
            this.enterButton = new System.Windows.Forms.Button();
            this.passShowExist = new System.Windows.Forms.PictureBox();
            this.passwordExistBox = new System.Windows.Forms.TextBox();
            this.createPanel = new System.Windows.Forms.Panel();
            this.passShowCreate = new System.Windows.Forms.PictureBox();
            this.createButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.messageCreateLabel = new System.Windows.Forms.Label();
            this.userCreateBox = new System.Windows.Forms.TextBox();
            this.passwordCreateBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.MinBt = new System.Windows.Forms.Button();
            this.CloseBt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.existPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passShowExist)).BeginInit();
            this.createPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passShowCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // enterTab
            // 
            this.enterTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.enterTab.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.enterTab, "enterTab");
            this.enterTab.FlatAppearance.BorderSize = 0;
            this.enterTab.ForeColor = System.Drawing.SystemColors.Control;
            this.enterTab.Name = "enterTab";
            this.enterTab.UseVisualStyleBackColor = false;
            this.enterTab.Click += new System.EventHandler(this.EnterTab_Click);
            // 
            // CreateTab
            // 
            this.CreateTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(80)))), ((int)(((byte)(100)))));
            this.CreateTab.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.CreateTab, "CreateTab");
            this.CreateTab.FlatAppearance.BorderSize = 0;
            this.CreateTab.ForeColor = System.Drawing.SystemColors.Control;
            this.CreateTab.Name = "CreateTab";
            this.CreateTab.UseVisualStyleBackColor = false;
            this.CreateTab.Click += new System.EventHandler(this.CreateTab_Click);
            // 
            // userExistBox
            // 
            this.userExistBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.userExistBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.userExistBox, "userExistBox");
            this.userExistBox.ForeColor = System.Drawing.SystemColors.Window;
            this.userExistBox.Name = "userExistBox";
            this.userExistBox.Enter += new System.EventHandler(this.UserExistBox_Enter);
            this.userExistBox.Leave += new System.EventHandler(this.UserExistBox_Leave);
            // 
            // existPanel
            // 
            this.existPanel.Controls.Add(this.pictureBox2);
            this.existPanel.Controls.Add(this.pictureBox1);
            this.existPanel.Controls.Add(this.messageExistLabel);
            this.existPanel.Controls.Add(this.enterButton);
            this.existPanel.Controls.Add(this.passShowExist);
            this.existPanel.Controls.Add(this.passwordExistBox);
            this.existPanel.Controls.Add(this.userExistBox);
            this.existPanel.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.existPanel, "existPanel");
            this.existPanel.Name = "existPanel";
            this.existPanel.TabStop = true;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // messageExistLabel
            // 
            resources.ApplyResources(this.messageExistLabel, "messageExistLabel");
            this.messageExistLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.messageExistLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.messageExistLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.messageExistLabel.Name = "messageExistLabel";
            // 
            // enterButton
            // 
            resources.ApplyResources(this.enterButton, "enterButton");
            this.enterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.enterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enterButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.enterButton.FlatAppearance.BorderSize = 5;
            this.enterButton.ForeColor = System.Drawing.SystemColors.Control;
            this.enterButton.Name = "enterButton";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // passShowExist
            // 
            this.passShowExist.BackColor = System.Drawing.Color.Transparent;
            this.passShowExist.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.passShowExist, "passShowExist");
            this.passShowExist.Name = "passShowExist";
            this.passShowExist.TabStop = false;
            this.passShowExist.Click += new System.EventHandler(this.PassShowExist_Click);
            // 
            // passwordExistBox
            // 
            this.passwordExistBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.passwordExistBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.passwordExistBox, "passwordExistBox");
            this.passwordExistBox.ForeColor = System.Drawing.SystemColors.Window;
            this.passwordExistBox.Name = "passwordExistBox";
            this.passwordExistBox.Enter += new System.EventHandler(this.PasswordExistBox_Enter);
            this.passwordExistBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterKey);
            this.passwordExistBox.Leave += new System.EventHandler(this.PasswordExistBox_Leave);
            // 
            // createPanel
            // 
            this.createPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.createPanel.Controls.Add(this.passShowCreate);
            this.createPanel.Controls.Add(this.createButton);
            this.createPanel.Controls.Add(this.pictureBox3);
            this.createPanel.Controls.Add(this.pictureBox4);
            this.createPanel.Controls.Add(this.messageCreateLabel);
            this.createPanel.Controls.Add(this.userCreateBox);
            this.createPanel.Controls.Add(this.passwordCreateBox);
            this.createPanel.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.createPanel, "createPanel");
            this.createPanel.Name = "createPanel";
            this.createPanel.TabStop = true;
            // 
            // passShowCreate
            // 
            this.passShowCreate.BackColor = System.Drawing.Color.Transparent;
            this.passShowCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.passShowCreate, "passShowCreate");
            this.passShowCreate.Name = "passShowCreate";
            this.passShowCreate.TabStop = false;
            this.passShowCreate.Click += new System.EventHandler(this.PassShowCreate_Click);
            // 
            // createButton
            // 
            resources.ApplyResources(this.createButton, "createButton");
            this.createButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.createButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.createButton.FlatAppearance.BorderSize = 5;
            this.createButton.ForeColor = System.Drawing.SystemColors.Control;
            this.createButton.Name = "createButton";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // messageCreateLabel
            // 
            resources.ApplyResources(this.messageCreateLabel, "messageCreateLabel");
            this.messageCreateLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.messageCreateLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.messageCreateLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.messageCreateLabel.Name = "messageCreateLabel";
            // 
            // userCreateBox
            // 
            this.userCreateBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.userCreateBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.userCreateBox, "userCreateBox");
            this.userCreateBox.ForeColor = System.Drawing.SystemColors.Window;
            this.userCreateBox.Name = "userCreateBox";
            this.userCreateBox.Enter += new System.EventHandler(this.UserCreateBox_Enter);
            this.userCreateBox.Leave += new System.EventHandler(this.UserCreateBox_Leave);
            // 
            // passwordCreateBox
            // 
            this.passwordCreateBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.passwordCreateBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.passwordCreateBox, "passwordCreateBox");
            this.passwordCreateBox.ForeColor = System.Drawing.SystemColors.Window;
            this.passwordCreateBox.Name = "passwordCreateBox";
            this.passwordCreateBox.Enter += new System.EventHandler(this.PasswordCreateBox_Enter);
            this.passwordCreateBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterKey);
            this.passwordCreateBox.Leave += new System.EventHandler(this.PasswordCreateBox_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.MinBt);
            this.panel1.Controls.Add(this.CloseBt);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.TabStop = true;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            // 
            // Title
            // 
            resources.ApplyResources(this.Title, "Title");
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Name = "Title";
            this.Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            // 
            // MinBt
            // 
            this.MinBt.FlatAppearance.BorderSize = 0;
            this.MinBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.MinBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            resources.ApplyResources(this.MinBt, "MinBt");
            this.MinBt.ForeColor = System.Drawing.Color.White;
            this.MinBt.Name = "MinBt";
            this.MinBt.UseVisualStyleBackColor = true;
            this.MinBt.Click += new System.EventHandler(this.MiniButton_Click);
            // 
            // CloseBt
            // 
            resources.ApplyResources(this.CloseBt, "CloseBt");
            this.CloseBt.FlatAppearance.BorderSize = 0;
            this.CloseBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.CloseBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.CloseBt.ForeColor = System.Drawing.Color.White;
            this.CloseBt.Name = "CloseBt";
            this.CloseBt.UseVisualStyleBackColor = true;
            this.CloseBt.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.enterTab);
            this.panel2.Controls.Add(this.CreateTab);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            // 
            // LoginForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.existPanel);
            this.Controls.Add(this.createPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Opacity = 0.99D;
            this.Activated += new System.EventHandler(this.LoginForm_Activated);
            this.Deactivate += new System.EventHandler(this.LoginForm_Deactivate);
            this.existPanel.ResumeLayout(false);
            this.existPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passShowExist)).EndInit();
            this.createPanel.ResumeLayout(false);
            this.createPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passShowCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button enterTab;
        private System.Windows.Forms.Button CreateTab;
        private System.Windows.Forms.TextBox userExistBox;
        private System.Windows.Forms.Panel existPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label messageExistLabel;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.PictureBox passShowExist;
        private System.Windows.Forms.TextBox passwordExistBox;
        private System.Windows.Forms.Panel createPanel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox passShowCreate;
        private System.Windows.Forms.TextBox userCreateBox;
        private System.Windows.Forms.TextBox passwordCreateBox;
        private System.Windows.Forms.Button createButton;
        public System.Windows.Forms.Label messageCreateLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button MinBt;
        private System.Windows.Forms.Button CloseBt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}