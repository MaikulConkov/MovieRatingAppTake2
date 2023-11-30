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
    public class AddRatedMovie : IAddRatedMovie
    {
        private readonly IMovieRepository _repository;

        public AddRatedMovie(IMovieRepository repository)
        {
            _repository= repository;
        }
        void IAddRatedMovie.AddRatedMovie(Movie movie)
        {
            _repository.AddRatedMovie(movie);
        }
    }
}
