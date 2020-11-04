using System.Collections.Generic;
using TenMovies.Web.Models.Core.MovieModels;

namespace TenMovies.Web.Models.Repositories
{
    public interface IMovieListRepository
    {
        IEnumerable<Movie> GetAllMoviesInTop10(int movieListId);
        IEnumerable<MovieList> GetAllMoviesLists();
    }
}
