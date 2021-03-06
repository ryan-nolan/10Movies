﻿using System.Linq;
using System.Threading.Tasks;
using TenMovies.Web.Models.MovieModels;

namespace TenMovies.Web.Clients
{
    public interface IMovieApiClient
    {
        Task<Movie> GetMovieByIdAsync(int? id);
        Task<Movie> GetMovieByImdbIdAsync(string imdbId);
        Task<IQueryable<Movie>> GetMoviesBySearchTermAsync(string searchTerm);
    }
}
