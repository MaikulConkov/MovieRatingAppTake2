
using MovieRatingAppTake2.Models;
using MovieRatingAppTake2.Models.Data;
using System.ComponentModel;
using System.Threading.Channels;
using System.Windows.Input;

namespace MovieRatingAppTake2.Controls;

public partial class MovieInfo : ContentView
{
	public static BindableProperty MovieProperty = BindableProperty.Create(nameof(Movie), typeof(Movie), typeof(MovieInfo), null);
	public static BindableProperty MovieRatingProperty= BindableProperty.Create(nameof(MovieRating), typeof(int), typeof(MovieInfo), 0);
	public static BindableProperty RateButtonIsVisibleProperty = BindableProperty.Create(nameof(RateButtonIsVisible), typeof(bool), typeof(MovieInfo));
	public static BindableProperty RateButtonIsReadOnlyProperty = BindableProperty.Create(nameof(RateButtonIsReadOnly), typeof(bool), typeof(MovieInfo), false);
	public event EventHandler Close;
	public event EventHandler<Movie> Rate;


    public MovieInfo()
	{
		InitializeComponent();
	}

	public Movie Movie
	{
		get=>(Movie)GetValue(MovieInfo.MovieProperty);
		set=> SetValue(MovieInfo.MovieProperty, value);
	}
	public int MovieRating
	{
		get=>(int)GetValue(MovieInfo.MovieRatingProperty);
		set=>SetValue(MovieInfo.MovieRatingProperty, value);
	}

	public bool RateButtonIsVisible
	{
		get=>(bool)GetValue(RateButtonIsVisibleProperty);
		set=>SetValue(RateButtonIsVisibleProperty, value);
	}

	public bool RateButtonIsReadOnly
	{
		get => (bool)GetValue(RateButtonIsReadOnlyProperty);
		set=> SetValue (RateButtonIsReadOnlyProperty, value);
	}
    private void Close_Clicked(object sender, EventArgs e)
    {
		Close.Invoke(this, EventArgs.Empty);
    }

	private void Rate_Clicked(object sender, EventArgs e)
	{
		var rating = starRatingControl.Value;
		this.Movie.Rating = rating;
        Rate.Invoke(this, this.Movie);
	}
}