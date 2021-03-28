using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;

namespace BS
{
    public class Adopcion : ICRUD<data.Adopcion>
    {
        private RefugioAnimalDBContext _repo = null;
        public Adopcion(RefugioAnimalDBContext happypetsDBContext)
        {
            _repo = happypetsDBContext;
        }

        public void Delete(data.Adopcion t)
        {
            new DAL.Adopcion(_repo).Delete(t);
        }

        public IEnumerable<data.Adopcion> GetAll()
        {
            return new DAL.Adopcion(_repo).GetAll();
        }

        public async Task<IEnumerable<data.Adopcion>> GetAllInclude()
        {
            return await new DAL.Adopcion(_repo).GetAllInclude();
        }

        public async Task<data.Adopcion> GetOneByIdInclude(int id)
        {
            return await new DAL.Adopcion(_repo).GetOneByIdInclude(id);
        }

        public data.Adopcion GetOneById(int id)
        {
            return new DAL.Adopcion(_repo).GetOneById(id);
        }

        public void Insert(data.Adopcion t)
        {
            new DAL.Adopcion(_repo).Insert(t);
        }

        public void Update(data.Adopcion t)
        {
            new DAL.Adopcion(_repo).Update(t);
        }
    }
}
