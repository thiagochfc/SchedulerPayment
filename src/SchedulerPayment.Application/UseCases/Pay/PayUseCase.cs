using CSharpFunctionalExtensions;
using SchedulerPayment.Payment.Domain;

namespace SchedulerPayment.Payment.UseCases.Pay;

public class PayUseCase : IPayUseCase
{
    private readonly ISchedulingStore _store;

    public PayUseCase(ISchedulingStore store)
    {
        _store = store;
    }

    public Result<Scheduling?> Pay(Guid id)
    {
        var scheduling = _store.Get(id);
        if (scheduling is null)
            return Result.Failure<Scheduling?>($"Scheduling {id} not found.");

        var result = scheduling.Pay();
        if (result.IsFailure)
            return Result.Failure<Scheduling?>(result.Error);

        _store.Save(scheduling);

        return Result.Success<Scheduling?>(scheduling);
    }
}
