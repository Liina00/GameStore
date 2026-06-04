using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Commands.Games;

public record DeleteGameCommand(int Id) : IRequest<bool>;