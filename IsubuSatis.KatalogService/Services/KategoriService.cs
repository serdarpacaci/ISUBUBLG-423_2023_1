using AutoMapper;
using IsubuSatis.KatalogService.Ayarlar;
using IsubuSatis.KatalogService.Dtos;
using IsubuSatis.KatalogService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq;

namespace IsubuSatis.KatalogService.Services
{
    public class KategoriService : IKategoriService
    {
        private readonly IMongoCollection<Kategori> _kategoriCollection;

        private readonly MongoDbSettings _databaseSetting;
        private readonly IMapper _mapper;
        public KategoriService(IOptions<MongoDbSettings> databaseSetting,
            IMapper mapper)
        {
            _databaseSetting = databaseSetting.Value;

            var client = new MongoClient(_databaseSetting.ConnectionString);
            var database = client.GetDatabase(_databaseSetting.Database);

            _kategoriCollection = database.GetCollection<Kategori>
                (MongoDbTables.KategoriTableName);
            _mapper = mapper;
        }
        public async Task CreateOrUpdate(CreateOrEditKategori input)
        {
            if (string.IsNullOrEmpty(input.Id))
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        private async Task Update(CreateOrEditKategori input)
        {
            var kategori = _kategoriCollection.AsQueryable()
                .Where(x => x.Id == input.Id)
                .FirstOrDefault();

            _mapper.Map(input, kategori);

            await _kategoriCollection.ReplaceOneAsync(
                Builders<Kategori>.Filter.Eq(x => x.Id, input.Id), kategori);
            //var kategori = _mapper.Map<Kategori>(input);

        }

        private async Task Create(CreateOrEditKategori input)
        {
            var kategori = _mapper.Map<Kategori>(input);

            await _kategoriCollection.InsertOneAsync(kategori);
        }

        public async Task<List<KategoriDto>> GetKategoriler()
        {
            var kategoriler = await _kategoriCollection.AsQueryable()
                .ToListAsync();

            var result = _mapper.Map<List<KategoriDto>>(kategoriler);

            return result;
        }

        public async Task Delete(string id)
        {
            await _kategoriCollection.DeleteOneAsync(
               Builders<Kategori>.Filter.Eq(x => x.Id, id));
            //var kategori = _mapper.Map<Kategori>(input);
        }
    }
}
