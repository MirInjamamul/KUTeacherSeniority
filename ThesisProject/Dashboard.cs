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

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select COUNT(*) From leave where joined = '0'";
            connection.OpenConection();
            int dataCount = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            if (dataCount > 0)
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
                    cmd.CommandText = "Update joining Set current_leave = '" + leave_count[i] + "' Where teacher_id = '" + teacher_Count[i] + "' and designation_id = '" + designation_count[i] + "'";

                    connection.OpenConection();
                    cmd.ExecuteNonQuery();
                    connection.CloseConnection();
                }
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
            maleSeniorityCheckerForm maleSeniorityCheckerForm = new maleSeniorityCheckerForm("Male");
            maleSeniorityCheckerForm.Show();
        }

        private void femaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*femaleSeniorityCheckerForm femaleSeniorityCheckerForm = new femaleSeniorityCheckerForm();
            femaleSeniorityCheckerForm.Show(); */

            maleSeniorityCheckerForm mscf = new maleSeniorityCheckerForm("Female");
            mscf.Show();
        }

        private void schoolToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           /* schoolDesignationForm schoolDesignationForm = new schoolDesignationForm();
            schoolDesignationForm.Show(); */
        }

        private void bioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            biodataForm biodataForm = new biodataForm();
            biodataForm.Show();
        }

        private void scienceEngineeringAndTechnologyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schoolSeniorityCheckerForm sscf = new schoolSeniorityCheckerForm(1);
            
            sscf.Show();

        }

        private void artsAndHuminitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schoolSeniorityCheckerForm sscf = new schoolSeniorityCheckerForm(2);
            
            sscf.Show();
        }

        private void managementAndBuisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schoolSeniorityCheckerForm sscf = new schoolSeniorityCheckerForm(3);
            
            sscf.Show();
        }

        private void socialScienceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schoolSeniorityCheckerForm sscf = new schoolSeniorityCheckerForm(4);
            
            sscf.Show();
        }

        private void lifeScienceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schoolSeniorityCheckerForm sscf = new schoolSeniorityCheckerForm(5);
            
            sscf.Show();
        }

        private void lawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schoolSeniorityCheckerForm sscf = new schoolSeniorityCheckerForm(6);
            
            sscf.Show();
        }

        private void fineArtsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schoolSeniorityCheckerForm sscf = new schoolSeniorityCheckerForm(7);
            
            sscf.Show();
        }

        private void educationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            schoolSeniorityCheckerForm sscf = new schoolSeniorityCheckerForm(8);
            
            sscf.Show();
        }

        private void aRCHITECTUREToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(1);
            
            dsc.Show();
        }

        private void cOMPUTERSCIENCEANDENGINEERINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(2);
            
            dsc.Show();
        }

        private void uRBANANDRURALPLANNINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(4);
            
            dsc.Show();
        }

        private void eLECTRONICSANDCOMMUNICATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(9);
            
            dsc.Show();
        }

        private void mATHEMATICSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(12);
            
            dsc.Show();
        }

        private void pHYSCICSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(17);
            
            dsc.Show();
        }

        private void cHEMISTRYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(18);
            
            dsc.Show();
        }

        private void sTATISTICSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(20);
            
            dsc.Show();
        }

        private void bUSINESSADMINISTRATIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(3);
            
            dsc.Show();
        }

        private void hUMANRESIURCEMANAGEMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(26);
            
            dsc.Show();
        }

        private void fORESTYANDWOODTECHNOLOGYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(5);
            
            dsc.Show();
        }

        private void fISHERIESANDMARINERESOURCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(6);
            
            dsc.Show();
        }

        private void bIOTECHNOLOGYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(7);
            
            dsc.Show();
        }

        private void eNVIRONMENTALSCIENCEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(10);
            
            dsc.Show();
        }

        private void aGROTECHNOLOGYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(8);
            
            dsc.Show();
        }

        private void fARMACYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(17);
            
            dsc.Show();
        }

        private void sOILWATERENVIRONMENTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(13);
            
            dsc.Show();
        }

        private void eCONOMICSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(15);
            
            dsc.Show();
        }

        private void sOCIOLOGYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(16);
            
            dsc.Show();
        }

        private void dEVELOPMENTSTUDIESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(21);
            
            dsc.Show();
        }

        private void jOUNALISMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(25);
            
            dsc.Show();
        }

        private void bANGLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(19);
            
            dsc.Show();
        }

        private void eNGLISHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(14);
            
            dsc.Show();
        }

        private void lAWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            disciplineSeniorityChecker dsc = new disciplineSeniorityChecker(28);
            
            dsc.Show();
        }

        private void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateFormPassword ufp = new updateFormPassword();
            ufp.Show();
        }
    }
}
