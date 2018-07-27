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
    public class RegisterOfficeItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterOfficeItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegisterOfficeItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegisterOfficeItems.ToListAsync());
        }

        // GET: RegisterOfficeItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerOfficeItems = await _context.RegisterOfficeItems
                .SingleOrDefaultAsync(m => m.ID == id);
            if (registerOfficeItems == null)
            {
                return NotFound();
            }

            return View(registerOfficeItems);
        }

        // GET: RegisterOfficeItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegisterOfficeItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Item,Type,Price")] RegisterOfficeItems registerOfficeItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registerOfficeItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registerOfficeItems);
        }

        // GET: RegisterOfficeItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerOfficeItems = await _context.RegisterOfficeItems.SingleOrDefaultAsync(m => m.ID == id);
            if (registerOfficeItems == null)
            {
                return NotFound();
            }
            return View(registerOfficeItems);
        }

        // POST: RegisterOfficeItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Item,Type,Price")] RegisterOfficeItems registerOfficeItems)
        {
            if (id != registerOfficeItems.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerOfficeItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterOfficeItemsExists(registerOfficeItems.ID))
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
            return View(registerOfficeItems);
        }

        // GET: RegisterOfficeItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerOfficeItems = await _context.RegisterOfficeItems
                .SingleOrDefaultAsync(m => m.ID == id);
            if (registerOfficeItems == null)
            {
                return NotFound();
            }

            return View(registerOfficeItems);
        }

        // POST: RegisterOfficeItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registerOfficeItems = await _context.RegisterOfficeItems.SingleOrDefaultAsync(m => m.ID == id);
            _context.RegisterOfficeItems.Remove(registerOfficeItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterOfficeItemsExists(int id)
        {
            return _context.RegisterOfficeItems.Any(e => e.ID == id);
        }
    }
}
