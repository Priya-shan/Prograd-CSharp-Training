using Microsoft.AspNetCore.Mvc;

namespace MVC_WebApllication.Controllers
{
    public class NewController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}
