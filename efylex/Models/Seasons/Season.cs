using egylex.Models.episodes;
using egylex.Models.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace egylex.Models.Seasons
{
    public class Season
    {
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
        public string SeasonImage { get; set; }
        public Serie Serie { get; set; }
        public ICollection<Episodes> Episodes{ get; set; }



    }
}
