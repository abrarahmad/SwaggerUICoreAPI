using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using Persistance.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Interfaces
{
    public class SupplierRepository : ISupplierRepository
    {
        private ProductDbContext _context;
        public SupplierRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier> AddAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        => await _context.Suppliers.ToListAsync();

        public async Task<Supplier> GetSupplierAsync(int id)
            => await _context.Suppliers.FindAsync(id);

        public async Task<Supplier> UpdateAsync(Supplier supplier)
        {

            if (await _context.Suppliers.AnyAsync(_ => _.Id == supplier.Id))
            {
                _context.Suppliers.Update(supplier);
                await _context.SaveChangesAsync();
                return supplier;
            }
            throw new KeyNotFoundException($"Supplier (key - {supplier.Id}) information is not found   is not found");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var Supplier = await _context.Suppliers.FindAsync(id);
            if (Supplier == null)
                throw new KeyNotFoundException($"Supplier Id {id} is not found");
            _context.Remove(Supplier).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
