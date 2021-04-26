using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solution.DO.Objects;
using Solution.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace Solution.DAL.Repository
{
    public class RepositoryAdministrador : Repository<Administrador>, IRepositoryAdministrador
    {

        public RepositoryAdministrador(SolutionDBContext solutionDBContext) : base(solutionDBContext)
        {

        }

        public async Task<IEnumerable<Administrador>> GetAllWithAsync()
        {
            return await context.Administrador.Include(m => m.Usuario).ToListAsync();
        }

        public async Task<Administrador> GetOneByIdWithAsync(int id)
        {
            return await context.Administrador.Include(m => m.Usuario).SingleOrDefaultAsync(m => m.AdministradorID == id);
        }

        private SolutionDBContext context
        {
            get { return dbContext as SolutionDBContext; }
        }
    }
}
