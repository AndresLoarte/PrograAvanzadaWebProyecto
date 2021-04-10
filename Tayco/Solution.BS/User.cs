using Solution.DAL.EF;
using Solution.DO.Interfases;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.BS
{
    public class User : ICRUD<Users>
    {
        private SolutionDBContext dbContext = null;

        public User(SolutionDBContext context)
        {
            this.dbContext = context;
        }

        public void Delete(Users t)
        {
            new DAL.User(dbContext).Delete(t);
        }

        public IEnumerable<Users> GetAll()
        {
            return new DAL.User(dbContext).GetAll();
        }

        public Users GetOneById(int id)
        {
            return new DAL.User(dbContext).GetOneById(id);
        }

        public void Insert(Users t)
        {
            new DAL.User(dbContext).Insert(t);
        }

        public void Update(Users t)
        {
            new DAL.User(dbContext).Update(t);
        }
    }
}
