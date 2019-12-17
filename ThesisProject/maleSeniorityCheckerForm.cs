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
    public partial class maleSeniorityCheckerForm : Form
    {
        private SqlDataAdapter da;
        private DataTable dt;

        private String gender;

        string name = "";
        int[] activeCount = new int[500];
        int[] teacherCount = new int[500];
        int count = 0;

        connection connection = new connection();

        public maleSeniorityCheckerForm(String gender)
        {
            this.gender = gender;
            InitializeComponent();
        }

        private void maleSeniorityCheckerForm_Load(object sender, EventArgs e)
        {
            professorGradeOneSeniorityCheck();

            professorGradeTwoSeniorityCheck();

            professorGradeThreeSeniorityCheck();

            assosciateProfessorSeniorityCheck();

            assistantProfessorSeniorityCheck();

            lecturerSeniorityScheck();
        }

        private void lecturerSeniorityScheck()
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                da = new SqlDataAdapter();
                dt = new DataTable();

                try
                {
                    connection.OpenConection();
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();
                    cmd.CommandText =
                        "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '1' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.gender = '" + gender + "'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime seniority = (DateTime) reader["joining_date"];
                        int teacher_id = (int) reader["teacher_id"];
                        int current_leave = (int) reader["current_leave"];
                        int total_leave = (int) reader["total_leave"];

                        DateTime now = DateTime.Now;
                        int active = ((TimeSpan) (now - seniority)).Days;

                        activeCount[count] = active - current_leave - total_leave;
                        teacherCount[count] = teacher_id;
                        System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" +
                                                 teacherCount[count]);

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
                    cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" +
                                      teacherCount[i] + "'";
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
                    cmd.CommandText =
                        "Select name, discipline_name , joining_date From info,joining,discipline where joining.designation_id = '1' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND info.gender = '" + gender + "' ORDER BY active DESC";

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    dataGridView6.DataSource = dt;



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

                //lecturer.Text = name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void assistantProfessorSeniorityCheck()
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                da = new SqlDataAdapter();
                dt = new DataTable();

                try
                {
                    connection.OpenConection();
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();
                    cmd.CommandText =
                        "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '2' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.gender = '" + gender + "'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime seniority = (DateTime) reader["joining_date"];
                        int teacher_id = (int) reader["teacher_id"];
                        int current_leave = (int) reader["current_leave"];
                        int total_leave = (int) reader["total_leave"];

                        DateTime now = DateTime.Now;
                        int active = ((TimeSpan) (now - seniority)).Days;

                        activeCount[count] = active - current_leave - total_leave;
                        teacherCount[count] = teacher_id;
                        System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" +
                                                 teacherCount[count]);

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
                    cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" +
                                      teacherCount[i] + "' and joining.current_designation = '1'";
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
                    cmd.CommandText =
                        "Select name, discipline_name , joining_date From info,joining,discipline where joining.designation_id = '2' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND info.gender = '" + gender + "' ORDER BY active DESC";

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    dataGridView5.DataSource = dt;

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

                //assistantProfessor.Text = name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void assosciateProfessorSeniorityCheck()
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                da = new SqlDataAdapter();
                dt = new DataTable();

                try
                {
                    connection.OpenConection();
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();
                    cmd.CommandText =
                        "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '3' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.gender = '" + gender + "'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime seniority = (DateTime) reader["joining_date"];
                        int teacher_id = (int) reader["teacher_id"];
                        int current_leave = (int) reader["current_leave"];
                        int total_leave = (int) reader["total_leave"];

                        DateTime now = DateTime.Now;
                        int active = ((TimeSpan) (now - seniority)).Days;

                        activeCount[count] = active - current_leave - total_leave;
                        teacherCount[count] = teacher_id;
                        System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" +
                                                 teacherCount[count]);

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
                    cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" +
                                      teacherCount[i] + "'";
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
                    cmd.CommandText =
                        "Select name, discipline_name , joining_date From info,joining,discipline where joining.designation_id = '3' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND info.gender = '" + gender + "' ORDER BY active DESC";

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    dataGridView4.DataSource = dt;

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

                //assosciateProfessor.Text = name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void professorGradeThreeSeniorityCheck()
        {
            try
            {

                SqlCommand cmd = new SqlCommand();
                da = new SqlDataAdapter();
                dt = new DataTable();


                try
                {
                    connection.OpenConection();
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();
                    cmd.CommandText =
                        "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '4' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.gender = '" + gender + "'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime seniority = (DateTime) reader["joining_date"];
                        int teacher_id = (int) reader["teacher_id"];
                        int current_leave = (int) reader["current_leave"];
                        int total_leave = (int) reader["total_leave"];

                        DateTime now = DateTime.Now;
                        int active = ((TimeSpan) (now - seniority)).Days;

                        activeCount[count] = active - current_leave - total_leave;
                        teacherCount[count] = teacher_id;
                        System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" +
                                                 teacherCount[count]);

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
                    cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" +
                                      teacherCount[i] + "'";
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
                    cmd.CommandText =
                        "Select name, discipline_name , joining_date From info,joining,discipline where joining.designation_id = '4' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND info.gender = '" + gender + "' ORDER BY active DESC";

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    dataGridView3.DataSource = dt;

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

                //professorGrade3.Text = name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void professorGradeTwoSeniorityCheck()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                da = new SqlDataAdapter();
                dt = new DataTable();


                try
                {
                    connection.OpenConection();
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();
                    cmd.CommandText =
                        "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '5' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.gender = '" + gender + "'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime seniority = (DateTime) reader["joining_date"];
                        int teacher_id = (int) reader["teacher_id"];
                        int current_leave = (int) reader["current_leave"];
                        int total_leave = (int) reader["total_leave"];

                        DateTime now = DateTime.Now;
                        int active = ((TimeSpan) (now - seniority)).Days;

                        activeCount[count] = active - current_leave - total_leave;
                        teacherCount[count] = teacher_id;
                        System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" +
                                                 teacherCount[count]);

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
                    cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" +
                                      teacherCount[i] + "'";
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
                    cmd.CommandText =
                        "Select name, discipline_name , joining_date From info,joining,discipline where joining.designation_id = '5' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND info.gender = '" + gender + "' ORDER BY active DESC";

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    dataGridView2.DataSource = dt;

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

                //professorGrade2.Text = name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void professorGradeOneSeniorityCheck()
        {
            try
            {

                SqlCommand cmd = new SqlCommand();

                da = new SqlDataAdapter();
                dt = new DataTable();


                try
                {
                    connection.OpenConection();
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();
                    cmd.CommandText =
                        "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '6' AND joining.teacher_id = info.Id AND joining.current_designation='1'";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime seniority = (DateTime) reader["joining_date"];
                        int teacher_id = (int) reader["teacher_id"];
                        int current_leave = (int) reader["current_leave"];
                        int total_leave = (int) reader["total_leave"];

                        DateTime now = DateTime.Now;
                        int active = ((TimeSpan) (now - seniority)).Days;

                        activeCount[count] = active - current_leave - total_leave;
                        teacherCount[count] = teacher_id;
                        System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" +
                                                 teacherCount[count]);

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
                    cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" +
                                      teacherCount[i] + "'";
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
                    cmd.CommandText =
                        "Select name, discipline_name , joining_date From info,joining,discipline where joining.designation_id = '6' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND info.gender = '" + gender + "' ORDER BY active DESC";

                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;

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

                //professorGrade1.Text = name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
    }
}
