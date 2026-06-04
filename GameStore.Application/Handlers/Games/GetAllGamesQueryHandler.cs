using GameStore.Domain.Interfaces;
using MediatR;
using GameStore.Application.DTOs.Games;
using GameStore.Application.Queries.Games;
namespace GameStore.Application.Handlers.Games
{
    public class GetAllGamesQueryHandler : IRequestHandler<GetAllGamesQuery, List<GameDto>>
    {
        private readonly IGameRepository _repo;
        public GetAllGamesQueryHandler(IGameRepository repo)
        {
            _repo = repo;
        }
        public async Task<List<GameDto>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
        {
            var games = await _repo.GetAllAsync();
            return games.Select(g => new GameDto
            {
                Id = g.Id,
                Title = g.Title,
                Price = g.Price,
                GenreId = g.GenreId
            }).ToList();
        }
    }
}
