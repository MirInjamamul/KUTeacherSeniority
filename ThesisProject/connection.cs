using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThesisProject
{
    class connection
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LATECH-001\Desktop\ThesisProject\database.mdf;Integrated Security=True;Connect Timeout=30");

        public void OpenConection()
        {
            con.Open();
        }


        public void CloseConnection()
        {
            con.Close();
        }

       /* public SqlCommand CreateCommand()
        {
            throw new NotImplementedException();
        } */

       public SqlCommand CreateCommand()
       {
           return con.CreateCommand();
       }

    }
}
