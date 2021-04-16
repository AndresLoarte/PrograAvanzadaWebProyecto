using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO;

namespace Solution.DAL
{
    public class TipoCancha : ICRUD<data.Objects.TipoCancha>
    {

        private Repository<data.Objects.TipoCancha> _repo = null;

        public TipoCancha(SolutionDBContext solutionDbContext)
        {
            _repo = new Repository<data.Objects.TipoCancha>(solutionDbContext);
        }

        public void Delete(data.Objects.TipoCancha t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Objects.TipoCancha> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Objects.TipoCancha GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Objects.TipoCancha t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Objects.TipoCancha t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
