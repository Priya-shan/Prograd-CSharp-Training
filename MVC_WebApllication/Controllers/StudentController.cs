using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_WebApllication.Models;

namespace MVC_WebApllication.Controllers
{
    public class StudentController : Controller
    {
        public List<StudentModel> student_lst = new List<StudentModel>();
        public IActionResult Index()
        {
            
            string conn_string = "Data Source=DESKTOP-KN3OCS1;Initial Catalog=Practice_SQL;Integrated Security=True;Encrypt=False";
            SqlConnection conn = new SqlConnection(conn_string);
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
            return View(student_lst);
        }

        public IActionResult Student()
        {
            
            return View();
        }
    }
}
