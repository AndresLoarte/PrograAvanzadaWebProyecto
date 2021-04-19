using Solution.DAL.EF;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class UsersInRoles : ICRUD<data.UsersInRoles>
    {

        private SolutionDBContext _repo = null;

        public UsersInRoles(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }

        public void Delete(data.UsersInRoles t)
        {
            new DAL.UsersInRoles(_repo).Delete(t);
        }

        public IEnumerable<data.UsersInRoles> GetAll()
        {
            return new DAL.UsersInRoles(_repo).GetAll();
        }

        public data.UsersInRoles GetOneById(int id)
        {
            return new DAL.UsersInRoles(_repo).GetOneById(id);
        }

        public void Insert(data.UsersInRoles t)
        {
            new DAL.UsersInRoles(_repo).Insert(t);
        }

        public void Update(data.UsersInRoles t)
        {
            new DAL.UsersInRoles(_repo).Update(t);
        }

        public async Task<IEnumerable<data.UsersInRoles>> GetAllInclude()
        {
            return await new DAL.UsersInRoles(_repo).GetAllInclude();
        }

        public async Task<data.UsersInRoles> GetOneByIdInclude(int id)
        {
            return await new DAL.UsersInRoles(_repo).GetOneByIdInclude(id);
        }

    }

}
