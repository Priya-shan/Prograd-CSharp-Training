using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebApplication2.Pages.book
{
    public class CreateBookModel : PageModel
    {
        books book =new books();
        public string ErrorMessage = "";
        public string SuccessMessage = "";
        public bool ShowSuccessMsg = false;
        public void OnGet()
        {
            if(ShowSuccessMsg)
            SuccessMessage = "Book Added Successfully";
        }
        public void OnPost()
        {
            string conn_string = "Data Source=DESKTOP-KN3OCS1;Initial Catalog=Library_Management_System;Integrated Security=True;Encrypt=false";
            SqlConnection conn = new SqlConnection(conn_string);
            conn.Open();

            book.book_code = Request.Form["book_code"];
            book.book_title = Request.Form["book_title"];
            book.category = Request.Form["category"];
            book.author = Request.Form["author"];
            book.publication = Request.Form["publication"];
            //book.publish_date = Convert.ToDateTime(Request.Form["publish_date"]);
            book.price = Convert.ToDecimal(Request.Form["price"]);
            book.rem_quantity = Convert.ToInt32(Request.Form["rem_quantity"]);
            book.sold_quantity = Convert.ToInt32(Request.Form["sold_quantity"]);

            try
            {
                SuccessMessage = "";
                ErrorMessage = "";
                string query = $"insert into PS_lms_booklist values(" +
                $" '{book.book_code}', '{book.book_title}', '{book.category}', '{book.author}', '{book.publication}', " +
                $" {book.price},{book.rem_quantity},{book.sold_quantity});";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
                SuccessMessage = "Book Added Successfully !";
                
            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
