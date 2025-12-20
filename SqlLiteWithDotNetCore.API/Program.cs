using Microsoft.EntityFrameworkCore;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistance;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Application.Contacts.Handlers;
using SqlLiteWithDotNetCore.Application.Country.Handlers;


//using SqlLiteWithDotNetCore.Application.Services.Interfaces;
using SqlLiteWithDotNetCore.Infrastructure;
using SqlLiteWithDotNetCore.Infrastructure.Persistence;

namespace SqlLiteWithDotNetCore.API
    {
        public class Program
        {
            public static async Task Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.

                builder.Services.AddControllers();
                // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
                builder.Services.AddOpenApi();

                builder.Services.AddSwaggerGen();

                // Add services to the container.
                var dbPath = Path.Combine(
                                builder.Environment.ContentRootPath,
                                builder.Configuration.GetConnectionString("SqlLiteDb")?? throw new InvalidOperationException("Connection string 'SqlLiteDb' not found.")
                    );

                var connStr = $"Data Source={dbPath}";



                // For HTTP requests (scoped DbContext per-request)
                //builder.Services.AddDbContext<SqlLiteWithDotNetCoreDbContext>(options =>
                //    options.UseSqlite(sqliteConnectionString));

                // For startup/background use (no manual scope needed)
                // Register the DBContextFactory
                builder.Services.AddDbContextFactory<SqlLiteWithDotNetCoreDbContext>(options =>
                    options.UseSqlite(connStr));

                // 2) Expose a scoped DbContext built from the factory
                //Why: lets controllers/endpoints keep injecting SqlLiteWithDotNetCoreDbContext
                builder.Services.AddScoped(sp =>
                {
                    var factory = sp.GetRequiredService<IDbContextFactory<SqlLiteWithDotNetCoreDbContext>>();
                    return factory.CreateDbContext();
                });

                
                /* DI configuration*/
                ////TODO: move this to per-project extension methods
                builder.Services.AddScoped<ICountryRepository, EfCountryReadRepository>();
                builder.Services.AddScoped<IContactRepository, EfContactRepository>();
                builder.Services.AddScoped<ICreateContact, CreateContactHandler>();
                builder.Services.AddScoped<IGetAllContacts, GetAllContactsHandler>();
                builder.Services.AddScoped<IGetContactById, GetContactByIdHandler>();
                builder.Services.AddScoped<IUpdateContact, UpdateContactHandler>();
                builder.Services.AddScoped<IDeleteContact, DeleteContactHandler>();
                builder.Services.AddScoped<IGetCountryByCode, GetCountryByCodeHandler>();
                //builder.Services.AddScoped();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {

                    
                    //// Could use factory at startup; no manual scope required
                    //var dbFactory = app.Services.GetRequiredService<IDbContextFactory<SqlLiteWithDotNetCoreDbContext>>();
                    //await using var db = await dbFactory.CreateDbContextAsync();

                    //but for startup migrations etc. better to use a manually created scope.

                    var scope = app.Services.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<SqlLiteWithDotNetCoreDbContext>();

                    await db.Database.MigrateAsync();

                    //await SeedData();

                    app.MapOpenApi();
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                
                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                await app.RunAsync();
            }
        }
    }
