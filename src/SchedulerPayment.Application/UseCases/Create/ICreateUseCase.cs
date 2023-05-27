using CSharpFunctionalExtensions;
using SchedulerPayment.Payment.Domain;

namespace SchedulerPayment.Payment.UseCases.Create;

public interface ICreateUseCase
{
    Result<Scheduling> Create(DateOnly date);
}
