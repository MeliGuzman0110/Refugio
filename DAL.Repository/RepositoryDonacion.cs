using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DO.Objects;
using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class RepositoryDonacion : Repository<Donacion>, IRepositoryDonacion
    {
        public RepositoryDonacion(RefugioAnimalDBContext context)
            : base(context)
        { }
        private RefugioAnimalDBContext RefugioAnimalDBContext
        {
            get { return dBContext as RefugioAnimalDBContext; }
        }

        public async Task<IEnumerable<Donacion>> GetAllWithAsync()
        {
            return await RefugioAnimalDBContext.Donacion
                .Include(m => m.IddonanteNavigation)
                .ToListAsync();
        }

        public async Task<Donacion> GetWithByIdAsync(int id)
        {
            return await RefugioAnimalDBContext.Donacion
               .Include(m => m.IddonanteNavigation)
               .SingleOrDefaultAsync(m => m.Iddonante == id);
        }
    }
}
