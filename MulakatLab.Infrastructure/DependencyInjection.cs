
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MulakatLab.Application;
using MulakatLab.Infrastructure;
using MulakatLab.Infrastructure.Persistence;

namespace MulakatLab.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        
        options.UseNpgsql(configuration.GetConnectionString("Default")));


        services.AddSingleton<ITicketNumberGenerator, InMemoryTicketNumberGenerator>();
        services.AddScoped<ITicketRepository, EfTicketRepository>();
        return services;
    }
}