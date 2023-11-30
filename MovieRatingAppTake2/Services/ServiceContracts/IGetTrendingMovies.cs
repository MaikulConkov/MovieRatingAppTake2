using MovieRatingAppTake2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MovieRatingAppTake2.Services.ServiceContracts
{
    public interface IGetTrendingMovies
    {
        public Task<List<Movie>> GetTrendingMoviesAsync();
    }
}
