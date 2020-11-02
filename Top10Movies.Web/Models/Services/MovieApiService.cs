using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top10Movies.Web.Models.Clients;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models.Services
{
    public class MovieApiService : IMovieApiService
    {
        private readonly IMovieApiClient _client;

        public MovieApiService(IMovieApiClient client)
        {
            _client = client;
        }
        public async Task<Movie> GetMovieByIdAsync(int? id)
        {
            return await _client.GetMovieByIdAsync(id);
        }
        //Example URI https://api.themoviedb.org/3/find/{external_id}?api_key=<<api_key>>&language=en-US&external_source=imdb_id
        public async Task<Movie> GetMovieByImdbIdAsync(string imdbId)
        {
            return await _client.GetMovieByImdbIdAsync(imdbId);
        }

        //https://api.themoviedb.org/3/search/movie?api_key=<<api_key>>&language=en-US&query={searchTerm}&include_adult=false 
        //DOCS: https://developers.themoviedb.org/3/search/search-movies
        public async Task<IQueryable<Movie>> GetMoviesBySearchTermAsync(string searchTerm)
        {
            return await _client.GetMoviesBySearchTermAsync(searchTerm);
        }
    }
}
