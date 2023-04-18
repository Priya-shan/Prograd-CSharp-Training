using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text;
using Text_Editor.Data;
using Text_Editor.Models;

namespace Text_Editor.Controllers
{
    public class UserController : Controller
    {
        // GET: UserController
        readonly DocumentDBContext db;
        IConfiguration configuration;
        public SqlConnection conn;
        
        public UserController(DocumentDBContext dbContext, IConfiguration configuration)
        {
            db = dbContext;
            this.configuration = configuration;
            conn = new SqlConnection(configuration.GetConnectionString("Text_Editor"));
        }
        public List<DocumentsModel> getDocs()

        {
            string current_user_email = Request.Cookies["current_user_email"];
            List<DocumentsModel> docList = new List<DocumentsModel>();
            string conn_string = configuration.GetConnectionString("Text_Editor");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_string;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string query = $"select * from Documents where email='{current_user_email}' order by doc_id";
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DocumentsModel model = new DocumentsModel();
                model.doc_id = (int)reader["doc_id"];
                //model.email = (string)reader["email"];
                model.created_date = (DateTime)reader["created_date"];
                model.doc_title = (string)reader["doc_title"];
                model.last_edited = (DateTime)reader["last_edited"];
                docList.Add(model);
            }
            reader.Close();
            conn.Close();
            //appointmentList = db.AppointmentDetails.Where(x=>x.email==current_user_email).ToList();
            return docList;
        }
        public DocumentsModel getDocsById(int id)

        {
            DocumentsModel model = new DocumentsModel();
            string conn_string = configuration.GetConnectionString("Text_Editor");
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conn_string;
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            string query = $"select * from Documents where doc_id='{id}'";
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                model.doc_id = (int)reader["doc_id"];
                //model.email = (string)reader["email"];
                model.created_date = (DateTime)reader["created_date"];
                model.doc_title = (string)reader["doc_title"];
                model.last_edited = (DateTime)reader["last_edited"];
                model.doc_content = (string)reader["doc_content"];
            }
            reader.Close();
            conn.Close();
            //appointmentList = db.AppointmentDetails.Where(x=>x.email==current_user_email).ToList();
            return model;
        }
        public ActionResult Index()
        {
            return View(getDocs());
        }

        public ActionResult NewDoc()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewDoc(DocumentsModel model)
        {
            string current_user_email = Request.Cookies["current_user_email"];
            Console.WriteLine(model.doc_title);
            Console.WriteLine(model.doc_content);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("add_doc", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email", current_user_email);
                DateTime current_date = DateTime.Now;
                cmd.Parameters.AddWithValue("@created_date", current_date);
                cmd.Parameters.AddWithValue("@last_edited", current_date);
                cmd.Parameters.AddWithValue("@doc_title", model.doc_title);
                cmd.Parameters.AddWithValue("@doc_content", model.doc_content);
                
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("Index", "User");
        }
        public ActionResult Edit(int id)
        {
            return View(getDocsById(id));
        }

        [HttpPost]
        public ActionResult Edit(int id,DocumentsModel model)
        {
            string current_user_email = Request.Cookies["current_user_email"];
            Console.WriteLine(model.doc_title);
            Console.WriteLine(model.doc_content);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update_doc", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                DateTime current_date = DateTime.Now;
                cmd.Parameters.AddWithValue("@doc_id", id);
                cmd.Parameters.AddWithValue("@last_edited", current_date);
                cmd.Parameters.AddWithValue("@doc_title", model.doc_title);
                cmd.Parameters.AddWithValue("@doc_content", model.doc_content);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("Index", "User");
        }

        //Downloads file
        [HttpPost]
        public FileResult DownloadFile(IFormCollection form)
        {
            string title = form["doc_title"];
            string text = form["doc_content"]; // Replace this with the text you want to download
            byte[] byteArray = Encoding.ASCII.GetBytes(text);
            MemoryStream stream = new MemoryStream(byteArray);
            return File(stream, "text/plain", $"{title}.txt");
        }
    }
}
