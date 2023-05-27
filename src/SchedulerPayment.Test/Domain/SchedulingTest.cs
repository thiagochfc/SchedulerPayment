using SchedulerPayment.Payment.Domain;
using SchedulerPayment.Test.Support;
using System.Runtime.CompilerServices;

namespace SchedulerPayment.Test.Domain;

public class SchedulingTest
{
    [Fact]
    public void ShouldCreateSuccessfullyWithStatusPending()
    {
        // Arrange
        var date = DateTimeOperation.Now();

        // Act
        var result = Scheduling.Create(date);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(Status.Pending, result.Value.Status);
        Assert.Equal(date, result.Value.Date);
    }

    [Fact]
    public void ShouldUpdateSuccessfullyDateIfStatusPending()
    {
        // Arrange
        var date = DateTimeOperation.AddDays(1);

        // Act
        var scheduling = Scheduling.Create(Guid.NewGuid(), Status.Pending, DateTimeOperation.Now()).Value;
        scheduling.UpdateDate(date);

        // Assert
        Assert.Equal(date, scheduling.Date);
    }

    [Fact]
    public void ShouldNotUpdateDueToStatusPaid()
    {
        // Act
        var scheduling = Scheduling.Create(Guid.NewGuid(), Status.Paid, DateTimeOperation.Now()).Value;
        var result = scheduling.UpdateDate(DateTimeOperation.Now());

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void ShouldNotUpdateDueToDateSmallerToday()
    {
        // Act
        var scheduling = Scheduling.Create(Guid.NewGuid(), Status.Pending, DateTimeOperation.Now()).Value;
        var result = scheduling.UpdateDate(DateTimeOperation.SubtractDays(1));

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void ShoudUpdateSuccessfullyDateIfEqualToday()
    {
        // Arrange
        var date = DateTimeOperation.Now();

        // Act
        var scheduling = Scheduling.Create(Guid.NewGuid(), Status.Pending, date).Value;
        var result = scheduling.UpdateDate(date);

        // Assert
        Assert.True(result.IsSuccess);
    }
}
