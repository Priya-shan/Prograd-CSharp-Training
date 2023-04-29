using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;

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

        //public List<BookModel> GetBooks()
        //{
        //    List<BookModel> book_list = new List<BookModel>();
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("fetch_book_details", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        BookModel book = new BookModel();
        //        //book.book_code = Convert.ToInt32(reader["book_code"]);
        //        book.book_title = (string)reader["book_title"];
        //        book.category = (string)reader["category"];
        //        book.author = (string)reader["author"];
        //        book_list.Add(book);
        //    }
        //    reader.Close();
        //    conn.Close();
        //    return book_list;
        //}

        //public BookModel getMovieWithId(int id)
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("fetch_book_withId", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@id", id);

        //    SqlDataReader reader = cmd.ExecuteReader();

        //    BookModel book = new();

        //    while (reader.Read())
        //    {
        //        //book.book_code = (int)reader["book_code"];
        //        book.book_title = (string)reader["book_title"];
        //        book.category = (string)reader["category"];
        //        book.author = (string)reader["author"];
        //    }
        //    return book;
        //}
        //void InsertBook(BookModel Book)
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("add_book", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@book_code",Book.book_code );
        //    cmd.Parameters.AddWithValue("@book_title",Book.book_title);
        //    cmd.Parameters.AddWithValue("@category", Book.category);
        //    cmd.Parameters.AddWithValue("@author",Book.author);

        //    cmd.ExecuteNonQuery();

        //    conn.Close();

        //}
        //public void UpdateBook(int id,BookModel Book)
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("edit_book_withID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@book_code", Book.book_code);
        //    cmd.Parameters.AddWithValue("@book_title", Book.book_title);
        //    cmd.Parameters.AddWithValue("@category", Book.category);
        //    cmd.Parameters.AddWithValue("@author", Book.author);

        //    cmd.ExecuteNonQuery();

        //    conn.Close();
        //}
        // GET: BookDetailsController
        public async Task<ActionResult> Index()
        {
            string Baseurl = "https://localhost:7259/";
            List<BookModel1> EmpInfo = new List<BookModel1>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Book/");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    Console.Write("res  " + EmpResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmpInfo = JsonConvert.DeserializeObject<List<BookModel1>>(EmpResponse);
                }
                foreach (var item in EmpInfo)
                {
                }
                //returning the employee list to view
                //return View(EmpInfo);

                return View(EmpInfo);
            }
        }

        // GET: BookDetailsController/Details/5
        public async Task<ActionResult> details(int id)
        {

            string Baseurl = "https://localhost:7259/";
            BookModel1 model = new BookModel1();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync($"api/Book/{id}");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    Console.Write("res  " + EmpResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list
                    model = JsonConvert.DeserializeObject<BookModel1>(EmpResponse);
                }
                //returning the employee list to view
                //return View(EmpInfo);

                return View(model);
            }
        }

        //// GET: BookDetailsController/Create
        //public ActionResult Create()
        //{

        //    return View();
        //}

        //// POST: BookDetailsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(BookModel Book)
        //{
        //    try
        //    {
        //        InsertBook(Book);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return View();
        //    }
        //}

        //// GET: BookDetailsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View(getMovieWithId(id));
        //}

        //// POST: BookDetailsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, BookModel Book)
        //{
        //    try
        //    {
        //        Console.WriteLine("edit post");
        //        UpdateBook(id, Book);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BookDetailsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string Baseurl = "https://localhost:7259/";
            BookModel1 model = new BookModel1();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync($"api/Book/{id}");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    Console.Write("res  " + EmpResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list
                    model = JsonConvert.DeserializeObject<BookModel1>(EmpResponse);
                }
                //returning the employee list to view
                //return View(EmpInfo);

                return View(model);
            }
        }

        //public void deleteWithId(int id)
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("delete_book_withId", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@id", id);

        //    cmd.ExecuteNonQuery();

        //    conn.Close();
        //}

        // POST: BookDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            string Baseurl = "https://localhost:7259/";
            BookModel1 model = new BookModel1();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.DeleteAsync($"api/Book/{id}");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    Console.Write("res  " + EmpResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list
                    model = JsonConvert.DeserializeObject<BookModel1>(EmpResponse);
                }
                //returning the employee list to view
                //return View(EmpInfo);

                return RedirectToAction("Index");
            }
        }
    }
        public class BookModel1
        {
            public string book_code { get; set; }

            public string book_title { get; set; }
            public string category { get; set; }
            public string author { get; set; }
            public string publication { get; set; }

            public double price { get; set; }
            public int rem_quantity { get; set; }

            public int sold_quantity { get; set; }
        }
    }