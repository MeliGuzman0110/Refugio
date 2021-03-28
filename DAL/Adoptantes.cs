using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects;
using DAL.EF;
using DAL.Repository;

namespace DAL
{
    public class Adoptantes : ICRUD<data.Adoptantes>
    {
        private Repository<data.Adoptantes> _repo = null;
        public Adoptantes(RefugioAnimalDBContext happypetsDBContext)
        {
            _repo = new Repository<data.Adoptantes>(happypetsDBContext);
        }

        public void Delete(data.Adoptantes t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Adoptantes> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Adoptantes GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Adoptantes t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Adoptantes t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
