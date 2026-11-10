
using MulakatLab.Application;

namespace MulakatLab.Infrastructure;

public class InMemoryTicketNumberGenerator : ITicketNumberGenerator
{
    private long _last; // en son verilen no. nesne yaşadıkça burada durur
    public Task<long> NextAsync(CancellationToken ct)
    {
        long next = Interlocked.Increment(ref _last);

        return Task.FromResult(next);
    }
}