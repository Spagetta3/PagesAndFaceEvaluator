﻿namespace PagesAndFaceEvaluator
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
            this.components = new System.ComponentModel.Container();
            this.camImageBox = new Emgu.CV.UI.ImageBox();
            this.generateSamplesButton = new System.Windows.Forms.Button();
            this.startAnalyzeButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.camImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // camImageBox
            // 
            this.camImageBox.Location = new System.Drawing.Point(12, 21);
            this.camImageBox.Name = "camImageBox";
            this.camImageBox.Size = new System.Drawing.Size(693, 374);
            this.camImageBox.TabIndex = 2;
            this.camImageBox.TabStop = false;
            // 
            // generateSamplesButton
            // 
            this.generateSamplesButton.Location = new System.Drawing.Point(419, 402);
            this.generateSamplesButton.Name = "generateSamplesButton";
            this.generateSamplesButton.Size = new System.Drawing.Size(114, 23);
            this.generateSamplesButton.TabIndex = 3;
            this.generateSamplesButton.Text = "Generate Samples";
            this.generateSamplesButton.UseVisualStyleBackColor = true;
            this.generateSamplesButton.Click += new System.EventHandler(this.GenerateSamplesButton_Click);
            // 
            // startAnalyzeButton
            // 
            this.startAnalyzeButton.Location = new System.Drawing.Point(539, 402);
            this.startAnalyzeButton.Name = "startAnalyzeButton";
            this.startAnalyzeButton.Size = new System.Drawing.Size(88, 23);
            this.startAnalyzeButton.TabIndex = 4;
            this.startAnalyzeButton.Text = "Start Analyze";
            this.startAnalyzeButton.UseVisualStyleBackColor = true;
            this.startAnalyzeButton.Click += new System.EventHandler(this.StartAnalyzeButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(632, 402);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 459);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startAnalyzeButton);
            this.Controls.Add(this.generateSamplesButton);
            this.Controls.Add(this.camImageBox);
            this.Name = "Main";
            this.Text = "Pages and Face evaluator";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.camImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox camImageBox;
        private System.Windows.Forms.Button generateSamplesButton;
        private System.Windows.Forms.Button startAnalyzeButton;
        private System.Windows.Forms.Button stopButton;
    }
}

