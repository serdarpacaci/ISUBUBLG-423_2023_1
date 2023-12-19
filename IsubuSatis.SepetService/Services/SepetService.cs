using IsubuSatis.SepetService.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace IsubuSatis.SepetService.Services
{
    public class IsubuSepetService : ISepetService
    {
        private readonly RedisService _redisService;
        private readonly IDatabase _redisDatabase;
        public IsubuSepetService(RedisService redisService)
        {
            _redisService = redisService;
            _redisDatabase = _redisService.GetVeriTabani();
        }

        public async Task<SepetDto> GetSepet(string userId)
        {
            var sonuc = await _redisDatabase.StringGetAsync(userId);
            if (string.IsNullOrEmpty(sonuc))
            {
                return new SepetDto() { UserId = userId };
            }

            var sepet = JsonSerializer.Deserialize<SepetDto>(sonuc);

            return sepet;
        }

        public async Task SepetKaydet(SepetDto sepet)
        {
            var sepetJson = JsonSerializer.Serialize(sepet);
            
            var sonuc = await _redisDatabase.StringSetAsync(sepet.UserId, sepetJson);

        }

        public async Task Sil(string userId)
        {
            var sonuc = await _redisDatabase.KeyDeleteAsync(userId);
        }
    }

}
