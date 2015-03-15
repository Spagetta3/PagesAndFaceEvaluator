namespace PagesAndFaceEvaluator
{
    partial class Main
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
            this.stopButton = new System.Windows.Forms.Button();
            this.statisticLabel = new System.Windows.Forms.Label();
            this.wholeStatisticsLabel = new System.Windows.Forms.Label();
            this.startAnalyzeButton = new System.Windows.Forms.Button();
            this.cameraSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(137, 212);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // statisticLabel
            // 
            this.statisticLabel.AutoSize = true;
            this.statisticLabel.Location = new System.Drawing.Point(22, 32);
            this.statisticLabel.Name = "statisticLabel";
            this.statisticLabel.Size = new System.Drawing.Size(102, 13);
            this.statisticLabel.TabIndex = 6;
            this.statisticLabel.Text = "Od začiatku ubehlo:";
            // 
            // wholeStatisticsLabel
            // 
            this.wholeStatisticsLabel.AutoSize = true;
            this.wholeStatisticsLabel.Location = new System.Drawing.Point(22, 60);
            this.wholeStatisticsLabel.Name = "wholeStatisticsLabel";
            this.wholeStatisticsLabel.Size = new System.Drawing.Size(124, 13);
            this.wholeStatisticsLabel.TabIndex = 7;
            this.wholeStatisticsLabel.Text = "Celkovo experiment trvá:";
            // 
            // startAnalyzeButton
            // 
            this.startAnalyzeButton.Location = new System.Drawing.Point(25, 212);
            this.startAnalyzeButton.Name = "startAnalyzeButton";
            this.startAnalyzeButton.Size = new System.Drawing.Size(111, 23);
            this.startAnalyzeButton.TabIndex = 8;
            this.startAnalyzeButton.Text = "Začni experiment";
            this.startAnalyzeButton.UseVisualStyleBackColor = true;
            // 
            // cameraSettingsButton
            // 
            this.cameraSettingsButton.Location = new System.Drawing.Point(25, 180);
            this.cameraSettingsButton.Name = "cameraSettingsButton";
            this.cameraSettingsButton.Size = new System.Drawing.Size(111, 23);
            this.cameraSettingsButton.TabIndex = 9;
            this.cameraSettingsButton.Text = "Nastavenie kamery";
            this.cameraSettingsButton.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 247);
            this.ControlBox = false;
            this.Controls.Add(this.cameraSettingsButton);
            this.Controls.Add(this.startAnalyzeButton);
            this.Controls.Add(this.wholeStatisticsLabel);
            this.Controls.Add(this.statisticLabel);
            this.Controls.Add(this.stopButton);
            this.Name = "Main";
            this.Text = "Pages and Face evaluator";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label statisticLabel;
        private System.Windows.Forms.Label wholeStatisticsLabel;
        private System.Windows.Forms.Button startAnalyzeButton;
        private System.Windows.Forms.Button cameraSettingsButton;
    }
}

