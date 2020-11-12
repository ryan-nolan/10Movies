using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TenMovies.Web.Models.User;

namespace TenMovies.Web.Models.MovieModels
{
    public class MovieList
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
        public Guid UserId { get; set; }

        [DisplayName("Make List Private?")]
        public bool IsPrivate { get; set; }
    }
}
