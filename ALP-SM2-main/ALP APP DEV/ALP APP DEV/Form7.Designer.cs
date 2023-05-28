namespace ALP_APP_DEV
{
    partial class Form7
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
            this.label_back = new System.Windows.Forms.Label();
            this.labeldesc = new System.Windows.Forms.Label();
            this.labelSelectedDate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelSeats = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.label_back.TabIndex = 6;
            this.label_back.Text = "<";
            this.label_back.Click += new System.EventHandler(this.label_back_Click);
            // 
            // labeldesc
            // 
            this.labeldesc.AutoSize = true;
            this.labeldesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldesc.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labeldesc.Location = new System.Drawing.Point(249, 21);
            this.labeldesc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labeldesc.Name = "labeldesc";
            this.labeldesc.Size = new System.Drawing.Size(0, 16);
            this.labeldesc.TabIndex = 7;
            // 
            // labelSelectedDate
            // 
            this.labelSelectedDate.AutoSize = true;
            this.labelSelectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedDate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSelectedDate.Location = new System.Drawing.Point(40, 210);
            this.labelSelectedDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectedDate.Name = "labelSelectedDate";
            this.labelSelectedDate.Size = new System.Drawing.Size(99, 16);
            this.labelSelectedDate.TabIndex = 8;
            this.labelSelectedDate.Text = "Selected Date: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(79, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 170);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // panelSeats
            // 
            this.panelSeats.AutoScroll = true;
            this.panelSeats.Location = new System.Drawing.Point(232, 146);
            this.panelSeats.Name = "panelSeats";
            this.panelSeats.Size = new System.Drawing.Size(438, 699);
            this.panelSeats.TabIndex = 10;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(702, 749);
            this.Controls.Add(this.panelSeats);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelSelectedDate);
            this.Controls.Add(this.labeldesc);
            this.Controls.Add(this.label_back);
            this.Name = "Form7";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_back;
        private System.Windows.Forms.Label labeldesc;
        private System.Windows.Forms.Label labelSelectedDate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelSeats;
    }
}