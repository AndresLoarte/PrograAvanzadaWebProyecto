using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEquipoController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public TipoEquipoController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/TipoEquipoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.TipoEquipo>>> GetTipoEquipo()
        {
            var aux = new BS.TipoEquipo(_context).GetAll().ToList();
            var mappaux = _mapper.Map<IEnumerable<data.TipoEquipo>, IEnumerable<DataModels.TipoEquipo>>(aux).ToList();
            return mappaux.ToList();
        }

        // GET: api/TipoEquipoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.TipoEquipo>> GetTipoEquipo(int id)
        {
            var users = new BS.TipoEquipo(_context).GetOneById(id);

            var mappaux = _mapper.Map<data.TipoEquipo, DataModels.TipoEquipo>(users);

            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/TipoEquipoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoEquipo(int id, DataModels.TipoEquipo tipoEquipo)
        {
            if (id != tipoEquipo.TipoEquipoId)
            {
                return BadRequest();
            }

            try
            {

                var mappaux = _mapper.Map<DataModels.TipoEquipo, data.TipoEquipo>(tipoEquipo);

                new BS.TipoEquipo(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!TipoEquipoExists(id))
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

        // POST: api/TipoEquipoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.TipoEquipo>> PostTipoEquipo(DataModels.TipoEquipo tipoEquipo)
        {
            var mappaux = _mapper.Map<DataModels.TipoEquipo, data.TipoEquipo>(tipoEquipo);

            new BS.TipoEquipo(_context).Insert(mappaux);

            return CreatedAtAction("GetTipoEquipo", new { id = tipoEquipo.TipoEquipoId }, tipoEquipo);
        }

        // DELETE: api/TipoEquipoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.TipoEquipo>> DeleteTipoEquipo(int id)
        {
            var tipoEquipo = new BS.TipoEquipo(_context).GetOneById(id);
            if (tipoEquipo == null)
            {
                return NotFound();
            }

            new BS.TipoEquipo(_context).Delete(tipoEquipo);
            var mappaux = _mapper.Map<data.TipoEquipo, DataModels.TipoEquipo>(tipoEquipo);

            return mappaux;
        }

        private bool TipoEquipoExists(int id)
        {
            return(new BS.TipoEquipo(_context).GetOneById(id) != null);
        }
    }
}
