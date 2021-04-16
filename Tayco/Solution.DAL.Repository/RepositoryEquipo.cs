using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryEquipo : Repository<Equipo>, IRepositoryEquipo
    {

        public RepositoryEquipo(SolutionDBContext solutionDBContext) : base(solutionDBContext)
        {

        }

        public async Task<IEnumerable<Equipo>> GetAllWithAsync()
        {
            return await context.Equipo.Include(m => m.EquipoId).ToListAsync();
        }

        public async Task<Equipo> GetOneByIdWithAsync(int id)
        {
            return await context.Equipo.Include(m => m.TipoEquipo).SingleOrDefaultAsync(m => m.EquipoId == id);
        }

        private SolutionDBContext context
        {
            get { return dbContext as SolutionDBContext; }
        }

    }
}
