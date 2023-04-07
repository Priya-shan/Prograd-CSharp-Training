using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Data;

namespace Database_Connectivity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conn_string = "Data Source=DESKTOP-KN3OCS1;Initial Catalog=Practice_SQL;Integrated Security=True;Encrypt=False";
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();

            // ****************************SELECT & WHERE QUERIES****************************

            //string query = "SELECT * FROM StudentDetails where age=22";
            //cmd.CommandText = query;
            //ArrayList lst=new ArrayList();
            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.Write(reader.GetInt32(0) + "\t");
            //    Console.Write(reader.GetString(1) + "\t");
            //    Console.Write(reader.GetInt32(2) + "\t");
            //    Console.Write(reader.GetDateTime(3).ToShortDateString()+ "\t");
            //    Console.Write(reader.GetInt32(4) + "\t");
            //    Console.Write(reader.GetString(5) + "\t");

            //    Console.WriteLine();
            //}
            // ****************************SELECT & WHERE QUERIES without typecast****************************
            //while (reader.Read())
            //{
            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        Console.Write(reader[i] + " ");
            //    }
            //    Console.WriteLine();

            //}
            // **************************** Insert Command using Parameters ****************************
            //string query = "INSERT INTO StudentDetails(studID,name,deptid,dob,age,email) VALUES(@id,@name,@deptid,@dob,@age,@email)";
            //Console.Write("enter id"+" ");
            //int id=Convert.ToInt32(Console.ReadLine());
            //Console.Write("enter name" + " ");
            //string name = Console.ReadLine();
            //Console.Write("enter deptid" + " ");
            //int deptid = Convert.ToInt32(Console.ReadLine());
            //Console.Write("enter dob" + " ");
            //string dob = Console.ReadLine();
            //Console.Write("enter age" + " ");
            //int age = Convert.ToInt32(Console.ReadLine());
            //Console.Write("enter email" + " ");
            //string email = Console.ReadLine();

            //cmd.Parameters.AddWithValue("@id", id);
            //cmd.Parameters.AddWithValue("@name", name);
            //cmd.Parameters.AddWithValue("@deptid", deptid);
            //cmd.Parameters.AddWithValue("@dob", dob);
            //cmd.Parameters.AddWithValue("@age", age);
            //cmd.Parameters.AddWithValue("@email", email);
            //cmd.CommandText = query;
            //cmd.ExecuteNonQuery();

            // direct insert with value
            //string query = "INSERT INTO StudentDetails(studID,name,deptid,dob,age,email) VALUES(200,'krithi',510,'2002-04-9',14,'krithi@gmail.com')";
            //cmd.Parameters.AddWithValue("@id", "200");
            //cmd.Parameters.AddWithValue("@name", "krithi");
            //cmd.Parameters.AddWithValue("@deptid", "510");
            //cmd.Parameters.AddWithValue("@dob", "2002-04-20");
            //cmd.Parameters.AddWithValue("@age", "14");
            //cmd.Parameters.AddWithValue("@email", "krithi@gmail.com");
            //cmd.CommandText = query;
            //cmd.ExecuteNonQuery();
            // deleting
            //try
            //{
            //    Console.Write("enter id" + " ");
            //    int id = Convert.ToInt32(Console.ReadLine());

            //    string query = $"delete from StudentDetails where studIDd={id}";
            //    cmd.CommandText = query;
            //    cmd.ExecuteReader();
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message.ToString());
            //}

            //Console.Write("enter dept id to which we have to change to null ");
            //int deptid=Convert.ToInt32(Console.ReadLine());
            //string query = $"update StudentDetails set deptid=000 where deptid={deptid}";
            //cmd.CommandText = query;
            //cmd.ExecuteReader();

            //string query = "exec callInsertProcedure 999,'shannn',502";
            //int id = 999;
            //int deptid = 501;
            //string name = "shann";
            //using(SqlCommand command=new SqlCommand("callInsertProcedure", conn))
            //{
            //    command.CommandType = System.Data.CommandType.StoredProcedure;
            //    command.Parameters.Add("id", SqlDbType.Int).Value = 909;
            //    command.Parameters.Add("name", SqlDbType.VarChar).Value = "priyaaaa";
            //    command.Parameters.Add("dept", SqlDbType.Int).Value = 505;
            //    command.ExecuteReader();
            //}


            //using (SqlCommand command = conn.CreateCommand())
            //{
            //    command.CommandText = "select * from dbo.fetchStudent(@dept_id)";
            //    command.Parameters.Add(new SqlParameter("@dept_id", 504));
            //    SqlDataReader rd = command.ExecuteReader();
            //    while (rd.Read())
            //    {
            //        Console.WriteLine(rd[0]);
            //    }
            //}


            conn.Close();

        }
    }
}

//ananth code

//using (SqlCommand cmd = conn.CreateCommand())
//{
//    cmd.CommandText = "select * from dbo.GetDobById(@name)";

//    cmd.Parameters.Add(new SqlParameter("@name", "John Doe"));

//    SqlDataReader reader = cmd.ExecuteReader();

//    DataTable dt = new DataTable();
//    dt.Load(reader);
//    Console.Write($" {dt.Rows[0][0]} - {dt.Rows[0][1]} - {dt.Rows[0][2]} ");

//}
