using DAL.EF;
using DAL.Repository;
using DO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class TipoCancha : ICRUD<DO.Objects.TipoCancha>
    {
        private Repository<DO.Objects.TipoCancha> _repo = null;

        public TipoCancha(SolutionDBContext solutionDbContext)
        {
            _repo = new Repository<DO.Objects.TipoCancha>(solutionDbContext);
        }

        public void Delete(DO.Objects.TipoCancha t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<DO.Objects.TipoCancha> GetAll()
        {
            return _repo.GetAll();
        }

        public DO.Objects.TipoCancha GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(DO.Objects.TipoCancha t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(DO.Objects.TipoCancha t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
