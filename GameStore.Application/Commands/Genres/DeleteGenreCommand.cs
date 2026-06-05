using MediatR;
namespace GameStore.Application.Commands.Genres;
public record DeleteGenreCommand(int Id) : IRequest<bool>;//this is to delete genre BY its ID