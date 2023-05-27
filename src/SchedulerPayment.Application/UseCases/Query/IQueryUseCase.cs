using CSharpFunctionalExtensions;
using SchedulerPayment.Payment.Domain;

namespace SchedulerPayment.Payment.UseCases.Query;

public interface IQueryUseCase
{
    Result<Scheduling?> Query(Guid id);
}
