using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top10Movies.Web.Models
{
    public interface IMovieRepository
    {
        Movie GetMyovieById(int id);
        Movie CreateMovie(Movie m);
        Movie DeleteMovieById(int id);
        Movie DeleteMovie(Movie m);
        int SaveChanges();

    }
}
