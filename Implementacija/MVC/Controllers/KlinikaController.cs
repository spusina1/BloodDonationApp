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
    public class KlinikaController : Controller
    {
        private readonly BDAContext _context;

        public KlinikaController(BDAContext context)
        {
            _context = context;
        }

        // GET: Klinika
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klinika.ToListAsync());
        }

        // GET: Klinika/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klinika = await _context.Klinika
                .FirstOrDefaultAsync(m => m.KlinikaId == id);
            if (klinika == null)
            {
                return NotFound();
            }

            return View(klinika);
        }

        // GET: Klinika/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klinika/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlinikaId,Naziv")] Klinika klinika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klinika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klinika);
        }

        // GET: Klinika/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klinika = await _context.Klinika.FindAsync(id);
            if (klinika == null)
            {
                return NotFound();
            }
            return View(klinika);
        }

        // POST: Klinika/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KlinikaId,Naziv")] Klinika klinika)
        {
            if (id != klinika.KlinikaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klinika);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlinikaExists(klinika.KlinikaId))
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
            return View(klinika);
        }

        // GET: Klinika/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klinika = await _context.Klinika
                .FirstOrDefaultAsync(m => m.KlinikaId == id);
            if (klinika == null)
            {
                return NotFound();
            }

            return View(klinika);
        }

        // POST: Klinika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klinika = await _context.Klinika.FindAsync(id);
            _context.Klinika.Remove(klinika);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlinikaExists(int id)
        {
            return _context.Klinika.Any(e => e.KlinikaId == id);
        }
    }
}
