namespace SchedulerPayment.Payment.Domain;

public interface ISchedulingStore
{
    Scheduling? Get(Guid id);
    void Save(Scheduling scheduling);
}
