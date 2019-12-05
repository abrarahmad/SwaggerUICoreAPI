using Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDto> AddAsync(CustomerDto customerDto);
        Task<CustomerDto> UpdateAsync(CustomerDto customerDto);
        Task<bool> DeleteAsync(int id);
        Task<CustomerDto> GetCustomerAsync(int id);
        Task<IEnumerable<CustomerDto>> GetAllCustomerAsync();
    }
}
