using Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierDto> AddAsync(SupplierDto supplier);
        Task<SupplierDto> UpdateAsync(SupplierDto supplier);
        Task<bool> DeleteAsync(int id);
        Task<SupplierDto> GetSupplierAsync(int id);
        Task<IEnumerable<SupplierDto>> GetAllSupplierAsync();
    }
}
