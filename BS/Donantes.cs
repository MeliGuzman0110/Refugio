using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects;

namespace BS
{
    public class Donantes : ICRUD<data.Donantes>
    {
        private RefugioAnimalDBContext _repo = null;
        public Donantes(RefugioAnimalDBContext happypetsDBContext)
        {
            _repo = happypetsDBContext;
        }

        public void Delete(data.Donantes t)
        {
            new DAL.Donantes(_repo).Delete(t);
        }

        public IEnumerable<data.Donantes> GetAll()
        {
            return new DAL.Donantes(_repo).GetAll();
        }

        public data.Donantes GetOneById(int id)
        {
            return new DAL.Donantes(_repo).GetOneById(id);
        }

        public void Insert(data.Donantes t)
        {
            new DAL.Donantes(_repo).Insert(t);
        }

        public void Update(data.Donantes t)
        {
            new DAL.Donantes(_repo).Update(t);
        }
    }
}
