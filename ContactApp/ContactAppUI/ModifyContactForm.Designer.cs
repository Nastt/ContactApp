namespace ContactAppUI
{
    partial class ModifyContactForm
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
            this.BirthdayTimePicker = new System.Windows.Forms.DateTimePicker();
            this.vkBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.PhoneBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.SurnameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OKbutton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BirthdayTimePicker
            // 
            this.BirthdayTimePicker.Location = new System.Drawing.Point(78, 66);
            this.BirthdayTimePicker.Name = "BirthdayTimePicker";
            this.BirthdayTimePicker.Size = new System.Drawing.Size(124, 20);
            this.BirthdayTimePicker.TabIndex = 29;
            // 
            // vkBox
            // 
            this.vkBox.BackColor = System.Drawing.Color.Silver;
            this.vkBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.vkBox.Location = new System.Drawing.Point(74, 172);
            this.vkBox.Name = "vkBox";
            this.vkBox.Size = new System.Drawing.Size(240, 20);
            this.vkBox.TabIndex = 28;
            this.vkBox.Text = "Пример ввода _id";
            this.vkBox.TextChanged += new System.EventHandler(this.vkBox_TextChanged);
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(78, 133);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(236, 20);
            this.EmailBox.TabIndex = 27;
            this.EmailBox.TextChanged += new System.EventHandler(this.EmailBox_TextChanged);
            // 
            // PhoneBox
            // 
            this.PhoneBox.BackColor = System.Drawing.Color.Silver;
            this.PhoneBox.Location = new System.Drawing.Point(78, 101);
            this.PhoneBox.MaxLength = 11;
            this.PhoneBox.Name = "PhoneBox";
            this.PhoneBox.Size = new System.Drawing.Size(236, 20);
            this.PhoneBox.TabIndex = 26;
            this.PhoneBox.Text = "Пример ввода: 79528074565";
            this.PhoneBox.TextChanged += new System.EventHandler(this.PhoneBox_TextChanged);
            this.PhoneBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PhoneBox_KeyPress);
            this.PhoneBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PhoneBox_MouseDown);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(78, 39);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(236, 20);
            this.NameBox.TabIndex = 25;
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // SurnameBox
            // 
            this.SurnameBox.Location = new System.Drawing.Point(78, 12);
            this.SurnameBox.Name = "SurnameBox";
            this.SurnameBox.Size = new System.Drawing.Size(236, 20);
            this.SurnameBox.TabIndex = 24;
            this.SurnameBox.TextChanged += new System.EventHandler(this.SurnameBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "vk.com";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "E-mail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Birhday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Surname";
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(174, 217);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(76, 28);
            this.OKbutton.TabIndex = 30;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(266, 218);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(76, 26);
            this.CancelButton.TabIndex = 31;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ModifyContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 255);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.BirthdayTimePicker);
            this.Controls.Add(this.vkBox);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.PhoneBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.SurnameBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ModifyContactForm";
            this.Text = "ModifyContactForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker BirthdayTimePicker;
        private System.Windows.Forms.TextBox vkBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.TextBox PhoneBox;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox SurnameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button CancelButton;
    }
}