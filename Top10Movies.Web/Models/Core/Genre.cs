﻿using System.Text.Json.Serialization;

namespace TenMovies.Web.Models.Core
{
    public class Genre
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}