using SchedulerPayment.Payment.Domain;
using SchedulerPayment.Payment.UseCases.Create;
using SchedulerPayment.Test.Support;

namespace SchedulerPayment.Test.UseCases;

public class CreateUseCaseTest
{
    private readonly ISchedulingStore _store;

    public CreateUseCaseTest()
    {
        _store = new FakeSchedulingStore();
    }

    [Fact]
    public void ShouldCreateAndPersistSuccessfully()
    {
        // Arrange
        var useCase = new CreateUseCase(_store);

        // Act
        var result = useCase.Create(DateOnlyOperation.Now());
        var scheduling = _store.Get(result.Value.Id);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(scheduling);
    }

    [Fact]
    public void ShouldNotCreateDueToInvalidDate()
    {
        // Arrange
        var useCase = new CreateUseCase(_store);

        // Act
        var result = useCase.Create(DateOnlyOperation.SubtractDays(1));

        // Assert
        Assert.True(result.IsFailure);
    }
}
