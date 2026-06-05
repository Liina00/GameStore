using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameStore.Application.DTOs.Genres;
using System.Threading.Tasks;

namespace GameStore.Application.Queries.Genres;
public record GetAllGenresQuery() : IRequest<IEnumerable<GenreDto>>;// will get all genres.