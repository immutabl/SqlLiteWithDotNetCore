using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SqlLiteWithDotNetCore.Infrastructure
{
    //Explicit implementation of IDesignTimeDbContextFactory
    //to help with EF Core Tools commands
    //since DI is not available during EF design-time service
    public sealed class SqlLiteWithDotNetCoreDbContextFactory
        : IDesignTimeDbContextFactory<SqlLiteWithDotNetCoreDbContext>
    {
        public SqlLiteWithDotNetCoreDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "..",
                "SqlLiteWithDotNetCore.API"
            );

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connStr = configuration.GetConnectionString("Default");

            var options = new DbContextOptionsBuilder<SqlLiteWithDotNetCoreDbContext>()
                .UseSqlite(connStr)
                .Options;

            return new SqlLiteWithDotNetCoreDbContext(options);
        }
    }

}
