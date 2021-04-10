using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Solution.API.W.Models;

namespace Solution.API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersInRolesController : ControllerBase
    {
        private readonly TaycoContext _context;

        public UsersInRolesController(TaycoContext context)
        {
            _context = context;
        }

        // GET: api/UsersInRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersInRoles>>> GetUsersInRoles()
        {
            return await _context.UsersInRoles.ToListAsync();
        }

        // GET: api/UsersInRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersInRoles>> GetUsersInRoles(int id)
        {
            var usersInRoles = await _context.UsersInRoles.FindAsync(id);

            if (usersInRoles == null)
            {
                return NotFound();
            }

            return usersInRoles;
        }

        // PUT: api/UsersInRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersInRoles(int id, UsersInRoles usersInRoles)
        {
            if (id != usersInRoles.RoleRoleId)
            {
                return BadRequest();
            }

            _context.Entry(usersInRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
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
        public async Task<ActionResult<UsersInRoles>> PostUsersInRoles(UsersInRoles usersInRoles)
        {
            _context.UsersInRoles.Add(usersInRoles);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsersInRolesExists(usersInRoles.RoleRoleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsersInRoles", new { id = usersInRoles.RoleRoleId }, usersInRoles);
        }

        // DELETE: api/UsersInRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsersInRoles>> DeleteUsersInRoles(int id)
        {
            var usersInRoles = await _context.UsersInRoles.FindAsync(id);
            if (usersInRoles == null)
            {
                return NotFound();
            }

            _context.UsersInRoles.Remove(usersInRoles);
            await _context.SaveChangesAsync();

            return usersInRoles;
        }

        private bool UsersInRolesExists(int id)
        {
            return _context.UsersInRoles.Any(e => e.RoleRoleId == id);
        }
    }
}
