using AutoMapper;
using Domain.Dtos;
using SwaggerUI.API.Models;

namespace SwaggerUI.API.Mappers
{
    internal class CustomerModelMapper : Profile
    {
        public CustomerModelMapper()
        {
            CreateMap<CustomerDto, CustomerModel>().ReverseMap();
        }
    }
}
