using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using GameStore.Domain.Interfaces;
using GameStore.Domain.Entities;
using GameStore.Application.DTOs.Genres;
using GameStore.Application.Commands.Genres;

namespace GameStore.Application.Handlers.Genres//handelr the logic when the command sends to create new genre
{
    public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, GenreDto>
    {
        private readonly IGenreRepository _repo;//repository, for acess to db
        public CreateGenreHandler(IGenreRepository repo)
        {
            _repo = repo;
        }
        public async Task<GenreDto> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre//Create new genre entit
            {
                Name = request.Name
            };
            var created = await _repo.CreateAsync(genre);
            return new GenreDto//return dto to API layer
            {
                Id = created.Id,
                Name = created.Name
            };
        }
    }
}
