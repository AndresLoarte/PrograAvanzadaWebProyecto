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
    public class AdministradorController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public AdministradorController(SolutionDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/Administradors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Administrador>>> GetAdministrador()
        {
            var aux = new BS.Admin(_context).GetAll().ToList();
            var mappaux = _mapper.Map<IEnumerable<data.Administrador>, IEnumerable<DataModels.Administrador>>(aux).ToList();
            return mappaux;
        }

        // GET: api/Administradors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Administrador>> GetAdministrador(int id)
        {
            var admin = new BS.Admin(_context).GetOneById(id);

            var mappaux = _mapper.Map<data.Administrador, DataModels.Administrador>(admin);

            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;

        }

        // PUT: api/Administradors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdministrador(int id, DataModels.Administrador administrador)
        {
            if (id != administrador.AdministradorId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.Administrador, data.Administrador>(administrador);
                new BS.Admin(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!AdministradorExists(id))
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
        

        // POST: api/Administradors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Administrador>> PostAdministrador(DataModels.Administrador administrador)
        {
            var mappaux = _mapper.Map<DataModels.Administrador, data.Administrador>(administrador);
            new BS.Admin(_context).Insert(mappaux);

            return CreatedAtAction("GetFoci", new { id = administrador.AdministradorId }, administrador);
        }

        // DELETE: api/Administradors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Administrador>> DeleteAdministrador(int id)
        {
            var administrador = new BS.Admin(_context).GetOneById(id);
            if (administrador == null)
            {
                return NotFound();
            }

            new BS.Admin(_context).Delete(administrador);
            var mappaux = _mapper.Map<data.Administrador, DataModels.Administrador>(administrador);

            return mappaux;
        }

        private bool AdministradorExists(int id)
        {
        return (new BS.Admin(_context).GetOneById(id) != null);
        }
    }
}
