using Persistance.Context;
using Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.Interfaces
{
    public class CustomerRepository : ICustomerRepository
    {
        private ProductDbContext _context;
        public CustomerRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        => await _context.Customers.ToListAsync().ConfigureAwait(false);

        public async Task<Customer> GetCustomerAsync(int id)
            => await _context.Customers.FindAsync(id);

        public async Task<Customer> UpdateAsync(Customer customer)
        {

            if (await _context.Customers.AnyAsync(_ => _.Id == customer.Id))
            {
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            throw new KeyNotFoundException($"Customer (key - {customer.Id}) information is not found   is not found");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
                throw new KeyNotFoundException($"Customer Id {id} is not found");
            _context.Remove(customer).State = EntityState.Deleted;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
