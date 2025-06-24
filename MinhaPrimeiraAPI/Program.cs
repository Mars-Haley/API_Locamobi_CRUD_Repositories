
using Locamobi_CRUD_Repositories.Contracts.Repository;
using Locamobi_CRUD_Repositories.Repository;
using MeuPrimeiroCrud.Infrastructure;
using Microsoft.AspNetCore.Mvc;
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

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //DEPENDENCIA

            builder.Services.AddSingleton<IConnection, Connection>();
            builder.Services.AddScoped<IVeiculoService, VeiculoService>();
            builder.Services.AddTransient<IVeiculoRepository, VeiculoRepository>();

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