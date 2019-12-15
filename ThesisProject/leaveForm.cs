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

namespace ThesisProject
{
    public partial class leaveForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");

        string designation;
        string discipline;
        string teacher_name;
        int designation_id , discipline_id;

        public leaveForm()
        {
            InitializeComponent();
        }

        private void leaveForm_Load(object sender, EventArgs e)
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
                MessageBox.Show("Invalid Designation name");
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

        void loadTeacherComboBox()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select name From info where designation = '" + designation_id + "' AND discipline = '" + discipline_id + "'";

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

        private void confirmbutton_Click(object sender, EventArgs e)
        {
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
            cmd.CommandText = "insert into [leave] (teacher_id,designation,leave_date,join_date,joined,total_leave) values ('" + teacher_id + "','" + designation_id + "','" + leavedateTimePicker.Text + "',Null,'0','0')";
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Teacher Leave Granted");

            leaveForm lf = new leaveForm();
            this.Close();
            lf.Show();
        }

        private void teachercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            teacher_name = teachercomboBox.Text;
        }
    }
}
