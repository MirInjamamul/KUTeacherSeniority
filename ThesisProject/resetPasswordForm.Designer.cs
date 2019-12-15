namespace ThesisProject
{
    partial class resetPasswordForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userNameTxt = new System.Windows.Forms.TextBox();
            this.newPasswordTxt = new System.Windows.Forms.TextBox();
            this.confirmPasswordTxt = new System.Windows.Forms.TextBox();
            this.updatePasswordBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Master Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password";
            // 
            // userNameTxt
            // 
            this.userNameTxt.Location = new System.Drawing.Point(230, 61);
            this.userNameTxt.Name = "userNameTxt";
            this.userNameTxt.Size = new System.Drawing.Size(152, 23);
            this.userNameTxt.TabIndex = 3;
            // 
            // newPasswordTxt
            // 
            this.newPasswordTxt.Location = new System.Drawing.Point(230, 93);
            this.newPasswordTxt.Name = "newPasswordTxt";
            this.newPasswordTxt.PasswordChar = '*';
            this.newPasswordTxt.Size = new System.Drawing.Size(152, 23);
            this.newPasswordTxt.TabIndex = 4;
            // 
            // confirmPasswordTxt
            // 
            this.confirmPasswordTxt.Location = new System.Drawing.Point(230, 125);
            this.confirmPasswordTxt.Name = "confirmPasswordTxt";
            this.confirmPasswordTxt.PasswordChar = '*';
            this.confirmPasswordTxt.Size = new System.Drawing.Size(152, 23);
            this.confirmPasswordTxt.TabIndex = 5;
            // 
            // updatePasswordBtn
            // 
            this.updatePasswordBtn.Location = new System.Drawing.Point(307, 163);
            this.updatePasswordBtn.Name = "updatePasswordBtn";
            this.updatePasswordBtn.Size = new System.Drawing.Size(75, 23);
            this.updatePasswordBtn.TabIndex = 6;
            this.updatePasswordBtn.Text = "Update";
            this.updatePasswordBtn.UseVisualStyleBackColor = true;
            this.updatePasswordBtn.Click += new System.EventHandler(this.updatePasswordBtn_Click);
            // 
            // resetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 238);
            this.Controls.Add(this.updatePasswordBtn);
            this.Controls.Add(this.confirmPasswordTxt);
            this.Controls.Add(this.newPasswordTxt);
            this.Controls.Add(this.userNameTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "resetPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Reset Form";
            this.Load += new System.EventHandler(this.resetPasswordForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userNameTxt;
        private System.Windows.Forms.TextBox newPasswordTxt;
        private System.Windows.Forms.TextBox confirmPasswordTxt;
        private System.Windows.Forms.Button updatePasswordBtn;
    }
}