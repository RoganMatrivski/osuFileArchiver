namespace osuFileArchiver
{
    partial class mainForm
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
            this.fileLocation = new System.Windows.Forms.TextBox();
            this.fileBrowse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.saveLocation = new System.Windows.Forms.TextBox();
            this.saveBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.compressionLevel = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.archiveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.compressionLevel)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Files/Directory to Archive";
            // 
            // fileLocation
            // 
            this.fileLocation.AllowDrop = true;
            this.fileLocation.Location = new System.Drawing.Point(12, 25);
            this.fileLocation.Name = "fileLocation";
            this.fileLocation.Size = new System.Drawing.Size(501, 20);
            this.fileLocation.TabIndex = 1;
            this.fileLocation.TextChanged += new System.EventHandler(this.fileLocation_TextChanged);
            this.fileLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileLocation_DragDrop);
            this.fileLocation.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileLocation_DragEnter);
            // 
            // fileBrowse
            // 
            this.fileBrowse.Location = new System.Drawing.Point(519, 23);
            this.fileBrowse.Name = "fileBrowse";
            this.fileBrowse.Size = new System.Drawing.Size(75, 23);
            this.fileBrowse.TabIndex = 2;
            this.fileBrowse.Text = "Browse";
            this.fileBrowse.UseVisualStyleBackColor = true;
            this.fileBrowse.Click += new System.EventHandler(this.fileLocation_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Archive Save Location";
            // 
            // saveLocation
            // 
            this.saveLocation.Location = new System.Drawing.Point(12, 64);
            this.saveLocation.Name = "saveLocation";
            this.saveLocation.Size = new System.Drawing.Size(501, 20);
            this.saveLocation.TabIndex = 4;
            // 
            // saveBrowse
            // 
            this.saveBrowse.Location = new System.Drawing.Point(519, 62);
            this.saveBrowse.Name = "saveBrowse";
            this.saveBrowse.Size = new System.Drawing.Size(75, 23);
            this.saveBrowse.TabIndex = 5;
            this.saveBrowse.Text = "Browse";
            this.saveBrowse.UseVisualStyleBackColor = true;
            this.saveBrowse.Click += new System.EventHandler(this.saveLocation_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Compression Level";
            // 
            // compressionLevel
            // 
            this.compressionLevel.LargeChange = 2;
            this.compressionLevel.Location = new System.Drawing.Point(12, 103);
            this.compressionLevel.Maximum = 9;
            this.compressionLevel.Minimum = 1;
            this.compressionLevel.Name = "compressionLevel";
            this.compressionLevel.Size = new System.Drawing.Size(582, 45);
            this.compressionLevel.TabIndex = 7;
            this.compressionLevel.Value = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "File Type";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(3, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(141, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "osu! Beatmap File (*.osz)";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(150, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(121, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "osu! Skin File (*.osk)";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // archiveButton
            // 
            this.archiveButton.Location = new System.Drawing.Point(519, 188);
            this.archiveButton.Name = "archiveButton";
            this.archiveButton.Size = new System.Drawing.Size(75, 23);
            this.archiveButton.TabIndex = 11;
            this.archiveButton.Text = "Archive";
            this.archiveButton.UseVisualStyleBackColor = true;
            this.archiveButton.Click += new System.EventHandler(this.archiveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(438, 188);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(12, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 25);
            this.panel1.TabIndex = 13;
            // 
            // mainForm
            // 
            this.AcceptButton = this.archiveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(606, 223);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.archiveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.compressionLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveBrowse);
            this.Controls.Add(this.saveLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileBrowse);
            this.Controls.Add(this.fileLocation);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.compressionLevel)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileLocation;
        private System.Windows.Forms.Button fileBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox saveLocation;
        private System.Windows.Forms.Button saveBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar compressionLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button archiveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

