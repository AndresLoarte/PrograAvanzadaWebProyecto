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
    public class ClienteController : ControllerBase 
    { 
    
    private readonly SolutionDBContext _context;
    private readonly IMapper _mapper;

    public ClienteController(SolutionDBContext context, IMapper mapper)
    {
        this._mapper = mapper;
        _context = context;
    }

    // GET: api/Cliente
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DataModels.Cliente>>> GetCliente()
    {
        // carga de datos
        var aux = await new BS.Cliente(_context).GetAllInclude();

        //implementacion del automapper
        var mappaux = _mapper.Map<IEnumerable<data.Cliente>, IEnumerable<DataModels.Cliente>>(aux).ToList();
        return mappaux;

    }

        //// GET: api/Cliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DataModels.Cliente>> GetCliente(int id)
        {
            // carga de datos
            var aux = await new BS.Cliente(_context).GetOneByIdInclude(id);

            //implementacion del automapper
            var mappaux = _mapper.Map<data.Cliente, DataModels.Cliente>(aux);
            if (mappaux == null)
            {
                return NotFound();
            }

            return mappaux;
        }

        // PUT: api/Cliente/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, DataModels.Cliente Cliente)
        {
            if (id != Cliente.ClienteId)
            {
                return BadRequest();
            }

            try
            {
                var mappaux = _mapper.Map<DataModels.Cliente, data.Cliente>(Cliente);
                new BS.Cliente(_context).Update(mappaux);
            }
            catch (Exception ee)
            {
                if (!ClienteExists(id))
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

        // POST: api/Cliente
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DataModels.Cliente>> PostCliente(DataModels.Cliente Cliente)
        {
            var mappaux = _mapper.Map<DataModels.Cliente, data.Cliente>(Cliente);
            new BS.Cliente(_context).Insert(mappaux);

            return CreatedAtAction("GetCliente", new { id = Cliente.ClienteId }, Cliente);
        }

        //// DELETE: api/Cliente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataModels.Cliente>> DeleteCliente(int id)
        {
            var Cliente = new BS.Cliente(_context).GetOneById(id);
            if (Cliente == null)
            {
                return NotFound();
            }

            new BS.Cliente(_context).Delete(Cliente);
            var mappaux = _mapper.Map<data.Cliente, DataModels.Cliente>(Cliente);

            return mappaux;
        }

        private bool ClienteExists(int id)
    {
        return (new BS.Cliente(_context).GetOneById(id) != null);
    }
}
}
