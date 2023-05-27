using CSharpFunctionalExtensions;
using SchedulerPayment.Payment.Domain;

namespace SchedulerPayment.Payment.UseCases.Create;

public class CreateUseCase : ICreateUseCase
{
    private readonly ISchedulingStore _store;

    public CreateUseCase(ISchedulingStore store)
    {
        _store = store;
    }

    public Result<Scheduling> Create(DateOnly date)
    {
        var createResult = Scheduling.Create(date);
        if (createResult.IsFailure)
            return createResult;

        _store.Save(createResult.Value);
        return createResult;
    }
}
