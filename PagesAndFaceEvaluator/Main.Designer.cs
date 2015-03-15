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
            this.statisticTextBox = new System.Windows.Forms.TextBox();
            this.wholeStatisticsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(137, 145);
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
            this.statisticLabel.Location = new System.Drawing.Point(22, 23);
            this.statisticLabel.Name = "statisticLabel";
            this.statisticLabel.Size = new System.Drawing.Size(102, 13);
            this.statisticLabel.TabIndex = 6;
            this.statisticLabel.Text = "Od začiatku ubehlo:";
            // 
            // wholeStatisticsLabel
            // 
            this.wholeStatisticsLabel.AutoSize = true;
            this.wholeStatisticsLabel.Location = new System.Drawing.Point(22, 51);
            this.wholeStatisticsLabel.Name = "wholeStatisticsLabel";
            this.wholeStatisticsLabel.Size = new System.Drawing.Size(124, 13);
            this.wholeStatisticsLabel.TabIndex = 7;
            this.wholeStatisticsLabel.Text = "Celkovo experiment trvá:";
            // 
            // startAnalyzeButton
            // 
            this.startAnalyzeButton.Location = new System.Drawing.Point(25, 145);
            this.startAnalyzeButton.Name = "startAnalyzeButton";
            this.startAnalyzeButton.Size = new System.Drawing.Size(111, 23);
            this.startAnalyzeButton.TabIndex = 8;
            this.startAnalyzeButton.Text = "Začni experiment";
            this.startAnalyzeButton.UseVisualStyleBackColor = true;
            this.startAnalyzeButton.Click += new System.EventHandler(this.startAnalyzeButton_Click);
            // 
            // cameraSettingsButton
            // 
            this.cameraSettingsButton.Location = new System.Drawing.Point(25, 113);
            this.cameraSettingsButton.Name = "cameraSettingsButton";
            this.cameraSettingsButton.Size = new System.Drawing.Size(111, 23);
            this.cameraSettingsButton.TabIndex = 9;
            this.cameraSettingsButton.Text = "Nastavenie kamery";
            this.cameraSettingsButton.UseVisualStyleBackColor = true;
            // 
            // statisticTextBox
            // 
            this.statisticTextBox.Location = new System.Drawing.Point(153, 16);
            this.statisticTextBox.Name = "statisticTextBox";
            this.statisticTextBox.Size = new System.Drawing.Size(88, 20);
            this.statisticTextBox.TabIndex = 10;
            // 
            // wholeStatisticsTextBox
            // 
            this.wholeStatisticsTextBox.Location = new System.Drawing.Point(153, 43);
            this.wholeStatisticsTextBox.Name = "wholeStatisticsTextBox";
            this.wholeStatisticsTextBox.Size = new System.Drawing.Size(88, 20);
            this.wholeStatisticsTextBox.TabIndex = 11;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 182);
            this.ControlBox = false;
            this.Controls.Add(this.wholeStatisticsTextBox);
            this.Controls.Add(this.statisticTextBox);
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
        private System.Windows.Forms.TextBox statisticTextBox;
        private System.Windows.Forms.TextBox wholeStatisticsTextBox;
    }
}

