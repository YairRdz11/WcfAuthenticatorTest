
namespace ClientApplication
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
            this.Authenticate = new System.Windows.Forms.Button();
            this.Utility = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Authenticate
            // 
            this.Authenticate.Location = new System.Drawing.Point(316, 218);
            this.Authenticate.Name = "Authenticate";
            this.Authenticate.Size = new System.Drawing.Size(75, 23);
            this.Authenticate.TabIndex = 0;
            this.Authenticate.Text = "Authenticate";
            this.Authenticate.UseVisualStyleBackColor = true;
            this.Authenticate.Click += new System.EventHandler(this.Authenticate_Click);
            // 
            // Utility
            // 
            this.Utility.Location = new System.Drawing.Point(468, 218);
            this.Utility.Name = "Utility";
            this.Utility.Size = new System.Drawing.Size(75, 23);
            this.Utility.TabIndex = 1;
            this.Utility.Text = "Utility";
            this.Utility.UseVisualStyleBackColor = true;
            this.Utility.Click += new System.EventHandler(this.Utility_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Utility);
            this.Controls.Add(this.Authenticate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Authenticate;
        private System.Windows.Forms.Button Utility;
    }
}

