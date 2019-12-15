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
    public partial class femaleSeniorityCheckerForm : Form
    {
       // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");

        connection connection = new connection();

        string designation;
        string name = "";
        int[] activeCount = new int[500];
        int[] teacherCount = new int[500];
        int count = 0;
        string queryGenderName = "Female";

        public femaleSeniorityCheckerForm()
        {
            InitializeComponent();
        }

        private void femaleSeniorityCheckerForm_Load(object sender, EventArgs e)
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

        private void designationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            designation = designationComboBox.Text;
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            connection.OpenConection();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select designation_id from designation where designation_name = '" + designation + "'";
            int designation_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            try
            {
                connection.OpenConection();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '" + designation_id + "' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.gender = '"+queryGenderName+"'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime seniority = (DateTime)reader["joining_date"];
                    int teacher_id = (int)reader["teacher_id"];
                    int current_leave = (int)reader["current_leave"];
                    int total_leave = (int)reader["total_leave"];

                    DateTime now = DateTime.Now;
                    int active = ((TimeSpan)(now - seniority)).Days;

                    activeCount[count] = active - current_leave - total_leave;
                    teacherCount[count] = teacher_id;
                    System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" + teacherCount[count]);

                    count++;
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }


            cmd = new SqlCommand();
            cmd = connection.CreateCommand();

            for (int i = 0; i < teacherCount.Length; i++)
            {
                Console.WriteLine("Updating");
                cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" + teacherCount[i] + "'";
                connection.OpenConection();
                cmd.ExecuteNonQuery();
                connection.CloseConnection();
            }
            name = "";
            try
            {
                connection.OpenConection();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select name, active From info,joining where joining.designation_id = '" + designation_id + "' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.gender = '" + queryGenderName + "' ORDER BY active DESC";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    name = name + " " + reader["name"].ToString();
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            textBox1.Text = name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
