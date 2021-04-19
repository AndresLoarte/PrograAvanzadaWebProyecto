using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solution.DO.Objects;

namespace Solution.DAL.Repository
{
   public interface IRepositoryAuditoria : IRepository<Auditoria>
    {
        Task<IEnumerable<Auditoria>> GetAllWithAsync();
        Task<Auditoria> GetOneByIdWithAsync(int id);
    }
}
