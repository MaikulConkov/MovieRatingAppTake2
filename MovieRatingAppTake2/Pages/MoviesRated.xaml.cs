using MovieRatingAppTake2.Services.ServiceContracts;
using MovieRatingAppTake2.ViewModels;

namespace MovieRatingAppTake2.Pages;

public partial class MoviesRated : ContentPage
{
    private readonly RatedMoviesViewModel _viewModel;
    private readonly IGetRatedMovies _getRatedMovies;
    public MoviesRated(IGetRatedMovies getRatedMovies)
    {
        InitializeComponent();
        Shell.SetNavBarIsVisible(this, false);
        _getRatedMovies = getRatedMovies;
        _viewModel = new RatedMoviesViewModel(_getRatedMovies);
        BindingContext = _viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.InitializeAsync();
    }
}