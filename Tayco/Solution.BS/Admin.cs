using Solution.DAL.EF;
using Solution.DO.Interfases;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.BS
{

    public class Admin : ICRUD<Administrador>
    {

        private SolutionDBContext dbContext = null;

        public Admin(SolutionDBContext context)
        {
            this.dbContext = context;
        }

        public void Delete(Administrador t)
        {
            new DAL.Admin(dbContext).Delete(t);
        }

        public IEnumerable<Administrador> GetAll()
        {
            return new DAL.Admin(dbContext).GetAll();
        }

        public Administrador GetOneById(int id)
        {
            return new DAL.Admin(dbContext).GetOneById(id);
        }

        public void Insert(Administrador t)
        {
            new DAL.Admin(dbContext).Insert(t);
        }

        public void Update(Administrador t)
        {
            new DAL.Admin(dbContext).Update(t);
        }
    }
}
