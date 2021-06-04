using egylex.Models.Seasons;
using egylex.Models.SeriesCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace egylex.Models.Series
{
    public class Serie
    {
        [Key]
        public int SeriesId { get; set; }
        public string SeriesName { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public DateTime Date { get; set; }
        public string story { get; set; }
        public string Triler { get; set; }
        public string Image { get; set; }
        public ICollection<Season> seasons { get; set; }
        public IList<SeriesCategory> SeriesCategories { get; set; }
    }
}
