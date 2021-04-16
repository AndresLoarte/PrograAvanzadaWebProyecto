using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryCliente : IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetAllWithAsync();
        Task<Cliente> GetOneByIdWithAsync(int id);
    }
}
