using DAL.EF;
using DO.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BS
{
    public class Users : ICRUD<DO.Objects.Users>
    {

        private SolutionDBContext context;

        public Users(SolutionDBContext _context)
        {
            this.context = _context;
        }

        public void Delete(DO.Objects.Users t)
        {
            new DAL.Users(context).Delete(t);
        }

        public IEnumerable<DO.Objects.Users> GetAll()
        {
            return new DAL.Users(context).GetAll();
        }

        public DO.Objects.Users GetOneById(int id)
        {
            return new DAL.Users(context).GetOneById(id);
        }

        public void Insert(DO.Objects.Users t)
        {
            new DAL.Users(context).Insert(t);
        }

        public void Update(DO.Objects.Users t)
        {
            new DAL.Users(context).Update(t);
        }

        public async Task<IEnumerable<DO.Objects.Users>> GetAllInclude()
        {
            return await new DAL.Users(context).GetAllInclude();
        }

        public async Task<DO.Objects.Users> GetOneByIdInclude(int id)
        {
            return await new DAL.Users(context).GetOneByIdInclude(id);
        }

    }
}
