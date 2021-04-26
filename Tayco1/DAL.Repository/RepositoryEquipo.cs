using Microsoft.EntityFrameworkCore;
using DAL.EF;
using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryEquipo : Repository<Equipo>, IRepositoryEquipo
    {

        public RepositoryEquipo(SolutionDBContext solutionDBContext) : base(solutionDBContext)
        {

        }

        public async Task<IEnumerable<Equipo>> GetAllWithAsync()
        {
            return await context.Equipo.Include(m => m.TipoEquipo).ToListAsync();
        }

        public async Task<Equipo> GetOneByIdWithAsync(int id)
        {
            return await context.Equipo.Include(m => m.TipoEquipo).SingleOrDefaultAsync(n => n.EquipoId == id);
        }

        private SolutionDBContext context
        {
            get { return dbContext as SolutionDBContext; }
        }

    }
}