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
    public class Reserva : ICRUD<data.Reserva>
    {
        private RepositoryReserva _repo = null;

        public Reserva(SolutionDBContext solutionDbContext)
        {
            _repo = new RepositoryReserva(solutionDbContext);
        }

        public void Delete(data.Reserva t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Reserva> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Reserva GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Reserva t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Reserva t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Reserva>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.Reserva> GetOneByIdInclude(int id)
        {
            return await _repo.GetOneByIdWithAsync(id);
        }

    }
}
