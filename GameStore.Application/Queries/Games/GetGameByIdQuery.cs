using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using GameStore.Application.DTOs.Games;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Queries.Games;

public record GetGameByIdQuery(int Id) : IRequest<GameDto>;