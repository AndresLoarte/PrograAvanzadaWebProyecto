using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryReserva : IRepository<Reserva>
    {
        Task<IEnumerable<Reserva>> GetAllWithAsync();
        Task<Reserva> GetOneByIdWithAsync(int id);
    }
}
