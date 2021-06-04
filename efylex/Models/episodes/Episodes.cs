using egylex.Models.Seasons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace egylex.Models.episodes
{
    public class Episodes
    {
        [Key]
        public int EpisodeId { get; set; }
        public string EpisodeName { get; set; }
        public string Video { get; set; }
        public Season Season { get; set; }
    }
}
