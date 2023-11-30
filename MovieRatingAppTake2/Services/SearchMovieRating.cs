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
    public class SearchMovieRating : ISearchMovieRating
    {
        private readonly IMovieRepository _repository;

        public SearchMovieRating(IMovieRepository repository)
        {
            _repository = repository;
        }

        public int GetMovieRating(Movie movie)
        {
            var result = _repository.GetMovieRating(movie);
            return result;
        }
    }
}
