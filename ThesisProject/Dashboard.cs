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


    public partial class Dashboard : Form
    {
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");

        connection connection = new connection();

        SqlCommand cmd;

        int[] leave_count = new int[500];
        int[] teacher_Count = new int[500];
        int[] designation_count = new int[500];
        
        int count = 0;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void designationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*designationSeniorityForm designationSeniorityForm = new designationSeniorityForm();
            designationSeniorityForm.Show(); */

            allTeacherSeniorityForm atsf = new allTeacherSeniorityForm();
            atsf.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void leaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leaveForm leaveForm = new leaveForm();
            leaveForm.Show();
        }

        private void disciplineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineEntryForm disciplineEntryForm = new disciplineEntryForm();
            disciplineEntryForm.Show();
        }

        private void schoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schoolEntryForm schoolEntryForm = new schoolEntryForm();
            schoolEntryForm.Show();
        }

        private void joiningDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            teacherPromotionDateForm teacherJoiningDateForm = new teacherPromotionDateForm();
            teacherJoiningDateForm.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                connection.OpenConection();
                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select teacher_id,leave_date,designation From leave where joined = '0'";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime leave_date = (DateTime)reader["leave_date"];
                    int teacher_id = (int)reader["teacher_id"];
                    int designation = (int)reader["designation"];

                    DateTime now = DateTime.Now;
                    int leave = ((TimeSpan)(now - leave_date)).Days;

                    leave_count[count] = leave;
                    teacher_Count[count] = teacher_id;
                    designation_count[count] = designation;
                    
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

            for (int i = 0; i < teacher_Count.Length; i++)
            {
                Console.WriteLine("Updating");
                cmd.CommandText = "Update leave Set total_leave = '" + leave_count[i] + "' Where teacher_id = '" + teacher_Count[i] + "'";
                connection.OpenConection();
                cmd.ExecuteNonQuery();
                connection.CloseConnection();


                cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Update joining Set current_leave = '" + leave_count[i] + "' Where teacher_id = '" + teacher_Count[i] + "' and designation_id = '"+designation_count[i]+"'";

                connection.OpenConection();
                cmd.ExecuteNonQuery();
                connection.CloseConnection();
            }
        }

        private void joinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            joinForm joinForm = new joinForm();
            joinForm.Show();
        }

        private void addTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            teacherEntryForm teacherEntryForm = new teacherEntryForm();
            teacherEntryForm.Show();
        }

        private void genderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void maleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maleSeniorityCheckerForm maleSeniorityCheckerForm = new maleSeniorityCheckerForm("male");
            maleSeniorityCheckerForm.Show();
        }

        private void femaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*femaleSeniorityCheckerForm femaleSeniorityCheckerForm = new femaleSeniorityCheckerForm();
            femaleSeniorityCheckerForm.Show(); */

            maleSeniorityCheckerForm mscf = new maleSeniorityCheckerForm("female");
            mscf.Show();
        }

        private void schoolToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            schoolDesignationForm schoolDesignationForm = new schoolDesignationForm();
            schoolDesignationForm.Show();
        }

        private void bioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            biodataForm biodataForm = new biodataForm();
            biodataForm.Show();
        }
    }
}
