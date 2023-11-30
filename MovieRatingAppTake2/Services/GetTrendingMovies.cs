using MovieRatingAppTake2.Models;
using MovieRatingAppTake2.Repositories.RepositoryContracts;
using MovieRatingAppTake2.Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MovieRatingAppTake2.Services
{
    public class GetTrendingMovies : IGetTrendingMovies
    {
        private readonly IMovieRepository _repository;

        public GetTrendingMovies(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Movie>> GetTrendingMoviesAsync()
        {
            var result = await _repository.GetTrendingMoviesAsync();
            return result;
        }
    }
}
