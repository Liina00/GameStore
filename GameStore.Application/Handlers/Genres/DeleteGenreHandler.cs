using GameStore.Application.Commands.Genres;
using GameStore.Domain.Interfaces;
using MediatR;
namespace GameStore.Application.Handlers.Genres
{
    public class DeleteGenreHandler : IRequestHandler<DeleteGenreCommand, bool>//HAndler to delete genre
    {
        private readonly IGenreRepository _repo;
        public DeleteGenreHandler(IGenreRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            var deleted = await _repo.DeleteAsync(request.Id);
            return deleted;
        }
    }
}
