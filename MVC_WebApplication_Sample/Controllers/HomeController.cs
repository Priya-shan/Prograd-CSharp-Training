using Microsoft.AspNetCore.Mvc;
using MVC_WebApplication_Sample.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace MVC_WebApplication_Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            string Baseurl = "https://localhost:7259/";
            List<BookModel> EmpInfo = new List<BookModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/Book");
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    Console.Write("res  " + EmpResponse);
                    //Deserializing the response recieved from web api and storing into the Employee list
                    EmpInfo = JsonConvert.DeserializeObject<List<BookModel>>(EmpResponse);
                }
                foreach(var item in EmpInfo)
                {
                    Console.WriteLine(item.author);
                }
                //returning the employee list to view
                //return View(EmpInfo);

                return View();
            }
        }

        public async Task<IActionResult> Privacy()
        {
            BookModel model = new BookModel();
            model.book_code = "a";
            model.book_title = "title";
            model.category = "cat";
            model.author = "auth-priya";
            model.publication = "pub";
            model.price = 123;
            model.rem_quantity = 0;
            model.sold_quantity = 10;

            string Baseurl = "https://localhost:7259/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //var json = JsonConvert.SerializeObject(model, Formatting.Indented);

                //var stringContent = new StringContent(json);

                var Res = await client.PostAsJsonAsync<BookModel>("api/Book", model);
                if (Res.IsSuccessStatusCode)
                {

                    Console.Write("res  success");

                }
                else
                {
                    Console.Write("res  failed");
                }
                //returning the employee list to view
                //return View(EmpInfo);

                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class BookModel
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