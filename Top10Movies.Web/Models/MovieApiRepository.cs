﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Top10Movies.Web.Models.Core;

namespace Top10Movies.Web.Models
{
    public class MovieApiRepository : IMovieApiService
    {
        private readonly IConfiguration _config;

        public MovieApiRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<Movie> GetMovieById(int id)
        {
            Movie m;
            string requestUri = $"https://api.themoviedb.org/3/movie/{id}?api_key="+ _config["MoviesApiKey"];
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
