using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApi.Models;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IConfiguration _configuration;
        public SqlConnection conn;
        public BookController(IConfiguration configuration)
        {
            _configuration = configuration;
            conn = new SqlConnection(_configuration.GetConnectionString("libraryDB"));
        }
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetBooks()
        {
            List<BookDetailsModel> booksList = new List<BookDetailsModel>();
            try
            {
                conn.Open();
                string query = "select * from PS_lms_booklist";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                { 
                    BookDetailsModel book = new BookDetailsModel();
                    book.book_code = Reader.GetString(0);
                    book.book_title = Reader.GetString(1);
                    book.category = Reader.GetString(2);
                    book.author = Reader.GetString(3);
                    book.publication = (string)Reader["publication"];
                    book.price = (double)Reader["price"];
                    book.rem_quantity = (int)Reader["rem_quantity"];
                    book.sold_quantity = (int)Reader["sold_quantity"];
                    booksList.Add(book);
                }
                conn.Close();
                return Ok(booksList);
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            return Ok(booksList);   
        }
        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            BookDetailsModel book = new BookDetailsModel();
            try
            {
                conn.Open();
                string query = $"select * from PS_lms_booklist where book_code = '{id}' " ;
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    book.book_code = Reader.GetString(0);
                    book.book_title = Reader.GetString(1);
                    book.category = Reader.GetString(2);
                    book.author = Reader.GetString(3);
                    book.publication = (string)Reader["publication"];
                    book.price = (double)Reader["price"];
                    book.rem_quantity = (int)Reader["rem_quantity"];
                    book.sold_quantity = (int)Reader["sold_quantity"];
                   
                }
                conn.Close();
                if (book.book_code == null)
                {
                    //Response.StatusCode = StatusCodes.Status204NoContent;
                    return NoContent();
                }
                return Ok(book);
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
                return NotFound();
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post(BookDetailsModel book)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("add_PS_book", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@book_code", book.book_code);
                cmd.Parameters.AddWithValue("@book_title", book.book_title);
                cmd.Parameters.AddWithValue("@category", book.category);
                cmd.Parameters.AddWithValue("@author", book.author);
                cmd.Parameters.AddWithValue("@publication", book.publication);
                cmd.Parameters.AddWithValue("@price", book.price);
                cmd.Parameters.AddWithValue("@rem_quantity", book.rem_quantity);
                cmd.Parameters.AddWithValue("@sold_quantity", book.sold_quantity);

                cmd.ExecuteNonQuery();

                conn.Close();
                return Ok(new
                {
                    status = true,
                    message = "book added"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, string book_title,string category,string author,string publication,double price,
            int rem_quantity,int sold_quantity)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update_PS_book", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@book_code", id);
                cmd.Parameters.AddWithValue("@book_title", book_title);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@publication", publication);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@rem_quantity", rem_quantity);
                cmd.Parameters.AddWithValue("@sold_quantity", sold_quantity);

                cmd.ExecuteNonQuery();

                conn.Close();
                return Ok(new
                {
                    status = true,
                    message = "book updated"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete_PS_book", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
               
                cmd.ExecuteNonQuery();

                conn.Close();
                return Ok(new
                {
                    status = true,
                    message = "book deleted"
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Ok();
        }
    }
}
