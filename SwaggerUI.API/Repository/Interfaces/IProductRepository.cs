using Persistance.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Interfaces
{
    public interface IProductRepository
    {

        Task<Product> AddAsync(Product customer);
        Task<Product> UpdateAsync(Product customer);
        Task<bool> DeleteAsync(int id);
        Task<Product> GetProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductAsync();

    }
}
