using MovieRatingAppTake2.Models;
using MovieRatingAppTake2.Models.Data;
using MovieRatingAppTake2.Repositories.Helpers;
using MovieRatingAppTake2.Repositories.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MovieRatingAppTake2.Repositories
{
    internal class MovieRepository : IMovieRepository
    {
        private const string ApiKey = "";
        public const string TmdbHttpClientName = "TmdbClient";
        private readonly IHttpClientFactory _httpCLientFactory;
        public MovieRepository(IHttpClientFactory httpCLientFactory)
        {
            _httpCLientFactory = httpCLientFactory;
        }

        private HttpClient HttpClient => _httpCLientFactory.CreateClient(TmdbHttpClientName);

        public async Task<List<Movie>> GetTrendingMoviesAsync()
        {
            var url = TmdbHelpers.Trending("movie");
            var moviesTrendingCollection = await HttpClient.GetFromJsonAsync<TmdbHelpers.Response>($"{url}&api_key={ApiKey}");
            List<Movie> trendingMovies = new List<Movie>();
            foreach (var r in moviesTrendingCollection.results)
            {
                var result = r.ToMovieObject();
                trendingMovies.Add(result);
            }
            return trendingMovies;
        }

        public async Task<List<Movie>> GetActionMoviesAsync()
        {
            var url = TmdbHelpers.Action("movie");
            var moviesTrendingCollection = await HttpClient.GetFromJsonAsync<TmdbHelpers.Response>($"{url}&api_key={ApiKey}");
            List<Movie> actionMovies = new List<Movie>();
            foreach (var r in moviesTrendingCollection.results)
            {
                var result = r.ToMovieObject();
                actionMovies.Add(result);
            }
            return actionMovies;
        }

        public async Task<List<Movie>> GetAnimationMoviesAsync()
        {
            var url = TmdbHelpers.Animation("movie");
            var moviesTrendingCollection = await HttpClient.GetFromJsonAsync<TmdbHelpers.Response>($"{url}&api_key={ApiKey}");
            List<Movie> animationMovies = new List<Movie>();
            foreach (var r in moviesTrendingCollection.results)
            {
                var result = r.ToMovieObject();
                animationMovies.Add(result);
            }
            return animationMovies;
        }

        public async Task<List<Movie>> GetCrimeMoviesAsync()
        {
            var url = TmdbHelpers.Crime("movie");
            var moviesTrendingCollection = await HttpClient.GetFromJsonAsync<TmdbHelpers.Response>($"{url}&api_key={ApiKey}");
            List<Movie> crimeMovies = new List<Movie>();
            foreach (var r in moviesTrendingCollection.results)
            {
                var result = r.ToMovieObject();
                crimeMovies.Add(result);
            }
            return crimeMovies;
        }

        public async Task<List<Movie>> GetDramaMoviesAsync()
        {
            var url = TmdbHelpers.Drama("movie");
            var moviesTrendingCollection = await HttpClient.GetFromJsonAsync<TmdbHelpers.Response>($"{url}&api_key={ApiKey}");
            List<Movie> dramaMovies = new List<Movie>();
            foreach (var r in moviesTrendingCollection.results)
            {
                var result = r.ToMovieObject();
                dramaMovies.Add(result);
            }
            return dramaMovies;
        }

        public void AddRatedMovie(Movie movie)
        {
            AppData.RatedMovies.Add(movie);
        }

        public List<Movie> GetRatedMovies()
        {
            var result = AppData.RatedMovies;
            return result;
        }

        public int GetMovieRating(Movie movie)
        {
            var rating = 0;
            foreach(var m in AppData.RatedMovies)
            {
                if(movie.Id == m.Id)
                {
                    rating = m.Rating;
                    break;
                }
            }
            return rating;
        }
    }
}
