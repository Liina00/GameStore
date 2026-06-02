using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Interfaces
{
    public interface IGenreRepository
    {
        Task<List<Genre>> GetAllAsync();//Gets all the genres from db
        Task<Genre?> GetByIdAsync(int id);//Gets a genre by its id from db
        Task<Genre> CreateAsync(Genre genre);//Adds a new genre to the db
        Task<Genre?> UpdateAsync(int id, Genre genre);//Updates an existing genre in the db
        Task<bool> DeleteAsync(int id);//Deletes a genre by its id from db
    }
}
