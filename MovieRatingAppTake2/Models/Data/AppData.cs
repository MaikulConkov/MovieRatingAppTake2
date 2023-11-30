using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MovieRatingAppTake2.Models.Data
{
    public static class AppData
    {
        public static List<Movie> RatedMovies { get; set; } = new List<Movie>();

        public static List<Movie> TrendingMovies { get; set; }

        public static List<Movie> ActionMovies { get; set; }

        public static List<Movie> AnimationMovies { get; set; }

        public static List<Movie> CrimeMovies { get; set; }

        public static List<Movie> DramaMovies { get; set; }
    }
}
