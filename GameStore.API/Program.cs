using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using GameStore.Infrastructure.Data;
using GameStore.Domain.Interfaces;
using GameStore.Infrastructure.Repositories;
using GameStore.Application.DTOs.Games;
namespace GameStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Db context
            builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Repositories
            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<IGenreRepository, GenreRepository>();

            //mediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GameDto>());

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