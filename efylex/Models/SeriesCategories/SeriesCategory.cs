using egylex.Models.Categories;
using egylex.Models.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace egylex.Models.SeriesCategories
{
    public class SeriesCategory
    {
        public int SeriesId { get; set; }
        public Serie Serie{ get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
