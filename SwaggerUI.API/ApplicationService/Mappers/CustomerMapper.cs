using AutoMapper;
using Domain.Dtos;
using Persistance.Entities;

namespace ApplicationService.Mappers
{
    internal class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
