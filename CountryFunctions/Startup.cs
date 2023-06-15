using CountryFunctions;
using CountryManagement.DataAccess.Context;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Startup))]

namespace CountryFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<CountryManagementDbContext>(option =>
            option.UseNpgsql(Environment.GetEnvironmentVariable("SqlConnectionString")));
        }
    }
}
