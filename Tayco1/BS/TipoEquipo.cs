using DAL.EF;
using DO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS
{
    public class TipoEquipo : ICRUD<DO.Objects.TipoEquipo>
    {

        private SolutionDBContext context;

        public TipoEquipo(SolutionDBContext _context)
        {
            this.context = _context;
        }

        public void Delete(DO.Objects.TipoEquipo t)
        {
            new DAL.TipoEquipo(context).Delete(t);
        }

        public IEnumerable<DO.Objects.TipoEquipo> GetAll()
        {
            return new DAL.TipoEquipo(context).GetAll();
        }

        public DO.Objects.TipoEquipo GetOneById(int id)
        {
            return new DAL.TipoEquipo(context).GetOneById(id);
        }

        public void Insert(DO.Objects.TipoEquipo t)
        {
            new DAL.TipoEquipo(context).Insert(t);
        }

        public void Update(DO.Objects.TipoEquipo t)
        {
            new DAL.TipoEquipo(context).Insert(t);
        }
    }
}
