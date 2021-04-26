using System;
using System.Collections.Generic;
using System.Text;
using DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL.Repository
{
   public class RepositoryReserva : Repository<Reserva>, IRepositoryReserva
    {
        public RepositoryReserva(SolutionDBContext solutionDBContext) : base(solutionDBContext)
        {

        }
        // Metodo encargado de traer datos con relaciones
        // Palabra clave include donde hacer la referencia entre ambas tablas
        public async Task<IEnumerable<Reserva>> GetAllWithAsync()
        {
            return await context.Reserva.Include(m => m.User).Include(n => n.TipoCancha).Include(x => x.Equipo).ToListAsync();
        }

        // Metodo encargado de traer datos con relaciones
        // Palabra clave include donde hacer la referencia entre ambas tablas
        // Solo trae un objeto
        public async Task<Reserva> GetOneByIdWithAsync(int id)
        {
            return await context.Reserva.Include(m => m.User).Include(n => n.TipoCancha).Include(x => x.Equipo).SingleOrDefaultAsync(p => p.ReservaId == id);
        }


        // Metodo para obtener el context de Repository inicializado en el constructor de esta clase. 
        private SolutionDBContext context
        {
            get { return dbContext as SolutionDBContext; }
        }
    }
}

