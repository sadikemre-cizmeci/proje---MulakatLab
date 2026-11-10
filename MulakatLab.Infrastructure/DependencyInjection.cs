
using Microsoft.Extensions.DependencyInjection;
using MulakatLab.Application;
using MulakatLab.Infrastructure;

namespace MulakatLab.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITicketNumberGenerator, InMemoryTicketNumberGenerator>();
        services.AddScoped<ITicketRepository, InMemoryTicketRepository>();
        return services;
    }
}