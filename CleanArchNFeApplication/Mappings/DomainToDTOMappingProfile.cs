using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchNFeDomain.Entities;
using CleanArchNFeApplication.DTOs;

namespace CleanArchNFeApplication.Mappings
{
    public class DomainToDTOMappingProfile : AutoMapper.Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Cliente,ClienteDTO>().ReverseMap();
            CreateMap<NotaFiscal, NotaFiscalDTO>().ReverseMap();
            CreateMap<ItemNotaFiscal, ItemNotaFiscalDTO>().ReverseMap();
            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
        }
    }
}
