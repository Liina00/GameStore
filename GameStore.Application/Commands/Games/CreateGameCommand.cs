using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using GameStore.Application.DTOs.Games;

namespace GameStore.Application.Commands.Games
{
    public record CreateGameCommand(
        string Title,
        decimal Price,
        int GenreId
    ) : IRequest<GameDto>;
}
