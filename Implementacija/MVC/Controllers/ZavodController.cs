using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodDonationApplication.Models;

namespace BloodDonationApplication.Controllers
{
    public class ZavodController : Controller
    {
        private readonly BDAContext _context;

        public ZavodController(BDAContext context)
        {
            _context = context;
        }

        public IActionResult PotvrdaEmailova()
        {
            return View();
        }

        // GET: Zavod
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zavod.ToListAsync());
        }

        // GET: Zavod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zavod = await _context.Zavod
                .FirstOrDefaultAsync(m => m.ZavodId == id);
            if (zavod == null)
            {
                return NotFound();
            }

            return View(zavod);
        }

        // GET: Zavod/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zavod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZavodId,Naziv,Grad")] Zavod zavod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zavod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zavod);
        }

        // GET: Zavod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zavod = await _context.Zavod.FindAsync(id);
            if (zavod == null)
            {
                return NotFound();
            }
            return View(zavod);
        }

        // POST: Zavod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZavodId,Naziv,Grad")] Zavod zavod)
        {
            if (id != zavod.ZavodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zavod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZavodExists(zavod.ZavodId))
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
            return View(zavod);
        }

        // GET: Zavod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zavod = await _context.Zavod
                .FirstOrDefaultAsync(m => m.ZavodId == id);
            if (zavod == null)
            {
                return NotFound();
            }

            return View(zavod);
        }

        // POST: Zavod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zavod = await _context.Zavod.FindAsync(id);
            _context.Zavod.Remove(zavod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZavodExists(int id)
        {
            return _context.Zavod.Any(e => e.ZavodId == id);
        }
    }
}
