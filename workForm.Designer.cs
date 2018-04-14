namespace osuFileArchiver
{
    partial class workForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pauseButton = new System.Windows.Forms.Button();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.logLabel = new System.Windows.Forms.Label();
            this.logView = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(387, 311);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 282);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(531, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 1;
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(468, 311);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 3;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(9, 266);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(124, 13);
            this.logLabel.TabIndex = 4;
            this.logLabel.Text = "Initializing. Please Wait...";
            // 
            // logView
            // 
            this.logView.FormattingEnabled = true;
            this.logView.Location = new System.Drawing.Point(12, 12);
            this.logView.Name = "logView";
            this.logView.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.logView.Size = new System.Drawing.Size(531, 251);
            this.logView.TabIndex = 2;
            // 
            // workForm
            // 
            this.AcceptButton = this.pauseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(555, 340);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.logView);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "workForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Archiving...";
            this.Load += new System.EventHandler(this.workForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button pauseButton;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.ListBox logView;
    }
}