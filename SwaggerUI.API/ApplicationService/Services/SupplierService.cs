using ApplicationService.Interfaces;
using AutoMapper;
using Domain.Dtos;
using Persistance.Entities;
using Persistance.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationService.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IMapper _mapper;
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }
        public async Task<SupplierDto> AddAsync(SupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            var result = await _supplierRepository.AddAsync(supplier);
            return _mapper.Map<SupplierDto>(result);

        }
        public async Task<SupplierDto> UpdateAsync(SupplierDto customerDto)
        {
            var supplier = _mapper.Map<Supplier>(customerDto);
            var result = await _supplierRepository.UpdateAsync(supplier);
            return _mapper.Map<SupplierDto>(result);
        }
        public async Task<bool> DeleteAsync(int id)
        => await _supplierRepository.DeleteAsync(id);
        public async Task<IEnumerable<SupplierDto>> GetAllSupplierAsync()
        {
            var result = await _supplierRepository.GetAllSupplierAsync();
            return _mapper.Map<IEnumerable<SupplierDto>>(result);
        }
        public async Task<SupplierDto> GetSupplierAsync(int id)
        {
            var result = await _supplierRepository.GetSupplierAsync(id);
            return _mapper.Map<SupplierDto>(result);
        }
    }
}
