using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryAdopcion : IRepository<Adopcion>
    {
        Task<IEnumerable<Adopcion>> GetAllWithAsync();
        Task<Adopcion> GetWithByIdAsync(int id);
    }
}
