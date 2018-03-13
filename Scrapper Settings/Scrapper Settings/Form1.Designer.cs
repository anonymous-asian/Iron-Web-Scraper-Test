namespace Scrapper_Settings
{
    partial class URL_Form
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
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL:";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(48, 9);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(224, 20);
            this.urlTextBox.TabIndex = 1;
            this.urlTextBox.Text = "https://www.stonemountaintoyota.com/inventory?keyword=&submit=Submit&type=new&loc" +
    "ation=&pg=";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(194, 36);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(77, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start Scrape!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // URL_Form
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 70);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.urlTextBox);
            this.Controls.Add(this.label1);
            this.Name = "URL_Form";
            this.Text = "URL Scraper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlTextBox;
        private System.Windows.Forms.Button startButton;
    }
}

