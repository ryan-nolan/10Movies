using System.Text.Json.Serialization;

namespace TenMovies.Web.Models.Core
{
    public class SpokenLanguage
    {
        [JsonPropertyName("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}