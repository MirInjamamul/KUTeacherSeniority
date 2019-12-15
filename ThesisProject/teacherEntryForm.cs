using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ThesisProject
{
    
    public partial class teacherEntryForm : Form
    {
        connection connection = new connection();

        string school_name_form;
        string designation_name_form;
        string discipline_name_form;
        string gender;
        string degree_name;
        string degree_obtained_university_name;

        public teacherEntryForm()
        {
            InitializeComponent();
        }

        int initRanking(String teacher_name, int techer_designation , String date_of_birth, String joining_date)
        {

            connection.OpenConection();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Select Id from info where name = '" + teacher_name + "'";
            int teacher_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            connection.OpenConection();
            cmd.CommandText = "insert into [ranking] (id) values ('" + teacher_id + "')";
            cmd.ExecuteNonQuery();
            connection.CloseConnection();

            return teacher_id;
        }

        private void addTeacherBtn_Click(object sender, EventArgs e)
        {
            if (teacherNameTxt.Text.Contains("1") || teacherNameTxt.Text.Contains("2") || teacherNameTxt.Text.Contains("3")
                 || teacherNameTxt.Text.Contains("4") || teacherNameTxt.Text.Contains("5") || teacherNameTxt.Text.Contains("6")
                 || teacherNameTxt.Text.Contains("7") || teacherNameTxt.Text.Contains("8") || teacherNameTxt.Text.Contains("9")
                 || teacherNameTxt.Text.Contains("0") || teacherNameTxt.Text ==null || teacherNameTxt.Text == "") {

                MessageBox.Show("Invalid Teacher Name");
                teacherNameTxt.Focus();
                return;
            }

            if (designationComboBox.Text == null || designationComboBox.Text == "")
            {
                MessageBox.Show("Invalid Designation name");
                designationComboBox.Focus();
                return;
            }

            if (schoolNameComboBox.Text == null || schoolNameComboBox.Text == "")
            {
                MessageBox.Show("Invalid School name");
                schoolNameComboBox.Focus();
                return;
            }
            if (disciplineNameComboBox.Text == null || disciplineNameComboBox.Text == "")
            {
                MessageBox.Show("Invalid Discipline name");
                disciplineNameComboBox.Focus();
                return;
            }
            if (genderComboBox.Text == null || genderComboBox.Text == "")
            {
                MessageBox.Show("Invalid Gender name");
                genderComboBox.Focus();
                return;
            }
            if (highestDegreeComboBox.Text == null || highestDegreeComboBox.Text == "")
            {
                MessageBox.Show("Invalid Highest Degree");
                highestDegreeComboBox.Focus();
                return;
            }

            if (degreeObtainedUniversityComboBox.Text == null || degreeObtainedUniversityComboBox.Text == "")
            {
                MessageBox.Show("Invalid University Name");
                degreeObtainedUniversityComboBox.Focus();
                return;
            }

            degree_obtained_university_name = degreeObtainedUniversityComboBox.Text;

            connection.OpenConection();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select school_id from school where school_name = '"+school_name_form.ToString()+"'";
            int school_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            connection.OpenConection();
            cmd.CommandText = "Select designation_id from designation where designation_name = '" + designation_name_form.ToString() + "'";
            int designation_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            connection.OpenConection();
            cmd.CommandText = "Select discipline_id from discipline where discipline_name = '" + discipline_name_form.ToString() + "'";
            int discipline_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            connection.OpenConection();
            cmd.CommandText = "insert into [info] (name,designation,discipline,school,gender,highest_degree,date_of_birth) values ('" + teacherNameTxt.Text + "','" + designation_id + "','" + discipline_id + "','" + school_id + "','" + gender + "','" + degree_name + "','" + dateTimePicker1.Text + "')";
            cmd.ExecuteNonQuery();
            connection.CloseConnection();

            int versity_count = 0;
            try
            {
                connection.OpenConection();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select university_name From degreeObtainedUniversity where university_name = '"+degree_obtained_university_name+"'";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    versity_count++;
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            if (versity_count == 0) {
                connection.OpenConection();
                cmd.CommandText = "insert into [degreeObtainedUniversity] (university_name) values ('" + degree_obtained_university_name + "')";
                cmd.ExecuteNonQuery();
                connection.CloseConnection();

            }

            connection.OpenConection();
            cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select id from info where name = '" + teacherNameTxt.Text + "'";
            int teacher_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            connection.OpenConection();
            cmd.CommandText = "insert into [teacherDegree] (teacher_id,degree_name,degree_obtained_university) values ('" + teacher_id + "','" + degree_name + "','" + degree_obtained_university_name + "')";
            cmd.ExecuteNonQuery();
            connection.CloseConnection();

            connection.OpenConection();
            cmd.CommandText = "insert into [joining] (teacher_id,designation_id,current_designation,joining_date,total_leave,current_leave,active) values ('" + teacher_id + "','" + designation_id + "','"+ designation_id +"','" + joiningdateTimePicker.Text + "','0','0','0')";
            cmd.ExecuteNonQuery();
            connection.CloseConnection();
            MessageBox.Show("New Teacher Added");

            teacherEntryForm tef = new teacherEntryForm();
            this.Close();
            tef.Show();

        }

        public void teacherEntryForm_Load(object sender, EventArgs e)
        {

            loadSchoolComnoBox();

            loadDesignationComboBox();

            loadHighestDegeeComboBox();

            loadDegreeObtainedUniversityComboBox();
            
        }

        private void loadDegreeObtainedUniversityComboBox()
        {
            try
            {
                connection.OpenConection();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select university_name From degreeObtainedUniversity";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string university_name = reader["university_name"].ToString();
                    degreeObtainedUniversityComboBox.Items.Add(university_name);
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void loadHighestDegeeComboBox()
        {
            try
            {
                connection.OpenConection();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select degree_name From degree";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string degree_name = reader["degree_name"].ToString();
                    highestDegreeComboBox.Items.Add(degree_name);
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void loadDesignationComboBox()
        {
            try
            {
                connection.OpenConection();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select designation_name From designation";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string designation_name = reader["designation_name"].ToString();
                    designationComboBox.Items.Add(designation_name);
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void loadSchoolComnoBox()
        {
            try
            {
                connection.OpenConection();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select school_name From school";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string schoolName = reader["school_name"].ToString();
                    schoolNameComboBox.Items.Add(schoolName);
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void setDisciplineCombobox(int school_id)
        {
            try
            {
                connection.OpenConection();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select discipline_name From discipline Where school_id = '"+school_id+ "' Order By discipline_name ASC ";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string discipline_name = reader["discipline_name"].ToString();
                    disciplineNameComboBox.Items.Add(discipline_name);
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void designationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            designation_name_form = designationComboBox.Text;
        }

        private void disciplineNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            discipline_name_form = disciplineNameComboBox.Text;
            
        }

        private void genderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            gender = genderComboBox.Text;
        }

        private void highestDegreeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            degree_name = highestDegreeComboBox.Text;
        }

        private void schoolNameComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            school_name_form = schoolNameComboBox.Text;

            connection.OpenConection();
            SqlCommand cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select school_id from school where school_name = '" + school_name_form + "'";
            int school_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            setDisciplineCombobox(school_id);
        }

        private void teacherNameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void degreeObtainedUniversityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            degree_obtained_university_name = degreeObtainedUniversityComboBox.Text;
        }
    }
}
