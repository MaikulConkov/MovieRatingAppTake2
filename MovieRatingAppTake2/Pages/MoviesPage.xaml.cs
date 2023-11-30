using MovieRatingAppTake2.Models;
using MovieRatingAppTake2.Models.Data;
using MovieRatingAppTake2.Services.ServiceContracts;
using MovieRatingAppTake2.ViewModels;

namespace MovieRatingAppTake2.Pages
{
    public partial class MoviesPage : ContentPage
    {
        private MoviesPageViewModel _mainPageViewModel;

        private readonly IAddRatedMovie _addRatedMovie;
        private readonly ISearchMovieRating _searchMovieRating;
        public MoviesPage(IAddRatedMovie addRatedMovie, ISearchMovieRating searchMovieRating)
        {
            InitializeComponent();
            Shell.SetNavBarIsVisible(this, false);
            _addRatedMovie = addRatedMovie;
            _searchMovieRating = searchMovieRating;
            _mainPageViewModel = new MoviesPageViewModel(_addRatedMovie, _searchMovieRating);
            BindingContext = _mainPageViewModel;
            
        }

        protected override void OnAppearing()
        {  
            base.OnAppearing();
            _mainPageViewModel.SelectRandomMovie();
        }

        private void MovieRow_OnMovieSelected(object sender, Models.Movie e)
        {
            _mainPageViewModel.SelectMovie(e);
        }

        private void MovieInfo_Close(object sender, EventArgs e)
        {
            _mainPageViewModel.SelectMovie(null);
        }

        private void MovieInfo_Rate(object sender, object e)
        {
            if (e is Movie movie)
            {
                _mainPageViewModel.AddRatedMovie(movie);
                _mainPageViewModel.SelectMovie(null);
            }
        }
    }
}