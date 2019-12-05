using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Interfaces
{
    public class ProductRepository : IProductRepository
    {
        private ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            _context.Products.Add(product).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        => await _context.Products.ToListAsync();

        public async Task<Product> GetProductAsync(int id)
            => await _context.Products.FindAsync(id);

        public async Task<Product> UpdateAsync(Product product)
        {

            if (await _context.Products.AnyAsync(_ => _.Id == product.Id))
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return product;
            }
            throw new KeyNotFoundException($"Product (key - {product.Id}) information is not found   is not found");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product Id {id} is not found");
            _context.Remove(product).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
