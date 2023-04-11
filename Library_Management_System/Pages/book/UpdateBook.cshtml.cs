using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library_Management_System.Pages.book
{
    public class UpdateBookModel : PageModel
    {
        public static bool editMode = false;
        public static string book_id="" ;
        public void OnGet()
        {
            Console.WriteLine("in update get");
            book_id = Request.Query["BookCode"];
            editMode = true;
            Response.Redirect("IndexBook");
        }
    }
}
