using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodDonationApplication.Models;
using System.Net.Mail;
using System.Net;

namespace BloodDonationApplication.Controllers
{
    public class KrvnaGrupaController : Controller
    {
        private readonly BDAContext _context;

        public KrvnaGrupaController(BDAContext context)
        {
            _context = context;
        }

        // GET: KrvnaGrupa
        public async Task<IActionResult> Index()
        {
            List<KrvnaGrupa> krvneGrupe = 
                await _context.KrvnaGrupa.GroupBy(k => k.Naziv).Select(k => k.FirstOrDefault()).ToListAsync();
            for (int i = 0; i < krvneGrupe.Count; i++)
            {
                if (krvneGrupe[i].Naziv == null)
                {
                    krvneGrupe.RemoveAt(i);
                    i--;
                    continue;
                }
                if (krvneGrupe[i].Naziv.Trim() == "")
                {
                    krvneGrupe.RemoveAt(i);
                    i--;
                    continue;
                }
                if (krvneGrupe[i].Naziv.Trim().Length == 0)
                {
                    krvneGrupe.RemoveAt(i);
                    i--;
                    continue;
                }
            }
            return View(krvneGrupe);
        }

        // GET: KrvnaGrupa/Details/5
        public async Task<IActionResult> Details(int? id, int? sifra)
        {
            if (id == null)
            {
                return NotFound();
            }

            var krvnaGrupa = await _context.KrvnaGrupa
                .FirstOrDefaultAsync(m => m.KrvnaGrupaId == id);

            if (sifra == 57) return RedirectToAction("IndexPoKrvnojGrupi", "Donor", new { krvnaGrupaNaziv = krvnaGrupa.Naziv });

            else if (sifra == 59)
            {
                List<Donor> listaNadjenihDonora 
                    = await _context.Donor.Where(d => d.KrvnaGrupa.Naziv == krvnaGrupa.Naziv).ToListAsync();
                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("bda.application@gmail.com", "RedLinks2019")
                };
                var message = new MailMessage();
                message.From = new MailAddress("bda.application@gmail.com");
                foreach (Donor donor in listaNadjenihDonora)
                {
                    message.To.Add(donor.Email.Trim());
                }
                message.Subject = "Poziv na doniranje krvi";
                message.Body = "Postovani/a,\n" +
                    "Ovim putem Vas, uslijed porasle potrebe za Vasom krvnom grupom, pozivamo da" +
                    " u sto skorijem roku, ukoliko ste u mogucnosti, ponovo donirate krv u nasem zavodu. Budite slobodni" +
                    " da nas za sva potrebna pitanja kontaktirate putem nase mail adrese.\n" +
                    "Unaprijed zahvalni,\n\n" +
                    "Zavod za transfuziologiju krvi";
                await smtpClient.SendMailAsync(message);
                return RedirectToAction("PotvrdaEmailova", "Zavod");
            }

            if (krvnaGrupa == null)
            {
                return NotFound();
            }

            return View(krvnaGrupa);
        }

        // GET: KrvnaGrupa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KrvnaGrupa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KrvnaGrupaId,Naziv")] KrvnaGrupa krvnaGrupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(krvnaGrupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(krvnaGrupa);
        }

        // GET: KrvnaGrupa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var krvnaGrupa = await _context.KrvnaGrupa.FindAsync(id);
            if (krvnaGrupa == null)
            {
                return NotFound();
            }
            return View(krvnaGrupa);
        }

        // POST: KrvnaGrupa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KrvnaGrupaId,Naziv")] KrvnaGrupa krvnaGrupa)
        {
            if (id != krvnaGrupa.KrvnaGrupaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(krvnaGrupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KrvnaGrupaExists(krvnaGrupa.KrvnaGrupaId))
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
            return View(krvnaGrupa);
        }

        // GET: KrvnaGrupa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var krvnaGrupa = await _context.KrvnaGrupa
                .FirstOrDefaultAsync(m => m.KrvnaGrupaId == id);
            if (krvnaGrupa == null)
            {
                return NotFound();
            }

            return View(krvnaGrupa);
        }

        // POST: KrvnaGrupa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var krvnaGrupa = await _context.KrvnaGrupa.FindAsync(id);
            _context.KrvnaGrupa.Remove(krvnaGrupa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KrvnaGrupaExists(int id)
        {
            return _context.KrvnaGrupa.Any(e => e.KrvnaGrupaId == id);
        }
    }
}
