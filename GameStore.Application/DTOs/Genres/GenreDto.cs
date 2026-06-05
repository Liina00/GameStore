using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.DTOs.Genres
{
    public class GenreDto//Dto for Genre transfer deata between layers API and front/application
    {
        public int Id { get; set; } //Unique Id for genre
        public string Name { get; set; } = string.Empty;//name of genre
    }
}
