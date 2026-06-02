using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces;
using GameStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;
        public GameRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }
        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }
        public async Task<Game> CreateAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }
        public async Task<Game?> UpdateAsync(int id, Game game)
        {
           var existing = await _context.Games.FindAsync(id);
            if (existing == null)
                return null;
            existing.Title = game.Title;
            existing.Price = game.Price;
            existing.Description = game.Description;
            existing.ReleaseYear = game.ReleaseYear;
            existing.GenreId = game.GenreId;

            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return false;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}