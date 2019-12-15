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
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = connection.CreateCommand();
                cmd.CommandText = "Select username,password From security";

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    string username = reader["username"].ToString();
                    string password = reader["password"].ToString();

                    if (username == userNameTxt.Text && password == passwordTxt.Text)
                    {
                        Dashboard dashBoardForm = new Dashboard();
                        dashBoardForm.Show();
                        break;
                    }
                    else {
                        MessageBox.Show("Wrong Username and Password");
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            resetPasswordForm resetPasswordForm = new resetPasswordForm();
            resetPasswordForm.Show();
        }
    }
}
