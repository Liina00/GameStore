using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;

namespace GameStore.Domain.Interfaces
{
    public interface IGameRepository//set whats possible for repository to do, "abstraction" infrastructure will implemt this IF
    {
        Task<List<Game>> GetAllAsync(); //Gets all the games from db
        Task<Game?> GetByIdAsync(int id);//Gets a game by id, if not found returns null
        Task<Game> CreateAsync(Game game);//create a new game and saves to db
        Task<Game?> UpdateAsync(int id, Game game);//update a game by its id, return null if not found, otherwise return the updated game
        Task<bool> DeleteAsync(int id);//Delete a game by its ID , return true if deleted, false if not found
    }
}
