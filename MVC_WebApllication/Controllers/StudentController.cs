using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_WebApllication.Models;

namespace MVC_WebApllication.Controllers
{
    public class StudentController : Controller
    {
        public List<StudentModel> student_lst = new List<StudentModel>();
        IConfiguration configuration;
        public StudentController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IActionResult Index()
        {

            //ConfigurationManager manager = new ConfigurationManager();
            //string conn_string = "Data Source=DESKTOP-KN3OCS1;Initial Catalog=Practice_SQL;Integrated Security=True;Encrypt=False";
            //SqlConnection conn = new SqlConnection(conn_string);
            string conn_string = configuration.GetConnectionString("StudentDB");
            string conn_string2= configuration.GetConnectionString("libraryDB");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_string;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string query = "select * from StudentDetails1";
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                StudentModel sm = new StudentModel();
                sm.id = reader.GetInt32(0);
                sm.name = reader.GetString(1);
                sm.dept = reader.GetInt32(2);
                student_lst.Add(sm);
            }
            conn.Close();

            SqlConnection conn2 = new SqlConnection();
            conn.ConnectionString = conn_string2;
            conn.Open();
            SqlCommand cmd2 = conn.CreateCommand();
            string query2 = "select * from lms_book_details";
            cmd.CommandText = query2;
            SqlDataReader reader2 = cmd.ExecuteReader();

            while (reader2.Read())
            {
                StudentModel sm = new StudentModel();
                sm.id = 0;
                sm.name = reader2.GetString(1);
                sm.dept =0;
                student_lst.Add(sm);
            }
            conn.Close();
            return View(student_lst);
        }

        public IActionResult Student()
        {
            
            return View();
        }
    }
}
