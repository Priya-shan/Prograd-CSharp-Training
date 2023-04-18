using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityExample.Data;
using EntityExample.Models;

namespace EntityExample.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
              return _context.StudentsEntity != null ? 
                          View(await _context.StudentsEntity.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StudentsEntity'  is null.");
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentsEntity == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentsEntity
                .FirstOrDefaultAsync(m => m.Id == id);
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
        public async Task<IActionResult> Create([Bind("Id,RollNo,Name,Dept,DOB,JoiningDate")] StudentModel studentModel)
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
            if (id == null || _context.StudentsEntity == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentsEntity.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,RollNo,Name,Dept,DOB,JoiningDate")] StudentModel studentModel)
        {
            if (id != studentModel.Id)
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
                    if (!StudentModelExists(studentModel.Id))
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
            if (id == null || _context.StudentsEntity == null)
            {
                return NotFound();
            }

            var studentModel = await _context.StudentsEntity
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.StudentsEntity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentsEntity'  is null.");
            }
            var studentModel = await _context.StudentsEntity.FindAsync(id);
            if (studentModel != null)
            {
                _context.StudentsEntity.Remove(studentModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentModelExists(int id)
        {
          return (_context.StudentsEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
