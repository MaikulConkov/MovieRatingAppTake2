using MovieRatingAppTake2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MovieRatingAppTake2.Repositories.RepositoryContracts
{
    public interface IMovieRepository
    {
        public Task<List<Movie>> GetTrendingMoviesAsync();

        public Task<List<Movie>> GetActionMoviesAsync();

        public Task<List<Movie>> GetAnimationMoviesAsync();

        public Task<List<Movie>> GetCrimeMoviesAsync();

        public Task<List<Movie>> GetDramaMoviesAsync();

        public void AddRatedMovie(Movie movie);

        public List<Movie> GetRatedMovies();

        public int GetMovieRating(Movie movie);
    }
}
