using GameStore.Application.Commands.Games;
using GameStore.Application.DTOs.Games;
using GameStore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Handlers.Games
{
    public class UpdateGameHandler : IRequestHandler<UpdateGameCommand, GameDto?>
    {
        private readonly IGameRepository _repo;
        public UpdateGameHandler(IGameRepository repo)
        {
            _repo = repo;
        }
        public async Task<GameDto?> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.Id);
            if (existing == null) return null;

            existing.Title = request.Title;
            existing.Price = request.Price;
            existing.GenreId = request.GenreId;
            var updated = await _repo.UpdateAsync(existing.Id, existing);

            return new GameDto
            {
                Id = updated.Id,
                Title = updated.Title,
                Price = updated.Price,
                GenreId = updated.GenreId
            };
        }
    }
}
