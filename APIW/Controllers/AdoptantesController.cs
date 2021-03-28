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
    public class AdoptantesController : ControllerBase
    {
        private readonly RefugioAnimal _context;

        public AdoptantesController(RefugioAnimal context)
        {
            _context = context;
        }

        // GET: api/Adoptantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adoptantes>>> GetAdoptantes()
        {
            return await _context.Adoptantes.ToListAsync();
        }

        // GET: api/Adoptantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adoptantes>> GetAdoptantes(int id)
        {
            var adoptantes = await _context.Adoptantes.FindAsync(id);

            if (adoptantes == null)
            {
                return NotFound();
            }

            return adoptantes;
        }

        // PUT: api/Adoptantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdoptantes(int id, Adoptantes adoptantes)
        {
            if (id != adoptantes.Idadoptante)
            {
                return BadRequest();
            }

            _context.Entry(adoptantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptantesExists(id))
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

        // POST: api/Adoptantes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Adoptantes>> PostAdoptantes(Adoptantes adoptantes)
        {
            _context.Adoptantes.Add(adoptantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdoptantes", new { id = adoptantes.Idadoptante }, adoptantes);
        }

        // DELETE: api/Adoptantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Adoptantes>> DeleteAdoptantes(int id)
        {
            var adoptantes = await _context.Adoptantes.FindAsync(id);
            if (adoptantes == null)
            {
                return NotFound();
            }

            _context.Adoptantes.Remove(adoptantes);
            await _context.SaveChangesAsync();

            return adoptantes;
        }

        private bool AdoptantesExists(int id)
        {
            return _context.Adoptantes.Any(e => e.Idadoptante == id);
        }
    }
}
