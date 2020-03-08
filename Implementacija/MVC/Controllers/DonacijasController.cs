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
    public class DonacijasController : Controller
    {
        private readonly BDAContext _context;

        public DonacijasController(BDAContext context)
        {
            _context = context;
        }

        // GET: Donacijas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donacija.ToListAsync());
        }

        // GET: Donacijas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donacija = await _context.Donacija
                .FirstOrDefaultAsync(m => m.DonacijaId == id);
            if (donacija == null)
            {
                return NotFound();
            }

            return View(donacija);
        }

        // GET: Donacijas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Donacijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonacijaId,DatumDonacije,DoniranaKolicinaKrvi")] Donacija donacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donacija);
        }

        // GET: Donacijas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donacija = await _context.Donacija.FindAsync(id);
            if (donacija == null)
            {
                return NotFound();
            }
            return View(donacija);
        }

        // POST: Donacijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonacijaId,DatumDonacije,DoniranaKolicinaKrvi")] Donacija donacija)
        {
            if (id != donacija.DonacijaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonacijaExists(donacija.DonacijaId))
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
            return View(donacija);
        }

        // GET: Donacijas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donacija = await _context.Donacija
                .FirstOrDefaultAsync(m => m.DonacijaId == id);
            if (donacija == null)
            {
                return NotFound();
            }

            return View(donacija);
        }

        // POST: Donacijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donacija = await _context.Donacija.FindAsync(id);
            _context.Donacija.Remove(donacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonacijaExists(int id)
        {
            return _context.Donacija.Any(e => e.DonacijaId == id);
        }
    }
}
