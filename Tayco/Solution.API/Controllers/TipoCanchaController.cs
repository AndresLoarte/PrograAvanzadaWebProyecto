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
    public class TipoCanchaController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public TipoCanchaController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/TipoCanchas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.TipoCancha>>> GetTipoCancha()
        {
            var aux = new BS.TipoCancha(_context).GetAll().ToList();
            var mappaux = _mapper.Map<IEnumerable<data.TipoCancha>, IEnumerable<DataModels.TipoCancha>>(aux).ToList();
            return mappaux.ToList();
        }

        // GET: api/TipoCanchas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.TipoCancha>> GetTipoCancha(int id)
        {
            var tipoCancha = new BS.TipoCancha(_context).GetOneById(id);

            var mappaux = _mapper.Map<data.TipoCancha, DataModels.TipoCancha>(tipoCancha);

            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/TipoCanchas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCancha(int id, DataModels.TipoCancha tipoCancha)
        {
            if (id != tipoCancha.TipoCanchaId)
            {
                return BadRequest();
            }

            try
            {

                var mappaux = _mapper.Map<DataModels.TipoCancha, data.TipoCancha>(tipoCancha);

                new BS.TipoCancha(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!TipoCanchaExists(id))
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

        // POST: api/TipoCanchas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.TipoCancha>> PostTipoCancha(DataModels.TipoCancha tipoCancha)
        {
            var mappaux = _mapper.Map<DataModels.TipoCancha, data.TipoCancha>(tipoCancha);

            new BS.TipoCancha(_context).Insert(mappaux);

            return CreatedAtAction("GetGroups", new { id = tipoCancha.TipoCanchaId }, tipoCancha);
        }

        // DELETE: api/TipoCanchas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.TipoCancha>> DeleteTipoCancha(int id)
        {
            var tipoCancha = new BS.TipoCancha(_context).GetOneById(id);
            if (tipoCancha == null)
            {
                return NotFound();
            }

            new BS.TipoCancha(_context).Delete(tipoCancha);
            var mappaux = _mapper.Map<data.TipoCancha, DataModels.TipoCancha>(tipoCancha);

            return mappaux;
        }

        private bool TipoCanchaExists(int id)
        {
            return (new BS.TipoEquipo(_context).GetOneById(id) != null);
        }
    }
}
