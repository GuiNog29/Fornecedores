using AutoMapper;
using Fornecedores.Domain.Entities;
using Fornecedores.Application.DTOs;

namespace Fornecedores.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
        }
    }
}
