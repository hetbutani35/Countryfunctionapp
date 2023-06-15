using CountryManagement.DataAccess.Implementation;
using CountryManagement.DataAccess.Context;
using CountryManagement.Domain.Repository;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace CountryManagement.API
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
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CountryManagementDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("sqlconn")));

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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