using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects;
using DAL.EF;
using DAL.Repository;
using System.Threading.Tasks;

namespace DAL
{
    public class Donacion : ICRUD<data.Donacion>
    {
        private RepositoryDonacion _repo = null;

        public Donacion(RefugioAnimalDBContext happypetsDBContext)
        {
            _repo = new RepositoryDonacion(happypetsDBContext);
        }
        public void Delete(data.Donacion t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Donacion> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Donacion>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.Donacion> GetOneByIdInclude(int id)
        {
            return await _repo.GetWithByIdAsync(id);
        }

        public data.Donacion GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Donacion t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Donacion t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
