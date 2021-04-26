using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepositoryEquipo : IRepository<Equipo>
    {
        Task<IEnumerable<Equipo>> GetAllWithAsync();
        Task<Equipo> GetOneByIdWithAsync(int id);
    }
}
