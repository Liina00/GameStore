using GameStore.Application.Commands.Genres;
using GameStore.Application.DTOs.Genres;
using GameStore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Handlers.Genres
{
    public class UpdateGenreHandler : IRequestHandler<UpdateGenreCommand, GenreDto?>//handlert to update a genre.
    {
        private readonly IGenreRepository _repo;
        public UpdateGenreHandler(IGenreRepository repo)
        {
            _repo = repo;
        }
        public async Task<GenreDto?> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var existing = await _repo.GetByIdAsync(request.Id);//get the genre by ID
            if (existing == null) return null;//if the genre doesn't exist, return null
            existing.Name = request.Name;

            var updated = await _repo.UpdateAsync(existing.Id, existing);//saave the updates to DB
            //returns DTO of the updated genre
            return new GenreDto
            {
                Id = updated.Id,
                Name = updated.Name
            };
        }
    }
}
