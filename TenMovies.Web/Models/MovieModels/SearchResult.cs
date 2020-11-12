using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TenMovies.Web.Models.MovieModels
{
    public class SearchResult
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("results")]
        public List<Movie> Movies { get; set; }
    }
}