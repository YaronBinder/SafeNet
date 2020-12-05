namespace Server_manager
{
    partial class ProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
            this.ScanningPrograss = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.MinBt = new System.Windows.Forms.Button();
            this.CloseBt = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Percentage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScanningPrograss
            // 
            this.ScanningPrograss.AutoSize = true;
            this.ScanningPrograss.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ScanningPrograss.Location = new System.Drawing.Point(220, 94);
            this.ScanningPrograss.Margin = new System.Windows.Forms.Padding(5);
            this.ScanningPrograss.Name = "ScanningPrograss";
            this.ScanningPrograss.Size = new System.Drawing.Size(44, 18);
            this.ScanningPrograss.TabIndex = 5;
            this.ScanningPrograss.Text = "טקסט";
            this.ScanningPrograss.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.progressBar1.Location = new System.Drawing.Point(14, 122);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(5);
            this.progressBar1.Maximum = 253;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RightToLeftLayout = true;
            this.progressBar1.Size = new System.Drawing.Size(456, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.MinBt);
            this.panel1.Controls.Add(this.CloseBt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 35);
            this.panel1.TabIndex = 12;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(126, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "סורק אחר מחשבים ברשת";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            // 
            // MinBt
            // 
            this.MinBt.FlatAppearance.BorderSize = 0;
            this.MinBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.MinBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(75)))));
            this.MinBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinBt.Font = new System.Drawing.Font("Varela Round", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MinBt.ForeColor = System.Drawing.Color.White;
            this.MinBt.Location = new System.Drawing.Point(384, 0);
            this.MinBt.Margin = new System.Windows.Forms.Padding(0);
            this.MinBt.Name = "MinBt";
            this.MinBt.Size = new System.Drawing.Size(50, 35);
            this.MinBt.TabIndex = 0;
            this.MinBt.Text = "─";
            this.MinBt.UseVisualStyleBackColor = true;
            this.MinBt.Click += new System.EventHandler(this.MiniButton_Click);
            // 
            // CloseBt
            // 
            this.CloseBt.FlatAppearance.BorderSize = 0;
            this.CloseBt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkRed;
            this.CloseBt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.CloseBt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBt.Font = new System.Drawing.Font("Varela Round", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CloseBt.ForeColor = System.Drawing.Color.White;
            this.CloseBt.Location = new System.Drawing.Point(434, 0);
            this.CloseBt.Margin = new System.Windows.Forms.Padding(0);
            this.CloseBt.Name = "CloseBt";
            this.CloseBt.Size = new System.Drawing.Size(50, 35);
            this.CloseBt.TabIndex = 0;
            this.CloseBt.Text = "X";
            this.CloseBt.UseVisualStyleBackColor = true;
            this.CloseBt.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            // 
            // Percentage
            // 
            this.Percentage.AutoSize = true;
            this.Percentage.Font = new System.Drawing.Font("Arial Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Percentage.Location = new System.Drawing.Point(198, 48);
            this.Percentage.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.Percentage.Name = "Percentage";
            this.Percentage.Size = new System.Drawing.Size(89, 36);
            this.Percentage.TabIndex = 5;
            this.Percentage.Text = "טקסט";
            this.Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(484, 159);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Percentage);
            this.Controls.Add(this.ScanningPrograss);
            this.Font = new System.Drawing.Font("Varela Round", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProgressForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "סורק אחר מחשבים ברשת";
            this.Activated += new System.EventHandler(this.ProgressForm_Activated);
            this.Deactivate += new System.EventHandler(this.ProgressForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressFrame_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ScanningPrograss;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button MinBt;
        private System.Windows.Forms.Button CloseBt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label Percentage;
    }
}