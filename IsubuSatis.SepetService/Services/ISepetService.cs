using IsubuSatis.SepetService.Models;
using Microsoft.AspNetCore.DataProtection;

namespace IsubuSatis.SepetService.Services
{
    public interface ISepetService
    {
        Task<SepetDto> GetSepet(string userId);
        Task SepetKaydet(SepetDto sepet);
        Task Sil(string userId);
    }

}
