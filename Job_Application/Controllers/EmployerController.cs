using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Job_Application.Controllers
{
    public class EmployerController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
       
    }
}
