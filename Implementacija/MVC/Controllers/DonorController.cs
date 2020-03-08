using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BloodDonationApplication.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace BloodDonationApplication.Controllers
{
   // [Authorize]
    public class DonorController : Controller
    {
      
        private readonly BDAContext _context;

        public DonorController(BDAContext context)
        {
            _context = context;
        }

        // GET: Donor
        public async Task<IActionResult> Index()
        {
            // Stara verzija:
            //return View(await _context.Donor.ToListAsync());

            // Nova verzija sa API-jem:
            string apiUrl = "https://blooddonationapplication.azurewebsites.net/";
            List<Donor> donori = new List<Donor>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponseMessage = await client.GetAsync("api/donor/");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    donori = JsonConvert.DeserializeObject<List<Donor>>(response);
                }
                return View(donori);
            }
        }

        public async Task<IActionResult> IndexPoKrvnojGrupi(string krvnaGrupaNaziv)
        {
            return View(await _context.Donor.Where(d => d.KrvnaGrupa.Naziv == krvnaGrupaNaziv).ToListAsync());
        }

        public async Task<IActionResult> Poziv()
        {
            return RedirectToAction();
        }

        // GET: Donor/Details/5
        public async Task<IActionResult> Details(int? id, int? sifra)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donor
                .FirstOrDefaultAsync(m => m.DonorId == id);

            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        public async Task<IActionResult> Pretraga()
        {
            return View();
        }

        public async Task<IActionResult> Usmjeravanje(Donor donor)
        {
            List<Donor> listaNadjenihDonora
                    = await _context.Donor.Where(d => d.Jmbg == donor.Jmbg).ToListAsync();
            if (listaNadjenihDonora.Count == 0) return RedirectToAction("Create", "Donor");
            else return RedirectToAction("Create", "Pregled", new { poslaniDonor = donor });
        }

        //   [Authorize(Roles ="Zavod")]
        // GET: Donor/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Donor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Donor donor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Pregled"); //kada odaberemo unos pregleda
            }
            return View(donor);
        }

        // GET: Donor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donor.FindAsync(id);
            if (donor == null)
            {
                return NotFound();
            }
            return View(donor);
        }

        // POST: Donor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonorId,Ime,Prezime,Email,Jmbg,BrojMobilnogTelefona,Grad")] Donor donor)
        {
            if (id != donor.DonorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(donor.DonorId))
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
            return View(donor);
        }

        // GET: Donor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donor
                .FirstOrDefaultAsync(m => m.DonorId == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // POST: Donor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donor = await _context.Donor.FindAsync(id);
            _context.Donor.Remove(donor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorExists(int id)
        {
            return _context.Donor.Any(e => e.DonorId == id);
        }
    }
}
