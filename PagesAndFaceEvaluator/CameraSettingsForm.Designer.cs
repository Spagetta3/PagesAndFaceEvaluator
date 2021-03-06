﻿namespace PagesAndFaceEvaluator
{
    partial class CameraSettingsForm
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
            this.analyzeButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.camImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // camImageBox
            // 
            this.camImageBox.Location = new System.Drawing.Point(12, 12);
            this.camImageBox.Name = "camImageBox";
            this.camImageBox.Size = new System.Drawing.Size(644, 410);
            this.camImageBox.TabIndex = 2;
            this.camImageBox.TabStop = false;
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(548, 428);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(108, 23);
            this.analyzeButton.TabIndex = 3;
            this.analyzeButton.Text = "Znova analyzuj";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 434);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(319, 13);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Ak si vidíte celú tvár a okolo nej červený obdĺžnik, tak stlačte OK.";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(467, 429);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // CameraSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 463);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.camImageBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CameraSettingsForm";
            this.Text = "CameraSettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.camImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox camImageBox;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Button okButton;
    }
}