using Job_Application.Data;
using Job_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Job_Application.Controllers
{
    public class JobSeekerController : Controller
    {
        public List<JobDetails> jobList = new List<JobDetails>();
        readonly ApplicationDBContext db;
        public JobSeekerController(ApplicationDBContext dbContext)
        {
            db = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            jobList = await db.Jobs.ToListAsync();
            ViewBag.job_list = jobList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection collection)
        {
            string formname= collection["form_name"];
            Console.WriteLine("formname :"+formname);
            if (formname.Equals("job_search_form"))
            {
                string keyword = collection["search_by_job_input"];
                jobList = await db.Jobs.Where(x=>x.job_name.Contains(keyword)).ToListAsync();
            }
            else if(formname.Equals("salary_search_form"))
            {
                double min_value = Convert.ToDouble(collection["search_by_salary_min_input"]);
                double max_value = Convert.ToDouble(collection["search_by_salary_max_input"]);
                Console.WriteLine(min_value+" "+max_value); 
                jobList=await db.Jobs.Where(x=> x.salary>=min_value && x.salary<=max_value).ToListAsync();
            }
            else
            {
                string keyword = collection["search_by_company_input"];
                jobList = await db.Jobs.Where(x => x.company_name == keyword).ToListAsync();
            }
            ViewBag.job_list=jobList;
            return View();
        }
    }
}
