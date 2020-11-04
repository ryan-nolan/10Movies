using System.Collections.Generic;
using System.Linq;
using TenMovies.Web.Data;
using TenMovies.Web.Models.Core.MovieModels;

namespace TenMovies.Web.Models.Repositories
{
    public class EFMovieListRepository : IMovieListRepository
    {
        private readonly MovieDbContext context;

        public EFMovieListRepository(MovieDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Movie> GetAllMoviesInTop10(int movieListId)
        {
            return context.Movies.Where(m => m.MovieListId == movieListId);
        }

        public IEnumerable<MovieList> GetAllMoviesLists()
        {
            return context.MovieLists;
        }
    }
}
