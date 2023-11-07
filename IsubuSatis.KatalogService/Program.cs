
using IsubuSatis.KatalogService.Ayarlar;
using IsubuSatis.KatalogService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IsubuSatis.KatalogService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var mongoDbSection = builder.Configuration.GetSection("MongoDbSettings");
            builder.Services.Configure<MongoDbSettings>(mongoDbSection);

            builder.Services.AddScoped<IKategoriService, KategoriService>();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.Authority = "https://localhost:5001";
                    x.Audience = "resource_katalog";
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}