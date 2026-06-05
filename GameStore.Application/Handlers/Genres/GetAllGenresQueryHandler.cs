using MediatR;
using GameStore.Application.DTOs.Genres;
using GameStore.Application.Queries.Genres;
using GameStore.Domain.Interfaces;

namespace GameStore.Application.Handlers.Genres;
public class GetAllGenresQueryHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<GenreDto>>//Handler to get all the genres.
{
    private readonly IGenreRepository _repo;
    public GetAllGenresQueryHandler(IGenreRepository repo)
    {
        _repo = repo;
    }
    public async Task<IEnumerable<GenreDto>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
    {
        var genres = await _repo.GetAllAsync();//gets genres form the DB
        return genres.Select(g => new GenreDto//maps the genres to GenreDto
        {
            Id = g.Id,
            Name = g.Name
        });
    }
}
