using Microsoft.Extensions.DependencyInjection;
using MulakatLab.Application.Tickets.CreateTicket;
using MulakatLab.Application.Tickets.GetTicket;

namespace MulakatLab.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<TicketService>();
        services.AddScoped<ITicketFactory,TicketFactory>();
        services.AddScoped<CreateTicketHandler>();
        services.AddScoped<GetTicketHandler>();
        
        return services ;
    }
}