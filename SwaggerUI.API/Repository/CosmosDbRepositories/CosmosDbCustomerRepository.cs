using MongoDB.Bson;
using MongoDB.Driver;
using Persistance.Context;
using Persistance.Entities;
using Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistance.CosmosDbRepositories
{
    public class CosmosDbCustomerRepository : ICustomerRepository
    {
        private CosmosDbContext _dbContext;
        public CosmosDbCustomerRepository(CosmosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Customer> AddAsync(Customer customer)
        {

            customer.Id = ObjectId.GenerateNewId().Increment;
            await _dbContext.Customers.InsertOneAsync(customer);

            return customer;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return await _dbContext.Customers.Find(_ => true).ToListAsync();
        }

        public Task<Customer> GetCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
