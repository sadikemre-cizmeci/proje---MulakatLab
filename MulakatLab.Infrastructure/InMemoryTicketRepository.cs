using MulakatLab.Application;
using MulakatLab.Domain;

public class InMemoryTicketRepository : ITicketRepository
{
    public Task AddAsync(Ticket ticket, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Ticket?> GetAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}