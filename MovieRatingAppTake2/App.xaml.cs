using MovieRatingAppTake2.Models.Data;
using MovieRatingAppTake2.Pages;
using MovieRatingAppTake2.Services.ServiceContracts;

namespace MovieRatingAppTake2
{
    public partial class App : Application
    {
        private readonly IGetTrendingMovies _getTrendingMoviesService;
        private readonly IGetActionMovies _getActionMoviesService;
        private readonly IGetAnimationMovies _getAnimationMoviesService;
        private readonly IGetCrimeMovies _getCrimeMoviesService;
        private readonly IGetDramaMovies _getDramaMoviesService;

        public App(IGetTrendingMovies getTrendingMoviesService,
                    IGetActionMovies getActionMoviesService,
                    IGetAnimationMovies getAnimationMoviesService,
                    IGetCrimeMovies getCrimeMoviesService,
                    IGetDramaMovies getDramaMoviesService)
        {
            InitializeComponent();
            _getTrendingMoviesService = getTrendingMoviesService;
            _getActionMoviesService = getActionMoviesService;
            _getAnimationMoviesService = getAnimationMoviesService;
            _getCrimeMoviesService = getCrimeMoviesService;
            _getDramaMoviesService = getDramaMoviesService;
            LoadTrendingMoviesAsync();
            MainPage = new AppShell();
        }
        private async void LoadTrendingMoviesAsync()
        {
            AppData.TrendingMovies = await _getTrendingMoviesService.GetTrendingMoviesAsync();
            AppData.ActionMovies = await _getActionMoviesService.GetActionMoviesAsync();
            AppData.AnimationMovies = await _getAnimationMoviesService.GetAnimationMoviesAsync();
            AppData.CrimeMovies = await _getCrimeMoviesService.GetCrimeMoviesAsync();
            AppData.DramaMovies= await _getDramaMoviesService.GetDramaMoviesAsync();
        }

    }
}