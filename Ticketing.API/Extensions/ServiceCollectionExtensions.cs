using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ticketing.Core;
using Ticketing.Core.IRepositories;
using Ticketing.Core.IServices;
using Ticketing.Data;
using Ticketing.Data.Repositories;
using Ticketing.Service.Services;

namespace Ticketing.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, string connectionString)
    {
        // DbContext
        services.AddDbContext<IDataContext, DataContext>(options =>
            options.UseNpgsql(connectionString));

        // AutoMapper
        services.AddAutoMapper(typeof(MappingProfile), typeof(MappingPostProfile));

        // Repositories
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();

        // Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITicketService, TicketService>();

        // CORS
        services.AddCors(options =>
        {
            options.AddPolicy("MyPolicy", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        return services;
    }
}
