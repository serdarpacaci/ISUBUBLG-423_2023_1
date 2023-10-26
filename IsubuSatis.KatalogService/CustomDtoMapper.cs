using AutoMapper;
using IsubuSatis.KatalogService.Dtos;
using IsubuSatis.KatalogService.Models;

namespace IsubuSatis.KatalogService
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Kategori,KategoriDto>().ReverseMap();
            CreateMap<Kategori, CreateOrEditKategori>().ReverseMap();


        }
    }
}
