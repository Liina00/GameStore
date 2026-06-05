using MediatR;
using GameStore.Application.DTOs.Genres;
namespace GameStore.Application.Commands.Genres;
public record UpdateGenreCommand(int Id,string Name) : IRequest<GenreDto>; //command to update GENRE