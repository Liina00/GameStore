using MediatR;
using Microsoft.AspNetCore.Mvc;
using GameStore.Application.Commands.Genres;
namespace GameStore.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly IMediator _mediator;
    public GenresController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGenreCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
