using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MVC_WebApplication_Sample.Models;
using System.Data;

namespace MVC_WebApplication_Sample.Controllers
{
    public class BookDetailsController : Controller
    {
        IConfiguration _configuration;
        public SqlConnection conn;
        public BookDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
            conn = new SqlConnection(_configuration.GetConnectionString("libraryDB"));
        }
         
        public List<BookModel> GetBooks()
        {
            List<BookModel> book_list = new List<BookModel>();
            conn.Open();
            SqlCommand cmd = new SqlCommand("fetch_book_details", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BookModel book = new BookModel();
                book.book_code = (int)reader["book_code"];
                book.book_title = (string)reader["book_title"];
                book.category = (string)reader["category"];
                book.author = (string)reader["author"];
                book_list.Add(book);
            }
            reader.Close();
            conn.Close();
            return book_list;
        }

        public BookModel getMovieWithId(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("fetch_book_withId", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            BookModel book = new();

            while (reader.Read())
            {
                book.book_code = (int)reader["book_code"];
                book.book_title = (string)reader["book_title"];
                book.category = (string)reader["category"];
                book.author = (string)reader["author"];
            }
            return book;
        }
        void InsertBook(BookModel Book)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("add_book", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@book_code",Book.book_code );
            cmd.Parameters.AddWithValue("@book_title",Book.book_title);
            cmd.Parameters.AddWithValue("@category", Book.category);
            cmd.Parameters.AddWithValue("@author",Book.author);

            cmd.ExecuteNonQuery();

            conn.Close();

        }
        public void UpdateBook(int id,BookModel Book)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("edit_book_withID", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@book_code", Book.book_code);
            cmd.Parameters.AddWithValue("@book_title", Book.book_title);
            cmd.Parameters.AddWithValue("@category", Book.category);
            cmd.Parameters.AddWithValue("@author", Book.author);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        // GET: BookDetailsController
        public ActionResult Index()
        {
            return View(GetBooks());
        }

        // GET: BookDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View(getMovieWithId(id));
        }

        // GET: BookDetailsController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: BookDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookModel Book)
        {
            try
            {
                InsertBook(Book);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return View();
            }
        }

        // GET: BookDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(getMovieWithId(id));
        }

        // POST: BookDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookModel Book)
        {
            try
            {
                Console.WriteLine("edit post");
                UpdateBook(id, Book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(getMovieWithId(id));
        }

        public void deleteWithId(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete_book_withId", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        // POST: BookDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteWithId(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
