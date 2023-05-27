using SchedulerPayment.Payment.Domain;

namespace SchedulerPayment.Test.Domain;

public class SchedulingTest
{
    [Fact]
    public void ShouldCreateSuccessfullyWithStatusPending()
    {
        // Arrange
        var date = DateTime.Now;

        // Act
        var result = Scheduling.Create(date);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(Status.Pending, result.Value.Status);
        Assert.Equal(date, result.Value.Date);
    }
}
