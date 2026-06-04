using GameStore.Domain.Interfaces;
using MediatR;
using GameStore.Application.Commands.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Handlers.Games
{
    public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, bool>
    {
        private readonly IGameRepository _repo;
        public DeleteGameHandler(IGameRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _repo.DeleteAsync(request.Id);
            return deleted;
        }
    }
}
