using SchedulerPayment.Payment.Domain;
using SchedulerPayment.Payment.UseCases.Pay;
using SchedulerPayment.Test.Support;

namespace SchedulerPayment.Test.UseCases;

public class PayUseCaseTest
{
    private readonly ISchedulingStore _store;

    public PayUseCaseTest()
    {
        _store = new FakeSchedulingStore();
    }

    [Fact]
    public void ShoudPaySuccessfully()
    {
        // Arrange
        var scheduling = Scheduling.Create(DateOnlyOperation.Now()).Value;
        _store.Save(scheduling);
        var useCase = new PayUseCase(_store);

        // Act
        var result = useCase.Pay(scheduling.Id);
        var resultPersist = _store.Get(scheduling.Id);

        // 
        Assert.True(result.IsSuccess);
        Assert.Equal(Status.Paid, resultPersist!.Status);
    }

    [Fact]
    public void ShoudNotPayDueToInvalidSheduling()
    {
        // Arrange
        var useCase = new PayUseCase(_store);

        // Act
        var result = useCase.Pay(Guid.NewGuid());

        // Assert
        Assert.True(result.IsFailure);
    }

    [Fact]
    public void ShoudNotPayDueToAlreadyPay()
    {
        // Arrange
        var scheduling = Scheduling.Create(DateOnlyOperation.Now()).Value;
        scheduling.Pay();
        _store.Save(scheduling);
        var useCase = new PayUseCase(_store);

        // Act
        var result = useCase.Pay(scheduling.Id);

        // Assert
        Assert.True(result.IsFailure);
    }
}
