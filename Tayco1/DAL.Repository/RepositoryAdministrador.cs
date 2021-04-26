using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
   public class RepositoryAdministrador : Repository<Administrador>, IRepositoryAdministrador
    {

        public RepositoryAdministrador(SolutionDBContext solutionDBContext) : base(solutionDBContext)
        {

        }

        public async Task<IEnumerable<Administrador>> GetAllWithAsync()
        {
            return await context.Administrador.Include(m => m.Role).ToListAsync();
        }

        public async Task<Administrador> GetOneByIdWithAsync(int id)
        {
            return await context.Administrador.Include(m => m.Role).SingleOrDefaultAsync(n => n.AdministradorId == id);
        }

        private SolutionDBContext context
        {
            get { return dbContext as SolutionDBContext; }
        }
    }
}