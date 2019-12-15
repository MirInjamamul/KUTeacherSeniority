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
    public partial class disciplineEntryForm : Form
    {
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");

        connection connection = new connection();

        string school_name_form;
        public disciplineEntryForm()
        {
            InitializeComponent();
        }

        private void disciplineEntryForm_Load(object sender, EventArgs e)
        {
            loadSchoolComboBox();
        }

        private void loadSchoolComboBox()
        {
            try
            {
                connection.OpenConection();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select school_name From school";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string schoolName = reader["school_name"].ToString();
                    comboBoxSchoolName.Items.Add(schoolName);
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void buttonDisciplineEntry_Click(object sender, EventArgs e)
        {

            if (textBoxDisciplineId.Text == null || textBoxDisciplineId.Text == "")
            {
                MessageBox.Show("Invalid Discipline Id");
                textBoxDisciplineId.Focus();
                return;
            }

            if (textBoxDisciplineName.Text == null || textBoxDisciplineName.Text == "")
            {
                MessageBox.Show("Invalid Discipline name");
                textBoxDisciplineName.Focus();
                return;
            }

            if (comboBoxSchoolName.Text == null || comboBoxSchoolName.Text == "")
            {
                MessageBox.Show("Invalid School name");
                comboBoxSchoolName.Focus();
                return;
            }

            connection.OpenConection();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select school_id from school where school_name = '" + school_name_form.ToString() + "'";
            int school_id = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            connection.OpenConection();
            cmd.CommandText = "insert into [discipline] (discipline_id,discipline_name,school_id) values ('" + textBoxDisciplineId.Text + "','" + textBoxDisciplineName.Text + "','" + school_id + "')";
            cmd.ExecuteNonQuery();
            connection.CloseConnection();
            MessageBox.Show("New Discipline Added");

            disciplineEntryForm def = new disciplineEntryForm();
            this.Close();
            def.Show();
        }

        private void comboBoxSchoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            school_name_form = comboBoxSchoolName.Text;
        }
    }
}
