namespace ThesisProject
{
    partial class teacherEntryForm
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.teacherNameTxt = new System.Windows.Forms.TextBox();
            this.addTeacherBtn = new System.Windows.Forms.Button();
            this.designationComboBox = new System.Windows.Forms.ComboBox();
            this.disciplineNameComboBox = new System.Windows.Forms.ComboBox();
            this.genderComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.highestDegreeComboBox = new System.Windows.Forms.ComboBox();
            this.joiningdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.schoolNameComboBox = new System.Windows.Forms.ComboBox();
            this.schoolNameTxt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.degreeObtainedUniversityComboBox = new System.Windows.Forms.ComboBox();
            this.seniorityDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.syndicateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Teacher Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Designation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Discipline Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 166);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Gender";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(71, 201);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Highest Degree";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 425);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Date of Birth";
            // 
            // teacherNameTxt
            // 
            this.teacherNameTxt.Location = new System.Drawing.Point(274, 16);
            this.teacherNameTxt.Margin = new System.Windows.Forms.Padding(4);
            this.teacherNameTxt.Name = "teacherNameTxt";
            this.teacherNameTxt.Size = new System.Drawing.Size(252, 22);
            this.teacherNameTxt.TabIndex = 9;
            this.teacherNameTxt.TextChanged += new System.EventHandler(this.teacherNameTxt_TextChanged);
            // 
            // addTeacherBtn
            // 
            this.addTeacherBtn.Location = new System.Drawing.Point(426, 464);
            this.addTeacherBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addTeacherBtn.Name = "addTeacherBtn";
            this.addTeacherBtn.Size = new System.Drawing.Size(100, 28);
            this.addTeacherBtn.TabIndex = 16;
            this.addTeacherBtn.Text = "ADD";
            this.addTeacherBtn.UseVisualStyleBackColor = true;
            this.addTeacherBtn.Click += new System.EventHandler(this.addTeacherBtn_Click);
            // 
            // designationComboBox
            // 
            this.designationComboBox.FormattingEnabled = true;
            this.designationComboBox.Location = new System.Drawing.Point(274, 52);
            this.designationComboBox.Name = "designationComboBox";
            this.designationComboBox.Size = new System.Drawing.Size(252, 24);
            this.designationComboBox.TabIndex = 18;
            this.designationComboBox.SelectedIndexChanged += new System.EventHandler(this.designationComboBox_SelectedIndexChanged);
            // 
            // disciplineNameComboBox
            // 
            this.disciplineNameComboBox.FormattingEnabled = true;
            this.disciplineNameComboBox.Location = new System.Drawing.Point(274, 127);
            this.disciplineNameComboBox.Name = "disciplineNameComboBox";
            this.disciplineNameComboBox.Size = new System.Drawing.Size(252, 24);
            this.disciplineNameComboBox.TabIndex = 19;
            this.disciplineNameComboBox.SelectedIndexChanged += new System.EventHandler(this.disciplineNameComboBox_SelectedIndexChanged);
            // 
            // genderComboBox
            // 
            this.genderComboBox.FormattingEnabled = true;
            this.genderComboBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.genderComboBox.Location = new System.Drawing.Point(274, 163);
            this.genderComboBox.Name = "genderComboBox";
            this.genderComboBox.Size = new System.Drawing.Size(252, 24);
            this.genderComboBox.TabIndex = 20;
            this.genderComboBox.SelectedIndexChanged += new System.EventHandler(this.genderComboBox_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(274, 417);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 27);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // highestDegreeComboBox
            // 
            this.highestDegreeComboBox.FormattingEnabled = true;
            this.highestDegreeComboBox.Location = new System.Drawing.Point(274, 198);
            this.highestDegreeComboBox.Name = "highestDegreeComboBox";
            this.highestDegreeComboBox.Size = new System.Drawing.Size(252, 24);
            this.highestDegreeComboBox.TabIndex = 22;
            this.highestDegreeComboBox.SelectedIndexChanged += new System.EventHandler(this.highestDegreeComboBox_SelectedIndexChanged);
            // 
            // joiningdateTimePicker
            // 
            this.joiningdateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.joiningdateTimePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.joiningdateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.joiningdateTimePicker.Location = new System.Drawing.Point(274, 280);
            this.joiningdateTimePicker.Name = "joiningdateTimePicker";
            this.joiningdateTimePicker.Size = new System.Drawing.Size(150, 27);
            this.joiningdateTimePicker.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 288);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Joining Date";
            // 
            // schoolNameComboBox
            // 
            this.schoolNameComboBox.FormattingEnabled = true;
            this.schoolNameComboBox.Location = new System.Drawing.Point(274, 91);
            this.schoolNameComboBox.Name = "schoolNameComboBox";
            this.schoolNameComboBox.Size = new System.Drawing.Size(252, 24);
            this.schoolNameComboBox.TabIndex = 26;
            this.schoolNameComboBox.SelectedIndexChanged += new System.EventHandler(this.schoolNameComboBox_SelectedIndexChanged_1);
            // 
            // schoolNameTxt
            // 
            this.schoolNameTxt.AutoSize = true;
            this.schoolNameTxt.Location = new System.Drawing.Point(71, 94);
            this.schoolNameTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.schoolNameTxt.Name = "schoolNameTxt";
            this.schoolNameTxt.Size = new System.Drawing.Size(90, 16);
            this.schoolNameTxt.TabIndex = 25;
            this.schoolNameTxt.Text = "School Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Degree Obtained University";
            // 
            // degreeObtainedUniversityComboBox
            // 
            this.degreeObtainedUniversityComboBox.FormattingEnabled = true;
            this.degreeObtainedUniversityComboBox.Location = new System.Drawing.Point(274, 236);
            this.degreeObtainedUniversityComboBox.Name = "degreeObtainedUniversityComboBox";
            this.degreeObtainedUniversityComboBox.Size = new System.Drawing.Size(252, 24);
            this.degreeObtainedUniversityComboBox.TabIndex = 28;
            this.degreeObtainedUniversityComboBox.SelectedIndexChanged += new System.EventHandler(this.degreeObtainedUniversityComboBox_SelectedIndexChanged);
            // 
            // seniorityDateTimePicker
            // 
            this.seniorityDateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.seniorityDateTimePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seniorityDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.seniorityDateTimePicker.Location = new System.Drawing.Point(274, 326);
            this.seniorityDateTimePicker.Name = "seniorityDateTimePicker";
            this.seniorityDateTimePicker.Size = new System.Drawing.Size(150, 27);
            this.seniorityDateTimePicker.TabIndex = 29;
            // 
            // syndicateDateTimePicker
            // 
            this.syndicateDateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.syndicateDateTimePicker.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.syndicateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.syndicateDateTimePicker.Location = new System.Drawing.Point(274, 372);
            this.syndicateDateTimePicker.Name = "syndicateDateTimePicker";
            this.syndicateDateTimePicker.Size = new System.Drawing.Size(150, 27);
            this.syndicateDateTimePicker.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 334);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "Seniority Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(71, 380);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 32;
            this.label10.Text = "Syndicate Date";
            // 
            // teacherEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 529);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.syndicateDateTimePicker);
            this.Controls.Add(this.seniorityDateTimePicker);
            this.Controls.Add(this.degreeObtainedUniversityComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.schoolNameComboBox);
            this.Controls.Add(this.schoolNameTxt);
            this.Controls.Add(this.joiningdateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.highestDegreeComboBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.genderComboBox);
            this.Controls.Add(this.disciplineNameComboBox);
            this.Controls.Add(this.designationComboBox);
            this.Controls.Add(this.addTeacherBtn);
            this.Controls.Add(this.teacherNameTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "teacherEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Teacher";
            this.Load += new System.EventHandler(this.teacherEntryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox teacherNameTxt;
        private System.Windows.Forms.Button addTeacherBtn;
        private System.Windows.Forms.ComboBox designationComboBox;
        private System.Windows.Forms.ComboBox disciplineNameComboBox;
        private System.Windows.Forms.ComboBox genderComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ComboBox highestDegreeComboBox;
        private System.Windows.Forms.DateTimePicker joiningdateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox schoolNameComboBox;
        private System.Windows.Forms.Label schoolNameTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox degreeObtainedUniversityComboBox;
        private System.Windows.Forms.DateTimePicker seniorityDateTimePicker;
        private System.Windows.Forms.DateTimePicker syndicateDateTimePicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}