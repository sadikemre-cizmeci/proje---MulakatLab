


using Microsoft.EntityFrameworkCore;
using MulakatLab.Application;
using MulakatLab.Domain;
using MulakatLab.Infrastructure.Persistence;

namespace MulakatLab.Infrastructure;

public class EfTicketRepository(AppDbContext db) : ITicketRepository
{
    public Task AddAsync(Ticket ticket, CancellationToken ct)
    {
        db.Tickets.Add(ticket);
        return Task.CompletedTask;
    }

    public Task<Ticket?> GetAsync(Guid id, CancellationToken ct)
    {
        //link sorguları db sorgularına dönüşür. SELECT ... WHERE "Id" = @Id
       return db.Tickets.FirstOrDefaultAsync(t=>t.Id == id,ct);
    }

    public Task SaveAsync(CancellationToken ct)
    {
        //işaretlenen her şey burada insert/update olur.
       return db.SaveChangesAsync(ct);
    }
}