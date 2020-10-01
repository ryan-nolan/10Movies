using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Top10Movies.Web.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public int Revenue { get; set; }
        public int Budget { get; set; }
        public int Runtime { get; set; }
        public string Genres { get; set; } //Potentially Change to List<Genre> where Genre is an object with an Id and a GenreString
        [ForeignKey("MoviesListId")]
        public int MovieListId { get; set; }
    }
}
