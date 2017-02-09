namespace DecodeCarotDAV
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_DecFile = new System.Windows.Forms.Button();
            this.button_DecFolder = new System.Windows.Forms.Button();
            this.button_EncFolder = new System.Windows.Forms.Button();
            this.button_EncFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Header";
            // 
            // button_DecFile
            // 
            this.button_DecFile.Location = new System.Drawing.Point(14, 65);
            this.button_DecFile.Name = "button_DecFile";
            this.button_DecFile.Size = new System.Drawing.Size(95, 23);
            this.button_DecFile.TabIndex = 2;
            this.button_DecFile.Text = "Decode files";
            this.button_DecFile.UseVisualStyleBackColor = true;
            this.button_DecFile.Click += new System.EventHandler(this.button_DecFile_Click);
            // 
            // button_DecFolder
            // 
            this.button_DecFolder.Location = new System.Drawing.Point(14, 107);
            this.button_DecFolder.Name = "button_DecFolder";
            this.button_DecFolder.Size = new System.Drawing.Size(95, 23);
            this.button_DecFolder.TabIndex = 3;
            this.button_DecFolder.Text = "Decode Folder";
            this.button_DecFolder.UseVisualStyleBackColor = true;
            this.button_DecFolder.Click += new System.EventHandler(this.button_DecFolder_Click);
            // 
            // button_EncFolder
            // 
            this.button_EncFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_EncFolder.Location = new System.Drawing.Point(143, 107);
            this.button_EncFolder.Name = "button_EncFolder";
            this.button_EncFolder.Size = new System.Drawing.Size(95, 23);
            this.button_EncFolder.TabIndex = 5;
            this.button_EncFolder.Text = "Encode Folder";
            this.button_EncFolder.UseVisualStyleBackColor = true;
            this.button_EncFolder.Click += new System.EventHandler(this.button_EncFolder_Click);
            // 
            // button_EncFile
            // 
            this.button_EncFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_EncFile.Location = new System.Drawing.Point(143, 65);
            this.button_EncFile.Name = "button_EncFile";
            this.button_EncFile.Size = new System.Drawing.Size(95, 23);
            this.button_EncFile.TabIndex = 4;
            this.button_EncFile.Text = "Encode files";
            this.button_EncFile.UseVisualStyleBackColor = true;
            this.button_EncFile.Click += new System.EventHandler(this.button_EncFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(143, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 19);
            this.textBox1.TabIndex = 7;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(146, 43);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(47, 16);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Hide";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox_log
            // 
            this.textBox_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_log.Location = new System.Drawing.Point(14, 146);
            this.textBox_log.MaxLength = 0;
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(229, 104);
            this.textBox_log.TabIndex = 10;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 262);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_EncFolder);
            this.Controls.Add(this.button_EncFile);
            this.Controls.Add(this.button_DecFolder);
            this.Controls.Add(this.button_DecFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_DecFile;
        private System.Windows.Forms.Button button_DecFolder;
        private System.Windows.Forms.Button button_EncFolder;
        private System.Windows.Forms.Button button_EncFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox_log;
    }
}

