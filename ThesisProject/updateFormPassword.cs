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
    public partial class updateFormPassword : Form
    {
        connection connection = new connection();

        public updateFormPassword()
        {
            InitializeComponent();
        }

        private void updateFormPassword_Load(object sender, EventArgs e)
        {

        }

        private void updatePasswordBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.OpenConection();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select password From security Where username = 'master'";

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                string master_password = reader["password"].ToString();
                connection.CloseConnection();

                if (master_password == masterPassword.Text)
                {
                    teacherUpdate tu = new teacherUpdate();
                    this.Close();
                    tu.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
    }
}
