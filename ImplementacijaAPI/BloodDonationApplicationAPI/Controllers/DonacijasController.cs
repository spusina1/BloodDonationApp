using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodDonationApplicationAPI.Models;

namespace BloodDonationApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonacijasController : ControllerBase
    {
        private readonly DatabaseBDAContext _context;

        public DonacijasController(DatabaseBDAContext context)
        {
            _context = context;
        }

        // GET: api/Donacijas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donacija>>> GetDonacija()
        {
            return await _context.Donacija.ToListAsync();
        }

        // GET: api/Donacijas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donacija>> GetDonacija(int id)
        {
            var donacija = await _context.Donacija.FindAsync(id);

            if (donacija == null)
            {
                return NotFound();
            }

            return donacija;
        }

        // PUT: api/Donacijas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonacija(int id, Donacija donacija)
        {
            if (id != donacija.DonacijaId)
            {
                return BadRequest();
            }

            _context.Entry(donacija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacijaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Donacijas
        [HttpPost]
        public async Task<ActionResult<Donacija>> PostDonacija(Donacija donacija)
        {
            _context.Donacija.Add(donacija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonacija", new { id = donacija.DonacijaId }, donacija);
        }

        // DELETE: api/Donacijas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Donacija>> DeleteDonacija(int id)
        {
            var donacija = await _context.Donacija.FindAsync(id);
            if (donacija == null)
            {
                return NotFound();
            }

            _context.Donacija.Remove(donacija);
            await _context.SaveChangesAsync();

            return donacija;
        }

        private bool DonacijaExists(int id)
        {
            return _context.Donacija.Any(e => e.DonacijaId == id);
        }
    }
}
