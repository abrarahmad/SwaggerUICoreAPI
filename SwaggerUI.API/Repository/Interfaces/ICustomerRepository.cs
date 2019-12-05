using Persistance.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Interfaces
{
    public interface ICustomerRepository
    {

        Task<Customer> AddAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(int id);
        Task<Customer> GetCustomerAsync(int id);
        Task<IEnumerable<Customer>> GetAllCustomerAsync();

    }
}
