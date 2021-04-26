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
    public class RolesController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public RolesController(SolutionDBContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }

        // GET: api/Roless
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Roles>>> GetRoles()
        {
            // carga de datos
            var aux =  new BS.Roles(_context).GetAll().ToList();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.Roles>, IEnumerable<DataModels.Roles>>(aux).ToList();
            return mappaux;
        }

        // GET: api/Roless/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Roles>> GetRoles(int id)
        {
            // carga de datos
            var aux =  new BS.Roles(_context).GetOneById(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.Roles, DataModels.Roles>(aux);
            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Roless/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, DataModels.Roles Roles)
        {
            if (id != Roles.RoleId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.Roles, data.Roles>(Roles);
                new BS.Roles(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!RolesExists(id))
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

        // POST: api/Roless
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Roles>> PostRoles(DataModels.Roles Roles)
        {
            var mappaux = _mapper.Map<DataModels.Roles, data.Roles>(Roles);
            new BS.Roles(_context).Insert(mappaux);

            return CreatedAtAction("GetRoles", new { id = Roles.RoleId }, Roles);
        }

        // DELETE: api/Roless/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Roles>> DeleteRoles(int id)
        {
            var admin = new BS.Roles(_context).GetOneById(id);
            if (admin == null)
            {
                return NotFound();
            }

            new BS.Roles(_context).Delete(admin);
            var mappaux = _mapper.Map<data.Roles, DataModels.Roles>(admin);

            return mappaux;
        }

        private bool RolesExists(int id)
        {
            return (new BS.Roles(_context).GetOneById(id) != null);
        }
    }
}
