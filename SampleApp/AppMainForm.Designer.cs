namespace SampleApp
{
    partial class AppMainForm
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
            this.cmdCheckForLatest = new System.Windows.Forms.Button();
            this.cmdSelectVersion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdCheckForLatest
            // 
            this.cmdCheckForLatest.Location = new System.Drawing.Point(21, 266);
            this.cmdCheckForLatest.Name = "cmdCheckForLatest";
            this.cmdCheckForLatest.Size = new System.Drawing.Size(109, 39);
            this.cmdCheckForLatest.TabIndex = 0;
            this.cmdCheckForLatest.Text = "Check for Latest Version...";
            this.cmdCheckForLatest.UseVisualStyleBackColor = true;
            this.cmdCheckForLatest.Click += new System.EventHandler(this.cmdCheckForLatest_Click);
            // 
            // cmdSelectVersion
            // 
            this.cmdSelectVersion.Location = new System.Drawing.Point(136, 266);
            this.cmdSelectVersion.Name = "cmdSelectVersion";
            this.cmdSelectVersion.Size = new System.Drawing.Size(109, 39);
            this.cmdSelectVersion.TabIndex = 0;
            this.cmdSelectVersion.Text = "Select Version...";
            this.cmdSelectVersion.UseVisualStyleBackColor = true;
            // 
            // AppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 340);
            this.Controls.Add(this.cmdSelectVersion);
            this.Controls.Add(this.cmdCheckForLatest);
            this.Name = "AppMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AppMainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCheckForLatest;
        private System.Windows.Forms.Button cmdSelectVersion;
    }
}