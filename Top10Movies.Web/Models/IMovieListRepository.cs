using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top10Movies.Web.Models
{
    public interface IMovieListRepository
    {
        IEnumerable<Movie> GetAllMoviesInTop10(int movieListId);
        IEnumerable<MovieList> GetAllMoviesLists();
    }
}
