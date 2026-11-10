namespace MulakatLab.Application.Tickets.GetTicket;

public class GetTicketHandler(ITicketRepository repo)
{
    public async Task<TicketDto?> Handle(GetTicketQuery query, CancellationToken ct)
    {
        var ticket = await repo.GetAsync(query.TicketId, ct);
        if (ticket is null) return null;

        return new TicketDto(
            ticket.Id,
            $"TKT-{ticket.TicketNumber:D6}",   // 1 → TKT-000001
            ticket.Title,
            ticket.Status.ToString());         // 0 → "Open"
    }
}