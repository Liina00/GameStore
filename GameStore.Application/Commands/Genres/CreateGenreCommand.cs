using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using GameStore.Application.DTOs.Genres;

namespace GameStore.Application.Commands.Genres
{
    public record CreateGenreCommand(string Name) : IRequest<GenreDto>;
}
