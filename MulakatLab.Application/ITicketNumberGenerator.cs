namespace MulakatLab.Application;

public interface ITicketNumberGenerator
{
    Task<long> NextAsync(CancellationToken ct);

}