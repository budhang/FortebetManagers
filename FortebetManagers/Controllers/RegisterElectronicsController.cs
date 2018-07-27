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
    public class RegisterElectronicsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterElectronicsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegisterElectronics
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegisterElectronics.Include(r => r.Electronics);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RegisterElectronics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerElectronics = await _context.RegisterElectronics
                .Include(r => r.Electronics)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (registerElectronics == null)
            {
                return NotFound();
            }

            return View(registerElectronics);
        }

        // GET: RegisterElectronics/Create
        public IActionResult Create()
        {
            ViewData["ElectronicsID"] = new SelectList(_context.Electronics, "ID", "Name");
            return View();
        }

        // POST: RegisterElectronics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ElectronicsID,Make,Model,SerialNumber,Price,Supplier,Invoice,DatePurchased")] RegisterElectronics registerElectronics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerElectronics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ElectronicsID"] = new SelectList(_context.Electronics, "ID", "Name", registerElectronics.ElectronicsID);
            return View(registerElectronics);
        }

        // GET: RegisterElectronics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerElectronics = await _context.RegisterElectronics.SingleOrDefaultAsync(m => m.ID == id);
            if (registerElectronics == null)
            {
                return NotFound();
            }
            ViewData["ElectronicsID"] = new SelectList(_context.Electronics, "ID", "Name", registerElectronics.ElectronicsID);
            return View(registerElectronics);
        }

        // POST: RegisterElectronics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ElectronicsID,Make,Model,SerialNumber,Price,Supplier,Invoice,DatePurchased")] RegisterElectronics registerElectronics)
        {
            if (id != registerElectronics.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerElectronics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterElectronicsExists(registerElectronics.ID))
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
            ViewData["ElectronicsID"] = new SelectList(_context.Electronics, "ID", "Name", registerElectronics.ElectronicsID);
            return View(registerElectronics);
        }

        // GET: RegisterElectronics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerElectronics = await _context.RegisterElectronics
                .Include(r => r.Electronics)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (registerElectronics == null)
            {
                return NotFound();
            }

            return View(registerElectronics);
        }

        // POST: RegisterElectronics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registerElectronics = await _context.RegisterElectronics.SingleOrDefaultAsync(m => m.ID == id);
            _context.RegisterElectronics.Remove(registerElectronics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterElectronicsExists(int id)
        {
            return _context.RegisterElectronics.Any(e => e.ID == id);
        }
    }
}
