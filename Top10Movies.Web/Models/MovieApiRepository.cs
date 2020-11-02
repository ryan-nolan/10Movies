using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
            string requestUri = $"https://api.themoviedb.org/3/movie/{id}?api_key="+ _apiKey;
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

        public Task<Movie> GetMovieByTitle(string title)
        {
            throw new NotImplementedException();
        }
    }
}
