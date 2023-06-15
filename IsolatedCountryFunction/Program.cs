using CountryManagement.DataAccess.Context;
using CountryManagement.DataAccess.Implementation;
using CountryManagement.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<CountryManagementDbContext>(option => option.UseNpgsql(Environment.GetEnvironmentVariable("SqlConnectionString")));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    })
    .Build();

host.Run();
//"host=localhost; Database=postgres; username=postgres; password=1kc23; port=5432"