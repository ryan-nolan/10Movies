using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TenMovies.Web.Models.MovieModels;

namespace TenMovies.Web.Models.ViewModels
{
    public class AddMovieToListViewModel
    {
        public Movie MovieToAdd { get; set; }
        public IEnumerable<MovieList> UsersMovieLists { get; set; }
        [Required] public int MovieId { get; set; }
        [Required] public int ListId { get; set; }
    }
}
