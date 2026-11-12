using Microsoft.EntityFrameworkCore;
using MulakatLab.Domain;

namespace MulakatLab.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }


}