using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityExample2.Data;
using EntityExample2.Models;

namespace EntityExample2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployeeTable()
        {
          if (_context.EmployeeTable == null)
          {
              return NotFound();
          }
            return await _context.EmployeeTable.ToListAsync();
        }

        // GET: api/EmployeeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeModel(int id)
        {
          if (_context.EmployeeTable == null)
          {
              return NotFound();
          }
            var employeeModel = await _context.EmployeeTable.FindAsync(id);

            if (employeeModel == null)
            {
                return NotFound();
            }

            return employeeModel;
        }

        // PUT: api/EmployeeModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeModel(int id, EmployeeModel employeeModel)
        {
            if (id != employeeModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeModel>> PostEmployeeModel(EmployeeModel employeeModel)
        {
          if (_context.EmployeeTable == null)
          {
              return Problem("Entity set 'AppDbContext.EmployeeTable'  is null.");
          }
            _context.EmployeeTable.Add(employeeModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeModel", new { id = employeeModel.Id }, employeeModel);
        }

        // DELETE: api/EmployeeModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeModel(int id)
        {
            if (_context.EmployeeTable == null)
            {
                return NotFound();
            }
            var employeeModel = await _context.EmployeeTable.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            _context.EmployeeTable.Remove(employeeModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeModelExists(int id)
        {
            return (_context.EmployeeTable?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
