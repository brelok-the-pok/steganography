namespace steganographyLab1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.attackPercent = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.saveAttackedImgBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.attackBtn = new System.Windows.Forms.Button();
            this.attackBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.attacedImg = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.alphaDecode = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.DecodMethodBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SaveWaterMark = new System.Windows.Forms.Button();
            this.cryptedImg = new System.Windows.Forms.PictureBox();
            this.decryptedImg = new System.Windows.Forms.PictureBox();
            this.decodeButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.alphaInput = new System.Windows.Forms.NumericUpDown();
            this.WatermarkImgInfo = new System.Windows.Forms.Label();
            this.OrigImgInfo = new System.Windows.Forms.Label();
            this.ChoseMethod = new System.Windows.Forms.Label();
            this.MethodBox = new System.Windows.Forms.ComboBox();
            this.cryptBtn = new System.Windows.Forms.Button();
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.origImg = new System.Windows.Forms.PictureBox();
            this.waterBtn = new System.Windows.Forms.Button();
            this.waterMark = new System.Windows.Forms.PictureBox();
            this.origBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.metricksData = new System.Windows.Forms.Label();
            this.CheckAllMetricksBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.origImageInMetrick = new System.Windows.Forms.PictureBox();
            this.EncryptedImgBtn = new System.Windows.Forms.Button();
            this.markedImg = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attackPercent)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attacedImg)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaDecode)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cryptedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.decryptedImg)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaInput)).BeginInit();
            this.layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.origImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterMark)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.origImageInMetrick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markedImg)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPage5.Controls.Add(this.attackPercent);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Controls.Add(this.saveAttackedImgBtn);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Controls.Add(this.attackBtn);
            this.tabPage5.Controls.Add(this.attackBox);
            this.tabPage5.Controls.Add(this.tableLayoutPanel2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1454, 772);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Атаки";
            // 
            // attackPercent
            // 
            this.attackPercent.Location = new System.Drawing.Point(867, 551);
            this.attackPercent.Name = "attackPercent";
            this.attackPercent.Size = new System.Drawing.Size(120, 20);
            this.attackPercent.TabIndex = 17;
            this.attackPercent.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(864, 529);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Изменить на Х %";
            // 
            // saveAttackedImgBtn
            // 
            this.saveAttackedImgBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveAttackedImgBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.saveAttackedImgBtn.Location = new System.Drawing.Point(822, 473);
            this.saveAttackedImgBtn.MinimumSize = new System.Drawing.Size(150, 50);
            this.saveAttackedImgBtn.Name = "saveAttackedImgBtn";
            this.saveAttackedImgBtn.Size = new System.Drawing.Size(150, 50);
            this.saveAttackedImgBtn.TabIndex = 15;
            this.saveAttackedImgBtn.Text = "Сохранить";
            this.saveAttackedImgBtn.UseVisualStyleBackColor = false;
            this.saveAttackedImgBtn.Click += new System.EventHandler(this.saveAttackedImgBtn_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(606, 522);
            this.label2.MinimumSize = new System.Drawing.Size(200, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "Выберите тип атаки";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // attackBtn
            // 
            this.attackBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.attackBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.attackBtn.Location = new System.Drawing.Point(452, 473);
            this.attackBtn.MinimumSize = new System.Drawing.Size(150, 50);
            this.attackBtn.Name = "attackBtn";
            this.attackBtn.Size = new System.Drawing.Size(150, 50);
            this.attackBtn.TabIndex = 8;
            this.attackBtn.Text = "Атака";
            this.attackBtn.UseVisualStyleBackColor = false;
            this.attackBtn.Click += new System.EventHandler(this.attackBtn_Click);
            // 
            // attackBox
            // 
            this.attackBox.FormattingEnabled = true;
            this.attackBox.Items.AddRange(new object[] {
            "Атака изменением яркости",
            "Атака размытием",
            "Атака резкостью",
            "Атака дрожанием",
            "Атака поворотом",
            "Атака вырезкой"});
            this.attackBox.Location = new System.Drawing.Point(582, 551);
            this.attackBox.Name = "attackBox";
            this.attackBox.Size = new System.Drawing.Size(257, 21);
            this.attackBox.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.attacedImg, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(9, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 462F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1406, 464);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // attacedImg
            // 
            this.attacedImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.attacedImg.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.attacedImg.Location = new System.Drawing.Point(383, 52);
            this.attacedImg.Name = "attacedImg";
            this.attacedImg.Size = new System.Drawing.Size(640, 360);
            this.attacedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.attacedImg.TabIndex = 1;
            this.attacedImg.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage2.Controls.Add(this.alphaDecode);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.DecodMethodBox);
            this.tabPage2.Controls.Add(this.tableLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1454, 772);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Декодировать";
            // 
            // alphaDecode
            // 
            this.alphaDecode.CausesValidation = false;
            this.alphaDecode.Location = new System.Drawing.Point(500, 506);
            this.alphaDecode.Margin = new System.Windows.Forms.Padding(2);
            this.alphaDecode.Name = "alphaDecode";
            this.alphaDecode.Size = new System.Drawing.Size(90, 20);
            this.alphaDecode.TabIndex = 13;
            this.alphaDecode.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(621, 477);
            this.label1.MinimumSize = new System.Drawing.Size(200, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Выберите метод кодирования";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DecodMethodBox
            // 
            this.DecodMethodBox.FormattingEnabled = true;
            this.DecodMethodBox.Items.AddRange(new object[] {
            "Метод наименьшего бита",
            "Метод Куттера-Джордана-Боссена",
            "Robust Image Watermarking"});
            this.DecodMethodBox.Location = new System.Drawing.Point(595, 506);
            this.DecodMethodBox.Name = "DecodMethodBox";
            this.DecodMethodBox.Size = new System.Drawing.Size(257, 21);
            this.DecodMethodBox.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.49801F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.50199F));
            this.tableLayoutPanel1.Controls.Add(this.SaveWaterMark, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cryptedImg, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.decryptedImg, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.decodeButton, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.58743F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.41256F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1406, 464);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // SaveWaterMark
            // 
            this.SaveWaterMark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveWaterMark.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.SaveWaterMark.Location = new System.Drawing.Point(982, 406);
            this.SaveWaterMark.MinimumSize = new System.Drawing.Size(150, 50);
            this.SaveWaterMark.Name = "SaveWaterMark";
            this.SaveWaterMark.Size = new System.Drawing.Size(150, 50);
            this.SaveWaterMark.TabIndex = 9;
            this.SaveWaterMark.Text = "Сохранить ЦВЗ";
            this.SaveWaterMark.UseVisualStyleBackColor = false;
            this.SaveWaterMark.Click += new System.EventHandler(this.SaveWaterMark_Click);
            // 
            // cryptedImg
            // 
            this.cryptedImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cryptedImg.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cryptedImg.Location = new System.Drawing.Point(35, 20);
            this.cryptedImg.Name = "cryptedImg";
            this.cryptedImg.Size = new System.Drawing.Size(640, 360);
            this.cryptedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cryptedImg.TabIndex = 1;
            this.cryptedImg.TabStop = false;
            // 
            // decryptedImg
            // 
            this.decryptedImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.decryptedImg.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.decryptedImg.Location = new System.Drawing.Point(737, 20);
            this.decryptedImg.Name = "decryptedImg";
            this.decryptedImg.Size = new System.Drawing.Size(640, 360);
            this.decryptedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.decryptedImg.TabIndex = 2;
            this.decryptedImg.TabStop = false;
            // 
            // decodeButton
            // 
            this.decodeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.decodeButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.decodeButton.Location = new System.Drawing.Point(280, 406);
            this.decodeButton.MinimumSize = new System.Drawing.Size(150, 50);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(150, 50);
            this.decodeButton.TabIndex = 8;
            this.decodeButton.Text = "Декодировать";
            this.decodeButton.UseVisualStyleBackColor = false;
            this.decodeButton.Click += new System.EventHandler(this.DecodeButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPage1.Controls.Add(this.alphaInput);
            this.tabPage1.Controls.Add(this.WatermarkImgInfo);
            this.tabPage1.Controls.Add(this.OrigImgInfo);
            this.tabPage1.Controls.Add(this.ChoseMethod);
            this.tabPage1.Controls.Add(this.MethodBox);
            this.tabPage1.Controls.Add(this.cryptBtn);
            this.tabPage1.Controls.Add(this.layout);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1454, 772);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Закодировать";
            // 
            // alphaInput
            // 
            this.alphaInput.CausesValidation = false;
            this.alphaInput.Location = new System.Drawing.Point(495, 572);
            this.alphaInput.Margin = new System.Windows.Forms.Padding(2);
            this.alphaInput.Name = "alphaInput";
            this.alphaInput.Size = new System.Drawing.Size(90, 20);
            this.alphaInput.TabIndex = 11;
            this.alphaInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // WatermarkImgInfo
            // 
            this.WatermarkImgInfo.AutoSize = true;
            this.WatermarkImgInfo.Location = new System.Drawing.Point(1132, 507);
            this.WatermarkImgInfo.Name = "WatermarkImgInfo";
            this.WatermarkImgInfo.Size = new System.Drawing.Size(259, 13);
            this.WatermarkImgInfo.TabIndex = 10;
            this.WatermarkImgInfo.Text = "Здесь будут отобрадены свойства водного знака";
            this.WatermarkImgInfo.Visible = false;
            // 
            // OrigImgInfo
            // 
            this.OrigImgInfo.AutoSize = true;
            this.OrigImgInfo.Location = new System.Drawing.Point(20, 507);
            this.OrigImgInfo.Name = "OrigImgInfo";
            this.OrigImgInfo.Size = new System.Drawing.Size(308, 13);
            this.OrigImgInfo.TabIndex = 9;
            this.OrigImgInfo.Text = "Здесь будут отобрадены свойства исходного изображения";
            this.OrigImgInfo.Visible = false;
            // 
            // ChoseMethod
            // 
            this.ChoseMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChoseMethod.AutoSize = true;
            this.ChoseMethod.Location = new System.Drawing.Point(611, 541);
            this.ChoseMethod.MinimumSize = new System.Drawing.Size(200, 26);
            this.ChoseMethod.Name = "ChoseMethod";
            this.ChoseMethod.Size = new System.Drawing.Size(200, 26);
            this.ChoseMethod.TabIndex = 8;
            this.ChoseMethod.Text = "Выберите метод кодирования";
            this.ChoseMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MethodBox
            // 
            this.MethodBox.FormattingEnabled = true;
            this.MethodBox.Items.AddRange(new object[] {
            "Метод наименьшего бита",
            "Метод Куттера-Джордана-Боссена",
            "Robust Image Watermarking Algorithm"});
            this.MethodBox.Location = new System.Drawing.Point(590, 570);
            this.MethodBox.Name = "MethodBox";
            this.MethodBox.Size = new System.Drawing.Size(257, 21);
            this.MethodBox.TabIndex = 7;
            // 
            // cryptBtn
            // 
            this.cryptBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cryptBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cryptBtn.Location = new System.Drawing.Point(614, 495);
            this.cryptBtn.MinimumSize = new System.Drawing.Size(150, 50);
            this.cryptBtn.Name = "cryptBtn";
            this.cryptBtn.Size = new System.Drawing.Size(189, 50);
            this.cryptBtn.TabIndex = 6;
            this.cryptBtn.Text = "Закодировать";
            this.cryptBtn.UseVisualStyleBackColor = false;
            this.cryptBtn.Click += new System.EventHandler(this.CryptBtn_Click);
            // 
            // layout
            // 
            this.layout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.layout.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.layout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.layout.ColumnCount = 2;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.96568F));
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.03432F));
            this.layout.Controls.Add(this.origImg, 0, 0);
            this.layout.Controls.Add(this.waterBtn, 1, 1);
            this.layout.Controls.Add(this.waterMark, 1, 0);
            this.layout.Controls.Add(this.origBtn, 0, 1);
            this.layout.Location = new System.Drawing.Point(-22, 7);
            this.layout.Name = "layout";
            this.layout.RowCount = 2;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.38622F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.61378F));
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout.Size = new System.Drawing.Size(1459, 479);
            this.layout.TabIndex = 5;
            // 
            // origImg
            // 
            this.origImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.origImg.BackColor = System.Drawing.SystemColors.ControlDark;
            this.origImg.Location = new System.Drawing.Point(45, 23);
            this.origImg.Name = "origImg";
            this.origImg.Size = new System.Drawing.Size(640, 360);
            this.origImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.origImg.TabIndex = 1;
            this.origImg.TabStop = false;
            // 
            // waterBtn
            // 
            this.waterBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.waterBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.waterBtn.Location = new System.Drawing.Point(1018, 417);
            this.waterBtn.MaximumSize = new System.Drawing.Size(150, 50);
            this.waterBtn.MinimumSize = new System.Drawing.Size(150, 50);
            this.waterBtn.Name = "waterBtn";
            this.waterBtn.Size = new System.Drawing.Size(150, 50);
            this.waterBtn.TabIndex = 4;
            this.waterBtn.Text = "Выбрать водный знак";
            this.waterBtn.UseVisualStyleBackColor = false;
            this.waterBtn.Click += new System.EventHandler(this.WaterBtn_Click);
            // 
            // waterMark
            // 
            this.waterMark.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.waterMark.BackColor = System.Drawing.SystemColors.ControlDark;
            this.waterMark.Location = new System.Drawing.Point(773, 23);
            this.waterMark.Name = "waterMark";
            this.waterMark.Size = new System.Drawing.Size(640, 360);
            this.waterMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.waterMark.TabIndex = 2;
            this.waterMark.TabStop = false;
            // 
            // origBtn
            // 
            this.origBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.origBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.origBtn.Location = new System.Drawing.Point(290, 417);
            this.origBtn.MaximumSize = new System.Drawing.Size(150, 50);
            this.origBtn.MinimumSize = new System.Drawing.Size(150, 50);
            this.origBtn.Name = "origBtn";
            this.origBtn.Size = new System.Drawing.Size(150, 50);
            this.origBtn.TabIndex = 3;
            this.origBtn.Text = "Выбрать исходное изображение";
            this.origBtn.UseVisualStyleBackColor = false;
            this.origBtn.Click += new System.EventHandler(this.OrigBtn_Click_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1462, 798);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage3.Controls.Add(this.metricksData);
            this.tabPage3.Controls.Add(this.CheckAllMetricksBtn);
            this.tabPage3.Controls.Add(this.tableLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1454, 772);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Метрики";
            // 
            // metricksData
            // 
            this.metricksData.AutoSize = true;
            this.metricksData.Location = new System.Drawing.Point(9, 520);
            this.metricksData.Name = "metricksData";
            this.metricksData.Size = new System.Drawing.Size(308, 13);
            this.metricksData.TabIndex = 10;
            this.metricksData.Text = "Здесь будут отобрадены свойства исходного изображения";
            this.metricksData.Visible = false;
            // 
            // CheckAllMetricksBtn
            // 
            this.CheckAllMetricksBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckAllMetricksBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.CheckAllMetricksBtn.Location = new System.Drawing.Point(637, 520);
            this.CheckAllMetricksBtn.MinimumSize = new System.Drawing.Size(150, 50);
            this.CheckAllMetricksBtn.Name = "CheckAllMetricksBtn";
            this.CheckAllMetricksBtn.Size = new System.Drawing.Size(189, 50);
            this.CheckAllMetricksBtn.TabIndex = 7;
            this.CheckAllMetricksBtn.Text = "Проверить все метрики";
            this.CheckAllMetricksBtn.UseVisualStyleBackColor = false;
            this.CheckAllMetricksBtn.Click += new System.EventHandler(this.CheckAllMetricksBtn_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.96568F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.03432F));
            this.tableLayoutPanel3.Controls.Add(this.origImageInMetrick, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.EncryptedImgBtn, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.markedImg, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.38622F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.61378F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1459, 479);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // origImageInMetrick
            // 
            this.origImageInMetrick.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.origImageInMetrick.BackColor = System.Drawing.SystemColors.ControlDark;
            this.origImageInMetrick.Location = new System.Drawing.Point(45, 23);
            this.origImageInMetrick.Name = "origImageInMetrick";
            this.origImageInMetrick.Size = new System.Drawing.Size(640, 360);
            this.origImageInMetrick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.origImageInMetrick.TabIndex = 1;
            this.origImageInMetrick.TabStop = false;
            // 
            // EncryptedImgBtn
            // 
            this.EncryptedImgBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EncryptedImgBtn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.EncryptedImgBtn.Location = new System.Drawing.Point(1018, 417);
            this.EncryptedImgBtn.MaximumSize = new System.Drawing.Size(150, 50);
            this.EncryptedImgBtn.MinimumSize = new System.Drawing.Size(150, 50);
            this.EncryptedImgBtn.Name = "EncryptedImgBtn";
            this.EncryptedImgBtn.Size = new System.Drawing.Size(150, 50);
            this.EncryptedImgBtn.TabIndex = 4;
            this.EncryptedImgBtn.Text = "Выбрать закодированное изображение";
            this.EncryptedImgBtn.UseVisualStyleBackColor = false;
            this.EncryptedImgBtn.Click += new System.EventHandler(this.EncryptedImgBtn_Click);
            // 
            // markedImg
            // 
            this.markedImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.markedImg.BackColor = System.Drawing.SystemColors.ControlDark;
            this.markedImg.Location = new System.Drawing.Point(773, 23);
            this.markedImg.Name = "markedImg";
            this.markedImg.Size = new System.Drawing.Size(640, 360);
            this.markedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.markedImg.TabIndex = 2;
            this.markedImg.TabStop = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button2.Location = new System.Drawing.Point(290, 417);
            this.button2.MaximumSize = new System.Drawing.Size(150, 50);
            this.button2.MinimumSize = new System.Drawing.Size(150, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Выбрать исходное изображение";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1443, 807);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stegonography";
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attackPercent)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attacedImg)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaDecode)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cryptedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.decryptedImg)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alphaInput)).EndInit();
            this.layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.origImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterMark)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.origImageInMetrick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markedImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button attackBtn;
        private System.Windows.Forms.ComboBox attackBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox attacedImg;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DecodMethodBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button SaveWaterMark;
        private System.Windows.Forms.PictureBox cryptedImg;
        private System.Windows.Forms.PictureBox decryptedImg;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label ChoseMethod;
        private System.Windows.Forms.ComboBox MethodBox;
        private System.Windows.Forms.Button cryptBtn;
        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.PictureBox origImg;
        private System.Windows.Forms.Button waterBtn;
        private System.Windows.Forms.PictureBox waterMark;
        private System.Windows.Forms.Button origBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button saveAttackedImgBtn;
        private System.Windows.Forms.NumericUpDown attackPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button CheckAllMetricksBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox origImageInMetrick;
        private System.Windows.Forms.Button EncryptedImgBtn;
        private System.Windows.Forms.PictureBox markedImg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label WatermarkImgInfo;
        private System.Windows.Forms.Label OrigImgInfo;
        private System.Windows.Forms.NumericUpDown alphaInput;
        private System.Windows.Forms.Label metricksData;
        private System.Windows.Forms.NumericUpDown alphaDecode;
    }
}

