using IsubuSatis.SepetService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace IsubuSatis.SepetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InMemoryCacheTestController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheTestController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetCacheTest()
        {
            var sonuc = await _memoryCache.GetOrCreateAsync("dersler", async x =>
            {
                //x.AbsoluteExpiration = DateTime.Now.AddSeconds(20);
                x.SlidingExpiration = TimeSpan.FromSeconds(10);
                var dersler = await DersleriDoldur();
                
                return dersler;
            });

            return Ok(sonuc);
        }

        private async Task<List<Ders>> DersleriDoldur()
        {
            await Task.Delay(5000);

            return new List<Ders>
            {
                new Ders(Guid.NewGuid(),"C#"),
                new Ders(Guid.NewGuid(),"Sql"),
                new Ders(Guid.NewGuid(),"MicroService"),
                new Ders(Guid.NewGuid(),"Tarih"),
            };
        }
    }
}
