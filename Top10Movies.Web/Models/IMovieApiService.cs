using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models
{
    public interface IMovieApiService
    {
        Task<Movie> GetMovieById(int id);
        Task<Movie> GetMovieByImdbId(string imdbId);
        Task<Movie> GetMovieByTitle(string title);
    }
}
