using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects;

namespace BS
{
    public class Adoptantes : ICRUD<data.Adoptantes>
    {
        private RefugioAnimalDBContext _repo = null;
        public Adoptantes(RefugioAnimalDBContext happypetsDBContext)
        {
            _repo = happypetsDBContext;
        }
        public void Delete(data.Adoptantes t)
        {
            new DAL.Adoptantes(_repo).Delete(t);
        }

        public IEnumerable<data.Adoptantes> GetAll()
        {
            return new DAL.Adoptantes(_repo).GetAll();
        }

        public data.Adoptantes GetOneById(int id)
        {
            return new DAL.Adoptantes(_repo).GetOneById(id);
        }

        public void Insert(data.Adoptantes t)
        {
            new DAL.Adoptantes(_repo).Insert(t);
        }

        public void Update(data.Adoptantes t)
        {
            new DAL.Adoptantes(_repo).Update(t);
        }
    }
}
