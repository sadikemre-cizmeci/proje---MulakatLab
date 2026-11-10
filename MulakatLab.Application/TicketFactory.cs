using MulakatLab.Domain;
namespace MulakatLab.Application;
public class TicketFactory : ITicketFactory
{
    private readonly ITicketNumberGenerator _ticketNumberGenerator;
    public TicketFactory(ITicketNumberGenerator numberGenerator)
    {
        _ticketNumberGenerator = numberGenerator;
    }

    public async Task<Ticket> CreateAsync(string title, CancellationToken ct)
    {
       var number = await _ticketNumberGenerator.NextAsync(ct);

       return new Ticket(title, number);
    }
}
