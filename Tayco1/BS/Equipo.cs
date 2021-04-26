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
    public class Equipo : ICRUD<data.Equipo>
    {

        private SolutionDBContext _repo = null;

        public Equipo(SolutionDBContext solutionDBContext)
        {
            _repo = solutionDBContext;
        }

        public void Delete(data.Equipo t)
        {
            new DAL.Equipo(_repo).Delete(t);
        }

        public IEnumerable<data.Equipo> GetAll()
        {
            return new DAL.Equipo(_repo).GetAll();
        }

        public data.Equipo GetOneById(int id)
        {
            return new DAL.Equipo(_repo).GetOneById(id);
        }

        public void Insert(data.Equipo t)
        {
            new DAL.Equipo(_repo).Insert(t);
        }

        public void Update(data.Equipo t)
        {
            new DAL.Equipo(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Equipo>> GetAllInclude()
        {
            return await new DAL.Equipo(_repo).GetAllInclude();
        }

        public async Task<data.Equipo> GetOneByIdInclude(int id)
        {
            return await new DAL.Equipo(_repo).GetOneByIdInclude(id);
        }

    }
}
