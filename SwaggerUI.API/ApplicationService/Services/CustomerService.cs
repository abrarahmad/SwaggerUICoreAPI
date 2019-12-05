using ApplicationService.Interfaces;
using AutoMapper;
using Domain.Dtos;
using Persistance.Entities;
using Persistance.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationService.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> AddAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            var result = await _customerRepository.AddAsync(customer);
            return _mapper.Map<CustomerDto>(result);

        }
        public async Task<CustomerDto> UpdateAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            var result = await _customerRepository.UpdateAsync(customer);
            return _mapper.Map<CustomerDto>(result);
        }
        public async Task<bool> DeleteAsync(int id)
        => await _customerRepository.DeleteAsync(id);
        public async Task<IEnumerable<CustomerDto>> GetAllCustomerAsync()
        {
            var result = await _customerRepository.GetAllCustomerAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<CustomerDto>>(result);
        }

        public async Task<CustomerDto> GetCustomerAsync(int id)
        {
            var result = await _customerRepository.GetCustomerAsync(id);
            return _mapper.Map<CustomerDto>(result);
        }

    }
}
