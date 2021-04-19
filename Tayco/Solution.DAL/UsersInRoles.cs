using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class UsersInRoles : ICRUD<data.UsersInRoles>
    {

        private RepositoryUsersInRoles _repo = null;

        public UsersInRoles(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryUsersInRoles(solutionDbContext);
        }

        public void Delete(data.UsersInRoles t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.UsersInRoles> GetAll()
        {
            return _repo.GetAll();
        }

        public data.UsersInRoles GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.UsersInRoles t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.UsersInRoles t)
        {
            _repo.Update(t);
            _repo.Commit(); ;
        }

        public async Task<IEnumerable<data.UsersInRoles>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.UsersInRoles> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

    }

}
