using MediatR;
using Microsoft.AspNetCore.Mvc;
using GameStore.Application.Queries.Genres;
using GameStore.Application.Commands.Genres;
namespace GameStore.API.Controllers;

[ApiController]//this is API CONTROLLER for the endpoints for GENRES
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly IMediator _mediator;
    public GenresController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]// POOST ENDPOIINT
    public async Task<IActionResult> Create([FromBody] CreateGenreCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet]//GET ENDPOINT
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllGenresQuery());
        return Ok(result);
    }
    [HttpGet("{id}")]//GET ENDPOINT WITH ID PARAMETER
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetGenreByIdQuery(id));

        if (result == null)
            return NotFound();
        return Ok(result);
    }
    [HttpPut("{id}")]//PUT ENDPOINT WITH ID PARAMETER
    public async Task<IActionResult> Update(int id, [FromBody] UpdateGenreCommand command)
    {
        if (id != command.Id) return BadRequest("Id not a match..");
        var result = await _mediator.Send(command);

        if (result == null)
            return NotFound();
        return Ok(result);
    }
    [HttpDelete("{id}")]//DELETE ENDPOINT WITH ID PARAMETER
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteGenreCommand(id));
        if (!result) return NotFound();
        return NoContent();
    }
}
