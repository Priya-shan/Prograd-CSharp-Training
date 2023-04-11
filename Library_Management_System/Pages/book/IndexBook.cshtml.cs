using Library_Management_System.Pages.book;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApplication2.Pages.book
{
    public class IndexModel : PageModel
    {
        public List<books> booksList = new List<books>();
        //public static string str = "stat";
        public string status = "normal";
        public bool editMode = false;
        public string book_id = "";
        public string operationMode = "";
        public void OnGet()
        {
            string conn_string = "Data Source=DESKTOP-KN3OCS1;Initial Catalog=Library_Management_System;Integrated Security=True;Encrypt=false";
            Console.WriteLine("get");
            operationMode = Request.Query["opnMode"];
            Console.WriteLine("operationMode :" + operationMode);
            string book_id_to_delete = Request.Query["BookCode"];
            Console.WriteLine("book_id :" + book_id);
            try
            {
                if (operationMode != null && operationMode.Equals("delete"))
                {
                    SqlConnection conn1 = new SqlConnection(conn_string);
                    conn1.Open();
                    string query1 = $"delete from PS_lms_booklist where book_code='{book_id_to_delete}'";
                    SqlCommand cmd1 = new SqlCommand(query1, conn1);
                    cmd1.ExecuteNonQuery();
                    conn1.Close();
                }
                if (UpdateBookModel.editMode)
                {
                    Console.WriteLine("entered edit mode");
                    editMode = true;
                    book_id = UpdateBookModel.book_id;
                    UpdateBookModel.editMode = false;
                    Console.WriteLine("book_code: " + UpdateBookModel.book_id);
                }
                //else
                //{
                //    Console.WriteLine("entered normal mode");
                //}

                SqlConnection conn = new SqlConnection(conn_string);
                conn.Open();
                string query = "select * from PS_lms_booklist";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    books book = new books();
                    book.book_code = Reader.GetString(0);
                    book.book_title = Reader.GetString(1);
                    book.category = Reader.GetString(2);
                    book.author = Reader.GetString(3);
                    book.publication = (string)Reader["publication"];
                    book.price = (decimal)Reader["price"];
                    book.rem_quantity = (int)Reader["rem_quantity"];
                    book.sold_quantity = (int)Reader["sold_quantity"];
                    booksList.Add(book);
                }
                conn.Close();
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
        }
        public void OnPost()
        {
            Console.WriteLine("entered index post");
            string conn_string = "Data Source=DESKTOP-KN3OCS1;Initial Catalog=Library_Management_System;Integrated Security=True;Encrypt=false";
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();
            string updated_code = Request.Form["book_code"];
            string updated_title = Request.Form["book_titlee"];
            string updated_category= Request.Form["book_category"];
            string updated_author = Request.Form["book_author"];
            string updated_publication = Request.Form["book_publication"];
            string updated_price = Request.Form["book_price"];
            string updated_rem_quantity = Request.Form["book_rem_quantity"];
            string updated_sold_quantity = Request.Form["book_sold_quantity"];


            Console.WriteLine("updated_title :" + updated_title);
            Console.WriteLine("book id :" + updated_code);
            string query = $"update PS_lms_booklist set " +
                $"book_title='{updated_title}',category='{updated_category}',author='{updated_author}'," +
                $"publication='{updated_publication}',price={updated_price},rem_quantity={updated_rem_quantity}," +
                $" sold_quantity={updated_sold_quantity} where book_code='{updated_code}'";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.ExecuteNonQuery();
            conn.Close();
            OnGet();

        }
    }
    public class books
    {
        public string book_code { get; set; }
        public string book_title { get; set; }
        public string category { get; set; }
        public string author { get; set; }
        public string publication { get; set; }

        //public DateTime publish_date { get; set; }

        public decimal price { get; set; }

        public int rem_quantity { get; set; }

        public int sold_quantity { get; set; }

    }
}
