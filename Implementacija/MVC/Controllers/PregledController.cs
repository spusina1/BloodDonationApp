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
    public class PregledController : Controller
    {
        private readonly BDAContext _context;

        public PregledController(BDAContext context)
        {
            _context = context;
        }

        // GET: Pregled
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pregled.ToListAsync());
        }

        // GET: Pregled/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregled = await _context.Pregled
                .FirstOrDefaultAsync(m => m.PregledId == id);
            if (pregled == null)
            {
                return NotFound();
            }

            return View(pregled);
        }

        // GET: Pregled/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pregled/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PregledId,DatumPregleda,DetaljiPregleda,UspjesanPregled")] Pregled pregled)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pregled);
                await _context.SaveChangesAsync();
                if (pregled.UspjesanPregled == true) return RedirectToAction("Create", "Donacijas");
                else return RedirectToAction("Index", "Zavod");
            }
            return View(pregled);
        }

        // GET: Pregled/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregled = await _context.Pregled.FindAsync(id);
            if (pregled == null)
            {
                return NotFound();
            }
            return View(pregled);
        }

        // POST: Pregled/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PregledId,DatumPregleda,DetaljiPregleda,UspjesanPregled")] Pregled pregled)
        {
            if (id != pregled.PregledId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pregled);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PregledExists(pregled.PregledId))
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
            return View(pregled);
        }

        // GET: Pregled/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pregled = await _context.Pregled
                .FirstOrDefaultAsync(m => m.PregledId == id);
            if (pregled == null)
            {
                return NotFound();
            }

            return View(pregled);
        }

        // POST: Pregled/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pregled = await _context.Pregled.FindAsync(id);
            _context.Pregled.Remove(pregled);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PregledExists(int id)
        {
            return _context.Pregled.Any(e => e.PregledId == id);
        }
    }
}
