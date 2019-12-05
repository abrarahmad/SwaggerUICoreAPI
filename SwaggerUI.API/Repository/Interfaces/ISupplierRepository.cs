using Persistance.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Interfaces
{
    public interface ISupplierRepository
    {

        Task<Supplier> AddAsync(Supplier supplier);
        Task<Supplier> UpdateAsync(Supplier supplier);
        Task<bool> DeleteAsync(int id);
        Task<Supplier> GetSupplierAsync(int id);
        Task<IEnumerable<Supplier>> GetAllSupplierAsync();

    }
}
