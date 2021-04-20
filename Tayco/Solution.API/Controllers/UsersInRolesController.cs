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
    public class UsersInRolesController : ControllerBase
    {

        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public UsersInRolesController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/UsersInRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.UsersInRoles>>> GetUsersInRoles()
        {
            var aux = await new BS.UsersInRoles(_context).GetAllInclude();

            //implementacion del automapper
            var mappaux = _mapper.Map<IEnumerable<data.UsersInRoles>, IEnumerable<DataModels.UsersInRoles>>(aux).ToList();
            return mappaux;
        }

        // GET: api/UsersInRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.UsersInRoles>> GetUsersInRoles(int Role_RoleID, int User_UserID)
        {
            // carga de datos
            var aux = await new BS.UsersInRoles(_context).GetOneByIdInclude(Role_RoleID, User_UserID);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.UsersInRoles, DataModels.UsersInRoles>(aux);
            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/UsersInRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersInRoles(int id, DataModels.UsersInRoles usersInRoles)
        {
            if (id != usersInRoles.UserUserId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.UsersInRoles, data.UsersInRoles>(usersInRoles);
                new BS.UsersInRoles(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!UsersInRolesExists(id))
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

        // POST: api/UsersInRoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.UsersInRoles>> PostUsersInRoles(DataModels.UsersInRoles usersInRoles)
        {
            var mappaux = _mapper.Map<DataModels.UsersInRoles, data.UsersInRoles>(usersInRoles);
            new BS.UsersInRoles(_context).Insert(mappaux);

            return CreatedAtAction("GetUsersInRoles", new { id = usersInRoles.UserUserId }, usersInRoles);
        }

        // DELETE: api/UsersInRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.UsersInRoles>> DeleteUsersInRoles(int id)
        {
            var usersinRoles = new BS.UsersInRoles(_context).GetOneById(id);
            if (usersinRoles == null)
            {
                return NotFound();
            }

            new BS.UsersInRoles(_context).Delete(usersinRoles);
            var mappaux = _mapper.Map<data.UsersInRoles, DataModels.UsersInRoles>(usersinRoles);

            return mappaux;
        }

        private bool UsersInRolesExists(int id)
        {
            return (new BS.UsersInRoles(_context).GetOneById(id) != null);
        }

    }
}
