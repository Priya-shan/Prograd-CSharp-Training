using Microsoft.AspNetCore.Mvc;

namespace Concurrency_Token.Controllers
{
    public class productController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
