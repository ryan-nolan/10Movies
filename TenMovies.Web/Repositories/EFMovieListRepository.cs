using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using TenMovies.Web.Data;
using TenMovies.Web.Models.MovieModels;
using TenMovies.Web.Models.User;

namespace TenMovies.Web.Repositories
{
    public class EFMovieListRepository : IMovieListRepository
    {
        private readonly MovieDbContext _context;
        //private readonly UserManager<User> _userManager;

        public EFMovieListRepository(MovieDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieList> GetAllListsForUser(Guid userGuid)
        {
            return _context.MovieLists.Where(l => l.UserId == userGuid);
        }

        public void AddList(MovieList list)
        {
            _context.MovieLists.Add(list);
            _context.SaveChanges();
        }

        public IEnumerable<Movie> GetAllMoviesInMovieList(int movieListId)
        {
            return _context.Movies.Where(m => m.MovieListId == movieListId);
        }

        public IEnumerable<MovieList> GetAllMoviesLists()
        {
            return _context.MovieLists;
        }
    }
}
