using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIW.Models;

namespace APIW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonantesController : ControllerBase
    {
        private readonly RefugioAnimal _context;

        public DonantesController(RefugioAnimal context)
        {
            _context = context;
        }

        // GET: api/Donantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donantes>>> GetDonantes()
        {
            return await _context.Donantes.ToListAsync();
        }

        // GET: api/Donantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donantes>> GetDonantes(int id)
        {
            var donantes = await _context.Donantes.FindAsync(id);

            if (donantes == null)
            {
                return NotFound();
            }

            return donantes;
        }

        // PUT: api/Donantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonantes(int id, Donantes donantes)
        {
            if (id != donantes.Iddonante)
            {
                return BadRequest();
            }

            _context.Entry(donantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonantesExists(id))
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

        // POST: api/Donantes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Donantes>> PostDonantes(Donantes donantes)
        {
            _context.Donantes.Add(donantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonantes", new { id = donantes.Iddonante }, donantes);
        }

        // DELETE: api/Donantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Donantes>> DeleteDonantes(int id)
        {
            var donantes = await _context.Donantes.FindAsync(id);
            if (donantes == null)
            {
                return NotFound();
            }

            _context.Donantes.Remove(donantes);
            await _context.SaveChangesAsync();

            return donantes;
        }

        private bool DonantesExists(int id)
        {
            return _context.Donantes.Any(e => e.Iddonante == id);
        }
    }
}
