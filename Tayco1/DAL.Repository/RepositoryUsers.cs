using DAL.EF;
using DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryUsers : Repository<Users>, IRepositoryUsers
    {
        public RepositoryUsers(SolutionDBContext solutionDBContext) : base(solutionDBContext) { }

        private SolutionDBContext context
        {
            get { return dbContext as SolutionDBContext; }
        }

        public async Task<IEnumerable<Users>> GetAllWithAsync()
        {
            return await context.Users.Include(m => m.Role).ToArrayAsync();
        }

        public async Task<Users> GetOneByIdWithAsync(int id)
        {
            return await context.Users.Include(m => m.Role).SingleOrDefaultAsync(n => n.UserId == id);
        }
    }
}
