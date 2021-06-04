using egylex.Models.MovieCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace egylex.Models.Movies
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public DateTime Date { get; set; }
        public string story { get; set; }
        public string Triler { get; set; }
        public string Image { get; set; }
        public string Video { get; set; }
        public IList<MoviesCategory> MoviesCategories { get; set; }
    }
}
