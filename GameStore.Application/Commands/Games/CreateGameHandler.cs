using GameStore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Application.DTOs.Games;

namespace GameStore.Application.Commands.Games;

public class CreateGameHandler : IRequestHandler<CreateGameCommand, GameDto>
{
    private readonly IGameRepository _repo;
    public CreateGameHandler(IGameRepository repo)
    {
        _repo = repo;
    }
    public async Task<GameDto> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var game = new Game
        {
            Title = request.Title,
            Price = request.Price,
            GenreId = request.GenreId
        };
        var created = await _repo.CreateAsync(game);
        return new GameDto
        {
            Id = created.Id,
            Title = created.Title,
            Price = created.Price,
            GenreId = created.GenreId
        };
    }
}
