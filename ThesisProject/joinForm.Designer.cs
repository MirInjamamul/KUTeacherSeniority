namespace ThesisProject
{
    partial class joinForm
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
            this.joinDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.confirmbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.teachercomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchbutton = new System.Windows.Forms.Button();
            this.disciplinecomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.designationcomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // joinDateTimePicker
            // 
            this.joinDateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.joinDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.joinDateTimePicker.Location = new System.Drawing.Point(288, 257);
            this.joinDateTimePicker.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.joinDateTimePicker.Name = "joinDateTimePicker";
            this.joinDateTimePicker.Size = new System.Drawing.Size(391, 23);
            this.joinDateTimePicker.TabIndex = 20;
            // 
            // confirmbutton
            // 
            this.confirmbutton.Location = new System.Drawing.Point(580, 309);
            this.confirmbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirmbutton.Name = "confirmbutton";
            this.confirmbutton.Size = new System.Drawing.Size(100, 28);
            this.confirmbutton.TabIndex = 19;
            this.confirmbutton.Text = "Confirm";
            this.confirmbutton.UseVisualStyleBackColor = true;
            this.confirmbutton.Click += new System.EventHandler(this.confirmbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 264);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Join date";
            // 
            // teachercomboBox
            // 
            this.teachercomboBox.FormattingEnabled = true;
            this.teachercomboBox.Location = new System.Drawing.Point(288, 209);
            this.teachercomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.teachercomboBox.Name = "teachercomboBox";
            this.teachercomboBox.Size = new System.Drawing.Size(391, 24);
            this.teachercomboBox.TabIndex = 17;
            this.teachercomboBox.SelectedIndexChanged += new System.EventHandler(this.teachercomboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 213);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Teacher Name";
            // 
            // searchbutton
            // 
            this.searchbutton.Location = new System.Drawing.Point(580, 158);
            this.searchbutton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(100, 28);
            this.searchbutton.TabIndex = 15;
            this.searchbutton.Text = "Search";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // disciplinecomboBox
            // 
            this.disciplinecomboBox.FormattingEnabled = true;
            this.disciplinecomboBox.Location = new System.Drawing.Point(288, 109);
            this.disciplinecomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.disciplinecomboBox.Name = "disciplinecomboBox";
            this.disciplinecomboBox.Size = new System.Drawing.Size(391, 24);
            this.disciplinecomboBox.TabIndex = 14;
            this.disciplinecomboBox.SelectedIndexChanged += new System.EventHandler(this.disciplinecomboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Discipline";
            // 
            // designationcomboBox
            // 
            this.designationcomboBox.FormattingEnabled = true;
            this.designationcomboBox.Location = new System.Drawing.Point(288, 59);
            this.designationcomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.designationcomboBox.Name = "designationcomboBox";
            this.designationcomboBox.Size = new System.Drawing.Size(391, 24);
            this.designationcomboBox.TabIndex = 12;
            this.designationcomboBox.SelectedIndexChanged += new System.EventHandler(this.designationcomboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Designation";
            // 
            // joinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 390);
            this.Controls.Add(this.joinDateTimePicker);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "joinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Join Form";
            this.Load += new System.EventHandler(this.joinForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker joinDateTimePicker;
        private System.Windows.Forms.Button confirmbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox teachercomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchbutton;
        private System.Windows.Forms.ComboBox disciplinecomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox designationcomboBox;
        private System.Windows.Forms.Label label1;
    }
}