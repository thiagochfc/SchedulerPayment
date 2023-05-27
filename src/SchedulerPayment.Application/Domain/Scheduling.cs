using CSharpFunctionalExtensions;

namespace SchedulerPayment.Payment.Domain;

public class Scheduling
{
    public Guid Id { get; private set; }

    public Status Status { get; private set; }
    public DateTime Date { get; private set; }

    private Scheduling(DateTime date)
    {
        Id = Guid.NewGuid();
        Status = Status.Pending;
        Date = date;
    }

    private Scheduling(Guid id, Status status, DateTime date) : this(date)
        => (Id, Status) = (id, status);

    public static Result<Scheduling> Create(DateTime date)
        => Result.Success(new Scheduling(date));

    public static Result<Scheduling> Create(Guid id, Status status, DateTime date)
        => Result.Success(new Scheduling(id, status, date));
}
