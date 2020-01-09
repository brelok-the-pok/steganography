namespace steganographyLab1
{
    partial class Form3
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
            this.img = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.img2 = new System.Windows.Forms.PictureBox();
            this.match = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).BeginInit();
            this.SuspendLayout();
            // 
            // img
            // 
            this.img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img.BackColor = System.Drawing.SystemColors.ControlDark;
            this.img.Location = new System.Drawing.Point(-2, 1);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(512, 512);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img.TabIndex = 1;
            this.img.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(314, 558);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "rot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // img2
            // 
            this.img2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.img2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.img2.Location = new System.Drawing.Point(551, 1);
            this.img2.Name = "img2";
            this.img2.Size = new System.Drawing.Size(512, 512);
            this.img2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img2.TabIndex = 3;
            this.img2.TabStop = false;
            // 
            // match
            // 
            this.match.Location = new System.Drawing.Point(622, 558);
            this.match.Name = "match";
            this.match.Size = new System.Drawing.Size(75, 23);
            this.match.TabIndex = 4;
            this.match.Text = "match";
            this.match.UseVisualStyleBackColor = true;
            this.match.Click += new System.EventHandler(this.match_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(458, 558);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 691);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 913);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.match);
            this.Controls.Add(this.img2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.img);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox img2;
        private System.Windows.Forms.Button match;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}