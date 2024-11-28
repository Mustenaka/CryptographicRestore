namespace CryptographicRestore
{
    partial class MainForm
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
            GBox_Origin = new GroupBox();
            RText_Origin = new RichTextBox();
            Btn_Crypton = new Button();
            Btn_OriginInput = new Button();
            Inp_OriginFile = new TextBox();
            Lab_OriginFile = new Label();
            GBox_Crypto = new GroupBox();
            RText_Crypton = new RichTextBox();
            Btn_Decrypt = new Button();
            Inp_CryptonFile = new TextBox();
            label1 = new Label();
            GBox_Decrypt = new GroupBox();
            RText_Decrypt = new RichTextBox();
            Btn_ExportFile = new Button();
            Inp_DecryptFile = new TextBox();
            label2 = new Label();
            GBox_Origin.SuspendLayout();
            GBox_Crypto.SuspendLayout();
            GBox_Decrypt.SuspendLayout();
            SuspendLayout();
            // 
            // GBox_Origin
            // 
            GBox_Origin.Controls.Add(RText_Origin);
            GBox_Origin.Controls.Add(Btn_Crypton);
            GBox_Origin.Controls.Add(Btn_OriginInput);
            GBox_Origin.Controls.Add(Inp_OriginFile);
            GBox_Origin.Controls.Add(Lab_OriginFile);
            GBox_Origin.Location = new Point(12, 12);
            GBox_Origin.Name = "GBox_Origin";
            GBox_Origin.Size = new Size(405, 426);
            GBox_Origin.TabIndex = 0;
            GBox_Origin.TabStop = false;
            GBox_Origin.Text = "原始";
            // 
            // RText_Origin
            // 
            RText_Origin.Location = new Point(10, 86);
            RText_Origin.Name = "RText_Origin";
            RText_Origin.Size = new Size(379, 300);
            RText_Origin.TabIndex = 4;
            RText_Origin.Text = "";
            // 
            // Btn_Crypton
            // 
            Btn_Crypton.Location = new Point(136, 392);
            Btn_Crypton.Name = "Btn_Crypton";
            Btn_Crypton.Size = new Size(112, 28);
            Btn_Crypton.TabIndex = 3;
            Btn_Crypton.Text = "加密";
            Btn_Crypton.UseVisualStyleBackColor = true;
            Btn_Crypton.Click += Btn_Crypton_Click;
            // 
            // Btn_OriginInput
            // 
            Btn_OriginInput.Location = new Point(287, 42);
            Btn_OriginInput.Name = "Btn_OriginInput";
            Btn_OriginInput.Size = new Size(112, 28);
            Btn_OriginInput.TabIndex = 2;
            Btn_OriginInput.Text = "载入文件";
            Btn_OriginInput.UseVisualStyleBackColor = true;
            Btn_OriginInput.Click += Btn_OriginInput_Click;
            // 
            // Inp_OriginFile
            // 
            Inp_OriginFile.Location = new Point(68, 40);
            Inp_OriginFile.Name = "Inp_OriginFile";
            Inp_OriginFile.Size = new Size(202, 30);
            Inp_OriginFile.TabIndex = 1;
            // 
            // Lab_OriginFile
            // 
            Lab_OriginFile.AutoSize = true;
            Lab_OriginFile.Location = new Point(6, 43);
            Lab_OriginFile.Name = "Lab_OriginFile";
            Lab_OriginFile.Size = new Size(46, 24);
            Lab_OriginFile.TabIndex = 0;
            Lab_OriginFile.Text = "文件";
            // 
            // GBox_Crypto
            // 
            GBox_Crypto.Controls.Add(RText_Crypton);
            GBox_Crypto.Controls.Add(Btn_Decrypt);
            GBox_Crypto.Controls.Add(Inp_CryptonFile);
            GBox_Crypto.Controls.Add(label1);
            GBox_Crypto.Location = new Point(433, 12);
            GBox_Crypto.Name = "GBox_Crypto";
            GBox_Crypto.Size = new Size(405, 426);
            GBox_Crypto.TabIndex = 1;
            GBox_Crypto.TabStop = false;
            GBox_Crypto.Text = "加密";
            // 
            // RText_Crypton
            // 
            RText_Crypton.Location = new Point(18, 86);
            RText_Crypton.Name = "RText_Crypton";
            RText_Crypton.Size = new Size(379, 300);
            RText_Crypton.TabIndex = 5;
            RText_Crypton.Text = "";
            // 
            // Btn_Decrypt
            // 
            Btn_Decrypt.Location = new Point(153, 392);
            Btn_Decrypt.Name = "Btn_Decrypt";
            Btn_Decrypt.Size = new Size(112, 28);
            Btn_Decrypt.TabIndex = 4;
            Btn_Decrypt.Text = "解密";
            Btn_Decrypt.UseVisualStyleBackColor = true;
            Btn_Decrypt.Click += Btn_Decrypt_Click;
            // 
            // Inp_CryptonFile
            // 
            Inp_CryptonFile.Location = new Point(80, 41);
            Inp_CryptonFile.Name = "Inp_CryptonFile";
            Inp_CryptonFile.Size = new Size(297, 30);
            Inp_CryptonFile.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 44);
            label1.Name = "label1";
            label1.Size = new Size(46, 24);
            label1.TabIndex = 2;
            label1.Text = "文件";
            // 
            // GBox_Decrypt
            // 
            GBox_Decrypt.Controls.Add(RText_Decrypt);
            GBox_Decrypt.Controls.Add(Btn_ExportFile);
            GBox_Decrypt.Controls.Add(Inp_DecryptFile);
            GBox_Decrypt.Controls.Add(label2);
            GBox_Decrypt.Location = new Point(856, 12);
            GBox_Decrypt.Name = "GBox_Decrypt";
            GBox_Decrypt.Size = new Size(405, 426);
            GBox_Decrypt.TabIndex = 2;
            GBox_Decrypt.TabStop = false;
            GBox_Decrypt.Text = "解密";
            // 
            // RText_Decrypt
            // 
            RText_Decrypt.Location = new Point(20, 86);
            RText_Decrypt.Name = "RText_Decrypt";
            RText_Decrypt.Size = new Size(379, 300);
            RText_Decrypt.TabIndex = 6;
            RText_Decrypt.Text = "";
            // 
            // Btn_ExportFile
            // 
            Btn_ExportFile.Location = new Point(287, 45);
            Btn_ExportFile.Name = "Btn_ExportFile";
            Btn_ExportFile.Size = new Size(112, 28);
            Btn_ExportFile.TabIndex = 5;
            Btn_ExportFile.Text = "导出文件";
            Btn_ExportFile.UseVisualStyleBackColor = true;
            Btn_ExportFile.Click += Btn_ExportFile_Click;
            // 
            // Inp_decryptFile
            // 
            Inp_DecryptFile.Location = new Point(68, 43);
            Inp_DecryptFile.Name = "Inp_DecryptFile";
            Inp_DecryptFile.Size = new Size(202, 30);
            Inp_DecryptFile.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 46);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 3;
            label2.Text = "文件";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 488);
            Controls.Add(GBox_Decrypt);
            Controls.Add(GBox_Crypto);
            Controls.Add(GBox_Origin);
            Name = "MainForm";
            Text = "对称加密 - 完全还原";
            GBox_Origin.ResumeLayout(false);
            GBox_Origin.PerformLayout();
            GBox_Crypto.ResumeLayout(false);
            GBox_Crypto.PerformLayout();
            GBox_Decrypt.ResumeLayout(false);
            GBox_Decrypt.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox GBox_Origin;
        private GroupBox GBox_Crypto;
        private Button Btn_OriginInput;
        private TextBox Inp_OriginFile;
        private Label Lab_OriginFile;
        private GroupBox GBox_Decrypt;
        private Button Btn_Crypton;
        private RichTextBox RText_Origin;
        private RichTextBox RText_Crypton;
        private Button Btn_Decrypt;
        private TextBox Inp_CryptonFile;
        private Label label1;
        private RichTextBox RText_Decrypt;
        private Button Btn_ExportFile;
        private TextBox Inp_DecryptFile;
        private Label label2;
    }
}
