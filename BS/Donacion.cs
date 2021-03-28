using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DO.Objects;

namespace BS
{
    public class Donacion : ICRUD<data.Donacion>
    {
        private RefugioAnimalDBContext _repo = null;
        public Donacion(RefugioAnimalDBContext happypetsDBContext)
        {
            _repo = happypetsDBContext;
        }
        public void Delete(data.Donacion t)
        {
            new DAL.Donacion(_repo).Delete(t);
        }

        public IEnumerable<data.Donacion> GetAll()
        {
            return new DAL.Donacion(_repo).GetAll();
        }
        public async Task<IEnumerable<data.Donacion>> GetAllInclude()
        {
            return await new DAL.Donacion(_repo).GetAllInclude();
        }

        public async Task<data.Donacion> GetOneByIdInclude(int id)
        {
            return await new DAL.Donacion(_repo).GetOneByIdInclude(id);
        }

        public data.Donacion GetOneById(int id)
        {
            return new DAL.Donacion(_repo).GetOneById(id);
        }

        public void Insert(data.Donacion t)
        {
            new DAL.Donacion(_repo).Insert(t);
        }

        public void Update(data.Donacion t)
        {
            new DAL.Donacion(_repo).Update(t);
        }
    }
}
