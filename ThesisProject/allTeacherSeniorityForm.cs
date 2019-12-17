﻿using System;
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
    public partial class allTeacherSeniorityForm : Form
    {
        connection connection = new connection();
        SqlDataAdapter da;
        DataTable dt;

        string name = "";
        int[] activeCount = new int[500];
        int[] teacherCount = new int[500];
        int count = 0;
        public allTeacherSeniorityForm()
        {
            InitializeComponent();
        }

        private void allTeacherSeniorityForm_Load(object sender, EventArgs e)
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
            
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select COUNT(*)Id From info where designation = '1'";
            connection.OpenConection();
            int dataCount = (int) cmd.ExecuteScalar();
            connection.CloseConnection();

            if (dataCount>0)
            {
                try
                {

                    cmd = new SqlCommand();
                    da = new SqlDataAdapter();
                    dt = new DataTable();

                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '1' AND joining.teacher_id = info.Id AND joining.current_designation='1'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            DateTime seniority = (DateTime)reader["joining_date"];
                            int teacher_id = (int)reader["teacher_id"];
                            int current_leave = (int)reader["current_leave"];
                            int total_leave = (int)reader["total_leave"];

                            DateTime now = DateTime.Now;
                            int active = ((TimeSpan)(now - seniority)).Days;

                            activeCount[count] = active - current_leave - total_leave;
                            teacherCount[count] = teacher_id;
                            System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" + teacherCount[count]);

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
                    int i;
         /*           for (i = 0; i < teacherCount.Length; i++)
                    {

                        cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" + teacherCount[i] + "'";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }   */

                    int val = teacherCount.Length;

                    // traverse
                    int temp;
                    int temp1;
                    for (i = 0; i < val - 1; i++)
                    {
                        // traverse i+1 to array length 
                        for (int j = i + 1; j < val; j++)
                        {
                            // compare array element with  
                            // all next element 
                            if (activeCount[i] < activeCount[j])
                            {

                                temp = activeCount[i];
                                temp1 = teacherCount[i];

                                activeCount[i] = activeCount[j];
                                teacherCount[i] = teacherCount[j];

                                activeCount[j] = temp;
                                teacherCount[j] = temp1;
                            }
                            else if (activeCount[i] == activeCount[j])
                            {
                                if (teacherCount[i] == 0)
                                {
                                    break;

                                }
                                try
                                {

                                    if (teacherCount[j] == 0)
                                    {
                                        break;
                                    }
                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select date_of_birth From info where Id = '" + teacherCount[i] + "'";
                                    
                                    DateTime dt1 = (DateTime)cmd.ExecuteScalar();
                                    connection.CloseConnection();

                                    DateTime now = DateTime.Now;
                                    int active1 = ((TimeSpan)(now - dt1)).Days;

                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select date_of_birth From info where Id = '" + teacherCount[j] + "'";

                                    SqlDataReader reader = cmd.ExecuteReader();
                                    int active2 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt2 = (DateTime)reader["date_of_birth"];

                                        now = DateTime.Now;
                                        active2 = ((TimeSpan)(now - dt2)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();

                                    if (active1 < active2)
                                    {
                                        temp = activeCount[i];
                                        temp1 = teacherCount[i];

                                        activeCount[i] = activeCount[j];
                                        teacherCount[i] = teacherCount[j];

                                        activeCount[j] = temp;
                                        teacherCount[j] = temp1;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error " + ex);
                                }
                                //tiebreaker();
                            }
                        }
                    }
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    for (i = 0; i < val; i++)
                    {
                        int j = i + 1;

                        cmd.CommandText = "Insert into ranking(id,teacher_id,count) values ('" + j + "', '" + teacherCount[i] + "' , '" + activeCount[i] + "')";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }

                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    cmd.CommandText = "delete from ranking where teacher_id = '0'";

                    connection.OpenConection();
                    cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select name, discipline_name , joining_date From info,joining,discipline, ranking where joining.designation_id = '1' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND ranking.teacher_id = info.Id ORDER BY ranking.id ASC";

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        dataGridView6.DataSource = dt;
                        connection.CloseConnection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();

                        cmd.CommandText = "delete from ranking";

                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
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
            
        }

        private void tiebreaker()
        {
           
        }

        private void assistantProfessorSeniorityCheck()
        {

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select COUNT(*)Id From info where designation = '2'";
            connection.OpenConection();
            int dataCount = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            if (dataCount>0)
            {
                try
                {

                    cmd = new SqlCommand();
                    da = new SqlDataAdapter();
                    dt = new DataTable();

                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '2' AND joining.teacher_id = info.Id AND joining.current_designation='1'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            DateTime seniority = (DateTime)reader["joining_date"];
                            int teacher_id = (int)reader["teacher_id"];
                            int current_leave = (int)reader["current_leave"];
                            int total_leave = (int)reader["total_leave"];

                            DateTime now = DateTime.Now;
                            int active = ((TimeSpan)(now - seniority)).Days;

                            activeCount[count] = active - current_leave - total_leave;
                            teacherCount[count] = teacher_id;

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
                    int i;
           /*         for (i = 0; i < teacherCount.Length; i++)
                    {
                        cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" + teacherCount[i] + "' and joining.current_designation = '1'";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }  */

                    int val = teacherCount.Length;

                    // traverse
                    int temp;
                    int temp1;
                    for (i = 0; i < val - 1; i++)
                    {
                        // traverse i+1 to array length 
                        for (int j = i + 1; j < val; j++)
                        {
                            // compare array element with  
                            // all next element 
                            if (activeCount[i] < activeCount[j])
                            {

                                temp = activeCount[i];
                                temp1 = teacherCount[i];

                                activeCount[i] = activeCount[j];
                                teacherCount[i] = teacherCount[j];

                                activeCount[j] = temp;
                                teacherCount[j] = temp1;
                            }
                            else if (activeCount[i] == activeCount[j])
                            {
                                if (teacherCount[i] == 0)
                                {
                                    break;

                                }
                                try
                                {

                                    if (teacherCount[j] == 0)
                                    {
                                        break;
                                    }
                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select joining_date From joining where teacher_id = '" + teacherCount[i] + "' AND designation_id = '1'";

                                    SqlDataReader reader = cmd.ExecuteReader();
                                    int active1 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt1 = (DateTime)reader["joining_date"];

                                        DateTime now = DateTime.Now;
                                        active1 = ((TimeSpan)(now - dt1)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();
                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select joining_date From joining where teacher_id = '" + teacherCount[j] + "' AND designation_id = '1'";

                                    reader = cmd.ExecuteReader();
                                    int active2 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt2 = (DateTime)reader["joining_date"];

                                        DateTime now = DateTime.Now;
                                        active2 = ((TimeSpan)(now - dt2)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();

                                    if (active1 < active2)
                                    {
                                        temp = activeCount[i];
                                        temp1 = teacherCount[i];

                                        activeCount[i] = activeCount[j];
                                        teacherCount[i] = teacherCount[j];

                                        activeCount[j] = temp;
                                        teacherCount[j] = temp1;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error " + ex);
                                }
                                //tiebreaker();
                            }
                        }
                    }
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    for (i = 0; i < val; i++)
                    {
                        int j = i + 1;

                        cmd.CommandText = "Insert into ranking(id,teacher_id,count) values ('" + j + "', '" + teacherCount[i] + "' , '" + activeCount[i] + "')";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }

                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    cmd.CommandText = "delete from ranking where teacher_id = '0'";

                    connection.OpenConection();
                    cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                    name = "";
                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select name, discipline_name , joining_date From info,joining,discipline, ranking where joining.designation_id = '2' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND ranking.teacher_id = info.Id ORDER BY ranking.id ASC";

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        dataGridView5.DataSource = dt;
                        connection.CloseConnection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();

                        cmd.CommandText = "delete from ranking";

                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
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

            
        }

        private void assosciateProfessorSeniorityCheck()
        {

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select COUNT(*) From info where designation = '3'";
            connection.OpenConection();
            int dataCount = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            if (dataCount > 0)
            {
                try
                {

                    cmd = new SqlCommand();
                    da = new SqlDataAdapter();
                    dt = new DataTable();

                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '3' AND joining.teacher_id = info.Id AND joining.current_designation='1'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            DateTime seniority = (DateTime)reader["joining_date"];
                            int teacher_id = (int)reader["teacher_id"];
                            int current_leave = (int)reader["current_leave"];
                            int total_leave = (int)reader["total_leave"];

                            DateTime now = DateTime.Now;
                            int active = ((TimeSpan)(now - seniority)).Days;

                            activeCount[count] = active - current_leave - total_leave;
                            teacherCount[count] = teacher_id;
                            System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" + teacherCount[count]);

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
                    int i;
         /*           for (i = 0; i < teacherCount.Length; i++)
                    {
                        cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" + teacherCount[i] + "'";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }  */

                    int val = teacherCount.Length;

                    // traverse
                    int temp;
                    int temp1;
                    for (i = 0; i < val - 1; i++)
                    {
                        // traverse i+1 to array length 
                        for (int j = i + 1; j < val; j++)
                        {
                            // compare array element with  
                            // all next element 
                            if (activeCount[i] < activeCount[j])
                            {

                                temp = activeCount[i];
                                temp1 = teacherCount[i];

                                activeCount[i] = activeCount[j];
                                teacherCount[i] = teacherCount[j];

                                activeCount[j] = temp;
                                teacherCount[j] = temp1;
                            }
                            else if (activeCount[i] == activeCount[j])
                            {
                                if (teacherCount[i] == 0)
                                {
                                    break;

                                }
                                try
                                {

                                    if (teacherCount[j] == 0)
                                    {
                                        break;
                                    }

                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select joining_date From joining where teacher_id = '" + teacherCount[i] + "' AND designation_id = '2'";

                                    SqlDataReader reader = cmd.ExecuteReader();
                                    int active1 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt1 = (DateTime)reader["joining_date"];

                                        DateTime now = DateTime.Now;
                                        active1 = ((TimeSpan)(now - dt1)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();
                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select joining_date From joining where teacher_id = '" + teacherCount[j] + "' AND designation_id = '2'";

                                    reader = cmd.ExecuteReader();
                                    int active2 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt2 = (DateTime)reader["joining_date"];

                                        DateTime now = DateTime.Now;
                                        active2 = ((TimeSpan)(now - dt2)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();

                                    if (active1 < active2)
                                    {
                                        temp = activeCount[i];
                                        temp1 = teacherCount[i];

                                        activeCount[i] = activeCount[j];
                                        teacherCount[i] = teacherCount[j];

                                        activeCount[j] = temp;
                                        teacherCount[j] = temp1;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error " + ex);
                                }
                                //tiebreaker();
                            }
                        }
                    }
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    for (i = 0; i < val; i++)
                    {
                        int j = i + 1;

                        cmd.CommandText = "Insert into ranking(id,teacher_id,count) values ('" + j + "', '" + teacherCount[i] + "' , '" + activeCount[i] + "')";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }

                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    cmd.CommandText = "delete from ranking where teacher_id = '0'";

                    connection.OpenConection();
                    cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                    name = "";
                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select name, discipline_name , joining_date From info,joining,discipline, ranking where joining.designation_id = '3' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND ranking.teacher_id = info.Id ORDER BY ranking.id ASC";

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        dataGridView4.DataSource = dt;
                        connection.CloseConnection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();

                        cmd.CommandText = "delete from ranking";

                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
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

            
        }

        private void professorGradeThreeSeniorityCheck()
        {

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select COUNT(*)Id From info where designation = '4'";
            connection.OpenConection();
            int dataCount = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            if (dataCount > 0)
            {
                try
                {

                    cmd = new SqlCommand();
                    da = new SqlDataAdapter();
                    dt = new DataTable();


                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '4' AND joining.teacher_id = info.Id AND joining.current_designation='1'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            DateTime seniority = (DateTime)reader["joining_date"];
                            int teacher_id = (int)reader["teacher_id"];
                            int current_leave = (int)reader["current_leave"];
                            int total_leave = (int)reader["total_leave"];

                            DateTime now = DateTime.Now;
                            int active = ((TimeSpan)(now - seniority)).Days;

                            activeCount[count] = active - current_leave - total_leave;
                            teacherCount[count] = teacher_id;
                            System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" + teacherCount[count]);

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
                    int i;
          /*          for (i = 0; i < teacherCount.Length; i++)
                    {
                        Console.WriteLine("Updating");
                        cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" + teacherCount[i] + "'";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }   */

                    int val = teacherCount.Length;

                    // traverse
                    int temp;
                    int temp1;
                    for (i = 0; i < val - 1; i++)
                    {
                        // traverse i+1 to array length 
                        for (int j = i + 1; j < val; j++)
                        {
                            // compare array element with  
                            // all next element 
                            if (activeCount[i] < activeCount[j])
                            {

                                temp = activeCount[i];
                                temp1 = teacherCount[i];

                                activeCount[i] = activeCount[j];
                                teacherCount[i] = teacherCount[j];

                                activeCount[j] = temp;
                                teacherCount[j] = temp1;
                            }
                            else if (activeCount[i] == activeCount[j])
                            {
                                if (teacherCount[i] == 0)
                                {
                                    break;

                                }
                                try
                                {
                                    if (teacherCount[j] == 0)
                                    {
                                        break;
                                    }
                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select joining_date From joining where teacher_id = '" + teacherCount[i] + "' AND designation_id = '3'";

                                    SqlDataReader reader = cmd.ExecuteReader();
                                    int active1 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt1 = (DateTime)reader["joining_date"];

                                        DateTime now = DateTime.Now;
                                        active1 = ((TimeSpan)(now - dt1)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();
                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select joining_date From joining where teacher_id = '" + teacherCount[j] + "' AND designation_id = '3'";

                                    reader = cmd.ExecuteReader();
                                    int active2 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt2 = (DateTime)reader["joining_date"];

                                        DateTime now = DateTime.Now;
                                        active2 = ((TimeSpan)(now - dt2)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();

                                    if (active1 < active2)
                                    {
                                        temp = activeCount[i];
                                        temp1 = teacherCount[i];

                                        activeCount[i] = activeCount[j];
                                        teacherCount[i] = teacherCount[j];

                                        activeCount[j] = temp;
                                        teacherCount[j] = temp1;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error " + ex);
                                }
                                //tiebreaker();
                            }
                        }
                    }
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    for (i = 0; i < val; i++)
                    {
                        int j = i + 1;

                        cmd.CommandText = "Insert into ranking(id,teacher_id,count) values ('" + j + "', '" + teacherCount[i] + "' , '" + activeCount[i] + "')";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }

                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    cmd.CommandText = "delete from ranking where teacher_id = '0'";

                    connection.OpenConection();
                    cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                    name = "";
                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select name, discipline_name , joining_date From info,joining,discipline, ranking where joining.designation_id = '4' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND ranking.teacher_id = info.Id ORDER BY ranking.id ASC";

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        dataGridView3.DataSource = dt;
                        connection.CloseConnection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();

                        cmd.CommandText = "delete from ranking";

                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
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

            
        }

        private void professorGradeTwoSeniorityCheck()
        {

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select COUNT(*)Id From info where designation = '5'";
            connection.OpenConection();
            int dataCount = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            if (dataCount > 0)
            {

                try
                {
                    cmd = new SqlCommand();
                    da = new SqlDataAdapter();
                    dt = new DataTable();


                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '5' AND joining.teacher_id = info.Id AND joining.current_designation='1'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            DateTime seniority = (DateTime)reader["joining_date"];
                            int teacher_id = (int)reader["teacher_id"];
                            int current_leave = (int)reader["current_leave"];
                            int total_leave = (int)reader["total_leave"];

                            DateTime now = DateTime.Now;
                            int active = ((TimeSpan)(now - seniority)).Days;

                            activeCount[count] = active - current_leave - total_leave;
                            teacherCount[count] = teacher_id;

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

                    int i;
                    /*   for (i = 0; i < teacherCount.Length; i++)
                        {
                            Console.WriteLine("Updating");
                            cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" + teacherCount[i] + "'";
                            connection.OpenConection();
                            cmd.ExecuteNonQuery();
                            connection.CloseConnection();
                        } */

                    int val = teacherCount.Length;

                    // traverse
                    int temp;
                    int temp1;
                    for (i = 0; i < val - 1; i++)
                    {
                        // traverse i+1 to array length 
                        for (int j = i + 1; j < val; j++)
                        {
                            // compare array element with  
                            // all next element 
                            if (activeCount[i] < activeCount[j])
                            {

                                temp = activeCount[i];
                                temp1 = teacherCount[i];

                                activeCount[i] = activeCount[j];
                                teacherCount[i] = teacherCount[j];

                                activeCount[j] = temp;
                                teacherCount[j] = temp1;
                            }
                            else if (activeCount[i] == activeCount[j])
                            {
                                if (teacherCount[i] == 0)
                                {
                                    break;

                                }
                                try
                                {
                                    if (teacherCount[j] == 0)
                                    {
                                        break;
                                    }
                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select joining_date From joining where teacher_id = '" + teacherCount[i] + "' AND designation_id = '4'";

                                    SqlDataReader reader = cmd.ExecuteReader();
                                    int active1 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt1 = (DateTime)reader["joining_date"];

                                        DateTime now = DateTime.Now;
                                        active1 = ((TimeSpan)(now - dt1)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();
                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select joining_date From joining where teacher_id = '" + teacherCount[j] + "' AND designation_id = '4'";

                                    reader = cmd.ExecuteReader();
                                    int active2 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt2 = (DateTime)reader["joining_date"];

                                        DateTime now = DateTime.Now;
                                        active2 = ((TimeSpan)(now - dt2)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();

                                    if (active1 < active2)
                                    {
                                        temp = activeCount[i];
                                        temp1 = teacherCount[i];

                                        activeCount[i] = activeCount[j];
                                        teacherCount[i] = teacherCount[j];

                                        activeCount[j] = temp;
                                        teacherCount[j] = temp1;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error " + ex);
                                }
                                //tiebreaker();
                            }
                        }
                    }
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    for (i = 0; i < val; i++)
                    {
                        int j = i + 1;

                        cmd.CommandText = "Insert into ranking(id,teacher_id,count) values ('" + j + "', '" + teacherCount[i] + "' , '" + activeCount[i] + "')";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }

                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    cmd.CommandText = "delete from ranking where teacher_id = '0'";

                    connection.OpenConection();
                    cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                    name = "";
                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select name, discipline_name , joining_date From info,joining,discipline, ranking where joining.designation_id = '5' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND ranking.teacher_id = info.Id ORDER BY ranking.id ASC";

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        dataGridView2.DataSource = dt;
                        connection.CloseConnection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();

                        cmd.CommandText = "delete from ranking";

                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
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

        }

        private void professorGradeOneSeniorityCheck()
        {

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand();
            cmd = connection.CreateCommand();
            cmd.CommandText = "Select COUNT(*)Id From info where designation = '6'";
            connection.OpenConection();
            int dataCount = (int)cmd.ExecuteScalar();
            connection.CloseConnection();

            if (dataCount > 0)
            {
                try
                {

                    cmd = new SqlCommand();

                    da = new SqlDataAdapter();
                    dt = new DataTable();


                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select teacher_id,name,joining_date,current_leave,total_leave From info,joining where joining.designation_id = '6' AND joining.teacher_id = info.Id AND joining.current_designation='1'";

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            DateTime seniority = (DateTime)reader["joining_date"];
                            int teacher_id = (int)reader["teacher_id"];
                            int current_leave = (int)reader["current_leave"];
                            int total_leave = (int)reader["total_leave"];

                            DateTime now = DateTime.Now;
                            int active = ((TimeSpan)(now - seniority)).Days;

                            activeCount[count] = active - current_leave - total_leave;
                            teacherCount[count] = teacher_id;
                            System.Console.WriteLine("name : " + name + " Active : " + active + "teacher_id" + teacherCount[count]);

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


                    int i;
            /*        for (i = 0; i < teacherCount.Length; i++)
                    {
                        Console.WriteLine("Updating");
                        cmd.CommandText = "Update joining Set active = '" + activeCount[i] + "' Where teacher_id = '" + teacherCount[i] + "'";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }   */

                    int val = teacherCount.Length;

                    // traverse
                    int temp;
                    int temp1;
                    for (i = 0; i <  val - 1; i++)
                    {
                        // traverse i+1 to array length 
                        for (int j = i + 1; j < val; j++)
                        {
                            // compare array element with  
                            // all next element 
                            if (activeCount[i] < activeCount[j])
                            {

                                temp = activeCount[i];
                                temp1 = teacherCount[i];

                                activeCount[i] = activeCount[j];
                                teacherCount[i] = teacherCount[j];

                                activeCount[j] = temp;
                                teacherCount[j] = temp1;
                            }
                            else if (activeCount[i] == activeCount[j])
                            {
                                if (teacherCount[i] == 0)
                                {
                                    break;

                                }
                                try
                                {
                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select joining_date From joining where teacher_id = '" + teacherCount[i] + "' AND designation_id = '5'";

                                    SqlDataReader reader = cmd.ExecuteReader();
                                    int active1 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt1 = (DateTime)reader["joining_date"];

                                        DateTime now = DateTime.Now;
                                        active1 = ((TimeSpan)(now - dt1)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();
                                    connection.OpenConection();
                                    cmd = new SqlCommand();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "Select joining_date From joining where teacher_id = '" + teacherCount[j] + "' AND designation_id = '5'";

                                    reader = cmd.ExecuteReader();
                                    int active2 = 0;
                                    while (reader.Read())
                                    {
                                        DateTime dt2 = (DateTime)reader["joining_date"];

                                        DateTime now = DateTime.Now;
                                        active2 = ((TimeSpan)(now - dt2)).Days;

                                        count++;
                                    }
                                    connection.CloseConnection();

                                    if (active1 < active2)
                                    {
                                        temp = activeCount[i];
                                        temp1 = teacherCount[i];

                                        activeCount[i] = activeCount[j];
                                        teacherCount[i] = teacherCount[j];

                                        activeCount[j] = temp;
                                        teacherCount[j] = temp1;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error " + ex);
                                }
                                //tiebreaker();
                            }
                        }
                    }
                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    for (i = 0; i < val; i++)
                    {
                        int j = i + 1;

                        cmd.CommandText = "Insert into ranking(id,teacher_id,count) values ('" + j + "', '" + teacherCount[i] + "' , '" + activeCount[i] + "')";
                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
                        connection.CloseConnection();
                    }

                    cmd = new SqlCommand();
                    cmd = connection.CreateCommand();

                    cmd.CommandText = "delete from ranking where teacher_id = '0'";

                    connection.OpenConection();
                    cmd.ExecuteNonQuery();
                    connection.CloseConnection();

                    name = "";
                    try
                    {
                        connection.OpenConection();
                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "Select name, discipline_name , joining_date From info,joining,discipline, ranking where joining.designation_id = '6' AND joining.teacher_id = info.Id AND joining.current_designation='1' AND info.discipline = discipline.discipline_id AND ranking.teacher_id = info.Id ORDER BY ranking.id ASC";

                        da.SelectCommand = cmd;
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                        connection.CloseConnection();

                        cmd = new SqlCommand();
                        cmd = connection.CreateCommand();

                        cmd.CommandText = "delete from ranking";

                        connection.OpenConection();
                        cmd.ExecuteNonQuery();
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
}