using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO;

namespace Solution.DAL
{
    public class Roles : ICRUD<data.Objects.Roles>
    {

        private Repository<data.Objects.Roles> _repo = null;

        public Roles(SolutionDBContext solutionDbContext)
        {
            _repo = new Repository<data.Objects.Roles>(solutionDbContext);
        }

        public void Delete(data.Objects.Roles t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Objects.Roles> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Objects.Roles GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Objects.Roles t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Objects.Roles t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
