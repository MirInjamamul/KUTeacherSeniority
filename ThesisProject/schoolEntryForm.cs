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
    public partial class schoolEntryForm : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");

        public schoolEntryForm()
        {
            InitializeComponent();
        }

        private void buttonSchoolEntry_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [school] (school_id,school_name) values ('" + textBoxSchoolId.Text + "','" + textBoxSchoolName.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("New School Added");
        }
    }
}
