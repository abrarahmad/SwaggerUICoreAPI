using AutoMapper;
using Domain.Dtos;
using Persistance.Entities;

namespace ApplicationService.Mappers
{
    internal class SupplierMapper : Profile
    {
        public SupplierMapper()
        {
            CreateMap<Supplier, SupplierDto>().ReverseMap();
        }
    }
}
