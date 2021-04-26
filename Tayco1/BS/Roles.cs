using DAL.EF;
using DO.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BS
{
    public class Roles : ICRUD<DO.Objects.Roles>
    {

        private SolutionDBContext context;

        public Roles(SolutionDBContext _context)
        {
            this.context = _context;
        }


        public void Delete(DO.Objects.Roles t)
        {
            new DAL.Roles(context).Delete(t);
        }

        public IEnumerable<DO.Objects.Roles> GetAll()
        {
            return new DAL.Roles(context).GetAll();
        }

        public DO.Objects.Roles GetOneById(int id)
        {
            return new DAL.Roles(context).GetOneById(id);
        }

        public void Insert(DO.Objects.Roles t)
        {
            new DAL.Roles(context).Insert(t);
        }

        public void Update(DO.Objects.Roles t)
        {
            new DAL.Roles(context).Update(t);
        }
    }
}
