using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Game//DOMAIN ENTITY represent "A" game in store
    {
        public int Id { get; set; } //primary key 
        public string Title { get; set; } = string.Empty;//the name of game
        public decimal Price { get; set; }//price of game
        public string Description { get; set; } = string.Empty;//description of game
        public int ReleaseYear { get; set; }// Release year of game
        public int GenreId { get; set; }//foreign key, links the "Game" to a genre.
        public Genre Genre { get; set; } = null; //never null when running, "called" navigation property, use to gain acess to details from GENRE
    }
}
