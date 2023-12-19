using IsubuSatis.SepetService.Ayarlar;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace IsubuSatis.SepetService.Services
{
    public class RedisService
    {
        private readonly string host;
        private readonly int port;

        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(IOptions<RedisSettings> options)
        {
            host = options.Value.Host;
            port = options.Value.Port;

            Baglan();
        }

        public void Baglan()
        {
            var configuration = $"{host}:{port}";

            _connectionMultiplexer = ConnectionMultiplexer.Connect(configuration);
        }

        public IDatabase GetVeriTabani(int db = 1)
        {
            return _connectionMultiplexer.GetDatabase(db);
        }
    }
}
