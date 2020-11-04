using System.Collections.Generic;
using System.Text.Json.Serialization;
using TenMovies.Web.Models.Core.MovieModels;

namespace TenMovies.Web.Models.Core
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