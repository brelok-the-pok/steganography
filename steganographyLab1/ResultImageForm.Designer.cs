namespace steganographyLab1
{
    partial class ResultImageForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveCryptedImgButton = new System.Windows.Forms.Button();
            this.closeFormBtn = new System.Windows.Forms.Button();
            this.cryptedImg = new System.Windows.Forms.PictureBox();
            this.differenceImg = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cryptedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.differenceImg)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.saveCryptedImgButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.closeFormBtn, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cryptedImg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.differenceImg, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.14286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.85714F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1525, 841);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // saveCryptedImgButton
            // 
            this.saveCryptedImgButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.saveCryptedImgButton.Location = new System.Drawing.Point(4, 652);
            this.saveCryptedImgButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveCryptedImgButton.Name = "saveCryptedImgButton";
            this.saveCryptedImgButton.Size = new System.Drawing.Size(243, 46);
            this.saveCryptedImgButton.TabIndex = 1;
            this.saveCryptedImgButton.Text = "Сохранить изображение";
            this.saveCryptedImgButton.UseVisualStyleBackColor = false;
            this.saveCryptedImgButton.Click += new System.EventHandler(this.SaveCryptedImgButton_Click);
            // 
            // closeFormBtn
            // 
            this.closeFormBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.closeFormBtn.Location = new System.Drawing.Point(766, 652);
            this.closeFormBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeFormBtn.Name = "closeFormBtn";
            this.closeFormBtn.Size = new System.Drawing.Size(243, 46);
            this.closeFormBtn.TabIndex = 2;
            this.closeFormBtn.Text = "Выход";
            this.closeFormBtn.UseVisualStyleBackColor = false;
            this.closeFormBtn.Click += new System.EventHandler(this.CloseFormBtn_Click);
            // 
            // cryptedImg
            // 
            this.cryptedImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cryptedImg.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cryptedImg.Location = new System.Drawing.Point(4, 4);
            this.cryptedImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cryptedImg.Name = "cryptedImg";
            this.cryptedImg.Size = new System.Drawing.Size(754, 640);
            this.cryptedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cryptedImg.TabIndex = 0;
            this.cryptedImg.TabStop = false;
            // 
            // differenceImg
            // 
            this.differenceImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.differenceImg.BackColor = System.Drawing.SystemColors.ControlDark;
            this.differenceImg.Location = new System.Drawing.Point(766, 4);
            this.differenceImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.differenceImg.Name = "differenceImg";
            this.differenceImg.Size = new System.Drawing.Size(755, 640);
            this.differenceImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.differenceImg.TabIndex = 1;
            this.differenceImg.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1537, 870);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cryptedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.differenceImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox cryptedImg;
        private System.Windows.Forms.PictureBox differenceImg;
        private System.Windows.Forms.Button saveCryptedImgButton;
        private System.Windows.Forms.Button closeFormBtn;
    }
}