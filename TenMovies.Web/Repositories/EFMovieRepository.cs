﻿using System;
using System.Linq;
using TenMovies.Web.Data;
using TenMovies.Web.Models.MovieModels;

namespace TenMovies.Web.Repositories
{
    public class EfMovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public EfMovieRepository(MovieDbContext context)
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
