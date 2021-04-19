using System;
using System.Collections.Generic;
using System.Text;
using Solution.DO.Objects;
using Solution.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryAuditoria : Repository<Auditoria>, IRepositoryAuditoria
    {
        public RepositoryAuditoria(SolutionDBContext solutionDBContext) : base(solutionDBContext)
        {

        }
        // Metodo encargado de traer datos con relaciones
        // Palabra clave include donde hacer la referencia entre ambas tablas
        public async Task<IEnumerable<Auditoria>> GetAllWithAsync()
        {
            return await context.Auditoria.Include(m => m.Reserva).ToListAsync();
        }

        // Metodo encargado de traer datos con relaciones
        // Palabra clave include donde hacer la referencia entre ambas tablas
        // Solo trae un objeto
        public async Task<Auditoria> GetOneByIdWithAsync(int id)
        {
            return await context.Auditoria.Include(m => m.Reserva).SingleOrDefaultAsync(m => m.AuditoriaId == id);
        }


        // Metodo para obtener el context de Repository inicializado en el constructor de esta clase. 
        private SolutionDBContext context
        {
            get { return dbContext as SolutionDBContext; }
        }
    }
}
