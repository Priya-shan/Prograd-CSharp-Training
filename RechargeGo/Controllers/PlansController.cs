using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RechargeGo.Data;
using RechargeGo.Models;

namespace RechargeGo.Controllers
{
    public class PlansController : Controller
    {
        private readonly AppDbContext db;

        public PlansController(AppDbContext context)
        {
            db = context;
        }

        // GET: Plans
        [Authorize(Roles= "administrator")]
        public async Task<IActionResult> Index()
        {
              return db.PlansInfo != null ? 
                          View(await db.PlansInfo.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.PlansInfo'  is null.");
        }
        
        public IActionResult Transactions()
        {
            List<CombinedData> joinedList = new List<CombinedData> ();  
                var Combined_Table = (from d in db.PlansInfo
                                 join f in db.RechargeInfo
                                 on d.plan_id equals f.plan_id
                                 select new CombinedData
                                 {
                                     recharge_id = f.recharge_id,
                                     operator_name = d.operator_name,
                                     category=d.category,
                                     customer_name = f.customer_name,
                                     mobile_number=f.mobile_number,
                                     amount = d.amount,
                                     date=f.date,
                                     transact_status=f.transact_status,
                                     plan_id =d.plan_id,
                                     data=d.data,
                                     validity=d.validity
                                 }).ToList();
            foreach(var item in Combined_Table)
            {
                CombinedData data=new CombinedData();
                data.recharge_id = item.recharge_id;
                data.customer_name = item.customer_name;
                data.mobile_number = item.mobile_number;
                data.operator_name = item.operator_name;
                data.category = item.category;
                data.amount=item.amount;
                data.date=item.date;
                data.transact_status = item.transact_status;

                joinedList.Add(data);
            }
            ViewBag.joinedList = joinedList;
            return View();
        }
        // GET: Plans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("plan_id,operator_name,category,amount,data,validity")] PlansModel plansModel)
        {
            if (ModelState.IsValid)
            {
                db.Add(plansModel);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plansModel);
        }

        // GET: Plans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.PlansInfo == null)
            {
                return NotFound();
            }

            var plansModel = await db.PlansInfo.FindAsync(id);
            if (plansModel == null)
            {
                return NotFound();
            }
            return View(plansModel);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("plan_id,operator_name,category,amount,data,validity")] PlansModel plansModel)
        {
            if (id != plansModel.plan_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(plansModel);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlansModelExists(plansModel.plan_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(plansModel);
        }

        // GET: Plans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || db.PlansInfo == null)
            {
                return NotFound();
            }

            var plansModel = await db.PlansInfo
                .FirstOrDefaultAsync(m => m.plan_id == id);
            if (plansModel == null)
            {
                return NotFound();
            }

            return View(plansModel);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (db.PlansInfo == null)
            {
                return Problem("Entity set 'AppDbContext.PlansInfo'  is null.");
            }
            var plansModel = await db.PlansInfo.FindAsync(id);
            if (plansModel != null)
            {
                db.PlansInfo.Remove(plansModel);
            }
            
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlansModelExists(int id)
        {
          return (db.PlansInfo?.Any(e => e.plan_id == id)).GetValueOrDefault();
        }
    }
}

public class CombinedData{
public int plan_id { get; set; }
public string operator_name { get; set; }
public string category { get; set; }
public int amount { get; set; }
public string data { get; set; }
public string validity { get; set; }
    public int recharge_id { get; set; }
    public string customer_name { get; set; }
    public string mobile_number { get; set; }
    public DateTime date { get; set; }
    public string transact_status { get; set; }
}