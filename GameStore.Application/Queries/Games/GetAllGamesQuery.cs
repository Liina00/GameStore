using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Application.DTOs.Games;
using MediatR;

namespace GameStore.Application.Queries.Games
{
    public record GetAllGamesQuery() : IRequest<List<GameDto>>;
}
