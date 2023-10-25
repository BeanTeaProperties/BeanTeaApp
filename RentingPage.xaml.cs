namespace BeanTea;

//using Android.Gms.Maps;
using Microsoft.Maui.Maps;
///using static Android.Icu.Text.Transliterator;
///using static Android.Provider.CallLog;
using Map = Microsoft.Maui.Controls.Maps.Map;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;

public partial class RentingPage : ContentPage
{
    Location selectedLocation;


    public RentingPage()
	{
        //Location location = new Location(36.9628066, -122.0194722);
        //MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);
        // Map maps = new Map();
       
        InitializeComponent();
	}  

    private async void OnBackButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private async void OnSearchAreaButtonClicked(object sender, EventArgs e)
	{
        //string searchTerm = searchEntry.Text;
        //LblLoadingSearch.Text = $"Searching for {searchTerm}...";

        //var locations = await Geocoding.GetLocationsAsync(searchTerm);
        //      var location = locations?.FirstOrDefault();

        //if (location != null && location.Any())
        //{
        //    var locations = location.First();
        //    var position = new Position(locations.Latitude, locations.Longitude);

        //    // Center the map on the found location
        //    map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(1)));
        //}
        //else
        //{
        //    // Handle case where no location is found
        //    // You could display an error message to the user
        //}
    }

    private void OnMapTapped(object sender, MapClickedEventArgs e)
    {
        selectedLocation = e.Location;
    }

    private void BudgetSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblBudget.Text = $"${(int)e.NewValue}";
    }


    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        var centerLocation = new Location(49.2901, -123.1376);
        if (selectedLocation!=null)
        {
            centerLocation = selectedLocation;
        }       

        var radius = new Circle {
            Center = centerLocation,
            Radius = Distance.FromMeters(e.NewValue),
            StrokeColor = Color.FromHex("#88FF0000"),
            FillColor = Color.FromHex("#88FFC0CB"),
            StrokeWidth = 2
        };        

        map.MapElements.Clear();
        map.MapElements.Add(radius);

        // Update drawing parameters based on slider value
        // For example, set line thickness or opacity
    }
}