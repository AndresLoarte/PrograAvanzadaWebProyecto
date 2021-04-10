using data = Solution.DO;
using System;
using System.Collections.Generic;
using System.Text;
using Solution.DO.Interfases;
using Solution.DO.Objects;
using Solution.DAL.Repository;
using Solution.DAL.EF;

namespace Solution.DAL
{
    public class Admin : ICRUD<data.Objects.Administrador>
    {

        private Repository<data.Objects.Administrador> _repo = null;

        public Admin(SolutionDBContext solutionDbContext)
        {
            _repo = new Repository<data.Objects.Administrador>(solutionDbContext);
        }

        public void Delete(Administrador t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<Administrador> GetAll()
        {
            return _repo.GetAll();
        }

        public Administrador GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(Administrador t)
        {
            try
            {
                _repo.Insert(t);
                _repo.Commit();
            }
            catch (Exception ee)
            {

            }
        }

        public void Update(Administrador t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
