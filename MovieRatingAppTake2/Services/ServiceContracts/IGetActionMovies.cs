using MovieRatingAppTake2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRatingAppTake2.Services.ServiceContracts
{
    public interface IGetActionMovies
    {
        public Task<List<Movie>> GetActionMoviesAsync();
    }
}
