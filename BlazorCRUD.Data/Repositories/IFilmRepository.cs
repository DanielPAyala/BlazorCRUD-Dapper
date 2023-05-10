using BlazorCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Repositories
{
    public interface IFilmRepository
    {
        Task<IEnumerable<Film>> GetAllFilms();
        Task<Film> GetFilmDetails(int id);
        Task<bool> InsertFilm(Film film);
        Task<bool> UpdateFilm(Film film);
        Task<bool> DeleteFilm(int id);
    }
}
