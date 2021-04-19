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
    public class Auditoria : ICRUD<data.Auditoria>
    {
        private RepositoryAuditoria _repo = null;

        public Auditoria(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryAuditoria(solutionDbContext);
        }

        public void Delete(data.Auditoria t)
        {
            _repo.Delete(t);
            _repo.Commit(); ;
        }

        public data.Auditoria GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Auditoria t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }


        public void Update(data.Auditoria t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public IEnumerable<data.Auditoria> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Auditoria>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.Auditoria> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }
    }
}
