
using Microsoft.Extensions.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

namespace IsubuSatis.Gateway2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("ocelotConfiguration.json",optional:false, reloadOnChange:true);


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            
            builder.Services.AddOcelot();
            builder.Services.AddSwaggerForOcelot(builder.Configuration);
            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            

            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });

            app.MapControllers();
            app.UseOcelot().Wait();
            app.Run();
        }
    }
}
