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
    public partial class teacherUpdate : Form
    {
        connection connection = new connection();

        string designation;
        string discipline;
        string teacher_name;

        int designation_id;
        int teacher_id;
        public teacherUpdate()
        {
            InitializeComponent();
        }

        private void searchbutton_Click(object sender, EventArgs e)
        {
            connection.OpenConection();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select designation_id from designation where designation_name = '" + designation + "'";
            designation_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            connection.OpenConection();
            cmd.CommandText = "Select discipline_id from discipline where discipline_name = '" + discipline + "'";
            int discipline_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            try
            {
                connection.OpenConection();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select name From info where designation = '" + designation_id + "' AND discipline = '" + discipline_id + "'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    teachercomboBox.Items.Add(name);
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {
            connection.OpenConection();
            SqlCommand cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Id from info where name = '" + teacher_name + "'";
            teacher_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            connection.OpenConection();
            cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update joining Set joining_date = '"+joiningdateTimePicker.Text+"' Where teacher_id = '" + teacher_id + "' And designation_id = '"+designation_id+"'";
            cmd.ExecuteNonQuery();
            connection.CloseConnection();

            MessageBox.Show("Teacher Joining Date Updated");

            teacherUpdate tu = new teacherUpdate();
            this.Close();
            tu.Show();
        }

        private void teacherUpdate_Load(object sender, EventArgs e)
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
                    string designation = reader["designation_name"].ToString();
                    designationcomboBox.Items.Add(designation);
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            try
            {
                connection.OpenConection();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select discipline_name From discipline";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string discipline_name = reader["discipline_name"].ToString();
                    disciplinecomboBox.Items.Add(discipline_name);
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
        
        private void designationcomboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            designation = designationcomboBox.Text;
        }

        private void disciplinecomboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            discipline = disciplinecomboBox.Text;
        }

        private void teachercomboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            teacher_name = teachercomboBox.Text;
        }
    }
}
