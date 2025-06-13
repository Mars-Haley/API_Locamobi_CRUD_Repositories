
using Crudzin.Contracts.Repository;
using Crudzin.Infrastructure;
using Crudzin.Repository;
using MinhaPrimeiraAPI.Contracts.Infrastructure;
using MinhaPrimeiraAPI.Contracts.Service;
using MinhaPrimeiraAPI.Services;

namespace MinhaPrimeiraAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Dependencia
            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<ICidadeService, CidadeService>();
            builder.Services.AddScoped<ICidadeRepository, CidadeRepository>();
            builder.Services.AddTransient<IConnection, Connection>();
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}