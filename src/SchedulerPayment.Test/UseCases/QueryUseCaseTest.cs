using SchedulerPayment.Payment.Domain;
using SchedulerPayment.Payment.UseCases.Query;
using SchedulerPayment.Test.Support;

namespace SchedulerPayment.Test.UseCases;

public class QueryUseCaseTest
{
    private readonly ISchedulingStore _store;

    public QueryUseCaseTest()
    {
        _store = new FakeSchedulingStore();
    }

    [Fact]
    public void ShouldQuerySuccessfully()
    {
        // Arrange
        var scheduling = Scheduling.Create(DateOnlyOperation.Now()).Value;
        _store.Save(scheduling);
        var useCase = new QueryUseCase(_store);

        // Act
        var queryResult = useCase.Query(scheduling.Id);

        // Assert
        Assert.True(queryResult.IsSuccess);
        Assert.NotNull(queryResult.Value);
        Assert.Equal(queryResult.Value.Id, scheduling.Id);
    }

    [Fact]
    public void ShoudNotQueryDueToNonExistentScheduling()
    {
        // Arrange
        var useCase = new QueryUseCase(_store);

        // Act
        var queryResult = useCase.Query(Guid.NewGuid());

        // Assert
        Assert.True(queryResult.IsFailure);
    }
}
