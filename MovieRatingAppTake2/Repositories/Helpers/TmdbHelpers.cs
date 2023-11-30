using MovieRatingAppTake2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MovieRatingAppTake2.Repositories.Helpers
{
    public static class TmdbHelpers
    {
        public static string Trending(string type)
        {
            return $"3/trending/{type}/week?language=en-US";
        }

        public static string Action(string type)
        {
            if (type == "movie")
            {
                return $"3/discover/{type}?language=en-US&with_genres=28";
            }
            return $"3/discover/{type}?language=en-US&with_genres=10759";
        }

        public static string Animation(string type)
        {
            return $"3/discover/{type}?language=en-US&with_genres=16";

        }

        public static string Crime(string type)
        {
            return $"3/discover/{type}?language=en-US&with_genres=80";
        }

        public static string Drama(string type)
        {
            return $"3/discover/{type}?language=en-US&with_genres=18";
        }

        public static void FetchData(Response response, List<Movie> datamedia)
        {
            foreach (var r in response.results)
            {
                var result = r.ToMovieObject();
                datamedia.Add(result);
            }
        }

        public class Response
        {
            public Result[] results { get; set; }
        }
        public class Result
        {
            public string backdrop_path { get; set; }
            public int id { get; set; }
            public string original_title { get; set; }
            public string original_name { get; set; }
            public string overview { get; set; }
            public string poster_path { get; set; }
            public string release_date { get; set; }
            public string title { get; set; }
            public string name { get; set; }
            public string media_type { get; set; } 
            public string ThumbnailPath => poster_path ?? backdrop_path;
            public string Thumbnail => $"https://image.tmdb.org/t/p/w600_and_h900_bestv2/{ThumbnailPath}";
            public string ThumbnailSmall => $"https://image.tmdb.org/t/p/w220_and_h330_face/{ThumbnailPath}";
            public string ThumbnailUrl => $"https://image.tmdb.org/t/p/original/{ThumbnailPath}";
            public string DisplayTitle => title ?? name ?? original_title ?? original_name;

            public Movie ToMovieObject() =>
                new()
                {
                    Id = id,
                    DisplayTitle = DisplayTitle,
                    MediaType = media_type,
                    Overview = overview,
                    ReleaseDate = release_date,
                    Thumbnail = Thumbnail,
                    ThumbnailSmall = ThumbnailSmall,
                    ThumbnailUrl = ThumbnailUrl
                };
        }
    }
}
