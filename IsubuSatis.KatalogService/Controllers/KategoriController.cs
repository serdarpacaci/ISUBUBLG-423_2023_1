using IsubuSatis.KatalogService.Dtos;
using IsubuSatis.KatalogService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.KatalogService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        //[HttpGet]
        //public async Task<List<KategoriDto>> GetKategoriler()
        //{
        //    var sonuc = await _kategoriService.GetKategoriler();

        //    return sonuc;
        //}

        [HttpGet]
        public async Task<IActionResult> GetKategoriler()
        {
            var sonuc = await _kategoriService.GetKategoriler();

            return Ok(sonuc);
        }

        [HttpPost]
        public async Task CreateOrUpdate(CreateOrEditKategori input)
        {
            await _kategoriService.CreateOrUpdate(input);
        }

        [HttpPost]
        //[Route("/KategoriAktiflikSet")]
        public async Task<IActionResult> KategoriAktiflikSet(PostTestModel input)
        {
            return Ok(input);
        }

        [HttpDelete]
        public async Task Delete(string id)
        {
            await _kategoriService.Delete(id);
        }
    }
}
