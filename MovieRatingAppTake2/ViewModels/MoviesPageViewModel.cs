using CommunityToolkit.Mvvm.Input;
using MovieRatingAppTake2.Models;
using MovieRatingAppTake2.Models.Data;
using MovieRatingAppTake2.Services.ServiceContracts;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MovieRatingAppTake2.ViewModels
{
    public partial class MoviesPageViewModel : INotifyPropertyChanged
    { 
        private Random _random = new Random();

        private readonly IAddRatedMovie _addRatedMovie;
        private readonly ISearchMovieRating _searchMovieRating;

        private ObservableCollection<Movie> _trendingMovies= new ObservableCollection<Movie>();
        private ObservableCollection<Movie> _actionMovies = new ObservableCollection<Movie>();
        private ObservableCollection<Movie> _animationMovies = new ObservableCollection<Movie>();
        private ObservableCollection<Movie> _crimeMovies = new ObservableCollection<Movie>();
        private ObservableCollection<Movie> _dramaMovies = new ObservableCollection<Movie>();

        private Movie _trendingMovie;

        private Movie _selectedMovie;

        private int _selectedMovieRating;

        private bool _rateButtonIsVisible;

        private bool _rateButtonIsReadOnly;
        public bool ShowMovieInfoBox => SelectedMovie is not null;

        public MoviesPageViewModel(IAddRatedMovie addRatedMovie, ISearchMovieRating searchMovieRating)
        {
            _searchMovieRating = searchMovieRating;
            _addRatedMovie = addRatedMovie;
        }

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged(nameof(SelectedMovie));
                OnPropertyChanged(nameof(ShowMovieInfoBox));
            }
        }
        public Movie TrendingMovie
        {
            get => _trendingMovie;
            set
            {
                _trendingMovie = value;
                OnPropertyChanged(nameof(TrendingMovie));
            }
        }
        public int SelectedMovieRating
        {
            get => _selectedMovieRating;
            set
            {
                _selectedMovieRating = value;
                OnPropertyChanged(nameof(SelectedMovieRating));
            }          
        }

        public bool RateButtonIsVisible
        {
            get => _rateButtonIsVisible;
            set
            {
                _rateButtonIsVisible = value;
                OnPropertyChanged(nameof(RateButtonIsVisible));
            }
        }

        public bool RateButtonIsReadOnly
        {
            get => _rateButtonIsReadOnly;
            set 
            { 
            _rateButtonIsReadOnly = value;
            OnPropertyChanged(nameof(RateButtonIsReadOnly));
            }
        }
        public ObservableCollection<Movie> TrendingMovies
        {
            get => _trendingMovies;
            set
            {
                _trendingMovies = value;
                OnPropertyChanged(nameof(TrendingMovies));
            }
        }
        public ObservableCollection<Movie> ActionMovies
        {
            get => _actionMovies;
            set
            {
                _actionMovies = value;
                OnPropertyChanged(nameof(ActionMovies));
            }
        }
        public ObservableCollection<Movie> AnimationMovies
        {
            get => _animationMovies;
            set
            {
                _animationMovies = value;
                OnPropertyChanged(nameof(AnimationMovies));
            }
        }
        public ObservableCollection<Movie> CrimeMovies
        {
            get => _crimeMovies;
            set
            {
                _crimeMovies = value;
                OnPropertyChanged(nameof(CrimeMovies));
            }
        }
        public ObservableCollection<Movie> DramaMovies
        {
            get => _dramaMovies;
            set
            {
                _dramaMovies = value;
                OnPropertyChanged(nameof(DramaMovies));
            }
        }
        

        public void SelectRandomMovie()
        {
            if (DramaMovies.Count == 0)
            {
                InitializeMovies();
            }
            if (AppData.TrendingMovies != null && AppData.TrendingMovies.Any())
            {
                int index = _random.Next(AppData.TrendingMovies.Count);
                TrendingMovie = AppData.TrendingMovies[index];
            }
        }
        private void InitializeMovies()
        {           
            TrendingMovies = new ObservableCollection<Movie>(AppData.TrendingMovies);
            ActionMovies = new ObservableCollection<Movie>(AppData.ActionMovies);
            AnimationMovies = new ObservableCollection<Movie>(AppData.AnimationMovies);
            CrimeMovies = new ObservableCollection<Movie>(AppData.CrimeMovies);
            DramaMovies = new ObservableCollection<Movie>(AppData.DramaMovies);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [RelayCommand]
        public async void SelectMovie(Movie movie)
        {
            if(movie is not null)
            {
                if (movie.Id == SelectedMovie?.Id)
                {
                    movie = null;
                }
                else
                {
                    var result= _searchMovieRating.GetMovieRating(movie);
                    SelectedMovieRating = result;
                    if(result > 0)
                    {
                        RateButtonIsVisible = false;
                        RateButtonIsReadOnly = true;
                    }
                    else
                    {
                        RateButtonIsVisible= true;
                        RateButtonIsReadOnly = false;
                    }
                }
            }
            SelectedMovie = movie;
        }

        public void AddRatedMovie(Movie? movie)
        {
            _addRatedMovie.AddRatedMovie(movie);
        }
    }
}
