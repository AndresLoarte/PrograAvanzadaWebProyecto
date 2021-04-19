using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO;

namespace Solution.DAL
{
    public class Observaciones : ICRUD<data.Objects.Observaciones>
    {

        private Repository<data.Objects.Observaciones> _repo = null;

        public Observaciones(SolutionDBContext solutionDbContext)
        {
            _repo = new Repository<data.Objects.Observaciones>(solutionDbContext);
        }

        public void Delete(data.Objects.Observaciones t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Objects.Observaciones> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Objects.Observaciones GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Objects.Observaciones t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Objects.Observaciones t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

    }
}
