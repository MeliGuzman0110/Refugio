using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DO.Objects;

namespace DAL.Repository
{
    public interface IRepositoryDonacion : IRepository<Donacion>
    {
        Task<IEnumerable<Donacion>> GetAllWithAsync();
        Task<Donacion> GetWithByIdAsync(int id);
    }
}
