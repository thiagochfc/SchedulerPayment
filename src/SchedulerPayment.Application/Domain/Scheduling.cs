using CSharpFunctionalExtensions;

namespace SchedulerPayment.Payment.Domain;

public class Scheduling
{
    public Guid Id { get; private set; }

    public Status Status { get; private set; }
    public DateOnly Date { get; private set; }

    private Scheduling(Guid id, Status status, DateOnly date)
        => (Id, Status, Date) = (id, status, date);

    public static Result<Scheduling> Create(DateOnly date)
        => Create(Guid.NewGuid(), Status.Pending, date);

    public static Result<Scheduling> Create(Guid id, Status status, DateOnly date)
    {
        if (date < DateOnly.FromDateTime(DateTime.Now))
            return Result.Failure<Scheduling>("Date can't to be smaller that today.");

        return Result.Success(new Scheduling(id, status, date));
    }

    public Result UpdateDate(DateOnly date)
    {
        if (Status == Status.Paid)
            return Result.Failure("Scheduling is already paid.");

        if (date < DateOnly.FromDateTime(DateTime.Now))
            return Result.Failure("Date can't to be smaller that today.");

        Date = date;
        return Result.Success();
    }

    public Result Pay()
    {
        if (Status == Status.Paid)
            return Result.Failure("Scheduling is already paid.");

        Status = Status.Paid;
        return Result.Success();
    }
}
