using IsubuSatis.Siparis.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IsubuSatis.Siparis.Domain;

namespace IsubuSatis.Siparis.Application.Mapping
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Domain.Siparis, SiparisDto>().ReverseMap();
            CreateMap<Domain.SiparisItem, SiparisItemDto>().ReverseMap();
            CreateMap<Domain.Address, AddressDto>().ReverseMap();
        }
    }

    public static class IsubuObjectMapper
    {
        private static readonly MapperConfiguration mapper 
            = new MapperConfiguration(x => x.AddProfile<CustomDtoMapper>());

        public static IMapper Mapper
        {
            get
            {
                //var configuration = new MapperConfiguration(x => x.AddProfile<CustomDtoMapper>());
                return mapper.CreateMapper();

            }
        }
    }
}
