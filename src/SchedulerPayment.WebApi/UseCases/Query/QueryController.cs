using Microsoft.AspNetCore.Mvc;
using SchedulerPayment.Payment.UseCases.Query;

namespace SchedulerPayment.WebApi.UseCases.Query;

[Route("api/[controller]")]
[ApiController]
public class QueryController : ControllerBase
{
    private readonly IQueryUseCase _useCase;

    public QueryController(IQueryUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet]
    public IActionResult Query(string id)
    {
        if (!Guid.TryParse(id, out Guid guid))
            return BadRequest(new { error = $"id {id} format invalid." });

        var result = _useCase.Query(guid);
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(new { error = result.Error });
    }
}
