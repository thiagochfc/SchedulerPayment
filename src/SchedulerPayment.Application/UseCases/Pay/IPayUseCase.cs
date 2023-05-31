using CSharpFunctionalExtensions;
using SchedulerPayment.Payment.Domain;

namespace SchedulerPayment.Payment.UseCases.Pay
{
    public interface IPayUseCase
    {
        Result<Scheduling?> Pay(Guid id);
    }
}
