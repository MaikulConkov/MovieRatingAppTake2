using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MovieRatingAppTake2.Controls;

public partial class StarRatingControl : ContentView , INotifyPropertyChanged
{
    public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(int), typeof(StarRatingControl), 0, propertyChanged: OnValuePropertyChanged);
    public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(nameof(IsReadOnly), typeof(bool), typeof(StarRatingControl), false);
    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public bool IsReadOnly
    {
        get => (bool)GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    private static void OnValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is StarRatingControl control)
        {
            control.UpdateStars();
        }
    }

    public ObservableCollection<Image> Stars { get; set; } = new ObservableCollection<Image>();

    public StarRatingControl()
    {
        BuildContent();
    }

    private void BuildContent()
    {
        var layout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        for (int i = 0; i < 5; i++)
        {
            var starImage = new Image
            {
                Source = "empty_star.png", 
                WidthRequest = 30,
                HeightRequest = 30
            };

            int starIndex = i; 
            var tapGestureRecognizer = new TapGestureRecognizer
            {
                Command = new Command(() => {
                    if (!IsReadOnly) 
                    {
                        Value = starIndex + 1;
                    }
                }),
                NumberOfTapsRequired = 1
            };

            starImage.GestureRecognizers.Add(tapGestureRecognizer);
            Stars.Add(starImage);
            layout.Children.Add(starImage);
        }

        Content = layout;
        UpdateStars();
    }

    private void UpdateStars()
    {
            for (int i = 0; i < Stars.Count; i++)
            {
                Stars[i].Source = i < Value ? "filled_star.png" : "empty_star.png";
            }
    }
}
