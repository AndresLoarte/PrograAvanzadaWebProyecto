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
    public class RolesController : ControllerBase
    {

        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public RolesController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Roles>>> GetRoles()
        {
            var aux = new BS.Roles(_context).GetAll().ToList();
            var mappaux = _mapper.Map<IEnumerable<data.Roles>, IEnumerable<DataModels.Roles>>(aux).ToList();
            return mappaux.ToList();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Roles>> GetRoles(int id)
        {
            var roles = new BS.Roles(_context).GetOneById(id);

            var mappaux = _mapper.Map<data.Roles, DataModels.Roles>(roles);

            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoles(int id, DataModels.Roles roles)
        {
            if (id != roles.RoleId)
            {
                return BadRequest();
            }

            try
            {

                var mappaux = _mapper.Map<DataModels.Roles, data.Roles>(roles);

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

        // POST: api/Roles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Roles>> PostRoles(DataModels.Roles roles)
        {
            var mappaux = _mapper.Map<DataModels.Roles, data.Roles>(roles);

            new BS.Roles(_context).Insert(mappaux);

            return CreatedAtAction("GetRoles", new { id = roles.RoleId }, roles);

        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Roles>> DeleteRoles(int id)
        {
            var roles  = new BS.Roles(_context).GetOneById(id);
            if (roles == null)
            {
                return NotFound();
            }

            new BS.Roles(_context).Delete(roles);
            var mappaux = _mapper.Map<data.Roles, DataModels.Roles>(roles);

            return mappaux;
        }

        private bool RolesExists(int id)
        {
            return (new BS.Roles(_context).GetOneById(id) != null);
        }

    }
}
