namespace xofz.HasteTracker
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hasteRatingLabel = new System.Windows.Forms.Label();
            this.hastePercentageLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.coreVersionLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rating:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Percent:";
            // 
            // hasteRatingLabel
            // 
            this.hasteRatingLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hasteRatingLabel.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hasteRatingLabel.Location = new System.Drawing.Point(95, 9);
            this.hasteRatingLabel.Name = "hasteRatingLabel";
            this.hasteRatingLabel.Size = new System.Drawing.Size(277, 67);
            this.hasteRatingLabel.TabIndex = 2;
            this.hasteRatingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hastePercentageLabel
            // 
            this.hastePercentageLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hastePercentageLabel.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hastePercentageLabel.Location = new System.Drawing.Point(95, 76);
            this.hastePercentageLabel.Name = "hastePercentageLabel";
            this.hastePercentageLabel.Size = new System.Drawing.Size(277, 76);
            this.hastePercentageLabel.TabIndex = 3;
            this.hastePercentageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "x(z) HasteTracker";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDown);
            // 
            // coreVersionLabel
            // 
            this.coreVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coreVersionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.coreVersionLabel.Location = new System.Drawing.Point(231, 183);
            this.coreVersionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.coreVersionLabel.Name = "coreVersionLabel";
            this.coreVersionLabel.Size = new System.Drawing.Size(144, 29);
            this.coreVersionLabel.TabIndex = 4;
            // 
            // versionLabel
            // 
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.versionLabel.Location = new System.Drawing.Point(12, 183);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(144, 29);
            this.versionLabel.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 221);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.coreVersionLabel);
            this.Controls.Add(this.hastePercentageLabel);
            this.Controls.Add(this.hasteRatingLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "x(z) HasteTracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label hasteRatingLabel;
        private System.Windows.Forms.Label hastePercentageLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label coreVersionLabel;
        private System.Windows.Forms.Label versionLabel;
    }
}

