using Solution.DAL.EF;
using Solution.DO.Interfases;
using data = Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.BS
{
    public class Reserva : ICRUD<data.Reserva>
    {
        private SolutionDBContext _repo = null;

        public Reserva(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }

        public void Delete(data.Reserva t)
        {
            new DAL.Reserva(_repo).Delete(t);
        }

        public IEnumerable<data.Reserva> GetAll()
        {
            return new DAL.Reserva(_repo).GetAll();
        }

        public data.Reserva GetOneById(int id)
        {

            return new DAL.Reserva(_repo).GetOneById(id);
        }

        public void Insert(data.Reserva t)
        {

            new DAL.Reserva(_repo).Insert(t);
        }

        public void Update(data.Reserva t)
        {

            new DAL.Reserva(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Reserva>> GetAllInclude()
        {
            return await new DAL.Reserva(_repo).GetAllInclude();
        }

        public async Task<data.Reserva> GetOneByIdInclude(int id)
        {
            return await new DAL.Reserva(_repo).GetOneByIdInclude(id);
        }

    }
}
