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
    public partial class biodataForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");

        string designation;
        string discipline;
        string teacher_name;

        int designation_id;
        int teacher_id;

        string leavejoin;

        public biodataForm()
        {
            InitializeComponent();
        }

        private void biodataForm_Load(object sender, EventArgs e)
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

        private void searchbutton_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select designation_id from designation where designation_name = '" + designation + "'";
            designation_id = (int)cmd.ExecuteScalar();
            connection.Close();

            connection.Open();
            cmd.CommandText = "Select discipline_id from discipline where discipline_name = '" + discipline + "'";
            int discipline_id = (int)cmd.ExecuteScalar();
            connection.Close();

            try
            {
                connection.Open();
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
            cmd.CommandText = "Select Id from info where name = '" + teacher_name + "'";
            teacher_id = (int)cmd.ExecuteScalar();
            connection.Close();



            try
            {
                connection.Open();
                cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select highest_degree,date_of_birth,designation,joining_date From info,joining where name = '" + teacher_name + "' AND joining.teacher_id = '"+teacher_id+"' AND joining.designation_id = '"+designation_id+"'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    
                    labelBioName.Text = teacher_name;
                    labelBioName.Visible = true;

                    labelBioHighestDegree.Text = (string)reader["highest_degree"];
                    labelBioHighestDegree.Visible = true;

                    labelBioDateOfBirth.Text = (string)reader["date_of_birth"].ToString();
                    labelBioDateOfBirth.Visible = true;

                    labelBioCurrentDesignation.Text = designation;
                    labelBioCurrentDesignation.Visible = true;

                    labelBioSeniorityDate.Text = (string)reader["joining_date"].ToString();
                    labelBioSeniorityDate.Visible = true;

                    labelBioDisciplineName.Text = discipline.ToString();
                    labelBioDisciplineName.Visible = true;
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
                cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select degree_obtained_university From teacherDegree where teacher_id = '" + teacher_id + "' AND degree_name = '" + labelBioHighestDegree.Text + "'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    labelBioHighestDegreeObtainedUniversity.Text = (string)reader["degree_obtained_university"].ToString();
                    labelBioHighestDegreeObtainedUniversity.Visible = true;
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
                cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select leave_date,join_date From leave where teacher_id = '" + teacher_id + "' AND designation = '" + designation_id + "'";

                SqlDataReader reader = cmd.ExecuteReader();

                textBoxBioLeaveJoin.Text = "";
                while (reader.Read())
                {
                    textBoxBioLeaveJoin.Visible = true;
                    string leave = (string)reader["leave_date"].ToString();
                    string join = (string)reader["join_date"].ToString();

                    Console.WriteLine("" + join);

                    if (join == "")
                        join = "Not Join Yet";

                    textBoxBioLeaveJoin.Text = textBoxBioLeaveJoin.Text + "Leave : " + leave + " Join : " + join +"\n";
                    
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }            
        }

        private void teachercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            teacher_name = teachercomboBox.Text;
        }

        private void designationcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            designation = designationcomboBox.Text;
        }

        private void disciplinecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            discipline = disciplinecomboBox.Text;
        }
    }
}
