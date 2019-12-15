namespace ThesisProject
{
    partial class teacherPromotionDateForm
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
            this.schoolComboBox = new System.Windows.Forms.ComboBox();
            this.disciplineComboBox = new System.Windows.Forms.ComboBox();
            this.teacherSearchButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.teacherComboBox = new System.Windows.Forms.ComboBox();
            this.JoiningdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.confirmButton2 = new System.Windows.Forms.Button();
            this.designationComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "School :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Discipline : ";
            // 
            // schoolComboBox
            // 
            this.schoolComboBox.FormattingEnabled = true;
            this.schoolComboBox.Location = new System.Drawing.Point(189, 46);
            this.schoolComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.schoolComboBox.Name = "schoolComboBox";
            this.schoolComboBox.Size = new System.Drawing.Size(301, 24);
            this.schoolComboBox.TabIndex = 2;
            this.schoolComboBox.SelectedIndexChanged += new System.EventHandler(this.schoolComboBox_SelectedIndexChanged);
            // 
            // disciplineComboBox
            // 
            this.disciplineComboBox.FormattingEnabled = true;
            this.disciplineComboBox.Location = new System.Drawing.Point(189, 78);
            this.disciplineComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.disciplineComboBox.Name = "disciplineComboBox";
            this.disciplineComboBox.Size = new System.Drawing.Size(301, 24);
            this.disciplineComboBox.TabIndex = 3;
            this.disciplineComboBox.SelectedIndexChanged += new System.EventHandler(this.disciplineComboBox_SelectedIndexChanged);
            // 
            // teacherSearchButton
            // 
            this.teacherSearchButton.Location = new System.Drawing.Point(392, 146);
            this.teacherSearchButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.teacherSearchButton.Name = "teacherSearchButton";
            this.teacherSearchButton.Size = new System.Drawing.Size(100, 28);
            this.teacherSearchButton.TabIndex = 4;
            this.teacherSearchButton.Text = "Search";
            this.teacherSearchButton.UseVisualStyleBackColor = true;
            this.teacherSearchButton.Click += new System.EventHandler(this.teacherSearchButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 193);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Teacher ";
            // 
            // teacherComboBox
            // 
            this.teacherComboBox.FormattingEnabled = true;
            this.teacherComboBox.Location = new System.Drawing.Point(189, 189);
            this.teacherComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.teacherComboBox.Name = "teacherComboBox";
            this.teacherComboBox.Size = new System.Drawing.Size(301, 24);
            this.teacherComboBox.TabIndex = 6;
            this.teacherComboBox.SelectedIndexChanged += new System.EventHandler(this.teacherComboBox_SelectedIndexChanged);
            // 
            // JoiningdateTimePicker
            // 
            this.JoiningdateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.JoiningdateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.JoiningdateTimePicker.Location = new System.Drawing.Point(189, 237);
            this.JoiningdateTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.JoiningdateTimePicker.Name = "JoiningdateTimePicker";
            this.JoiningdateTimePicker.Size = new System.Drawing.Size(301, 23);
            this.JoiningdateTimePicker.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 244);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Seniority Date";
            // 
            // confirmButton2
            // 
            this.confirmButton2.Location = new System.Drawing.Point(392, 280);
            this.confirmButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirmButton2.Name = "confirmButton2";
            this.confirmButton2.Size = new System.Drawing.Size(100, 28);
            this.confirmButton2.TabIndex = 10;
            this.confirmButton2.Text = "Promote";
            this.confirmButton2.UseVisualStyleBackColor = true;
            this.confirmButton2.Click += new System.EventHandler(this.confirmButton2_Click);
            // 
            // designationComboBox
            // 
            this.designationComboBox.FormattingEnabled = true;
            this.designationComboBox.Location = new System.Drawing.Point(188, 113);
            this.designationComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.designationComboBox.Name = "designationComboBox";
            this.designationComboBox.Size = new System.Drawing.Size(301, 24);
            this.designationComboBox.TabIndex = 13;
            this.designationComboBox.SelectedIndexChanged += new System.EventHandler(this.designationComboBox_SelectedIndexChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Designation";
            // 
            // teacherPromotionDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 364);
            this.Controls.Add(this.designationComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.confirmButton2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.JoiningdateTimePicker);
            this.Controls.Add(this.teacherComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.teacherSearchButton);
            this.Controls.Add(this.disciplineComboBox);
            this.Controls.Add(this.schoolComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "teacherPromotionDateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teacher Promotion Form";
            this.Load += new System.EventHandler(this.teacherJoiningDateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox schoolComboBox;
        private System.Windows.Forms.ComboBox disciplineComboBox;
        private System.Windows.Forms.Button teacherSearchButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox teacherComboBox;
        private System.Windows.Forms.DateTimePicker JoiningdateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button confirmButton2;
        private System.Windows.Forms.ComboBox designationComboBox;
        private System.Windows.Forms.Label label4;
    }
}