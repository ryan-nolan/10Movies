using System.Text.Json.Serialization;

namespace TenMovies.Web.Models.MovieModels
{
    public class ProductionCountry
    {
        [JsonPropertyName("iso_3166_1")]
        public string Iso31661 { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}