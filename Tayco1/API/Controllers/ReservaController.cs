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
    public class ReservaController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public ReservaController(SolutionDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Reserva>>> GetReserva()
        {
            // carga de datos
            var aux = await new BS.Reserva(_context).GetAllInclude();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.Reserva>, IEnumerable<DataModels.Reserva>>(aux).ToList();
            return mappaux;

        }

        // GET: api/Reserva/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Reserva>> GetReserva(int id)
        {
            // carga de datos
            var aux = await new BS.Reserva(_context).GetOneByIdInclude(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.Reserva, DataModels.Reserva>(aux);
            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Reserva/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, DataModels.Reserva Reserva)
        {
            if (id != Reserva.ReservaId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.Reserva, data.Reserva>(Reserva);
                new BS.Reserva(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!ReservaExists(id))
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

        // POST: api/Reserva
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Reserva>> PostReserva(DataModels.Reserva Reserva)
        {
            var mappaux = _mapper.Map<DataModels.Reserva, data.Reserva>(Reserva);
            new BS.Reserva(_context).Insert(mappaux);

            return CreatedAtAction("GetReserva", new { id = Reserva.ReservaId }, Reserva);
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Reserva>> DeleteReserva(int id)
        {
            var Reserva = new BS.Reserva(_context).GetOneById(id);
            if (Reserva == null)
            {
                return NotFound();
            }

            new BS.Reserva(_context).Delete(Reserva);
            var mappaux = _mapper.Map<data.Reserva, DataModels.Reserva>(Reserva);

            return mappaux;
        }

        private bool ReservaExists(int id)
        {
            return (new BS.Reserva(_context).GetOneById(id) != null);
        }
    }
}
