using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.DAL.EF;
using data = Solution.DO.Objects;
using AutoMapper;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public AuditoriaController(SolutionDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/Auditoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Auditoria>>> GetAuditoria()
        {
            // carga de datos
            var aux = await new BS.Auditoria(_context).GetAllInclude();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.Auditoria>, IEnumerable<DataModels.Auditoria>>(aux).ToList();
            return mappaux;

        }

        // GET: api/Auditoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Auditoria>> GetAuditoria(int id)
        {
            // carga de datos
            var aux = await new BS.Auditoria(_context).GetOneByIdInclude(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.Auditoria, DataModels.Auditoria>(aux);
            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Auditoria/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuditoria(int id, DataModels.Auditoria Auditoria)
        {
            if (id != Auditoria.ReservaId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.Auditoria, data.Auditoria>(Auditoria);
                new BS.Auditoria(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!AuditoriaExists(id))
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

        // POST: api/Auditoria
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Auditoria>> PostAuditoria(DataModels.Auditoria Auditoria)
        {
            var mappaux = _mapper.Map<DataModels.Auditoria, data.Auditoria>(Auditoria);
            new BS.Auditoria(_context).Insert(mappaux);

            return CreatedAtAction("GetAuditoria", new { id = Auditoria.AuditoriaId }, Auditoria);
        }

        // DELETE: api/Auditoria/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Auditoria>> DeleteAuditoria(int id)
        {
            var Auditoria = new BS.Auditoria(_context).GetOneById(id);
            if (Auditoria == null)
            {
                return NotFound();
            }

            new BS.Auditoria(_context).Delete(Auditoria);
            var mappaux = _mapper.Map<data.Auditoria, DataModels.Auditoria>(Auditoria);

            return mappaux;
        }

        private bool AuditoriaExists(int id)
        {
            return (new BS.Auditoria(_context).GetOneById(id) != null);
        }

    }
}
