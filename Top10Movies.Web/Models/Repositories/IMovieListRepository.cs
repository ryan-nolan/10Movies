using System.Collections.Generic;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models.Repositories
{
    public interface IMovieListRepository
    {
        IEnumerable<Movie> GetAllMoviesInTop10(int movieListId);
        IEnumerable<MovieList> GetAllMoviesLists();
    }
}
