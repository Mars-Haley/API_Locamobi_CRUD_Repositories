using Api1.Contracts.Infrastructure;
using Api1.Contracts.Repository;
using Api1.Contracts.Service;
using Api1.Infrastructure;
using Api1.Models;
using Api1.Repository;
using Api1.Services;

namespace Api1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //dependency
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddTransient<IUserRepository, UserRepository>();
            builder.Services.AddTransient<TokenService>();
            builder.Services.AddSingleton<IConnection, Connection>();

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
            app.MapPost("/Login", (User user, TokenService tokenService) => tokenService.GenerateToken(user));

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}