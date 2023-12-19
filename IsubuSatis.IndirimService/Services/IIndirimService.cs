using IsubuSatis.IndirimService.Models;

namespace IsubuSatis.IndirimService.Services
{
    public interface IIndirimService
    {
        Task<List<Indirim>> GetAll();

        Task<Indirim> GetbyId(int id);

        Task Kaydet(Indirim indirim);

        Task Guncelle(Indirim indirim);

        Task Sil(int id);

    }
}
