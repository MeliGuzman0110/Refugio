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
    public class ClientesAdoptantesController : ControllerBase
    {
        private readonly RefugioAnimalDBContext _context;
        private readonly IMapper _mapper;

        public ClientesAdoptantesController(RefugioAnimalDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/Adoptantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Adoptantes>>> GetAdoptantes()
        {
            var aux = new BS.Adoptantes(_context).GetAll();

            // Hacemos el casting del dato una vez que ya el proceso finaliza en la base de datos 
            var mapaux = _mapper.Map<IEnumerable<data.Adoptantes>, IEnumerable<DataModels.Adoptantes>>(aux).ToList();
            return mapaux;
        }

        // GET: api/Adoptantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Adoptantes>> GetAdoptantes(int id)
        {
            var adoptantes = new BS.Adoptantes(_context).GetOneById(id);
            var mapaux = _mapper.Map<data.Adoptantes, DataModels.Adoptantes>(adoptantes);
            if (adoptantes == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Adoptantes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdoptantes(int id, DataModels.Adoptantes adoptantes)
        {
            if (id != adoptantes.Idadoptante)
            {
                return BadRequest();
            }

            var mapaux = _mapper.Map<DataModels.Adoptantes, data.Adoptantes>(adoptantes);
            try
            {
                new BS.Adoptantes(_context).Update(mapaux);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<DataModels.Adoptantes>> PostAdoptantes(DataModels.Adoptantes adoptantes)
        {
            var mapaux = _mapper.Map<DataModels.Adoptantes, data.Adoptantes>(adoptantes);
            new BS.Adoptantes(_context).Insert(mapaux);

            return CreatedAtAction("GetAdoptantes", new { id = adoptantes.Idadoptante }, adoptantes);
        }

        // DELETE: api/Adoptantes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Adoptantes>> DeleteAdoptantes(int id)
        {
            var adoptantes = new BS.Adoptantes(_context).GetOneById(id);
            if (adoptantes == null)
            {
                return NotFound();
            }

            new BS.Adoptantes(_context).Delete(adoptantes);
            var mapaux = _mapper.Map<data.Adoptantes, DataModels.Adoptantes>(adoptantes);
            return mapaux;
        }

        private bool AdoptantesExists(int id)
        {
            return _context.Adoptantes.Any(e => e.Idadoptante == id);
        }
    }
}
