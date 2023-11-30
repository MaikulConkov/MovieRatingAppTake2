using Microsoft.Maui.Controls;
using MovieRatingAppTake2.Models;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace MovieRatingAppTake2.Controls;

public partial class MovieRow : ContentView
{
	public static readonly BindableProperty HeadingProperty = BindableProperty.Create(nameof(Heading), typeof(string), typeof(MovieRow), string.Empty);
	public static readonly BindableProperty MoviesProperty = BindableProperty.Create(nameof(Movies), typeof(IEnumerable<Movie>), typeof(MovieRow), Enumerable.Empty<Movie>());

	public event EventHandler<Movie> OnMovieSelected;
	public MovieRow()
	{
        InitializeComponent();
		MovieSelectedCommand = new Command(ExecuteMovieSelectedCommand);
    }

	public string Heading
	{
		get=>(string)GetValue(HeadingProperty);
		set => SetValue(HeadingProperty, value);
	}

	public IEnumerable<Movie> Movies
	{
		get=>(IEnumerable<Movie>)GetValue(MoviesProperty);
		set=>SetValue(MoviesProperty, value);
	}

	public ICommand MovieSelectedCommand { get; set; }

	private void ExecuteMovieSelectedCommand(object parameter)
	{
		if(parameter is Movie movie && movie is not null)
		{
			OnMovieSelected?.Invoke(this, movie);
		}
	}

}