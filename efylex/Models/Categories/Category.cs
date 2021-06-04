using egylex.Models.MovieCategory;
using egylex.Models.SeriesCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace egylex.Models.Categories
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        
        [Required]
        public string CategoryName { get; set; }
        public IList<MoviesCategory> MoviesCategories { get; set; }
        public IList<SeriesCategory> SeriesCategories{ get; set; }



    }
}
