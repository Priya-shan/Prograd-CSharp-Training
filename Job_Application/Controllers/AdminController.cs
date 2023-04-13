using Job_Application.Data;
using Job_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Job_Application.Controllers
{
    public class AdminController : Controller
    {
        public List<JobDetails> jobList = new List<JobDetails>();
        public static int job_id_to_edit = -1;

        
        readonly ApplicationDBContext db;
        public AdminController(ApplicationDBContext dbContext)
        {
            db = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            Console.WriteLine("in index get");
            string operationMode = Request.Query["opnMode"];
            string job_id_to_delete = Request.Query["JobId"];
            try
            {
                if (operationMode != null && operationMode.Equals("delete"))
                {
                    Console.WriteLine("entered delete mode");
                    var temp = await db.Jobs.FindAsync(Convert.ToInt32(job_id_to_delete));
                    db.Jobs.Remove(temp);
                    await db.SaveChangesAsync();
                }
                if(operationMode != null && operationMode.Equals("cancel"))
                {
                    Console.WriteLine("entered cancel mode");
                    job_id_to_edit = -1;
                }
                jobList = await db.Jobs.ToListAsync();
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            ViewBag.job_id_to_edit = job_id_to_edit;
            ViewBag.job_list = jobList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("job_id", "job_name", "job_category", "job_desc", "salary", "company_name")] JobDetails jobdet)
        {
            Console.WriteLine("in index post");
            db.Update(jobdet);
            await db.SaveChangesAsync();
            job_id_to_edit = -1;
            ViewBag.job_list = jobList;
            ViewBag.job_id_to_edit = job_id_to_edit;
            Response.Redirect("Index");
            return View();
        }
        
        public IActionResult AddJob()
        {
            Console.WriteLine("in add get");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddJob([Bind("job_id", "job_name", "job_category", "job_desc", "salary", "company_name")] JobDetails jobdet)
        {
            Console.WriteLine("in add post");
            db.Add(jobdet);
            await db.SaveChangesAsync();
            Response.Redirect("Index");
            return View();
        }
        
        public IActionResult UpdateJob()
        {
            Console.WriteLine("in update get");
            job_id_to_edit = Convert.ToInt32(Request.Query["JobId"]);
            Console.WriteLine(job_id_to_edit);
            Response.Redirect("/Admin/Index");
            return View();
        }

    }

}
