using MulakatLab.Domain;

namespace MulakatLab.Application;

public class TicketService(ITicketRepository repo, ITicketFactory ticketFactory)
{

    public async Task CloseAsync(Guid id, CancellationToken ct)
    {
        var ticket = await repo.GetAsync(id, ct)
                     ?? throw new KeyNotFoundException($"Ticket bulunamadı: {id}");
        ticket.Close();              // iş kuralı Domain'de
        await repo.SaveAsync(ct);
    }
}