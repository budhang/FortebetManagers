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
    public class PaperRollsTransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaperRollsTransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaperRollsTransactions1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PaperRollsTransactions.Include(p => p.Shops);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PaperRollsTransactions1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperRollsTransactions = await _context.PaperRollsTransactions
                .Include(p => p.Shops)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (paperRollsTransactions == null)
            {
                return NotFound();
            }

            return View(paperRollsTransactions);
        }

        // GET: PaperRollsTransactions1/Create
        public IActionResult Create()
        {
            ViewData["ShopsId"] = new SelectList(_context.Shops, "ID", "Name");
            return View();
        }

        // POST: PaperRollsTransactions1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Source,ShopsId,Quantity")] PaperRollsTransactions paperRollsTransactions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paperRollsTransactions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShopsId"] = new SelectList(_context.Shops, "ID", "Name", paperRollsTransactions.ShopsId);
            return View(paperRollsTransactions);
        }

        // GET: PaperRollsTransactions1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperRollsTransactions = await _context.PaperRollsTransactions.SingleOrDefaultAsync(m => m.Id == id);
            if (paperRollsTransactions == null)
            {
                return NotFound();
            }
            ViewData["ShopsId"] = new SelectList(_context.Shops, "ID", "Name", paperRollsTransactions.ShopsId);
            return View(paperRollsTransactions);
        }

        // POST: PaperRollsTransactions1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Source,ShopsId,Quantity")] PaperRollsTransactions paperRollsTransactions)
        {
            if (id != paperRollsTransactions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paperRollsTransactions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaperRollsTransactionsExists(paperRollsTransactions.Id))
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
            ViewData["ShopsId"] = new SelectList(_context.Shops, "ID", "Name", paperRollsTransactions.ShopsId);
            return View(paperRollsTransactions);
        }

        // GET: PaperRollsTransactions1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperRollsTransactions = await _context.PaperRollsTransactions
                .Include(p => p.Shops)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (paperRollsTransactions == null)
            {
                return NotFound();
            }

            return View(paperRollsTransactions);
        }

        // POST: PaperRollsTransactions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paperRollsTransactions = await _context.PaperRollsTransactions.SingleOrDefaultAsync(m => m.Id == id);
            _context.PaperRollsTransactions.Remove(paperRollsTransactions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaperRollsTransactionsExists(int id)
        {
            return _context.PaperRollsTransactions.Any(e => e.Id == id);
        }
    }
}
