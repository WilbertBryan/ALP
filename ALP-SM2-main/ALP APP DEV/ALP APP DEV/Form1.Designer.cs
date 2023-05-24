namespace ALP_APP_DEV
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.btn_signIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label_signUp = new System.Windows.Forms.Label();
            this.label_info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(237, 35);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 221);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(322, 219);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(313, 279);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_email.Location = new System.Drawing.Point(260, 246);
            this.txt_email.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(157, 24);
            this.txt_email.TabIndex = 0;
            this.txt_email.Enter += new System.EventHandler(this.txt_username_Enter);
            this.txt_email.Leave += new System.EventHandler(this.txt_username_Leave);
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Location = new System.Drawing.Point(260, 306);
            this.txt_password.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(157, 24);
            this.txt_password.TabIndex = 0;
            this.txt_password.Tag = "";
            this.txt_password.UseSystemPasswordChar = true;
            this.txt_password.Enter += new System.EventHandler(this.txt_password_Enter);
            this.txt_password.Leave += new System.EventHandler(this.txt_password_Leave);
            // 
            // btn_signIn
            // 
            this.btn_signIn.AutoEllipsis = true;
            this.btn_signIn.Location = new System.Drawing.Point(286, 358);
            this.btn_signIn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btn_signIn.Name = "btn_signIn";
            this.btn_signIn.Size = new System.Drawing.Size(106, 30);
            this.btn_signIn.TabIndex = 0;
            this.btn_signIn.Text = "Sign In";
            this.btn_signIn.UseVisualStyleBackColor = true;
            this.btn_signIn.Click += new System.EventHandler(this.btn_signIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(248, 408);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Don\'t have an account? ";
            // 
            // label_signUp
            // 
            this.label_signUp.AutoSize = true;
            this.label_signUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.1F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_signUp.ForeColor = System.Drawing.Color.White;
            this.label_signUp.Location = new System.Drawing.Point(371, 408);
            this.label_signUp.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_signUp.Name = "label_signUp";
            this.label_signUp.Size = new System.Drawing.Size(52, 13);
            this.label_signUp.TabIndex = 7;
            this.label_signUp.Text = "Sign Up";
            this.label_signUp.Click += new System.EventHandler(this.label_signUp_Click);
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.ForeColor = System.Drawing.Color.Red;
            this.label_info.Location = new System.Drawing.Point(268, 339);
            this.label_info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(138, 13);
            this.label_info.TabIndex = 8;
            this.label_info.Text = "Incorrect Email or Password";
            this.label_info.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(690, 445);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.label_signUp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_signIn);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Button btn_signIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_signUp;
        private System.Windows.Forms.Label label_info;
    }
}

