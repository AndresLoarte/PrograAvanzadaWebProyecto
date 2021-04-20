using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public interface IRepositoryUsersInRoles : IRepository<UsersInRoles>
    {
        Task<IEnumerable<UsersInRoles>> GetAllWithAsync();
        Task<UsersInRoles> GetOneByIdWithAsync(int Role_RoleID, int User_UserID);
    }
}
