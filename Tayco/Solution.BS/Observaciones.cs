using Solution.DAL.EF;
using Solution.DO.Interfases;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.BS
{
    public class Observaciones : ICRUD<DO.Objects.Observaciones>
    {
        private SolutionDBContext context;

        public Observaciones(SolutionDBContext _context)
        {
            this.context = _context;
        }

        public void Delete(DO.Objects.Observaciones t)
        {
            new DAL.Observaciones(context).Delete(t);
        }

        public IEnumerable<DO.Objects.Observaciones> GetAll()
        {
            return new DAL.Observaciones(context).GetAll();
        }

        public DO.Objects.Observaciones GetOneById(int id)
        {
            return new DAL.Observaciones(context).GetOneById(id);
        }

        public void Insert(DO.Objects.Observaciones t)
        {
            new DAL.Observaciones(context).Insert(t);
        }

        public void Update(DO.Objects.Observaciones t)
        {
            new DAL.Observaciones(context).Update(t);
        }
    }
}
