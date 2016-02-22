namespace SampleApp
{
    partial class NewVersionForm
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
            this.cmdNo = new System.Windows.Forms.Button();
            this.cmdYes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYourVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLatestVersion = new System.Windows.Forms.TextBox();
            this.cmdVersion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdNo
            // 
            this.cmdNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdNo.Location = new System.Drawing.Point(217, 142);
            this.cmdNo.Name = "cmdNo";
            this.cmdNo.Size = new System.Drawing.Size(78, 23);
            this.cmdNo.TabIndex = 8;
            this.cmdNo.Text = "No, Thanks";
            this.cmdNo.UseVisualStyleBackColor = true;
            // 
            // cmdYes
            // 
            this.cmdYes.Location = new System.Drawing.Point(301, 142);
            this.cmdYes.Name = "cmdYes";
            this.cmdYes.Size = new System.Drawing.Size(80, 23);
            this.cmdYes.TabIndex = 10;
            this.cmdYes.Text = "Sure";
            this.cmdYes.UseVisualStyleBackColor = true;
            this.cmdYes.Click += new System.EventHandler(this.cmdYes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(29, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "A new version is available.  Would you like to download it?";
            // 
            // txtYourVersion
            // 
            this.txtYourVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYourVersion.Location = new System.Drawing.Point(118, 65);
            this.txtYourVersion.Name = "txtYourVersion";
            this.txtYourVersion.ReadOnly = true;
            this.txtYourVersion.Size = new System.Drawing.Size(122, 20);
            this.txtYourVersion.TabIndex = 6;
            this.txtYourVersion.Text = "1.1.0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Your version:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lastest version:";
            // 
            // txtLatestVersion
            // 
            this.txtLatestVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLatestVersion.Location = new System.Drawing.Point(118, 91);
            this.txtLatestVersion.Name = "txtLatestVersion";
            this.txtLatestVersion.ReadOnly = true;
            this.txtLatestVersion.Size = new System.Drawing.Size(122, 20);
            this.txtLatestVersion.TabIndex = 6;
            this.txtLatestVersion.Text = "1.1.0.2";
            // 
            // cmdVersion
            // 
            this.cmdVersion.Location = new System.Drawing.Point(93, 142);
            this.cmdVersion.Name = "cmdVersion";
            this.cmdVersion.Size = new System.Drawing.Size(118, 23);
            this.cmdVersion.TabIndex = 10;
            this.cmdVersion.Text = "Browse Versions...";
            this.cmdVersion.UseVisualStyleBackColor = true;
            // 
            // NewVersionForm
            // 
            this.AcceptButton = this.cmdYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdNo;
            this.ClientSize = new System.Drawing.Size(400, 184);
            this.ControlBox = false;
            this.Controls.Add(this.cmdNo);
            this.Controls.Add(this.cmdVersion);
            this.Controls.Add(this.cmdYes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLatestVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYourVersion);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewVersionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Version of {app}";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdNo;
        private System.Windows.Forms.Button cmdYes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYourVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLatestVersion;
        private System.Windows.Forms.Button cmdVersion;
    }
}

