using DAL.EF;
using DO.Interface;
using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;


namespace BS
{
    public class Administrador : ICRUD<data.Administrador>
    {

        private SolutionDBContext _repo = null;

        public Administrador(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }

        public void Delete(data.Administrador t)
        {
            new DAL.Administrador(_repo).Delete(t);
        }

        public IEnumerable<data.Administrador> GetAll()
        {
            return new DAL.Administrador(_repo).GetAll();
        }

        public data.Administrador GetOneById(int id)
        {
            return new DAL.Administrador(_repo).GetOneById(id);
        }

        public void Insert(data.Administrador t)
        {
            new DAL.Administrador(_repo).Insert(t);
        }

        public void Update(data.Administrador t)
        {
            new DAL.Administrador(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Administrador>> GetAllInclude()
        {
            return await new DAL.Administrador(_repo).GetAllInclude();
        }

        public async Task<data.Administrador> GetOneByIdInclude(int id)
        {
            return await new DAL.Administrador(_repo).GetOneByIdInclude(id);
        }
    }
}
