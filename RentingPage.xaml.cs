namespace BeanTea;

//using Android.Gms.Maps;
using Microsoft.Maui.Maps;
///using static Android.Icu.Text.Transliterator;
///using static Android.Provider.CallLog;
using Map = Microsoft.Maui.Controls.Maps.Map;
using Microsoft.Maui.Controls;


public partial class RentingPage : ContentPage
{
    public RentingPage()
	{
        //Location location = new Location(36.9628066, -122.0194722);
        //MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);
        //Map maps = new Map(mapSpan);

        InitializeComponent();
	}  

    private async void OnBackButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private async void OnSearchAreaButtonClicked(object sender, EventArgs e)
	{
        string searchTerm = searchEntry.Text;
        LblLoadingSearch.Text = $"Searching for {searchTerm}...";

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
}