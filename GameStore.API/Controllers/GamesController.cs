using MediatR;
using Microsoft.AspNetCore.Mvc;
using GameStore.Application.DTOs.Games;
using GameStore.Application.Commands.Games;
using GameStore.Application.Queries.Games;

namespace GameStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllGamesQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetGameByIdQuery(id));
            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGameCommand command)
        {
            if (id != command.Id) return BadRequest("Id did not match..");
            var result = await _mediator.Send(command);

            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var result = await _mediator.Send(new DeleteGameCommand(id));
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
