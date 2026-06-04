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

namespace GameStore.Application.Handlers.Genres
{
    public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, GenreDto>
    {
        private readonly IGenreRepository _repo;
        public CreateGenreHandler(IGenreRepository repo)
        {
            _repo = repo;
        }
        public async Task<GenreDto> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Name = request.Name
            };
            var created = await _repo.CreateAsync(genre);
            return new GenreDto
            {
                Id = created.Id,
                Name = created.Name
            };
        }
    }
}
