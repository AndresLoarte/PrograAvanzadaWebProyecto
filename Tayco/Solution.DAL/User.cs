using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO;

namespace Solution.DAL
{
    public class User : ICRUD<data.Objects.Users>
    {

        private Repository<data.Objects.Users> _repo = null;

        public User(SolutionDBContext solutionDbContext)
        {
            _repo = new Repository<data.Objects.Users>(solutionDbContext);
        }

        public void Delete(data.Objects.Users t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Objects.Users> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Objects.Users GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Objects.Users t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Objects.Users t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
