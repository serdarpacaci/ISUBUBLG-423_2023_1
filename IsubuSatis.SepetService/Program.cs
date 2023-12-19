
using IsubuSatis.SepetService.Ayarlar;
using IsubuSatis.SepetService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

namespace IsubuSatis.SepetService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var redisSection = builder.Configuration.GetSection("RedisSettings");
            builder.Services.Configure<RedisSettings>(redisSection);

            //Local cache
            //Distributed cache

            //On-Demand Caching
            //Pre-populate Cashing


            builder.Services.AddSingleton<RedisService>();
            builder.Services.AddScoped<ISepetService, IsubuSepetService>();
            builder.Services.AddScoped<IIdentityHelperService, IdentityHelperService>();
            

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMemoryCache();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.Authority = "https://localhost:5001";
                    x.Audience = "resource_sepet";
                });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

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