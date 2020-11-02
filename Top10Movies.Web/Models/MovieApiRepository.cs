using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        public async Task<Movie> GetMovieById(int id)
        {
            Movie m;
            string requestUri = $"https://api.themoviedb.org/3/movie/{id}?api_key={_apiKey}";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    m = JsonConvert.DeserializeObject<Movie>(apiResponse);
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

        public Task<Movie> GetMovieByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
