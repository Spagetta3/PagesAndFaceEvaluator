namespace PagesAndFaceEvaluator
{
    partial class AIDsettings
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
            this.aidLabel = new System.Windows.Forms.Label();
            this.aidTextBox = new System.Windows.Forms.TextBox();
            this.setButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // aidLabel
            // 
            this.aidLabel.AutoSize = true;
            this.aidLabel.Location = new System.Drawing.Point(12, 21);
            this.aidLabel.Name = "aidLabel";
            this.aidLabel.Size = new System.Drawing.Size(105, 13);
            this.aidLabel.TabIndex = 0;
            this.aidLabel.Text = "Zadajte svoje AIS id:";
            // 
            // aidTextBox
            // 
            this.aidTextBox.Location = new System.Drawing.Point(123, 14);
            this.aidTextBox.Name = "aidTextBox";
            this.aidTextBox.Size = new System.Drawing.Size(102, 20);
            this.aidTextBox.TabIndex = 1;
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(123, 40);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(102, 23);
            this.setButton.TabIndex = 2;
            this.setButton.Text = "Uložiť";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // AIDsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 69);
            this.ControlBox = false;
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.aidTextBox);
            this.Controls.Add(this.aidLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AIDsettings";
            this.Text = "AIS id nastavenia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aidLabel;
        private System.Windows.Forms.TextBox aidTextBox;
        private System.Windows.Forms.Button setButton;
    }
}