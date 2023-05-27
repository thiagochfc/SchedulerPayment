using CSharpFunctionalExtensions;
using SchedulerPayment.Payment.Domain;

namespace SchedulerPayment.Payment.UseCases.Query;

public class QueryUseCase : IQueryUseCase
{
    private readonly ISchedulingStore _store;

    public QueryUseCase(ISchedulingStore store)
    {
        _store = store;
    }

    public Result<Scheduling?> Query(Guid id)
    {
        var scheduling = _store.Get(id);
        return (scheduling is not null)
            ? Result.Success<Scheduling?>(scheduling)
            : Result.Failure<Scheduling?>($"Scheduling {id} not found.");
    }
}
