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
    public class Adopcion : ICRUD<data.Adopcion>
    {
        private RepositoryAdopcion _repo = null;

        public Adopcion(RefugioAnimalDBContext happypetsDBContext)
        {
            _repo = new RepositoryAdopcion(happypetsDBContext);
        }

        public void Delete(data.Adopcion t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Adopcion> GetAll()
        {
            return _repo.GetAll();
        }

        public async Task<IEnumerable<data.Adopcion>> GetAllInclude()
        {
            return await _repo.GetAllWithAsync();
        }

        public async Task<data.Adopcion> GetOneByIdInclude(int id)
        {
            return await _repo.GetWithByIdAsync(id);
        }

        public data.Adopcion GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Adopcion t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Adopcion t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
