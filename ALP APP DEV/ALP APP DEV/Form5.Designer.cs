namespace ALP_APP_DEV
{
    partial class Form5
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_oldPass = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txt_newPass = new System.Windows.Forms.TextBox();
            this.txt_verifyPass = new System.Windows.Forms.TextBox();
            this.btn_editPassword = new System.Windows.Forms.Button();
            this.label_msgPass = new System.Windows.Forms.Label();
            this.label_back = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(220, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Enter New Password";
            // 
            // txt_oldPass
            // 
            this.txt_oldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oldPass.Location = new System.Drawing.Point(258, 176);
            this.txt_oldPass.Margin = new System.Windows.Forms.Padding(2);
            this.txt_oldPass.Name = "txt_oldPass";
            this.txt_oldPass.Size = new System.Drawing.Size(206, 24);
            this.txt_oldPass.TabIndex = 0;
            this.txt_oldPass.Enter += new System.EventHandler(this.txt_oldPass_Enter);
            this.txt_oldPass.Leave += new System.EventHandler(this.txt_oldPass_Leave);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(258, 124);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(206, 20);
            this.dateTimePicker.TabIndex = 0;
            // 
            // txt_newPass
            // 
            this.txt_newPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newPass.Location = new System.Drawing.Point(258, 228);
            this.txt_newPass.Margin = new System.Windows.Forms.Padding(2);
            this.txt_newPass.Name = "txt_newPass";
            this.txt_newPass.Size = new System.Drawing.Size(206, 24);
            this.txt_newPass.TabIndex = 0;
            this.txt_newPass.Enter += new System.EventHandler(this.txt_newPass_Enter);
            this.txt_newPass.Leave += new System.EventHandler(this.txt_newPass_Leave);
            // 
            // txt_verifyPass
            // 
            this.txt_verifyPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_verifyPass.Location = new System.Drawing.Point(258, 281);
            this.txt_verifyPass.Margin = new System.Windows.Forms.Padding(2);
            this.txt_verifyPass.Name = "txt_verifyPass";
            this.txt_verifyPass.Size = new System.Drawing.Size(206, 24);
            this.txt_verifyPass.TabIndex = 0;
            this.txt_verifyPass.Enter += new System.EventHandler(this.txt_verifyPass_Enter);
            this.txt_verifyPass.Leave += new System.EventHandler(this.txt_verifyPass_Leave);
            // 
            // btn_editPassword
            // 
            this.btn_editPassword.Location = new System.Drawing.Point(314, 349);
            this.btn_editPassword.Margin = new System.Windows.Forms.Padding(2);
            this.btn_editPassword.Name = "btn_editPassword";
            this.btn_editPassword.Size = new System.Drawing.Size(92, 34);
            this.btn_editPassword.TabIndex = 0;
            this.btn_editPassword.Text = "Edit Password";
            this.btn_editPassword.UseVisualStyleBackColor = true;
            this.btn_editPassword.Click += new System.EventHandler(this.btn_editPassword_Click);
            // 
            // label_msgPass
            // 
            this.label_msgPass.AutoSize = true;
            this.label_msgPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_msgPass.ForeColor = System.Drawing.Color.Red;
            this.label_msgPass.Location = new System.Drawing.Point(310, 320);
            this.label_msgPass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_msgPass.Name = "label_msgPass";
            this.label_msgPass.Size = new System.Drawing.Size(105, 17);
            this.label_msgPass.TabIndex = 1;
            this.label_msgPass.Text = "Incorrect Input !";
            // 
            // label_back
            // 
            this.label_back.AutoSize = true;
            this.label_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_back.ForeColor = System.Drawing.Color.White;
            this.label_back.Location = new System.Drawing.Point(10, 21);
            this.label_back.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_back.Name = "label_back";
            this.label_back.Size = new System.Drawing.Size(37, 37);
            this.label_back.TabIndex = 7;
            this.label_back.Text = "<";
            this.label_back.Click += new System.EventHandler(this.label_back_Click);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(754, 443);
            this.Controls.Add(this.label_back);
            this.Controls.Add(this.label_msgPass);
            this.Controls.Add(this.btn_editPassword);
            this.Controls.Add(this.txt_verifyPass);
            this.Controls.Add(this.txt_newPass);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.txt_oldPass);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_oldPass;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox txt_newPass;
        private System.Windows.Forms.TextBox txt_verifyPass;
        private System.Windows.Forms.Button btn_editPassword;
        private System.Windows.Forms.Label label_msgPass;
        private System.Windows.Forms.Label label_back;
    }
}