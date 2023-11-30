using MovieRatingAppTake2.Models;
using MovieRatingAppTake2.Repositories.RepositoryContracts;
using MovieRatingAppTake2.Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRatingAppTake2.Services
{
    public class GetDramaMovies : IGetDramaMovies
    {
        private readonly IMovieRepository _repository;

        public GetDramaMovies(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Movie>> GetDramaMoviesAsync()
        {
            var result = await _repository.GetDramaMoviesAsync();
            return result;
        }
    }
}
