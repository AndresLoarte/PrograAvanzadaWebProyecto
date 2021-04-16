using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Cliente : ICRUD<data.Cliente>
    {
        private RepositoryCliente _repo = null;

        public Cliente(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryCliente(solutionDbContext);
        }

        public void Delete(data.Cliente t)
        {
            _repo.Delete(t);
            _repo.Commit(); ;
        }

        public data.Cliente GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Cliente t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }


        public void Update(data.Cliente t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public IEnumerable<data.Cliente> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Cliente>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.Cliente> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
