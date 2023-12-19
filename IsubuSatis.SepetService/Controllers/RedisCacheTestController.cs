using IsubuSatis.SepetService.Models;
using IsubuSatis.SepetService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace IsubuSatis.SepetService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisCacheTestController : ControllerBase
    {
        private readonly RedisService _redisService;

        public RedisCacheTestController(RedisService redisService)
        {
            _redisService = redisService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestData()
        {
            var db =  _redisService.GetVeriTabani();

            var sonuc = await db.StringGetAsync("testRedis");
            var result = JsonSerializer.Deserialize<Ders>(sonuc);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> SetTestData(Ders ders)
        {
            var db = _redisService.GetVeriTabani();

            var dersJson = JsonSerializer.Serialize(ders); 
            var sonuc = await db.StringSetAsync("testRedis", dersJson);

            return Ok(sonuc);
        }
    }
}
