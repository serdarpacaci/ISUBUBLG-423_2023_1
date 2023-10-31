using IsubuSatis.KatalogService.Dtos;

namespace IsubuSatis.KatalogService.Services
{
    public interface IKategoriService
    {
        Task<List<KategoriDto>> GetKategoriler();
        Task CreateOrUpdate(CreateOrEditKategori input);

        Task Delete(string id);

    }
}
