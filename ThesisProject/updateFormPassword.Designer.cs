namespace ThesisProject
{
    partial class updateFormPassword
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
            this.updatePasswordBtn = new System.Windows.Forms.Button();
            this.masterPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // updatePasswordBtn
            // 
            this.updatePasswordBtn.Location = new System.Drawing.Point(289, 65);
            this.updatePasswordBtn.Name = "updatePasswordBtn";
            this.updatePasswordBtn.Size = new System.Drawing.Size(75, 23);
            this.updatePasswordBtn.TabIndex = 13;
            this.updatePasswordBtn.Text = "Enter";
            this.updatePasswordBtn.UseVisualStyleBackColor = true;
            this.updatePasswordBtn.Click += new System.EventHandler(this.updatePasswordBtn_Click);
            // 
            // masterPassword
            // 
            this.masterPassword.Location = new System.Drawing.Point(212, 24);
            this.masterPassword.Name = "masterPassword";
            this.masterPassword.PasswordChar = '*';
            this.masterPassword.Size = new System.Drawing.Size(152, 23);
            this.masterPassword.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Master Password";
            // 
            // updateFormPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 132);
            this.Controls.Add(this.updatePasswordBtn);
            this.Controls.Add(this.masterPassword);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "updateFormPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "updateFormPassword";
            this.Load += new System.EventHandler(this.updateFormPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button updatePasswordBtn;
        private System.Windows.Forms.TextBox masterPassword;
        private System.Windows.Forms.Label label1;
    }
}