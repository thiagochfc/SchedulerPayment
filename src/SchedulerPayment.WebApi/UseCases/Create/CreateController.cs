using Microsoft.AspNetCore.Mvc;
using SchedulerPayment.Payment.UseCases.Create;

namespace SchedulerPayment.WebApi.UseCases.Create;

[Route("api/[controller]")]
[ApiController]
public class CreateController : ControllerBase
{
    private readonly ICreateUseCase _useCase;

    public CreateController(ICreateUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateRequest request)
    {
        var result = _useCase.Create(DateOnly.Parse(request.Date));
        return result.IsSuccess
            ? Ok(result.Value.Id) 
            : BadRequest(new { error = result.Error });
    }
}
