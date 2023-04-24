using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DockerSupport.Data;
using DockerSupport.Models;

namespace DockerSupport.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
              return _context.StudentTableForDockerSupport != null ? 
                          View(await _context.StudentTableForDockerSupport.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.StudentTableForDockerSupport'  is null.");
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentTableForDockerSupport == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentTableForDockerSupport
                .FirstOrDefaultAsync(m => m.id == id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,age,dept,college_name")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentModel);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentTableForDockerSupport == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentTableForDockerSupport.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }
            return View(studentModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,age,dept,college_name")] StudentModel studentModel)
        {
            if (id != studentModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentModelExists(studentModel.id))
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
            return View(studentModel);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentTableForDockerSupport == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentTableForDockerSupport
                .FirstOrDefaultAsync(m => m.id == id);
            if (studentModel == null)
            {
                return NotFound();
            }

            return View(studentModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentTableForDockerSupport == null)
            {
                return Problem("Entity set 'AppDbContext.StudentTableForDockerSupport'  is null.");
            }
            var studentModel = await _context.StudentTableForDockerSupport.FindAsync(id);
            if (studentModel != null)
            {
                _context.StudentTableForDockerSupport.Remove(studentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentModelExists(int id)
        {
          return (_context.StudentTableForDockerSupport?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
