using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FortebetManagers.Data;
using FortebetManagers.Models;

namespace FortebetManagers.Controllers
{
    public class ElectronicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ElectronicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Electronics
        public async Task<IActionResult> Index()
        {
            List<Electronics> electronicsList = new List<Electronics>();
          
            return View(await _context.Electronics.ToListAsync());
        }

        // GET: Electronics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electronics = await _context.Electronics
                .SingleOrDefaultAsync(m => m.ID == id);
            if (electronics == null)
            {
                return NotFound();
            }

            return View(electronics);
        }

        // GET: Electronics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Electronics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Electronics electronics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(electronics);
                await _context.SaveChangesAsync();
                TempData["message"] = "Electronic Created";
                return RedirectToAction(nameof(Index));
            }
            return View(electronics);
        }

        // GET: Electronics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electronics = await _context.Electronics.SingleOrDefaultAsync(m => m.ID == id);
            if (electronics == null)
            {
                return NotFound();
            }
            return View(electronics);
        }

        // POST: Electronics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Electronics electronics)
        {
            if (id != electronics.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(electronics);
                    await _context.SaveChangesAsync();
                    TempData["message"] = "Electronic Edited";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectronicsExists(electronics.ID))
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
            return View(electronics);
        }

        // GET: Electronics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var electronics = await _context.Electronics
                .SingleOrDefaultAsync(m => m.ID == id);
            if (electronics == null)
            {
                return NotFound();
            }

            return View(electronics);
        }

        // POST: Electronics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var electronics = await _context.Electronics.SingleOrDefaultAsync(m => m.ID == id);
            _context.Electronics.Remove(electronics);
            await _context.SaveChangesAsync();
            TempData["message"] = "Electronic Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool ElectronicsExists(int id)
        {
            return _context.Electronics.Any(e => e.ID == id);
        }
    }
}
