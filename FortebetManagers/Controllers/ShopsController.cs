using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FortebetManagers.Data;
using FortebetManagers.Models;
using Microsoft.AspNetCore.Authorization;

namespace FortebetManagers.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class ShopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Shops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shops.ToListAsync());
        }

        // GET: Shops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shops = await _context.Shops
                .SingleOrDefaultAsync(m => m.ID == id);
            if (shops == null)
            {
                return NotFound();
            }

            return View(shops);
        }

        // GET: Shops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Province,District,Sector,Cell,Village,Landlord,Rent,DateRented")] Shops shops)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shops);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shops);
        }

        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shops = await _context.Shops.SingleOrDefaultAsync(m => m.ID == id);
            if (shops == null)
            {
                return NotFound();
            }
            return View(shops);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Province,District,Sector,Cell,Village,Landlord,Rent,DateRented")] Shops shops)
        {
            if (id != shops.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shops);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopsExists(shops.ID))
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
            return View(shops);
        }

        // GET: Shops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shops = await _context.Shops
                .SingleOrDefaultAsync(m => m.ID == id);
            if (shops == null)
            {
                return NotFound();
            }

            return View(shops);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shops = await _context.Shops.SingleOrDefaultAsync(m => m.ID == id);
            _context.Shops.Remove(shops);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopsExists(int id)
        {
            return _context.Shops.Any(e => e.ID == id);
        }
    }
}
