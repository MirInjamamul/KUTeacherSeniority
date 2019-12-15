namespace ThesisProject
{
    partial class disciplineEntryForm
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
            this.textBoxDisciplineId = new System.Windows.Forms.TextBox();
            this.textBoxDisciplineName = new System.Windows.Forms.TextBox();
            this.comboBoxSchoolName = new System.Windows.Forms.ComboBox();
            this.buttonDisciplineEntry = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Discipline Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Discipline Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "School Name";
            // 
            // textBoxDisciplineId
            // 
            this.textBoxDisciplineId.Location = new System.Drawing.Point(200, 42);
            this.textBoxDisciplineId.Name = "textBoxDisciplineId";
            this.textBoxDisciplineId.Size = new System.Drawing.Size(121, 23);
            this.textBoxDisciplineId.TabIndex = 3;
            // 
            // textBoxDisciplineName
            // 
            this.textBoxDisciplineName.Location = new System.Drawing.Point(200, 78);
            this.textBoxDisciplineName.Name = "textBoxDisciplineName";
            this.textBoxDisciplineName.Size = new System.Drawing.Size(235, 23);
            this.textBoxDisciplineName.TabIndex = 4;
            // 
            // comboBoxSchoolName
            // 
            this.comboBoxSchoolName.FormattingEnabled = true;
            this.comboBoxSchoolName.Location = new System.Drawing.Point(200, 108);
            this.comboBoxSchoolName.Name = "comboBoxSchoolName";
            this.comboBoxSchoolName.Size = new System.Drawing.Size(235, 24);
            this.comboBoxSchoolName.TabIndex = 5;
            this.comboBoxSchoolName.SelectedIndexChanged += new System.EventHandler(this.comboBoxSchoolName_SelectedIndexChanged);
            // 
            // buttonDisciplineEntry
            // 
            this.buttonDisciplineEntry.Location = new System.Drawing.Point(360, 148);
            this.buttonDisciplineEntry.Name = "buttonDisciplineEntry";
            this.buttonDisciplineEntry.Size = new System.Drawing.Size(75, 23);
            this.buttonDisciplineEntry.TabIndex = 6;
            this.buttonDisciplineEntry.Text = "Confirm";
            this.buttonDisciplineEntry.UseVisualStyleBackColor = true;
            this.buttonDisciplineEntry.Click += new System.EventHandler(this.buttonDisciplineEntry_Click);
            // 
            // disciplineEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 210);
            this.Controls.Add(this.buttonDisciplineEntry);
            this.Controls.Add(this.comboBoxSchoolName);
            this.Controls.Add(this.textBoxDisciplineName);
            this.Controls.Add(this.textBoxDisciplineId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "disciplineEntryForm";
            this.Text = "Discipline Entry Form";
            this.Load += new System.EventHandler(this.disciplineEntryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDisciplineId;
        private System.Windows.Forms.TextBox textBoxDisciplineName;
        private System.Windows.Forms.ComboBox comboBoxSchoolName;
        private System.Windows.Forms.Button buttonDisciplineEntry;
    }
}