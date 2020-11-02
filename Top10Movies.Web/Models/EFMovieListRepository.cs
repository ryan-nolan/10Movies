using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top10Movies.Web.Data;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models
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
