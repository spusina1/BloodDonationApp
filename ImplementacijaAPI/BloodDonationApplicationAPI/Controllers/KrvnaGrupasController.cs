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
    public class KrvnaGrupasController : ControllerBase
    {
        private readonly DatabaseBDAContext _context;

        public KrvnaGrupasController(DatabaseBDAContext context)
        {
            _context = context;
        }

        // GET: api/KrvnaGrupas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KrvnaGrupa>>> GetKrvnaGrupa()
        {
            return await _context.KrvnaGrupa.ToListAsync();
        }

        // GET: api/KrvnaGrupas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KrvnaGrupa>> GetKrvnaGrupa(int id)
        {
            var krvnaGrupa = await _context.KrvnaGrupa.FindAsync(id);

            if (krvnaGrupa == null)
            {
                return NotFound();
            }

            return krvnaGrupa;
        }

        // PUT: api/KrvnaGrupas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKrvnaGrupa(int id, KrvnaGrupa krvnaGrupa)
        {
            if (id != krvnaGrupa.KrvnaGrupaId)
            {
                return BadRequest();
            }

            _context.Entry(krvnaGrupa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KrvnaGrupaExists(id))
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

        // POST: api/KrvnaGrupas
        [HttpPost]
        public async Task<ActionResult<KrvnaGrupa>> PostKrvnaGrupa(KrvnaGrupa krvnaGrupa)
        {
            _context.KrvnaGrupa.Add(krvnaGrupa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKrvnaGrupa", new { id = krvnaGrupa.KrvnaGrupaId }, krvnaGrupa);
        }

        // DELETE: api/KrvnaGrupas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KrvnaGrupa>> DeleteKrvnaGrupa(int id)
        {
            var krvnaGrupa = await _context.KrvnaGrupa.FindAsync(id);
            if (krvnaGrupa == null)
            {
                return NotFound();
            }

            _context.KrvnaGrupa.Remove(krvnaGrupa);
            await _context.SaveChangesAsync();

            return krvnaGrupa;
        }

        private bool KrvnaGrupaExists(int id)
        {
            return _context.KrvnaGrupa.Any(e => e.KrvnaGrupaId == id);
        }
    }
}
