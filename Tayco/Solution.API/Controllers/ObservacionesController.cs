using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.DAL.EF;
using data = Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacionesController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public ObservacionesController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Observaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Observaciones>>> GetObservaciones()
        {

            var aux = new BS.Observaciones(_context).GetAll().ToList();
            var mappaux = _mapper.Map<IEnumerable<data.Observaciones>, IEnumerable<DataModels.Observaciones>>(aux).ToList();
            return mappaux.ToList();

        }

        // GET: api/Observaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Observaciones>> GetObservaciones(int id)
        {
            var observaciones = new BS.Observaciones(_context).GetOneById(id);

            var mappaux = _mapper.Map<data.Observaciones, DataModels.Observaciones>(observaciones);

            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Observaciones/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObservaciones(int id, DataModels.Observaciones observaciones)
        {
            if (id != observaciones.ObservacionesId)
            {
                return BadRequest();
            }

            try
            {

                var mappaux = _mapper.Map<DataModels.Observaciones, data.Observaciones>(observaciones);

                new BS.Observaciones(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!ObservacionesExists(id))
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

        // POST: api/Observaciones
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Observaciones>> PostObservaciones(DataModels.Observaciones observaciones)
        {
            var mappaux = _mapper.Map<DataModels.Observaciones, data.Observaciones>(observaciones);

            new BS.Observaciones(_context).Insert(mappaux);

            return CreatedAtAction("GetObservaciones", new { id = observaciones.ObservacionesId }, observaciones);
        }

        // DELETE: api/Observaciones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Observaciones>> DeleteObservaciones(int id)
        {
            var observaciones = new BS.Observaciones(_context).GetOneById(id);
            if (observaciones == null)
            {
                return NotFound();
            }

            new BS.Observaciones(_context).Delete(observaciones);
            var mappaux = _mapper.Map<data.Observaciones, DataModels.Observaciones>(observaciones);

            return mappaux;
        }

        private bool ObservacionesExists(int id)
        {
            return (new BS.Observaciones(_context).GetOneById(id) != null);
        }
    }
}
