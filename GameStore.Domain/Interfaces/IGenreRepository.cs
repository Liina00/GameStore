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
        Task<IEnumerable<Genre>> GetAllAsync();//Gets all the genres from db

        Task<Genre?> GetByIdAsync(Guid id);//Gets a genre by its id from db
        Task AddAsync(Genre genre);//Adds a new genre to the db
        Task UpdateAsync(Genre genre);//Updates an existing genre in the db
        Task DeleteAsync(Guid id);//Deletes a genre by its id from db
    }
}
