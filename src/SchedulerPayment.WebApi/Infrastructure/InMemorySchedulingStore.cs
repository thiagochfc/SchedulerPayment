using Microsoft.Extensions.Caching.Memory;
using SchedulerPayment.Payment.Domain;

namespace SchedulerPayment.WebApi.Infrastructure;

public class InMemorySchedulingStore : ISchedulingStore
{
    private readonly IMemoryCache _memoryCache;

    public InMemorySchedulingStore(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public Scheduling? Get(Guid id)
    {
        return _memoryCache.TryGetValue(id, out Scheduling? scheduling)
                ? scheduling
                : null;
    }

    public void Save(Scheduling scheduling)
    {
        _memoryCache.Set(scheduling.Id, scheduling);
    }
}
