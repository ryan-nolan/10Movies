using System;
using System.Linq;
using Top10Movies.Web.Data;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models.Repositories
{
    public class EFMovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public EFMovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public Movie GetMovieById(int id)
        {
            return _context.Movies.First(m => m.Id == id);
        }

        public Movie CreateMovie(Movie m)
        {
            throw new NotImplementedException();
        }

        public Movie DeleteMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public Movie DeleteMovie(Movie m)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
