using MulakatLab.Domain;
namespace MulakatLab.Application;

public interface ITicketFactory
{
    Task<Ticket> CreateAsync(string title, CancellationToken ct =  default);
}