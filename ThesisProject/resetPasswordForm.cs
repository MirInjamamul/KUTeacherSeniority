using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ThesisProject
{
    public partial class resetPasswordForm : Form
    {
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");

        connection connection = new connection();

        public resetPasswordForm()
        {
            InitializeComponent();
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

                if (master_password == userNameTxt.Text)
                    {
                        if(newPasswordTxt.Text == confirmPasswordTxt.Text){
                            connection.OpenConection();
                            cmd.CommandText = "UPDATE security SET password = '"+newPasswordTxt.Text+"' where username = 'a'";
                            cmd.ExecuteNonQuery();
                            connection.CloseConnection();
                            MessageBox.Show("Password has been reset");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Username");
                    }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void resetPasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
