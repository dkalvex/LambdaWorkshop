using Microsoft.AspNetCore.Mvc;
using MediatR;
using Shared.Events;

namespace ServingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> PostEvent([FromBody] EventReceived eventData)
    {
        eventData.Timestamp = DateTime.UtcNow;
        await _mediator.Publish(eventData);
        return Ok(new { Message = "Evento publicado", eventData.Id });
    }
}
