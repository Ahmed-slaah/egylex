using egylex.Models.Categories;
using egylex.Models.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace egylex.Models.MovieCategory
{
    public class MoviesCategory
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int CategoryId { get; set; }
        public Category Category{ get; set; }


    }
}
