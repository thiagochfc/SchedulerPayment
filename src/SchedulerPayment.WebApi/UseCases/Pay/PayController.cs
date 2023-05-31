using Microsoft.AspNetCore.Mvc;
using SchedulerPayment.Payment.UseCases.Pay;

namespace SchedulerPayment.WebApi.UseCases.Pay;

[Route("api/[controller]")]
[ApiController]
public class PayController : ControllerBase
{
    private readonly IPayUseCase _useCase;

    public PayController(IPayUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public IActionResult Pay([FromQuery] string id)
    {
        if (!Guid.TryParse(id, out Guid guid))
            return BadRequest(new { error = $"id {id} format invalid." });

        var result = _useCase.Pay(guid);
        return result.IsSuccess
                ? Ok(result.Value) 
                : BadRequest(new { error = result.Error });
    }
}
