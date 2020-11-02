using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models
{
    public class MovieApiRepository : IMovieApiService
    {
        private readonly IConfiguration _config;
        private readonly string _apiKey;
        public MovieApiRepository(IConfiguration config)
        {
            _config = config;
            _apiKey = config["MoviesApiKey"];
        }
        public async Task<Movie> GetMovieById(int? id)
        {
            Movie m = null;
            if (id != null & id != 0)
            {
                string requestUri = $"https://api.themoviedb.org/3/movie/{id.Value}?api_key={_apiKey}&language=en-US";
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(requestUri))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        m = JsonSerializer.Deserialize<Movie>(apiResponse);
                    }
                }
            }
            return m;
        }
        //Example URI https://api.themoviedb.org/3/find/{external_id}?api_key=<<api_key>>&language=en-US&external_source=imdb_id
        public async Task<Movie> GetMovieByImdbId(string imdbId)
        {
            Movie m;
            string requestUri = $"https://api.themoviedb.org/3/find/{imdbId}?api_key={_apiKey}&language=en-US&external_source=imdb_id";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(apiResponse);
                    var jsonMovieResults = json["movie_results"][0]["id"];
                    m = await GetMovieById(jsonMovieResults.Value<int>());
                }
            }

            return m;
        }


        //https://api.themoviedb.org/3/search/movie?api_key=<<api_key>>&language=en-US&query=Borat&include_adult=false 
        //DOCS: https://developers.themoviedb.org/3/search/search-movies
        public async Task<IQueryable<Movie>> GetMoviesBySearchTerm(string searchTerm)
        {
            IQueryable<Movie> movies;
            string requestUri = $"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&language=en-US&query={searchTerm}&include_adult=false";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movies = JsonSerializer.Deserialize<SearchResult>(apiResponse).Movies.AsQueryable();
                }
            }
            return movies;
        }
    }
}
