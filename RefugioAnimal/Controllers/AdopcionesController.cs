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
    public class AdopcionesController : ControllerBase
    {
        private readonly RefugioAnimalDBContext _context;
        private readonly IMapper _mapper;

        public AdopcionesController(RefugioAnimalDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/Adopciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Adopcion>>> GetAdopcion()
        {
            var aux = await new BS.Adopcion(_context).GetAllInclude();

            // Hacemos el casting del dato una vez que ya el proceso finaliza en la base de datos 
            var mapaux = _mapper.Map<IEnumerable<data.Adopcion>, IEnumerable<DataModels.Adopcion>>(aux).ToList();
            return mapaux;
        }

        // GET: api/Adopcions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Adopcion>> GetAdopcion(int id)
        {
            var adopcion = new BS.Adopcion(_context).GetOneById(id);
            var mapaux = _mapper.Map<data.Adopcion, DataModels.Adopcion>(adopcion);
            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Adopcions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdopcion(int id, DataModels.Adopcion adopcion)
        {
            if (id != adopcion.Idadopcion)
            {
                return BadRequest();
            }

            var mapaux = _mapper.Map<DataModels.Adopcion, data.Adopcion>(adopcion);
            try
            {
                new BS.Adopcion(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!AdopcionExists(id))
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

        // POST: api/Adopcions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Adopcion>> PostAdopcion(DataModels.Adopcion adopcion)
        {
            var mapaux = _mapper.Map<DataModels.Adopcion, data.Adopcion>(adopcion);
            new BS.Adopcion(_context).Insert(mapaux);

            return CreatedAtAction("GetAdopcion", new { id = adopcion.Idadopcion }, adopcion);
        }

        // DELETE: api/Adopcions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Adopcion>> DeleteAdopcion(int id)
        {
            var adopcion = new BS.Adopcion(_context).GetOneById(id);
            if (adopcion == null)
            {
                return NotFound();
            }

            new BS.Adopcion(_context).Delete(adopcion);
            var mapaux = _mapper.Map<data.Adopcion, DataModels.Adopcion>(adopcion);
            return mapaux;
        }

        private bool AdopcionExists(int id)
        {
            return (new BS.Adopcion(_context).GetOneById(id) != null);
        }

    }
}
