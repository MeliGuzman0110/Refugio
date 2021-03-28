using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = DO.Objects;

namespace RefugioAnimal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonacionesController : ControllerBase
    {
        private readonly RefugioAnimalDBContext _context;
        private readonly IMapper _mapper;

        public DonacionesController(RefugioAnimalDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/Donacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Donacion>>> GetDonacion()
        {
            var aux = await new BS.Donacion(_context).GetAllInclude();

            // Hacemos el casting del dato una vez que ya el proceso finaliza en la base de datos 
            var mapaux = _mapper.Map<IEnumerable<data.Donacion>, IEnumerable<DataModels.Donacion>>(aux).ToList();
            return mapaux;
        }

        // GET: api/Donacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Donacion>> GetDonacion(int id)
        {
            var donacion = new BS.Donacion(_context).GetOneById(id);
            var mapaux = _mapper.Map<data.Donacion, DataModels.Donacion>(donacion);
            if (mapaux == null)
            {
                return NotFound();
            }
            return mapaux;
        }

        // PUT: api/Donacions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonacion(int id, DataModels.Donacion donacion)
        {
            if (id != donacion.Iddonacion)
            {
                return BadRequest();
            }
            var mapaux = _mapper.Map<DataModels.Donacion, data.Donacion>(donacion);
            try
            {
                new BS.Donacion(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!DonacionExists(id))
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

        // POST: api/Donacions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Donacion>> PostDonacion(DataModels.Donacion donacion)
        {
            var mapaux = _mapper.Map<DataModels.Donacion, data.Donacion>(donacion);
            new BS.Donacion(_context).Insert(mapaux);

            return CreatedAtAction("GetDonacion", new { id = donacion.Iddonacion }, donacion);
        }

        // DELETE: api/Donacions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Donacion>> DeleteDonacion(int id)
        {
            var donacion = new BS.Donacion(_context).GetOneById(id);
            if (donacion == null)
            {
                return NotFound();
            }
            new BS.Donacion(_context).Delete(donacion);
            var mapaux = _mapper.Map<data.Donacion, DataModels.Donacion>(donacion);
            return mapaux;
        }

        private bool DonacionExists(int id)
        {
            return (new BS.Donacion(_context).GetOneById(id) != null);
        }
    }
}
