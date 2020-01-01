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
        connection connection = new connection();

        string designation;
        string discipline;
        string teacher_name;

        int designation_id;
        int teacher_id;
        

        public biodataForm()
        {
            InitializeComponent();
        }

        private void biodataForm_Load(object sender, EventArgs e)
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

        private void searchbutton_Click(object sender, EventArgs e)
        {
            teachercomboBox.Items.Clear();

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
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Id from info where name = '" + teacher_name + "'";
            teacher_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();



            try
            {
                connection.OpenConection();
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

                    lecjoin.Text = (string)reader["joining_date"].ToString();
                    lecjoin.Visible = true;

                    labelBioDisciplineName.Text = discipline.ToString();
                    labelBioDisciplineName.Visible = true;
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
                cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select degree_obtained_university From teacherDegree where teacher_id = '" + teacher_id + "' AND degree_name = '" + labelBioHighestDegree.Text + "'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    labelBioHighestDegreeObtainedUniversity.Text = (string)reader["degree_obtained_university"].ToString();
                    labelBioHighestDegreeObtainedUniversity.Visible = true;
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            try
            {

                cmd = new SqlCommand();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select COUNT(*) joining_date From joining where teacher_id = '" + teacher_id + "' AND designation_id = '1'";
                connection.OpenConection();
                int dataCount = (int)cmd.ExecuteScalar();
                connection.CloseConnection();

                if (dataCount > 0)
                {
                    try
                    {
                        connection.OpenConection();
                        cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select joining_date,seniority_date,syndicate_date  From joining where teacher_id = '" + teacher_id + "' AND designation_id = '1'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            label44.Visible = true;

                            label13.Visible = true;
                            label8.Visible = true;
                            label15.Visible = true;

                            lecjoin.Text = (string)reader["joining_date"].ToString();
                            lecjoin.Visible = true;

                            lecsen.Text = (string)reader["seniority_date"].ToString();
                            lecsen.Visible = true;

                            lecsyn.Text = (string)reader["syndicate_date"].ToString();
                            lecsyn.Visible = true;
                        }
                        connection.CloseConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            //

            try
            {

                cmd = new SqlCommand();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select COUNT(*) joining_date From joining where teacher_id = '" + teacher_id + "' AND designation_id = '2'";
                connection.OpenConection();
                int dataCount = (int)cmd.ExecuteScalar();
                connection.CloseConnection();

                if (dataCount > 0)
                {
                    try
                    {
                        connection.OpenConection();
                        cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select joining_date,seniority_date,syndicate_date  From joining where teacher_id = '" + teacher_id + "' AND designation_id = '2'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            label45.Visible = true;

                            label17.Visible = true;
                            label19.Visible = true;
                            label14.Visible = true;

                            label18.Text = (string)reader["joining_date"].ToString();
                            label18.Visible = true;

                            label16.Text = (string)reader["seniority_date"].ToString();
                            label16.Visible = true;

                            label11.Text = (string)reader["syndicate_date"].ToString();
                            label11.Visible = true;
                        }
                        connection.CloseConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            //

            try
            {

                cmd = new SqlCommand();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select COUNT(*) joining_date From joining where teacher_id = '" + teacher_id + "' AND designation_id = '3'";
                connection.OpenConection();
                int dataCount = (int)cmd.ExecuteScalar();
                connection.CloseConnection();

                if (dataCount > 0)
                {
                    try
                    {
                        connection.OpenConection();
                        cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select joining_date,seniority_date,syndicate_date  From joining where teacher_id = '" + teacher_id + "' AND designation_id = '3'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            label46.Visible = true;

                            label23.Visible = true;
                            label25.Visible = true;
                            label21.Visible = true;

                            label24.Text = (string)reader["joining_date"].ToString();
                            label24.Visible = true;

                            label22.Text = (string)reader["seniority_date"].ToString();
                            label22.Visible = true;

                            label20.Text = (string)reader["syndicate_date"].ToString();
                            label20.Visible = true;
                        }
                        connection.CloseConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            //

            try
            {

                cmd = new SqlCommand();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select COUNT(*) joining_date From joining where teacher_id = '" + teacher_id + "' AND designation_id = '4'";
                connection.OpenConection();
                int dataCount = (int)cmd.ExecuteScalar();
                connection.CloseConnection();

                if (dataCount > 0)
                {
                    try
                    {
                        connection.OpenConection();
                        cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select joining_date,seniority_date,syndicate_date  From joining where teacher_id = '" + teacher_id + "' AND designation_id = '4'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            label47.Visible = true;

                            label29.Visible = true;
                            label31.Visible = true;
                            label27.Visible = true;

                            label30.Text = (string)reader["joining_date"].ToString();
                            label30.Visible = true;

                            label28.Text = (string)reader["seniority_date"].ToString();
                            label28.Visible = true;

                            label26.Text = (string)reader["syndicate_date"].ToString();
                            label26.Visible = true;
                        }
                        connection.CloseConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }


            //

            try
            {

                cmd = new SqlCommand();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select COUNT(*) joining_date From joining where teacher_id = '" + teacher_id + "' AND designation_id = '5'";
                connection.OpenConection();
                int dataCount = (int)cmd.ExecuteScalar();
                connection.CloseConnection();

                if (dataCount > 0)
                {
                    try
                    {
                        connection.OpenConection();
                        cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select joining_date,seniority_date,syndicate_date  From joining where teacher_id = '" + teacher_id + "' AND designation_id = '5'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            label48.Visible = true;

                            label35.Visible = true;
                            label37.Visible = true;
                            label33.Visible = true;

                            label36.Text = (string)reader["joining_date"].ToString();
                            label36.Visible = true;

                            label34.Text = (string)reader["seniority_date"].ToString();
                            label34.Visible = true;

                            label32.Text = (string)reader["syndicate_date"].ToString();
                            label32.Visible = true;
                        }
                        connection.CloseConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            //

            try
            {

                cmd = new SqlCommand();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select COUNT(*) joining_date From joining where teacher_id = '" + teacher_id + "' AND designation_id = '6'";
                connection.OpenConection();
                int dataCount = (int)cmd.ExecuteScalar();
                connection.CloseConnection();

                if (dataCount > 0)
                {
                    try
                    {
                        connection.OpenConection();
                        cmd = connection.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select joining_date,seniority_date,syndicate_date  From joining where teacher_id = '" + teacher_id + "' AND designation_id = '6'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            label49.Visible = true;

                            label41.Visible = true;
                            label43.Visible = true;
                            label39.Visible = true;

                            label42.Text = (string)reader["joining_date"].ToString();
                            label42.Visible = true;

                            label40.Text = (string)reader["seniority_date"].ToString();
                            label40.Visible = true;

                            label38.Text = (string)reader["syndicate_date"].ToString();
                            label38.Visible = true;
                        }
                        connection.CloseConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }

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

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
