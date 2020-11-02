using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models
{
    public interface IMovieRepository
    {
        Task<Movie> GetMovieById(int id);
        Movie CreateMovie(Movie m);
        Movie DeleteMovieById(int id);
        Movie DeleteMovie(Movie m);
        int SaveChanges();

    }
}
