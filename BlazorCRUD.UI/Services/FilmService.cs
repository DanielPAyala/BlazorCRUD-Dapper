using BlazorCRUD.Data.Repositories;
using BlazorCRUD.Model;
using BlazorCRUD.UI.Data;
using BlazorCRUD.UI.Interfaces;

namespace BlazorCRUD.UI.Services
{
    public class FilmService : IFilmService
    {
        private readonly SqlConfiguration _sqlConfiguration;
        private readonly IFilmRepository _filmRepository;

        public FilmService(SqlConfiguration sqlConfiguration)
        {
            _sqlConfiguration = sqlConfiguration;
            _filmRepository = new FilmRepository(sqlConfiguration.ConnectionString);
        }

        public Task<bool> DeleteFilm(int id)
        {
            return _filmRepository.DeleteFilm(id);
        }

        public Task<IEnumerable<Film>> GetAllFilms()
        {
            return _filmRepository.GetAllFilms();
        }

        public Task<Film> GetDetails(int id)
        {
            return _filmRepository.GetFilmDetails(id);
        }

        public Task<bool> SaveFilm(Film film)
        {
            if (film.Id == 0)
            {
                return _filmRepository.InsertFilm(film);
            }
            else
            {
                return _filmRepository.UpdateFilm(film);
            }
        }
    }
}
