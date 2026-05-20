using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Genre//DOMAIN ENTITY it represent "A" game genre
    {
        public int Id { get; set; } //This will be primary key, it is
        public string Name { get; set; } = string.Empty; //Genre name, rpg fps.

        public ICollection<Game> Games { get; set; } = new List<Game>();//one to many relationship, one genre can have many games.
    }
}
