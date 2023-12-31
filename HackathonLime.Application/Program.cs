using HackathonLime.Application.Controllers;
using HackathonLime.DAL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HackathonLime.Application
{
    public class Program
    {
        private const string connectionString = "User ID=postgres;Password=postgres;Server=app_db;Port=5432;DataBase=HackathonLime;Integrated Security=true;Pooling=true";
        public static void Main(string[] args)
        {
             
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddTransient<IMapper, AutoMapper>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            var connString = " Host=app_db;Port=5432;Database=HackathonLime;Username=postgres;Password=postgres";

            //Just for Debug
            if (string.IsNullOrWhiteSpace(connString))
                connString = connectionString;

            builder.Services.AddDbContext<HackathonLimeDbContext>(options => 
                options.UseNpgsql(connString));

            builder.Services.AddTransient<IConventionModelFactory, EdmModelFactory>();

            builder.Services.AddScoped<FilmController, FilmController>();

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