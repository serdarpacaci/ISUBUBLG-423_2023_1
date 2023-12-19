using Dapper;
using IsubuSatis.IndirimService.Models;
using Npgsql;
using System.Data;

namespace IsubuSatis.IndirimService.Services
{
    public class MyIndirimService : IIndirimService
    {
        
        private readonly IDbConnection _dbConnection;
        public MyIndirimService(IConfiguration configuration)
        {
            var constr = configuration.GetConnectionString("Default");

            _dbConnection= new NpgsqlConnection(constr);

        }
        public async Task<List<Indirim>> GetAll()
        {
            var indirimler = await _dbConnection
                .QueryAsync<Indirim>("select * from indirim");

            return indirimler.ToList();
        }

        public async Task<Indirim> GetbyId(int id)
        {
            var indirim = await _dbConnection
                .QueryAsync<Indirim>
                ("select * from indirim where id = @id", new { id = id })
                ;

            var indirimSonuc = indirim.FirstOrDefault();

            return indirimSonuc;

        }

        public async Task Kaydet(Indirim indirim)
        {
           int status = await _dbConnection
                .ExecuteAsync("insert into indirim (UserId,Kod,Oran,IsActive) values (@UserId,@Kod,@Oran,@IsActive)",
                indirim);

        }

        public async Task Guncelle(Indirim indirim)
        {
            int status = await _dbConnection
                .ExecuteAsync("update indirim set UserId=@UserId,Kod=@Kod,Oran=@Oran,IsActive=@IsActive where id=@Id", indirim);

        }

      

        public async Task Sil(int id)
        {
            int status = await _dbConnection
                .ExecuteAsync("delete from indirim where id=@Id", new { Id = id });

        }
    }
}
