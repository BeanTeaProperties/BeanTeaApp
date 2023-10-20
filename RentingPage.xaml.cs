namespace BeanTea;

using Android.Gms.Maps;
using Microsoft.Maui.Maps;
using static Android.Icu.Text.Transliterator;
using static Android.Provider.CallLog;
using Map = Microsoft.Maui.Controls.Maps.Map;
using Microsoft.Maui.Controls;


public partial class RentingPage : ContentPage
{
    public RentingPage()
	{
        Map map = new Map()
		{
			MapType = MapType.Street		
        };

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

		var locations = await Geocoding.GetLocationsAsync(searchTerm);
        var location = locations?.FirstOrDefault();

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