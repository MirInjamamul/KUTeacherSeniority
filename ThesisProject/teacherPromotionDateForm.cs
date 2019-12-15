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
    public partial class teacherPromotionDateForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");

        string school_name;
        string discipline_name;
        string teacher_name;
        string designation;

        public teacherPromotionDateForm()
        {
            InitializeComponent();
        }

        private void teacherJoiningDateForm_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select school_name From school";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string schoolName = reader["school_name"].ToString();
                    schoolComboBox.Items.Add(schoolName);
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
                    disciplineComboBox.Items.Add(discipline_name);
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
                cmd.CommandText = "Select designation_name From designation";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string designation_name = reader["designation_name"].ToString();
                    designationComboBox.Items.Add(designation_name);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void schoolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            school_name = schoolComboBox.Text;
        }

        private void disciplineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            discipline_name = disciplineComboBox.Text;
        }

        private void teacherSearchButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select school_id from school where school_name = '" + school_name + "'";
            int school_id = (int)cmd.ExecuteScalar();
            connection.Close();

            connection.Open();
            cmd.CommandText = "Select discipline_id from discipline where discipline_name = '" + discipline_name + "'";
            int discipline_id = (int)cmd.ExecuteScalar();
            connection.Close();

            connection.Open();
            cmd.CommandText = "Select designation_id from designation where designation_name = '" + designation + "'";
            int designation_id = (int)cmd.ExecuteScalar();
            connection.Close();

            try
            {
                connection.Open();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select name From info where discipline = '"+discipline_id+"' AND school = '"+school_id+"' AND designation = '"+designation_id+"'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string name = reader["name"].ToString();
                    teacherComboBox.Items.Add(name);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void confirmButton2_Click(object sender, EventArgs e)
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

            if (designation_id < 6 && designation_id > 0)
            {
                designation_id = designation_id + 1;
            }
            else {
                MessageBox.Show("Invalid Promotion");
            }

            connection.Open();
            cmd.CommandText = "Update info Set designation = '" + designation_id + "' Where Id = '" + teacher_id + "'";
            cmd.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            cmd.CommandText = "Update joining Set current_designation = '0' Where teacher_id = '" + teacher_id + "'";
            cmd.ExecuteNonQuery();
            connection.Close();

            connection.Open();
            cmd.CommandText = "insert into [joining] (teacher_id,designation_id,current_designation,joining_date,total_leave,current_leave,active) values ('" + teacher_id + "','" + designation_id + "','1','" + JoiningdateTimePicker.Text + "','0','0','0')";
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Teacher Promotion Done");
            
        }

        private void teacherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            teacher_name = teacherComboBox.Text;
        }

     //   private void designationComboBox_SelectedIndexChanged(object sender, EventArgs e)
      //  {
    //        designation = designationComboBox.Text;
     //   }

        private void designationComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            designation = designationComboBox.Text;
        }
    }
}
