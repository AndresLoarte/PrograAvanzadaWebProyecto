using Solution.DAL.EF;
using Solution.DO.Interfases;
using data = Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BS
{
    public class Auditoria : ICRUD<data.Auditoria>
    {
        private SolutionDBContext _repo = null;

        public Auditoria(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }

        public void Delete(data.Auditoria t)
        {
            new DAL.Auditoria(_repo).Delete(t);
        }

        public IEnumerable<data.Auditoria> GetAll()
        {
            return new DAL.Auditoria(_repo).GetAll();
        }

        public data.Auditoria GetOneById(int id)
        {

            return new DAL.Auditoria(_repo).GetOneById(id);
        }

        public void Insert(data.Auditoria t)
        {

            new DAL.Auditoria(_repo).Insert(t);
        }

        public void Update(data.Auditoria t)
        {

            new DAL.Auditoria(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Auditoria>> GetAllInclude()
        {
            return await new DAL.Auditoria(_repo).GetAllInclude();
        }

        public async Task<data.Auditoria> GetOneByIdInclude(int id)
        {
            return await new DAL.Auditoria(_repo).GetOneByIdInclude(id);
        }

    }
}
