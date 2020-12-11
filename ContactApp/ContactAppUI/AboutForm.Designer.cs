namespace ContactAppUI
{
    partial class AboutForm
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
            this.emailLabel = new System.Windows.Forms.LinkLabel();
            this.gitHubLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(162, 116);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(107, 13);
            this.emailLabel.TabIndex = 0;
            this.emailLabel.TabStop = true;
            this.emailLabel.Text = "amarkina@yandex.ru";
            this.emailLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // gitHubLabel
            // 
            this.gitHubLabel.AutoSize = true;
            this.gitHubLabel.Location = new System.Drawing.Point(173, 176);
            this.gitHubLabel.Name = "gitHubLabel";
            this.gitHubLabel.Size = new System.Drawing.Size(99, 13);
            this.gitHubLabel.TabIndex = 1;
            this.gitHubLabel.TabStop = true;
            this.gitHubLabel.Text = "nastya/ContactApp";
            this.gitHubLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitHubLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 313);
            this.Controls.Add(this.gitHubLabel);
            this.Controls.Add(this.emailLabel);
            this.Name = "AboutForm";
            this.Text = "AboutForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel emailLabel;
        private System.Windows.Forms.LinkLabel gitHubLabel;
    }
}