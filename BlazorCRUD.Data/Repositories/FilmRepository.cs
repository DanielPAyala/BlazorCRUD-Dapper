using BlazorCRUD.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private string _connectionString;

        public FilmRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection DbConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public Task<bool> DeleteFilm(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Film>> GetAllFilms()
        {
            using var db = DbConnection();
            var query = @"SELECT Id, Title, Director, ReleaseDate FROM Films";
            return await db.QueryAsync<Film>(query.ToString());
        }

        public async Task<Film> GetFilmDetails(int id)
        {
            using var db = DbConnection();
            var query = "SELECT Id, Title, Director, ReleaseDate FROM Films WHERE Id = @id";
            return await db.QueryFirstOrDefaultAsync<Film>(query.ToString(), new { id });
        }

        public async Task<bool> InsertFilm(Film film)
        {
            using var db = DbConnection();
            var query = @"INSERT INTO Films (Title, Director, ReleaseDate) VALUES(@Title, @Director, @ReleaseDate)";

            var result = await db.ExecuteAsync(query.ToString(), new
            {
                film.Title,
                film.Director,
                film.ReleaseDate
            });

            return result > 0;
        }

        public async Task<bool> UpdateFilm(Film film)
        {
            using var db = DbConnection();
            var query = @"UPDATE Films SET Title=@Title, Director=@Director, ReleaseDate=@ReleaseDate WHERE Id=@Id";

            var result = await db.ExecuteAsync(query.ToString(), new
            {
                film.Title,
                film.Director,
                film.ReleaseDate,
                film.Id
            });

            return result > 0;
        }
    }
}
