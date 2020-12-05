using System.Drawing;
using System.Windows.Forms;

namespace Server_manager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Table = new System.Windows.Forms.DataGridView();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isConnected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetCompNamesButt = new System.Windows.Forms.Button();
            this.SendButt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Time1 = new System.Windows.Forms.DateTimePicker();
            this.urlListBox = new System.Windows.Forms.RichTextBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timeCheck = new System.Windows.Forms.CheckBox();
            this.Time2 = new System.Windows.Forms.DateTimePicker();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.TitleBar = new System.Windows.Forms.Label();
            this.MinToTrayBt = new System.Windows.Forms.Button();
            this.MinBt = new System.Windows.Forms.Button();
            this.CloseBt = new System.Windows.Forms.Button();
            this.RefreshList = new System.Windows.Forms.Button();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.CloseTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.groupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(19, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(166, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // Table
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(232)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(90)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.Table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Table.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Table.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.Table.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Table.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Black", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(190)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Table.ColumnHeadersHeight = 30;
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.address,
            this.compName,
            this.isConnected});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(202)))), ((int)(((byte)(228)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Black", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(90)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Table.DefaultCellStyle = dataGridViewCellStyle6;
            this.Table.EnableHeadersVisualStyles = false;
            this.Table.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.Table.Location = new System.Drawing.Point(193, 49);
            this.Table.Margin = new System.Windows.Forms.Padding(5);
            this.Table.MultiSelect = false;
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            this.Table.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial Black", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Table.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.Table.RowHeadersVisible = false;
            this.Table.RowHeadersWidth = 82;
            this.Table.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Table.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Table.Size = new System.Drawing.Size(530, 164);
            this.Table.TabIndex = 4;
            this.Table.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Table_CellMouseClick);
            this.Table.SelectionChanged += new System.EventHandler(this.Table_SelectionChanged);
            // 
            // address
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.address.DefaultCellStyle = dataGridViewCellStyle3;
            this.address.HeaderText = "כתובת";
            this.address.MinimumWidth = 10;
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // compName
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.compName.DefaultCellStyle = dataGridViewCellStyle4;
            this.compName.HeaderText = "שם מחשב";
            this.compName.MinimumWidth = 10;
            this.compName.Name = "compName";
            this.compName.ReadOnly = true;
            // 
            // isConnected
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.isConnected.DefaultCellStyle = dataGridViewCellStyle5;
            this.isConnected.HeaderText = "מצב חיבור לרשת";
            this.isConnected.MinimumWidth = 10;
            this.isConnected.Name = "isConnected";
            this.isConnected.ReadOnly = true;
            // 
            // GetCompNamesButt
            // 
            this.GetCompNamesButt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.GetCompNamesButt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.GetCompNamesButt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.GetCompNamesButt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.GetCompNamesButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GetCompNamesButt.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.GetCompNamesButt.ForeColor = System.Drawing.SystemColors.Control;
            this.GetCompNamesButt.Location = new System.Drawing.Point(731, 49);
            this.GetCompNamesButt.Name = "GetCompNamesButt";
            this.GetCompNamesButt.Size = new System.Drawing.Size(107, 80);
            this.GetCompNamesButt.TabIndex = 5;
            this.GetCompNamesButt.Text = "קבל רשימת מחשבים";
            this.GetCompNamesButt.UseVisualStyleBackColor = false;
            this.GetCompNamesButt.Click += new System.EventHandler(this.GetCompNames_Click);
            // 
            // SendButt
            // 
            this.SendButt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.SendButt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.SendButt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.SendButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButt.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SendButt.ForeColor = System.Drawing.SystemColors.Control;
            this.SendButt.Location = new System.Drawing.Point(68, 121);
            this.SendButt.Name = "SendButt";
            this.SendButt.Size = new System.Drawing.Size(243, 43);
            this.SendButt.TabIndex = 6;
            this.SendButt.Text = "שלח רשימת חסימות";
            this.SendButt.UseVisualStyleBackColor = true;
            this.SendButt.Click += new System.EventHandler(this.SendButtAsync_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(492, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "רשימת כתובות חסומים";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Time1
            // 
            this.Time1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Time1.CalendarMonthBackground = System.Drawing.Color.White;
            this.Time1.CustomFormat = "HH:mm";
            this.Time1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.Time1.Enabled = false;
            this.Time1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Time1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Time1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Time1.Location = new System.Drawing.Point(181, 74);
            this.Time1.Margin = new System.Windows.Forms.Padding(0);
            this.Time1.Name = "Time1";
            this.Time1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Time1.ShowUpDown = true;
            this.Time1.Size = new System.Drawing.Size(71, 30);
            this.Time1.TabIndex = 8;
            this.Time1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Time1_MouseUp);
            // 
            // urlListBox
            // 
            this.urlListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urlListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.urlListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.urlListBox.BulletIndent = 4;
            this.urlListBox.DetectUrls = false;
            this.urlListBox.EnableAutoDragDrop = true;
            this.urlListBox.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 16F);
            this.urlListBox.Location = new System.Drawing.Point(372, 52);
            this.urlListBox.Name = "urlListBox";
            this.urlListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.urlListBox.Size = new System.Drawing.Size(434, 124);
            this.urlListBox.TabIndex = 9;
            this.urlListBox.Text = "";
            this.urlListBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UrlListBox_KeyPress);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.label3);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.timeCheck);
            this.groupBox.Controls.Add(this.urlListBox);
            this.groupBox.Controls.Add(this.Time2);
            this.groupBox.Controls.Add(this.Time1);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.SendButt);
            this.groupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox.Font = new System.Drawing.Font("Arial Black", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.groupBox.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox.Location = new System.Drawing.Point(19, 221);
            this.groupBox.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox.Size = new System.Drawing.Size(819, 189);
            this.groupBox.TabIndex = 10;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "ניהול רשימת חסימות";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 14F);
            this.label3.Location = new System.Drawing.Point(144, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 27);
            this.label3.TabIndex = 11;
            this.label3.Text = "ועד";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 14F);
            this.label1.Location = new System.Drawing.Point(252, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "משעה";
            // 
            // timeCheck
            // 
            this.timeCheck.AutoSize = true;
            this.timeCheck.Font = new System.Drawing.Font("Arial Black", 14F);
            this.timeCheck.Location = new System.Drawing.Point(68, 36);
            this.timeCheck.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.timeCheck.Name = "timeCheck";
            this.timeCheck.Size = new System.Drawing.Size(243, 31);
            this.timeCheck.TabIndex = 10;
            this.timeCheck.Text = "חסום אתרים אלו לפי שעה";
            this.timeCheck.UseVisualStyleBackColor = true;
            this.timeCheck.CheckStateChanged += new System.EventHandler(this.TimeCheck_CheckStateChanged);
            // 
            // Time2
            // 
            this.Time2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Time2.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(160)))), ((int)(((byte)(200)))));
            this.Time2.CustomFormat = "HH:mm";
            this.Time2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.Time2.Enabled = false;
            this.Time2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Time2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Time2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Time2.Location = new System.Drawing.Point(73, 74);
            this.Time2.Margin = new System.Windows.Forms.Padding(0);
            this.Time2.Name = "Time2";
            this.Time2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Time2.ShowUpDown = true;
            this.Time2.Size = new System.Drawing.Size(71, 30);
            this.Time2.TabIndex = 8;
            this.Time2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Time2_MouseUp);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "פועל ברקע - SafeNet";
            this.notifyIcon.BalloonTipTitle = "SafeNet";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SafeNet - Active";
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.NotifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.TitleBar);
            this.panel1.Controls.Add(this.MinToTrayBt);
            this.panel1.Controls.Add(this.MinBt);
            this.panel1.Controls.Add(this.CloseBt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 35);
            this.panel1.TabIndex = 11;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            // 
            // TitleBar
            // 
            this.TitleBar.AutoSize = true;
            this.TitleBar.BackColor = System.Drawing.Color.Transparent;
            this.TitleBar.Font = new System.Drawing.Font("Microsoft JhengHei UI Light", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TitleBar.ForeColor = System.Drawing.Color.White;
            this.TitleBar.Location = new System.Drawing.Point(379, 3);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(98, 28);
            this.TitleBar.TabIndex = 1;
            this.TitleBar.Text = "SafeNet";
            this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            // 
            // MinToTrayBt
            // 
            this.MinToTrayBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.MinToTrayBt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MinToTrayBt.BackgroundImage")));
            this.MinToTrayBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MinToTrayBt.FlatAppearance.BorderSize = 0;
            this.MinToTrayBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.MinToTrayBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.MinToTrayBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinToTrayBt.Font = new System.Drawing.Font("Varela Round", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(177)));
            this.MinToTrayBt.ForeColor = System.Drawing.Color.White;
            this.MinToTrayBt.Location = new System.Drawing.Point(737, 0);
            this.MinToTrayBt.Margin = new System.Windows.Forms.Padding(0);
            this.MinToTrayBt.Name = "MinToTrayBt";
            this.MinToTrayBt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MinToTrayBt.Size = new System.Drawing.Size(60, 35);
            this.MinToTrayBt.TabIndex = 0;
            this.MinToTrayBt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MinToTrayBt.UseVisualStyleBackColor = false;
            this.MinToTrayBt.Click += new System.EventHandler(this.MinimizeToTray_Click);
            // 
            // MinBt
            // 
            this.MinBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.MinBt.FlatAppearance.BorderSize = 0;
            this.MinBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.MinBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.MinBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinBt.Font = new System.Drawing.Font("Varela Round", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(177)));
            this.MinBt.ForeColor = System.Drawing.Color.White;
            this.MinBt.Location = new System.Drawing.Point(677, 0);
            this.MinBt.Margin = new System.Windows.Forms.Padding(0);
            this.MinBt.Name = "MinBt";
            this.MinBt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MinBt.Size = new System.Drawing.Size(60, 35);
            this.MinBt.TabIndex = 0;
            this.MinBt.Text = "─";
            this.MinBt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.MinBt.UseVisualStyleBackColor = false;
            this.MinBt.Click += new System.EventHandler(this.MiniButton_Click);
            // 
            // CloseBt
            // 
            this.CloseBt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.CloseBt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseBt.FlatAppearance.BorderSize = 0;
            this.CloseBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.CloseBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.CloseBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBt.Font = new System.Drawing.Font("Guttman Calligraphic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CloseBt.ForeColor = System.Drawing.Color.White;
            this.CloseBt.Location = new System.Drawing.Point(797, 0);
            this.CloseBt.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBt.Name = "CloseBt";
            this.CloseBt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CloseBt.Size = new System.Drawing.Size(60, 35);
            this.CloseBt.TabIndex = 0;
            this.CloseBt.Text = "X";
            this.CloseBt.UseVisualStyleBackColor = false;
            this.CloseBt.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // RefreshList
            // 
            this.RefreshList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.RefreshList.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.RefreshList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.RefreshList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.RefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshList.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RefreshList.ForeColor = System.Drawing.SystemColors.Control;
            this.RefreshList.Location = new System.Drawing.Point(731, 133);
            this.RefreshList.Name = "RefreshList";
            this.RefreshList.Size = new System.Drawing.Size(107, 80);
            this.RefreshList.TabIndex = 5;
            this.RefreshList.Text = "רענן רשימה";
            this.RefreshList.UseVisualStyleBackColor = false;
            this.RefreshList.Click += new System.EventHandler(this.RefreshListAsync_Click);
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Interval = 1000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // CloseTimer
            // 
            this.CloseTimer.Interval = 1000;
            this.CloseTimer.Tick += new System.EventHandler(this.CloseTimer_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(857, 429);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RefreshList);
            this.Controls.Add(this.GetCompNamesButt);
            this.Controls.Add(this.Table);
            this.Font = new System.Drawing.Font("Arial Black", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SafeNet";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker Time1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox timeCheck;
        private System.Windows.Forms.DateTimePicker Time2;
        public System.Windows.Forms.Button GetCompNamesButt;
        public System.Windows.Forms.Button SendButt;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CloseBt;
        private System.Windows.Forms.Button MinBt;
        private System.Windows.Forms.Label TitleBar;
        public System.Windows.Forms.RichTextBox urlListBox;
        public System.Windows.Forms.Button RefreshList;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.Timer CloseTimer;
        private System.Windows.Forms.Button MinToTrayBt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn compName;
        private System.Windows.Forms.DataGridViewTextBoxColumn isConnected;
        private System.Windows.Forms.DataGridView Table;
    }
}

