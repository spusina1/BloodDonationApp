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
    public class KomponenteKrviController : Controller
    {
        private readonly BDAContext _context;

        public KomponenteKrviController(BDAContext context)
        {
            _context = context;
        }

        // GET: KomponenteKrvi
        public async Task<IActionResult> Index()
        {
            return View(await _context.KomponenteKrvi.ToListAsync());
        }

        // GET: KomponenteKrvi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komponenteKrvi = await _context.KomponenteKrvi
                .FirstOrDefaultAsync(m => m.KomponenteKrviId == id);
            if (komponenteKrvi == null)
            {
                return NotFound();
            }

            return View(komponenteKrvi);
        }

        // GET: KomponenteKrvi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KomponenteKrvi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KomponenteKrviId,Eritrociti,Trombociti,Leukociti,KrvnaPlazma")] KomponenteKrvi komponenteKrvi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komponenteKrvi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(komponenteKrvi);
        }

        // GET: KomponenteKrvi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komponenteKrvi = await _context.KomponenteKrvi.FindAsync(id);
            if (komponenteKrvi == null)
            {
                return NotFound();
            }
            return View(komponenteKrvi);
        }

        // POST: KomponenteKrvi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KomponenteKrviId,Eritrociti,Trombociti,Leukociti,KrvnaPlazma")] KomponenteKrvi komponenteKrvi)
        {
            if (id != komponenteKrvi.KomponenteKrviId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komponenteKrvi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomponenteKrviExists(komponenteKrvi.KomponenteKrviId))
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
            return View(komponenteKrvi);
        }

        // GET: KomponenteKrvi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komponenteKrvi = await _context.KomponenteKrvi
                .FirstOrDefaultAsync(m => m.KomponenteKrviId == id);
            if (komponenteKrvi == null)
            {
                return NotFound();
            }

            return View(komponenteKrvi);
        }

        // POST: KomponenteKrvi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komponenteKrvi = await _context.KomponenteKrvi.FindAsync(id);
            _context.KomponenteKrvi.Remove(komponenteKrvi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomponenteKrviExists(int id)
        {
            return _context.KomponenteKrvi.Any(e => e.KomponenteKrviId == id);
        }
    }
}
