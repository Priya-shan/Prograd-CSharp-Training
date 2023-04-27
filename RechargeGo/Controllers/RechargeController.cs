using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RechargeGo.Data;
using RechargeGo.Models;

namespace RechargeGo.Controllers
{
    public class RechargeController : Controller
    {
        private readonly AppDbContext db;
        private static string name;
        private static string mobile_no;
        private static string operator_name;
        private static int plan_id;
        public RechargeController(AppDbContext context)
        {
            db = context;
        }

        public IActionResult Startup()
        {
            var operators = db.PlansInfo.Select(o => o.operator_name).Distinct().ToList();
            Console.WriteLine("*****");
            foreach (var item in operators)
            {
                Console.WriteLine(item);
            }
            ViewBag.OperatorNames = operators;
            ViewBag.disableAddPlan = "true";
            return View();
        }
        public IActionResult ShowPlans()
        {
            var plansList = db.PlansInfo.Select(o => o.category).Distinct().ToList();
            ViewBag.PlanNames = plansList;
            List<string> plans = new List<string>();
            foreach (string item in plansList)
            {
                plans.Add(item);
            }
            Dictionary<string, List<PlansModel>> plansDictionary = new Dictionary<string, List<PlansModel>>();

            foreach (string item in plans)
            {
                var list = db.PlansInfo.ToList().Where(x => x.operator_name == operator_name && x.category == item);
                List<PlansModel> lst = new List<PlansModel>();
                foreach (var x in list)
                {
                    PlansModel mod = new PlansModel();
                    mod.category = x.category;
                    mod.plan_id = x.plan_id;
                    mod.data = x.data;
                    mod.amount = x.amount;
                    mod.operator_name = x.operator_name;
                    mod.validity = x.validity;
                    lst.Add(mod);
                }
                plansDictionary.Add(item.Replace(" ", ""), lst);
            }
            ViewBag.PlansDictionary = plansDictionary;
            return View();
        }
        [HttpPost]
        public IActionResult ShowPlans(IFormCollection form)
        {
            name = form["name"];
            mobile_no = form["mobile-number"];
            operator_name = form["operator"];
            var plansList = db.PlansInfo.Select(o => o.category).Distinct().ToList();
            ViewBag.PlanNames = plansList;
            List<string> plans= new List<string>();
            foreach (string item in plansList)
            {
                plans.Add(item);
            }
            Dictionary<string, List<PlansModel>> plansDictionary = new Dictionary<string, List<PlansModel>>();

            foreach (string item in plans)
            {
                Console.WriteLine("**" + item);
                var list = db.PlansInfo.ToList().Where(x => x.operator_name == operator_name && x.category == item);
                List<PlansModel> lst = new List<PlansModel>();
                foreach (var x in list)
                {
                    PlansModel mod = new PlansModel();
                    mod.category = x.category;
                    mod.plan_id = x.plan_id;
                    mod.data = x.data;
                    mod.amount=x.amount;
                    mod.operator_name=x.operator_name;
                    mod.validity = x.validity;
                    lst.Add(mod);
                }
                plansDictionary.Add(item.Replace(" ", ""),lst);
            }
            //foreach (KeyValuePair<string, List<PlansModel>> kvp in plansDictionary)
            //{
            //    Console.WriteLine(kvp.Key);
            //    Console.WriteLine("before enetering kvp value");
            //    Console.WriteLine(kvp.Value.Count);
            //    foreach (var val in kvp.Value)
            //    {
            //        Console.WriteLine("enetering kvp value");
            //        Console.WriteLine("plan_id :"+val.plan_id);
            //        Console.WriteLine("data :" + val.data);
            //    }
            //}
            ViewBag.PlansDictionary = plansDictionary;
            return View();
        }
        public IActionResult PaymentDone()
        {
            var plan_model = db.PlansInfo.FirstOrDefault(x => x.plan_id == plan_id);
            RechargeModel model = new RechargeModel
            {
                customer_name = name,
                mobile_number = mobile_no,
                amount = plan_model.amount,
                date = DateTime.Now,
                plan_id = plan_id,
                transact_status = "Completed"
            };
            db.RechargeInfo.Add(model);
            db.SaveChanges();
            name = "";
            mobile_no = "";
            operator_name = "";
            plan_id = 0;
            return RedirectToAction("Startup");
        }
        public IActionResult PaymentFailed()
        {
            var plan_model = db.PlansInfo.FirstOrDefault(x => x.plan_id == plan_id);
            RechargeModel model = new RechargeModel
            {
                customer_name = name,
                mobile_number = mobile_no,
                amount = plan_model.amount,
                date = DateTime.Now,
                plan_id = plan_id,
                transact_status = "Failed"
            };
            db.RechargeInfo.Add(model);
            db.SaveChanges();
            plan_id = 0;
            return RedirectToAction("ShowPlans");
        }
        public IActionResult Claim(int id,int amount)
        {
            plan_id = id;
            ViewBag.amountToPay = amount;
            return View();
        }

        private bool RechargeModelExists(int id)
        {
            return (db.RechargeInfo?.Any(e => e.recharge_id == id)).GetValueOrDefault();
        }
    }
}
