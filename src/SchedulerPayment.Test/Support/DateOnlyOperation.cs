namespace SchedulerPayment.Test.Support
{
    internal static class DateOnlyOperation
    {
        internal static DateOnly Now()
            => DateOnly.FromDateTime(DateTime.Now);

        internal static DateOnly AddDays(double days)
            => DateOnly.FromDateTime(DateTime.Now.AddDays(days));

        internal static DateOnly SubtractDays(double days)
            => AddDays(days * -1);
    }
}