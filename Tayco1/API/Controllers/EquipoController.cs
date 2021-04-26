using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DO.Objects;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public EquipoController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Equipoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Equipo>>> GetEquipo()
        {
            // carga de datos
            var aux = await new BS.Equipo(_context).GetAllInclude();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.Equipo>, IEnumerable<DataModels.Equipo>>(aux).ToList();
            return mappaux;
        }

        // GET: api/Equipoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Equipo>> GetEquipo(int id)
        {
            // carga de datos
            var aux = await new BS.Equipo(_context).GetOneByIdInclude(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.Equipo, DataModels.Equipo>(aux);
            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Equipoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipo(int id, DataModels.Equipo equipo)
        {
            if (id != equipo.EquipoId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.Equipo, data.Equipo>(equipo);
                new BS.Equipo(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!EquipoExists(id))
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

        // POST: api/Equipoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Equipo>> PostEquipo(DataModels.Equipo equipo)
        {
            var mappaux = _mapper.Map<DataModels.Equipo, data.Equipo>(equipo);
            new BS.Equipo(_context).Insert(mappaux);

            return CreatedAtAction("GetEquipo", new { id = equipo.EquipoId }, equipo);
        }

        // DELETE: api/Equipoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Equipo>> DeleteEquipo(int id)
        {
            var equipo = new BS.Equipo(_context).GetOneById(id);
            if (equipo == null)
            {
                return NotFound();
            }

            new BS.Equipo(_context).Delete(equipo);
            var mappaux = _mapper.Map<data.Equipo, DataModels.Equipo>(equipo);

            return mappaux;
        }

        private bool EquipoExists(int id)
        {
            return (new BS.Equipo(_context).GetOneById(id) != null);
        }
    }
}
