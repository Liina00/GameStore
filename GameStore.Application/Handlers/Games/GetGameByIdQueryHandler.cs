using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using GameStore.Application.DTOs.Games;
using System.Threading.Tasks;
using GameStore.Domain.Interfaces;
using GameStore.Application.Queries.Games;

namespace GameStore.Application.Handlers.Games;
public class GetGameByIdQueryHandler : IRequestHandler<GetGameByIdQuery, GameDto?>
{
    private readonly IGameRepository _repo;
    public GetGameByIdQueryHandler(IGameRepository repo)
    {
        _repo = repo;
    }
    public async Task<GameDto?> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        var game = await _repo.GetByIdAsync(request.Id);

        if (game == null) return null;
        return new GameDto
        {
            Id = game.Id,
            Title = game.Title,
            Price = game.Price,
            GenreId = game.GenreId
        };
    }
}
