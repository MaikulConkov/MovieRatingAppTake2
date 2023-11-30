using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRatingAppTake2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string DisplayTitle { get; set; }

        public string MediaType { get; set; }

        public string MediaGenre { get; set; }

        public string Thumbnail { get; set; }

        public string ThumbnailSmall { get; set; }

        public string ThumbnailUrl { get; set; }

        public string Overview { get; set; }

        public string ReleaseDate { get; set; }

        public int Rating { get; set; } =0;
    }
}
