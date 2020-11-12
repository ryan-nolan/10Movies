using System.Collections.Generic;
using TenMovies.Web.Models.MovieModels;

namespace TenMovies.Web.Repositories
{
    public interface IMovieListRepository
    {
        IEnumerable<Movie> GetAllMoviesInTop10(int movieListId);
        IEnumerable<MovieList> GetAllMoviesLists();
    }
}
