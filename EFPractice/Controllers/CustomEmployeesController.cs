using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFPractice.Model1;
using EFPractice.Models;

namespace EFPractice.Controllers
{
    public class CustomEmployeesController : Controller
    {
        private readonly AdventureWorks2019DBContext _context;

        public CustomEmployeesController(AdventureWorks2019DBContext context)
        {
            _context = context;
        }

        // GET: CustomEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomEmployee.ToListAsync());
        }

        // GET: CustomEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customEmployee = await _context.CustomEmployee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customEmployee == null)
            {
                return NotFound();
            }

            return View(customEmployee);
        }

        // GET: CustomEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName")] CustomEmployee customEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customEmployee);
        }

        // GET: CustomEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customEmployee = await _context.CustomEmployee.FindAsync(id);
            if (customEmployee == null)
            {
                return NotFound();
            }
            return View(customEmployee);
        }

        // POST: CustomEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName")] CustomEmployee customEmployee)
        {
            if (id != customEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomEmployeeExists(customEmployee.Id))
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
            return View(customEmployee);
        }

        // GET: CustomEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customEmployee = await _context.CustomEmployee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customEmployee == null)
            {
                return NotFound();
            }

            return View(customEmployee);
        }

        // POST: CustomEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customEmployee = await _context.CustomEmployee.FindAsync(id);
            if (customEmployee != null)
            {
                _context.CustomEmployee.Remove(customEmployee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomEmployeeExists(int id)
        {
            return _context.CustomEmployee.Any(e => e.Id == id);
        }
    }
}
