using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThesisProject
{
    public partial class joinForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");

        string designation;
        string discipline;
        string teacher_name;
        int leave;
        int total_leave;
        int designation_id , discipline_id;

        public joinForm()
        {
            InitializeComponent();
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {

            if (designationcomboBox.Text == null || designationcomboBox.Text == "")
            {
                MessageBox.Show("Invalid Designation name");
                designationcomboBox.Focus();
                return;
            }

            if (disciplinecomboBox.Text == null || disciplinecomboBox.Text == "")
            {
                MessageBox.Show("Invalid Discipline name");
                disciplinecomboBox.Focus();
                return;
            }

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select designation_id from designation where designation_name = '" + designation + "'";
            designation_id = (int)cmd.ExecuteScalar();
            connection.Close();

            connection.Open();
            cmd.CommandText = "Select discipline_id from discipline where discipline_name = '" + discipline + "'";
            discipline_id = (int)cmd.ExecuteScalar();
            connection.Close();

            loadTeacherComboBox();
        }

        private void joinForm_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select designation_name From designation";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string designation = reader["designation_name"].ToString();
                    designationcomboBox.Items.Add(designation);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select discipline_name From discipline";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string discipline_name = reader["discipline_name"].ToString();
                    disciplinecomboBox.Items.Add(discipline_name);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void designationcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            designation = designationcomboBox.Text;
        }

        private void disciplinecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            discipline = disciplinecomboBox.Text;
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {

            if (teachercomboBox.Text == null || teachercomboBox.Text == "")
            {
                MessageBox.Show("Invalid Teacher name");
                designationcomboBox.Focus();
                return;
            }

            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select id from info where name = '" + teacher_name + "'";
            int teacher_id = (int)cmd.ExecuteScalar();
            connection.Close();

            connection.Open();
            cmd.CommandText = "Select designation_id from designation where designation_name = '" + designation + "'";
            int designation_id = (int)cmd.ExecuteScalar();
            connection.Close();

            connection.Open();
            cmd.CommandText = "Update leave Set join_date = '" + joinDateTimePicker.Text + "' Where teacher_id = '" + teacher_id + "' and designation = '" + designation_id + "' and joined = '0'";
            cmd.ExecuteNonQuery();
            connection.Close();

            
            MessageBox.Show("Teacher Joined");

            try
            {
                connection.Open();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select join_date,leave_date from leave where teacher_id = '" + teacher_id + "' and designation = '" + designation_id + "' and joined = '0'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime leave_date = (DateTime)reader["leave_date"];
                    DateTime join_date = (DateTime)reader["join_date"];

                    leave = ((TimeSpan)(join_date - leave_date)).Days;

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            connection.Open();
            cmd.CommandText = "Update leave Set total_leave = '"+leave+"' Where teacher_id = '" + teacher_id + "' and designation = '" + designation_id + "' and joined = '0'";
            cmd.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            cmd.CommandText = "Update leave Set joined = '1' Where teacher_id = '" + teacher_id + "' and designation = '" + designation_id + "' and joined = '0'";
            cmd.ExecuteNonQuery();
            connection.Close();

            try
            {
                connection.Open();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select total_leave from joining where teacher_id = '" + teacher_id + "' and designation_id = '" + designation_id + "' and current_designation = '1'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    total_leave = (int)reader["total_leave"];
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            total_leave = total_leave + leave;

            connection.Open();
            cmd.CommandText = "Update joining Set total_leave = '"+total_leave+"' Where teacher_id = '" + teacher_id + "' and designation_id = '" + designation_id + "'";
            cmd.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            cmd.CommandText = "Update joining Set current_leave = '0' Where teacher_id = '" + teacher_id + "' and designation_id = '" + designation_id + "'";
            cmd.ExecuteNonQuery();
            connection.Close();

            joinForm jf1 = new joinForm();
            this.Close();
            jf1.Show();

            loadTeacherComboBox();
        }

        private void teachercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            teacher_name = teachercomboBox.Text;
        }

        void loadTeacherComboBox()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select name From info,leave where info.designation = '" + designation_id + "' AND info.discipline = '" + discipline_id + "' AND info.Id = leave.teacher_id AND joined='0'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    teachercomboBox.Items.Add(name);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
    }
}
