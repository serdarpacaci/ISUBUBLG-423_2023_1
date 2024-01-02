
using IsubuSatis.Siparis.Api.Services;
using IsubuSatis.Siparis.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace IsubuSatis.Siparis.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SiparisDbContext>(x =>
            x.UseSqlServer(builder.Configuration.GetConnectionString("Default"), y =>
            {
                y.MigrationsAssembly("IsubuSatis.Siparis.Infrastructure");
            }));

            // Add services to the container.
            builder.Services.AddScoped<IIdentityHelperService, IdentityHelperService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Application.Dtos.SiparisDto).Assembly)); 
            
            builder.Services.AddHttpContextAccessor();

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
