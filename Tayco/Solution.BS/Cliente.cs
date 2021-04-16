using Solution.DAL.EF;
using Solution.DO.Interfases;
using data = Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BS
{
    public class Cliente : ICRUD<data.Cliente>
    {
        private SolutionDBContext _repo = null;

        public Cliente(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }

        public void Delete(data.Cliente t)
        {
            new DAL.Cliente(_repo).Delete(t);
        }

        public IEnumerable<data.Cliente> GetAll()
        {
            return new DAL.Cliente(_repo).GetAll();
        }

        public data.Cliente GetOneById(int id)
        {

            return new DAL.Cliente(_repo).GetOneById(id);
        }

        public void Insert(data.Cliente t)
        {

            new DAL.Cliente(_repo).Insert(t);
        }

        public void Update(data.Cliente t)
        {

            new DAL.Cliente(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Cliente>> GetAllInclude()
        {
            return await new DAL.Cliente(_repo).GetAllInclude();
        }

        public async Task<data.Cliente> GetOneByIdInclude(int id)
        {
            return await new DAL.Cliente(_repo).GetOneByIdInclude(id);
        }

    }
}
