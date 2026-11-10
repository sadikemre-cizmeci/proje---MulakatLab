using MulakatLab.Domain;

namespace MulakatLab.Application.Tickets.CreateTicket;

public class CreateTicketHandler(ITicketRepository repo, ITicketFactory factory)
{
    public async Task<Guid> Handle(CreateTicketCommand command, CancellationToken ct)
    {
        var ticket = await factory.CreateAsync(command.Title, ct);
        await repo.AddAsync(ticket, ct);
        await repo.SaveAsync(ct);
        return ticket.Id;
    }
}