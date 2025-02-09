namespace letscrypto_gui_windows
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            title = new Label();
            subtitle = new Label();
            textTip = new Label();
            utext = new TextBox();
            keyFileTip = new Label();
            ukeyfile = new TextBox();
            ukey = new TextBox();
            keyLoadFile = new Button();
            keyTip = new Label();
            generateKey = new Button();
            offsetTip = new Label();
            uoffset = new TextBox();
            randomOffset = new Button();
            result = new TextBox();
            resultTip = new Label();
            saveBtn = new Button();
            savekey = new Button();
            textReadFromFile = new Button();
            encryptFromCustomKey = new Button();
            encryptFromKeyOfFile = new Button();
            decryptFromKeyOfFile = new Button();
            decryptFromCustomKey = new Button();
            generateBox = new TextBox();
            generateTip = new Label();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Microsoft YaHei UI", 15F);
            title.Location = new Point(400, 28);
            title.Name = "title";
            title.Size = new Size(122, 27);
            title.TabIndex = 0;
            title.Text = "Let's crypto";
            // 
            // subtitle
            // 
            subtitle.AutoSize = true;
            subtitle.Location = new Point(392, 61);
            subtitle.Name = "subtitle";
            subtitle.Size = new Size(139, 17);
            subtitle.TabIndex = 1;
            subtitle.Text = "Let's encrypt together!";
            subtitle.TextAlign = ContentAlignment.TopCenter;
            subtitle.Click += subtitle_Click;
            // 
            // textTip
            // 
            textTip.AutoSize = true;
            textTip.Location = new Point(15, 101);
            textTip.Name = "textTip";
            textTip.Size = new Size(32, 17);
            textTip.TabIndex = 2;
            textTip.Text = "文本";
            // 
            // utext
            // 
            utext.AcceptsReturn = true;
            utext.AcceptsTab = true;
            utext.Location = new Point(15, 122);
            utext.Multiline = true;
            utext.Name = "utext";
            utext.ScrollBars = ScrollBars.Vertical;
            utext.Size = new Size(267, 339);
            utext.TabIndex = 4;
            // 
            // keyFileTip
            // 
            keyFileTip.AutoSize = true;
            keyFileTip.Location = new Point(288, 470);
            keyFileTip.Name = "keyFileTip";
            keyFileTip.Size = new Size(104, 17);
            keyFileTip.TabIndex = 11;
            keyFileTip.Text = "从文件中加载密钥";
            // 
            // ukeyfile
            // 
            ukeyfile.Location = new Point(288, 490);
            ukeyfile.Name = "ukeyfile";
            ukeyfile.Size = new Size(239, 23);
            ukeyfile.TabIndex = 10;
            // 
            // ukey
            // 
            ukey.AcceptsReturn = true;
            ukey.Location = new Point(288, 122);
            ukey.Multiline = true;
            ukey.Name = "ukey";
            ukey.ScrollBars = ScrollBars.Vertical;
            ukey.Size = new Size(267, 292);
            ukey.TabIndex = 9;
            // 
            // keyLoadFile
            // 
            keyLoadFile.Location = new Point(528, 490);
            keyLoadFile.Name = "keyLoadFile";
            keyLoadFile.Size = new Size(27, 23);
            keyLoadFile.TabIndex = 8;
            keyLoadFile.Text = "...";
            keyLoadFile.UseVisualStyleBackColor = true;
            keyLoadFile.Click += keyLoadFile_Click;
            // 
            // keyTip
            // 
            keyTip.AutoSize = true;
            keyTip.Location = new Point(288, 101);
            keyTip.Name = "keyTip";
            keyTip.Size = new Size(32, 17);
            keyTip.TabIndex = 7;
            keyTip.Text = "密钥";
            // 
            // generateKey
            // 
            generateKey.Location = new Point(484, 435);
            generateKey.Name = "generateKey";
            generateKey.Size = new Size(71, 26);
            generateKey.TabIndex = 12;
            generateKey.Text = "生成";
            generateKey.UseVisualStyleBackColor = true;
            generateKey.Click += generateKey_Click;
            // 
            // offsetTip
            // 
            offsetTip.AutoSize = true;
            offsetTip.Location = new Point(15, 469);
            offsetTip.Name = "offsetTip";
            offsetTip.Size = new Size(44, 17);
            offsetTip.TabIndex = 13;
            offsetTip.Text = "偏移值";
            // 
            // uoffset
            // 
            uoffset.Location = new Point(15, 490);
            uoffset.Name = "uoffset";
            uoffset.Size = new Size(267, 23);
            uoffset.TabIndex = 14;
            uoffset.Text = "3";
            // 
            // randomOffset
            // 
            randomOffset.Location = new Point(184, 465);
            randomOffset.Name = "randomOffset";
            randomOffset.Size = new Size(98, 25);
            randomOffset.TabIndex = 15;
            randomOffset.Text = "随机生成";
            randomOffset.UseVisualStyleBackColor = true;
            randomOffset.Click += randomOffset_Click;
            // 
            // result
            // 
            result.Location = new Point(670, 122);
            result.Multiline = true;
            result.Name = "result";
            result.ScrollBars = ScrollBars.Vertical;
            result.Size = new Size(233, 391);
            result.TabIndex = 17;
            // 
            // resultTip
            // 
            resultTip.AutoSize = true;
            resultTip.Location = new Point(670, 101);
            resultTip.Name = "resultTip";
            resultTip.Size = new Size(32, 17);
            resultTip.TabIndex = 16;
            resultTip.Text = "结果";
            // 
            // saveBtn
            // 
            saveBtn.Font = new Font("Microsoft YaHei UI", 9F);
            saveBtn.Location = new Point(795, 97);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(108, 25);
            saveBtn.TabIndex = 21;
            saveBtn.Text = "保存到文件";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // savekey
            // 
            savekey.Location = new Point(503, 96);
            savekey.Name = "savekey";
            savekey.Size = new Size(52, 26);
            savekey.TabIndex = 22;
            savekey.Text = "保存";
            savekey.UseVisualStyleBackColor = true;
            savekey.Click += savekey_Click;
            // 
            // textReadFromFile
            // 
            textReadFromFile.Location = new Point(166, 97);
            textReadFromFile.Name = "textReadFromFile";
            textReadFromFile.Size = new Size(116, 25);
            textReadFromFile.TabIndex = 23;
            textReadFromFile.Text = "从文件中读取";
            textReadFromFile.UseVisualStyleBackColor = true;
            textReadFromFile.Click += textReadFromFile_Click;
            // 
            // encryptFromCustomKey
            // 
            encryptFromCustomKey.Location = new Point(561, 122);
            encryptFromCustomKey.Name = "encryptFromCustomKey";
            encryptFromCustomKey.Size = new Size(103, 64);
            encryptFromCustomKey.TabIndex = 24;
            encryptFromCustomKey.Text = "用自定义密钥进行加密";
            encryptFromCustomKey.UseVisualStyleBackColor = true;
            encryptFromCustomKey.Click += encryptFromCustomKey_Click;
            // 
            // encryptFromKeyOfFile
            // 
            encryptFromKeyOfFile.Location = new Point(561, 192);
            encryptFromKeyOfFile.Name = "encryptFromKeyOfFile";
            encryptFromKeyOfFile.Size = new Size(103, 64);
            encryptFromKeyOfFile.TabIndex = 25;
            encryptFromKeyOfFile.Text = "用密钥文件进行加密";
            encryptFromKeyOfFile.UseVisualStyleBackColor = true;
            encryptFromKeyOfFile.Click += encryptFromKeyOfFile_Click;
            // 
            // decryptFromKeyOfFile
            // 
            decryptFromKeyOfFile.Location = new Point(561, 449);
            decryptFromKeyOfFile.Name = "decryptFromKeyOfFile";
            decryptFromKeyOfFile.Size = new Size(103, 64);
            decryptFromKeyOfFile.TabIndex = 27;
            decryptFromKeyOfFile.Text = "用密钥文件进行解密";
            decryptFromKeyOfFile.UseVisualStyleBackColor = true;
            decryptFromKeyOfFile.Click += decryptFromKeyOfFile_Click;
            // 
            // decryptFromCustomKey
            // 
            decryptFromCustomKey.Location = new Point(561, 379);
            decryptFromCustomKey.Name = "decryptFromCustomKey";
            decryptFromCustomKey.Size = new Size(103, 64);
            decryptFromCustomKey.TabIndex = 26;
            decryptFromCustomKey.Text = "用自定义密钥进行解密";
            decryptFromCustomKey.UseVisualStyleBackColor = true;
            decryptFromCustomKey.Click += decryptFromCustomKey_Click;
            // 
            // generateBox
            // 
            generateBox.Location = new Point(288, 437);
            generateBox.Name = "generateBox";
            generateBox.Size = new Size(190, 23);
            generateBox.TabIndex = 28;
            generateBox.Text = "20";
            // 
            // generateTip
            // 
            generateTip.AutoSize = true;
            generateTip.Location = new Point(288, 417);
            generateTip.Name = "generateTip";
            generateTip.Size = new Size(80, 17);
            generateTip.TabIndex = 29;
            generateTip.Text = "生成一个密钥";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 518);
            Controls.Add(generateTip);
            Controls.Add(generateBox);
            Controls.Add(decryptFromKeyOfFile);
            Controls.Add(decryptFromCustomKey);
            Controls.Add(encryptFromKeyOfFile);
            Controls.Add(encryptFromCustomKey);
            Controls.Add(textReadFromFile);
            Controls.Add(savekey);
            Controls.Add(saveBtn);
            Controls.Add(result);
            Controls.Add(resultTip);
            Controls.Add(randomOffset);
            Controls.Add(uoffset);
            Controls.Add(offsetTip);
            Controls.Add(generateKey);
            Controls.Add(keyFileTip);
            Controls.Add(ukeyfile);
            Controls.Add(ukey);
            Controls.Add(keyLoadFile);
            Controls.Add(keyTip);
            Controls.Add(utext);
            Controls.Add(textTip);
            Controls.Add(subtitle);
            Controls.Add(title);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Main";
            Text = "Let's crypto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Label subtitle;
        private Label textTip;
        private TextBox utext;
        private Label keyFileTip;
        private TextBox ukeyfile;
        private TextBox ukey;
        private Button keyLoadFile;
        private Label keyTip;
        private Button generateKey;
        private Label offsetTip;
        private TextBox uoffset;
        private Button randomOffset;
        private TextBox result;
        private Label resultTip;
        private Button saveBtn;
        private Button savekey;
        private Button textReadFromFile;
        private Button encryptFromCustomKey;
        private Button encryptFromKeyOfFile;
        private Button decryptFromKeyOfFile;
        private Button decryptFromCustomKey;
        private TextBox generateBox;
        private Label generateTip;
    }
}
