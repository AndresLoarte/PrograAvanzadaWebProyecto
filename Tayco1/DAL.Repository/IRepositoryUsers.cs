using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepositoryUsers : IRepository<Users>
    {
        Task<IEnumerable<Users>> GetAllWithAsync();
        Task<Users> GetOneByIdWithAsync(int id);
    }
}