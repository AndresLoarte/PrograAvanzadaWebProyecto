using DAL.EF;
using DAL.Repository;
using DO.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Users : ICRUD<DO.Objects.Users>
    {
        private RepositoryUsers _repo = null;

        public Users(SolutionDBContext solutionDBContext)
        {
            _repo = new RepositoryUsers(solutionDBContext);
        }

        public void Delete(DO.Objects.Users t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<DO.Objects.Users> GetAll()
        {
            return _repo.GetAll();
        }

        public DO.Objects.Users GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(DO.Objects.Users t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(DO.Objects.Users t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<DO.Objects.Users>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<DO.Objects.Users> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

    }
}
