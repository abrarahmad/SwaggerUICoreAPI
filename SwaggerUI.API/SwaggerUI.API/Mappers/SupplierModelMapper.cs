using AutoMapper;
using Domain.Dtos;
using SwaggerUI.API.Models;

namespace SwaggerUI.API.Mappers
{
    internal class SupplierModelMapper : Profile
    {
        public SupplierModelMapper()
        {
            CreateMap<SupplierDto, SupplierModel>().ReverseMap();
        }
    }
}
