namespace ThesisProject
{
    partial class schoolEntryForm
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
            this.textBoxSchoolId = new System.Windows.Forms.TextBox();
            this.textBoxSchoolName = new System.Windows.Forms.TextBox();
            this.buttonSchoolEntry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(125, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "School Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "School Name";
            // 
            // textBoxSchoolId
            // 
            this.textBoxSchoolId.Location = new System.Drawing.Point(254, 56);
            this.textBoxSchoolId.Name = "textBoxSchoolId";
            this.textBoxSchoolId.Size = new System.Drawing.Size(164, 23);
            this.textBoxSchoolId.TabIndex = 2;
            // 
            // textBoxSchoolName
            // 
            this.textBoxSchoolName.Location = new System.Drawing.Point(254, 91);
            this.textBoxSchoolName.Name = "textBoxSchoolName";
            this.textBoxSchoolName.Size = new System.Drawing.Size(164, 23);
            this.textBoxSchoolName.TabIndex = 3;
            // 
            // buttonSchoolEntry
            // 
            this.buttonSchoolEntry.Location = new System.Drawing.Point(343, 131);
            this.buttonSchoolEntry.Name = "buttonSchoolEntry";
            this.buttonSchoolEntry.Size = new System.Drawing.Size(75, 23);
            this.buttonSchoolEntry.TabIndex = 4;
            this.buttonSchoolEntry.Text = "Confirm";
            this.buttonSchoolEntry.UseVisualStyleBackColor = true;
            this.buttonSchoolEntry.Click += new System.EventHandler(this.buttonSchoolEntry_Click);
            // 
            // schoolEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 216);
            this.Controls.Add(this.buttonSchoolEntry);
            this.Controls.Add(this.textBoxSchoolName);
            this.Controls.Add(this.textBoxSchoolId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "schoolEntryForm";
            this.Text = "schoolEntryForm";
            this.Load += new System.EventHandler(this.schoolEntryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSchoolId;
        private System.Windows.Forms.TextBox textBoxSchoolName;
        private System.Windows.Forms.Button buttonSchoolEntry;
    }
}