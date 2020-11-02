using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using TenMovies.Web.Models.Core;

namespace TenMovies.Web.Models.Clients
{
    public class MovieApiClient : IMovieApiClient
    {
        //private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey;
        public MovieApiClient(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _apiKey = config["MoviesApiKey"];
        }

        public async Task<Movie> GetMovieByIdAsync(int? id)
        {

            if (id != null & id != 0)
            {
                string requestUri = $"https://api.themoviedb.org/3/movie/{id.Value}?api_key={_apiKey}&language=en-US";
                var httpClient = _httpClientFactory.CreateClient();
                using (var response = await httpClient.GetAsync(requestUri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<Movie>(apiResponse);
                }

            }
            return null;
        }
        //Example URI https://api.themoviedb.org/3/find/{external_id}?api_key=<<api_key>>&language=en-US&external_source=imdb_id
        public async Task<Movie> GetMovieByImdbIdAsync(string imdbId)
        {
            string requestUri = $"https://api.themoviedb.org/3/find/{imdbId}?api_key={_apiKey}&language=en-US&external_source=imdb_id";
            var httpClient = _httpClientFactory.CreateClient();
            using (var response = await httpClient.GetAsync(requestUri))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(apiResponse);
                var jsonMovieResults = json["movie_results"][0]["id"];
                return await GetMovieByIdAsync(jsonMovieResults.Value<int>());
            }

        }


        //https://api.themoviedb.org/3/search/movie?api_key=<<api_key>>&language=en-US&query=Borat&include_adult=false 
        //DOCS: https://developers.themoviedb.org/3/search/search-movies
        public async Task<IQueryable<Movie>> GetMoviesBySearchTermAsync(string searchTerm)
        {
            //IQueryable<Movie> movies;
            string requestUri = $"https://api.themoviedb.org/3/search/movie?api_key={_apiKey}&language=en-US&query={searchTerm}&include_adult=false";
            var httpClient = _httpClientFactory.CreateClient();
            using (var response = await httpClient.GetAsync(requestUri))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<SearchResult>(apiResponse).Movies.AsQueryable();
            }

        }
    }
}
