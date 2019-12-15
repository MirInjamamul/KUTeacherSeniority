namespace ThesisProject
{
    partial class leaveForm
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
            this.designationcomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.disciplinecomboBox = new System.Windows.Forms.ComboBox();
            this.searchbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.teachercomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.confirmbutton = new System.Windows.Forms.Button();
            this.leavedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Designation";
            // 
            // designationcomboBox
            // 
            this.designationcomboBox.FormattingEnabled = true;
            this.designationcomboBox.Location = new System.Drawing.Point(162, 40);
            this.designationcomboBox.Name = "designationcomboBox";
            this.designationcomboBox.Size = new System.Drawing.Size(294, 24);
            this.designationcomboBox.TabIndex = 1;
            this.designationcomboBox.SelectedIndexChanged += new System.EventHandler(this.designationcomboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Discipline";
            // 
            // disciplinecomboBox
            // 
            this.disciplinecomboBox.FormattingEnabled = true;
            this.disciplinecomboBox.Location = new System.Drawing.Point(162, 80);
            this.disciplinecomboBox.Name = "disciplinecomboBox";
            this.disciplinecomboBox.Size = new System.Drawing.Size(294, 24);
            this.disciplinecomboBox.TabIndex = 3;
            this.disciplinecomboBox.SelectedIndexChanged += new System.EventHandler(this.disciplinecomboBox_SelectedIndexChanged);
            // 
            // searchbutton
            // 
            this.searchbutton.Location = new System.Drawing.Point(381, 120);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(75, 23);
            this.searchbutton.TabIndex = 4;
            this.searchbutton.Text = "Search";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Teacher Name";
            // 
            // teachercomboBox
            // 
            this.teachercomboBox.FormattingEnabled = true;
            this.teachercomboBox.Location = new System.Drawing.Point(162, 162);
            this.teachercomboBox.Name = "teachercomboBox";
            this.teachercomboBox.Size = new System.Drawing.Size(294, 24);
            this.teachercomboBox.TabIndex = 6;
            this.teachercomboBox.SelectedIndexChanged += new System.EventHandler(this.teachercomboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Leave date";
            // 
            // confirmbutton
            // 
            this.confirmbutton.Location = new System.Drawing.Point(381, 243);
            this.confirmbutton.Name = "confirmbutton";
            this.confirmbutton.Size = new System.Drawing.Size(75, 23);
            this.confirmbutton.TabIndex = 9;
            this.confirmbutton.Text = "Confirm";
            this.confirmbutton.UseVisualStyleBackColor = true;
            this.confirmbutton.Click += new System.EventHandler(this.confirmbutton_Click);
            // 
            // leavedateTimePicker
            // 
            this.leavedateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.leavedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.leavedateTimePicker.Location = new System.Drawing.Point(162, 201);
            this.leavedateTimePicker.Name = "leavedateTimePicker";
            this.leavedateTimePicker.Size = new System.Drawing.Size(294, 23);
            this.leavedateTimePicker.TabIndex = 10;
            // 
            // leaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 281);
            this.Controls.Add(this.leavedateTimePicker);
            this.Controls.Add(this.confirmbutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.teachercomboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchbutton);
            this.Controls.Add(this.disciplinecomboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.designationcomboBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "leaveForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave Form";
            this.Load += new System.EventHandler(this.leaveForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox designationcomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox disciplinecomboBox;
        private System.Windows.Forms.Button searchbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox teachercomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button confirmbutton;
        private System.Windows.Forms.DateTimePicker leavedateTimePicker;
    }
}