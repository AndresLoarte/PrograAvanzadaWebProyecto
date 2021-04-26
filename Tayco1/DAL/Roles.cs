using DAL.EF;
using DAL.Repository;
using DO.Interface;
using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;

namespace DAL
{
    public class Roles : ICRUD<data.Roles>
    {
        private Repository<data.Roles> _repo = null;

        public Roles(SolutionDBContext solutionDbContext)
        {
            _repo = new Repository<data.Roles>(solutionDbContext);
        }

        public void Delete(data.Roles t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Roles> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Roles GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Roles t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Roles t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

   
    }
}
