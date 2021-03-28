using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects;
using DAL.EF;
using DAL.Repository;

namespace DAL
{
    public class Donantes : ICRUD<data.Donantes>
    {
        private Repository<data.Donantes> _repo = null;
        public Donantes(RefugioAnimalDBContext happypetsDBContext)
        {
            _repo = new Repository<data.Donantes>(happypetsDBContext);
        }
        public void Delete(data.Donantes t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Donantes> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Donantes GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Donantes t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Donantes t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
