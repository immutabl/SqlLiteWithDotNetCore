using Microsoft.EntityFrameworkCore;
using SqlLiteWithDotNetCore.Application.Services.Interfaces.IContactService;
using SqlLiteWithDotNetCore.Data;
using SqlLiteWithDotNetCore.Data.Services;

namespace SqlLiteWithDotNetCore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services
                .AddSwaggerGen();

            // Add services to the container.
            var sqliteConnectionString = builder.Configuration.GetConnectionString("SqlLiteConnection") 
                                          ?? throw new InvalidOperationException("Connection string 'SqlLiteConnection' not found.");


            // For HTTP requests (scoped DbContext per-request)
            //builder.Services.AddDbContext<SqlLiteWithDotNetCoreDbContext>(options =>
            //    options.UseSqlite(sqliteConnectionString));

            // For startup/background use (no manual scope needed)
            // Register the DBContextFactory
            builder.Services.AddDbContextFactory<SqlLiteWithDotNetCoreDbContext>(options =>
                options.UseSqlite(sqliteConnectionString));

            // 2) Expose a scoped DbContext built from the factory
            //Why: lets controllers/endpoints keep injecting SqlLiteWithDotNetCoreDbContext
            builder.Services.AddScoped(sp =>
            {
                var factory = sp.GetRequiredService<IDbContextFactory<SqlLiteWithDotNetCoreDbContext>>();
                return factory.CreateDbContext();
            });

            /* DI configuration*/
            builder.Services.AddScoped<IContactService, ContactService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
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
