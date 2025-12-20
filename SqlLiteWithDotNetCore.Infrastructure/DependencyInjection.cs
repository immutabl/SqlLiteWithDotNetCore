using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Infrastructure.Persistence;

namespace SqlLiteWithDotNetCore.Infrastructure
{

    public static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            var connStr = configuration.GetConnectionString("SqlLiteDb")
                          ?? throw new InvalidOperationException(
                              "Connection string 'SqlLiteDb' not found.");

            services.AddDbContextFactory<SqlLiteWithDotNetCoreDbContext>(options =>
                options.UseSqlite($"Data Source={connStr}"));
            //services.AddDbContextFactory<SqlLiteWithDotNetCoreDbContext>(options =>
            //    options.UseSqlite(configuration.GetConnectionString("SqlLiteDb")));

            services.AddScoped<IContactRepository, EfContactRepository>();
            services.AddScoped<ICountryRepository, EfCountryReadRepository>();

            return services;
        }
    }
}
