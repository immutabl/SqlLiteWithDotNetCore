using Microsoft.Extensions.DependencyInjection;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Contacts.Handlers;
using SqlLiteWithDotNetCore.Application.Country.Handlers;

namespace SqlLiteWithDotNetCore.Application
{

    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            // Add Application Services Here
            services.AddScoped<ICreateContact, CreateContactHandler>();
            services.AddScoped<IGetAllContacts, GetAllContactsHandler>();
            services.AddScoped<IGetContactById, GetContactByIdHandler>();
            services.AddScoped<IUpdateContact, UpdateContactHandler>();
            services.AddScoped<IDeleteContact, DeleteContactHandler>();


            services.AddScoped<IGetCountryByCode, GetCountryByCodeHandler>();
            //services.AddScoped<ICreateCountry, CreateCountryHandler>();
            //services.AddScoped<IDeleteCountry, DeleteCountryHandler>();
            //services.AddScoped<IUpdateCountry, UpdateCountryHandler>();

            return services;
        }
    }

}
