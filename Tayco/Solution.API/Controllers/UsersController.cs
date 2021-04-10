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
    public class UsersController : ControllerBase
    {
        private readonly SolutionDBContext _context;
        private readonly IMapper _mapper;

        public UsersController(SolutionDBContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Users>>> GetUsers()
        {

            var aux = new BS.User(_context).GetAll().ToList();
            var mappaux = _mapper.Map<IEnumerable<data.Users>, IEnumerable<DataModels.Users>>(aux).ToList();
            return mappaux.ToList();

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Users>> GetUsers(int id)
        {
            var users = new BS.User(_context).GetOneById(id);

            var mappaux = _mapper.Map<data.Users, DataModels.Users>(users);

            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, DataModels.Users users)
        {
            if (id != users.UserId)
            {
                return BadRequest();
            }

            try
            {

                var mappaux = _mapper.Map<DataModels.Users, data.Users>(users);

                new BS.User(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Users>> PostUsers(DataModels.Users users)
        {
            var mappaux = _mapper.Map<DataModels.Users, data.Users>(users);

            new BS.User(_context).Insert(mappaux);

            return CreatedAtAction("GetGroups", new { id = users.UserId }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Users>> DeleteUsers(int id)
        {
            var users = new BS.User(_context).GetOneById(id);
            if (users == null)
            {
                return NotFound();
            }

            new BS.User(_context).Delete(users);
            var mappaux = _mapper.Map<data.Users, DataModels.Users>(users);

            return mappaux;
        }

        private bool UsersExists(int id)
        {
            return (new BS.User(_context).GetOneById(id) != null);
        }
    }
}
