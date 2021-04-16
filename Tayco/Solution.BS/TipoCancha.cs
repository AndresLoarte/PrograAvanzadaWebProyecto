using Solution.DAL.EF;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.BS
{
    public class TipoCancha : ICRUD<DO.Objects.TipoCancha>
    {

        private SolutionDBContext context;

        public TipoCancha(SolutionDBContext _context)
        {
            this.context = _context;
        }

        public void Delete(DO.Objects.TipoCancha t)
        {
            new DAL.TipoCancha(context).Delete(t);
        }

        public IEnumerable<DO.Objects.TipoCancha> GetAll()
        {
            return new DAL.TipoCancha(context).GetAll();
        }

        public DO.Objects.TipoCancha GetOneById(int id)
        {
            return new DAL.TipoCancha(context).GetOneById(id);
        }

        public void Insert(DO.Objects.TipoCancha t)
        {
            new DAL.TipoCancha(context).Insert(t);
        }

        public void Update(DO.Objects.TipoCancha t)
        {
            new DAL.TipoCancha(context).Update(t);
        }
    }
}
