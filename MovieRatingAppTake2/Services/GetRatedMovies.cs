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
    public class GetRatedMovies : IGetRatedMovies
    {
        private readonly IMovieRepository _repository;

        public GetRatedMovies(IMovieRepository repository)
        {
            _repository = repository;
        }
        List<Movie> IGetRatedMovies.GetRatedMovies()
        {
            var result=_repository.GetRatedMovies();
            return result;
        }
    }
}
