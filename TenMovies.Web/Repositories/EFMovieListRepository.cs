using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using TenMovies.Web.Data;
using TenMovies.Web.Models.MovieModels;
using TenMovies.Web.Models.User;

namespace TenMovies.Web.Repositories
{
    public class EfMovieListRepository : IMovieListRepository
    {
        private readonly MovieDbContext _context;
        //private readonly UserManager<User> _userManager;

        public EfMovieListRepository(MovieDbContext context)
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

        public MovieList GetListById(int id)
        {
            return _context.MovieLists.First(l => l.Id == id);
        }

        public bool IsDuplicate(int movieId, int listId)
        {
            return _context.Movies.Any(m => m.Id == movieId && m.MovieListId == listId);
        }

        public MovieList GetListByMovieId(int movieId)
        {
            return _context.MovieLists.First(l => _context.Movies.First(m => m.Id == movieId).MovieListId == l.Id);
        }

        public MovieList DeleteListById(int movieListId)
        {
            var ml = _context.MovieLists.First(l => l.Id == movieListId);
            _context.Remove(ml);
            _context.SaveChanges();
            return ml;
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
