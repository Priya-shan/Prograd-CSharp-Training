using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Concurrency_Token.Data;
using Concurrency_Token.Models;

namespace Concurrency_Token.Controllers
{
    public class ProductsModelsController : Controller
    {
        private readonly AppDbContext db;

        public ProductsModelsController(AppDbContext context)
        {
            db = context;
        }

        // GET: ProductsModels
        public async Task<IActionResult> Index()
        {
              return db.productsModel != null ? 
                          View(await db.productsModel.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.productsModel'  is null.");
        }

        // GET: ProductsModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || db.productsModel == null)
            {
                return NotFound();
            }

            var productsModel = await db.productsModel.FindAsync(id);
            if (productsModel == null)
            {
                return NotFound();
            }
            return View(productsModel);
        }

        // POST: ProductsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ProductsModel productsModel)
        {
                var temp = db.productsModel.Find(id);
                temp.Name = productsModel.Name;
                temp.quantity = productsModel.quantity;
                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                Console.WriteLine(e.Message);
                return View();
            }
                return RedirectToAction(nameof(Index));
        }

        private bool ProductsModelExists(int id)
        {
          return (db.productsModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
