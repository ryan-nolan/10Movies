using System;
using System.Collections.Generic;
using TenMovies.Web.Models.User;

namespace TenMovies.Web.Models.MovieModels
{
    public class MovieList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
    }
}
