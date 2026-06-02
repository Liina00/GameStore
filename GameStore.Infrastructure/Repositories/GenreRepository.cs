using Microsoft.EntityFrameworkCore;
using GameStore.Infrastructure.Data;
using GameStore.Domain.Entities;
using GameStore.Domain.Interfaces;

namespace GameStore.Infrastructure.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;
        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }
        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }
        public async Task<Genre> CreateAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
            return genre;
        }
        public async Task<Genre?> UpdateAsync(int id, Genre genre)
        {
            var existing = await _context.Genres.FindAsync(id);
            if (existing == null)
                return null;
            existing.Name = genre.Name;

            await _context.SaveChangesAsync();
            return existing;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
                return false;
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
