using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryUsersInRoles : Repository<UsersInRoles>, IRepositoryUsersInRoles
    {

        public RepositoryUsersInRoles(SolutionDBContext solutionDBContext) : base(solutionDBContext)
        {

        }

        private SolutionDBContext context
        {
            get { return dbContext as SolutionDBContext; }
        }

        public async Task<IEnumerable<UsersInRoles>> GetAllWithAsync()
        {
            return await context.UsersInRoles.Include(m => m.UserUser).Include(n => n.RoleRole).ToListAsync();
        }

        public async Task<UsersInRoles> GetOneByIdWithAsync(int Role_RoleID, int User_UserID)
        {
            return await context.UsersInRoles.Include(m => m.UserUser).Include(n => n.RoleRole).SingleOrDefaultAsync(m => m.RoleRoleId == Role_RoleID && m.UserUserId == User_UserID);
        }

    }

}
