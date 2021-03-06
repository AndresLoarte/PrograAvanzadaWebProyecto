using DAL.EF;
using DAL.Repository;
using DO.Interface;
using DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;

namespace DAL
{
   public class Administrador : ICRUD<data.Administrador>
    {
        private RepositoryAdministrador _repo = null;

        public Administrador(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryAdministrador(solutionDbContext);
        }

        public void Delete(data.Administrador t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Administrador> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Administrador GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Administrador t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Administrador t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Administrador>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.Administrador> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
