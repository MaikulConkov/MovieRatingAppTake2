using MovieRatingAppTake2.Models;
using MovieRatingAppTake2.Services.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRatingAppTake2.ViewModels
{
    public class RatedMoviesViewModel : INotifyPropertyChanged
    {
        private readonly IGetRatedMovies _getRatedMovies;
        public RatedMoviesViewModel(IGetRatedMovies getRatedMovies) { _getRatedMovies = getRatedMovies; }

        private ObservableCollection<Movie> _ratedMovies = new ObservableCollection<Movie>();


        public ObservableCollection<Movie> RatedMovies
        {
            get => _ratedMovies;
            set
            {
                _ratedMovies = value;
                OnPropertyChanged(nameof(RatedMovies));
            }
        }

        public void InitializeAsync()
        {
            RatedMovies = new ObservableCollection<Movie>(_getRatedMovies.GetRatedMovies());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
