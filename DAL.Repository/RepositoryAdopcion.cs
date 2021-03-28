using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class RepositoryAdopcion : Repository<Adopcion>, IRepositoryAdopcion
    {
        public RepositoryAdopcion(RefugioAnimalDBContext context)
            : base(context)
        { }

        private RefugioAnimalDBContext HappyPetsDBContext
        {
            get { return dBContext as RefugioAnimalDBContext; }
        }

        public async Task<IEnumerable<Adopcion>> GetAllWithAsync()
        {
            return await HappyPetsDBContext.Adopcion
                .Include(m => m.IdadoptanteNavigation)
                .ToListAsync();
        }

        public async Task<Adopcion> GetWithByIdAsync(int id)
        {
            return await HappyPetsDBContext.Adopcion
                 .Include(m => m.IdadoptanteNavigation)
                 .SingleOrDefaultAsync(m => m.Idadoptante == id);
        }
    }
}
