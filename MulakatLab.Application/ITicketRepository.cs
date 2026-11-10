using MulakatLab.Domain;

namespace MulakatLab.Application;

// Application'ın veritabanından ne istediğini tanımlayan sözleşme.
// Application DB kodu yazmaz; işi bu interface üzerinden devreder.
// Uygulamasını Infrastructure yapar, ama Application Infrastructure'ı tanımaz.
// Çalışma anında DI, Infrastructure'daki gerçek sınıfı verir.
public interface ITicketRepository
{
    Task AddAsync(Ticket ticket, CancellationToken ct);
    Task<Ticket?> GetAsync(Guid id, CancellationToken ct);
    Task SaveAsync(CancellationToken ct);
}