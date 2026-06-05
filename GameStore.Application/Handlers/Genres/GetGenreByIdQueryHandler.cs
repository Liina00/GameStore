using GameStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using GameStore.Application.DTOs.Genres;
using GameStore.Application.Queries.Genres;
using GameStore.Domain.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Handlers.Genres;

public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, GenreDto?>//Handler to get the genre by its ID
{
    private readonly IGenreRepository _repo;
    public GetGenreByIdQueryHandler(IGenreRepository repo)
    {
        _repo = repo;
    }
    public async Task<GenreDto?> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
    {
        var genre = await _repo.GetByIdAsync(request.Id);//get the genre
        if (genre == null) return null;//will return null if its not existing or ofund

        return new GenreDto//map to GenreDto and return
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }
}
