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
    public class Equipo : ICRUD<data.Equipo>
    {

        private IRepositoryEquipo _repo = null;

        public Equipo(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryEquipo(solutionDbContext);
        }

        public void Delete(data.Equipo t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Equipo> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Equipo GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Equipo t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Equipo t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Equipo>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.Equipo> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

    }
}
