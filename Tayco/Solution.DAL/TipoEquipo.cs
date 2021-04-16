using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO;

namespace Solution.DAL
{
    public class TipoEquipo : ICRUD<data.Objects.TipoEquipo>
    {

        private Repository<data.Objects.TipoEquipo> _repo = null;

        public TipoEquipo(SolutionDBContext solutionDbContext)
        {
            _repo = new Repository<data.Objects.TipoEquipo>(solutionDbContext);
        }

        public void Delete(data.Objects.TipoEquipo t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Objects.TipoEquipo> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Objects.TipoEquipo GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Objects.TipoEquipo t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Objects.TipoEquipo t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
