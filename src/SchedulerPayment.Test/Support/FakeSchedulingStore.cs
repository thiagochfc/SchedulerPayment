using SchedulerPayment.Payment.Domain;
using System.Collections.Concurrent;

namespace SchedulerPayment.Test.Support;

internal class FakeSchedulingStore : ISchedulingStore
{
    private readonly ConcurrentDictionary<Guid, Scheduling> _storage = new();

    public Scheduling? Get(Guid id)
        => _storage.TryGetValue(id, out var scheduling)
            ? scheduling
            : null;

    public void Save(Scheduling scheduling)
        => _storage.AddOrUpdate(scheduling.Id, 
                                scheduling, 
                                (id, currentShedduling) => scheduling);
}
