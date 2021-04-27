using DAL.EF;
using DAL.Repository;
using DO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class TipoEquipo : ICRUD<DO.Objects.TipoEquipo>
    {
        private Repository<DO.Objects.TipoEquipo> _repo = null;

        public TipoEquipo(SolutionDBContext solutionDbContext) 
        {
            _repo = new Repository<DO.Objects.TipoEquipo>(solutionDbContext);
        }

        public void Delete(DO.Objects.TipoEquipo t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<DO.Objects.TipoEquipo> GetAll()
        {
            return _repo.GetAll();
        }

        public DO.Objects.TipoEquipo GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(DO.Objects.TipoEquipo t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(DO.Objects.TipoEquipo t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
