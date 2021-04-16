using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solution.DO.Objects;
using Solution.DAL.EF;
using Microsoft.EntityFrameworkCore;


namespace Solution.DAL.Repository
{
    public class RepositoryCliente : Repository<Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(SolutionDBContext solutionDBContext) : base(solutionDBContext)
        {

        }
        // Metodo encargado de traer datos con relaciones
        // Palabra clave include donde hacer la referencia entre ambas tablas
        public async Task<IEnumerable<Cliente>> GetAllWithAsync()
        {
            return await context.Cliente.Include(m => m.Usuario).ToListAsync();
        }

        // Metodo encargado de traer datos con relaciones
        // Palabra clave include donde hacer la referencia entre ambas tablas
        // Solo trae un objeto
        public async Task<Cliente> GetOneByIdWithAsync(int id)
        {
            return await context.Cliente.Include(m => m.Usuario).SingleOrDefaultAsync(m => m.ClienteId == id);
        }

        // Metodo para obtener el context de Repository inicializado en el constructor de esta clase. 
        private SolutionDBContext context
        {
            get { return dbContext as SolutionDBContext; }
        }
    }
}
