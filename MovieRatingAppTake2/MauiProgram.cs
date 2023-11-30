using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MovieRatingAppTake2.Pages;
using MovieRatingAppTake2.Repositories;
using MovieRatingAppTake2.Repositories.RepositoryContracts;
using MovieRatingAppTake2.Services;
using MovieRatingAppTake2.Services.ServiceContracts;
using MovieRatingAppTake2.ViewModels;

namespace MovieRatingAppTake2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif  
            builder.Services.AddHttpClient(MovieRepository.TmdbHttpClientName, httpClient => httpClient.BaseAddress = new Uri("https://api.themoviedb.org"));
            builder.Services.AddSingleton<IMovieRepository, MovieRepository>();
            builder.Services.AddSingleton<IGetTrendingMovies, GetTrendingMovies>();
            builder.Services.AddSingleton<IGetActionMovies, GetActionMovies>();
            builder.Services.AddSingleton<IGetAnimationMovies, GetAnimationMovies>();
            builder.Services.AddSingleton<IGetCrimeMovies, GetCrimeMovies>();
            builder.Services.AddSingleton<IGetDramaMovies, GetDramaMovies>();
            builder.Services.AddSingleton<IAddRatedMovie, AddRatedMovie>();
            builder.Services.AddSingleton<IGetRatedMovies, GetRatedMovies>();
            builder.Services.AddSingleton<ISearchMovieRating, SearchMovieRating>();
            builder.Services.AddSingleton<MoviesPageViewModel>();
            builder.Services.AddSingleton<MoviesPage>();
            builder.Services.AddSingleton<RatedMoviesViewModel>();
            builder.Services.AddSingleton<MoviesRated>();
            return builder.Build();
        }
    }
}