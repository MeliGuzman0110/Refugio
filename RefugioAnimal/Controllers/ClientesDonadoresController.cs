using AutoMapper;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DO.Objects;

namespace RefugioAnimal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesDonadoresController : ControllerBase
    {
        private readonly RefugioAnimalDBContext _context;
        private readonly IMapper _mapper;

        public ClientesDonadoresController(RefugioAnimalDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/Donantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Donantes>>> GetDonantes()
        {
            var aux = new BS.Donantes(_context).GetAll();

            // Hacemos el casting del dato una vez que ya el proceso finaliza en la base de datos 
            var mapaux = _mapper.Map<IEnumerable<data.Donantes>, IEnumerable<DataModels.Donantes>>(aux).ToList();
            return mapaux;
        }

        // GET: api/Donantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Donantes>> GetDonantes(int id)
        {
            var donantes = new BS.Donantes(_context).GetOneById(id);
            var mapaux = _mapper.Map<data.Donantes, DataModels.Donantes>(donantes);
            if (donantes == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Donantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonantes(int id, DataModels.Donantes donantes)
        {
            if (id != donantes.Iddonante)
            {
                return BadRequest();
            }

            var mapaux = _mapper.Map<DataModels.Donantes, data.Donantes>(donantes);
            try
            {
                new BS.Donantes(_context).Update(mapaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<DataModels.Donantes>> PostDonantes(DataModels.Donantes donantes)
        {
            var mapaux = _mapper.Map<DataModels.Donantes, data.Donantes>(donantes);
            new BS.Donantes(_context).Insert(mapaux);

            return CreatedAtAction("GetDonantes", new { id = donantes.Iddonante }, donantes);
        }

        // DELETE: api/Donantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Donantes>> DeleteDonantes(int id)
        {
            var donantes = new BS.Donantes(_context).GetOneById(id);
            if (donantes == null)
            {
                return NotFound();
            }

            new BS.Donantes(_context).Delete(donantes);
            var mapaux = _mapper.Map<data.Donantes, DataModels.Donantes>(donantes);
            return mapaux;
        }

        private bool DonantesExists(int id)
        {
            return _context.Donantes.Any(e => e.Iddonante == id);
        }

    }
}
