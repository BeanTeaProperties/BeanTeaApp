namespace BeanTea;

using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
public partial class RentingPage : ContentPage
{
    public RentingPage()
	{
        Map map = new Map()
		{
			MapType = MapType.Street,
			IsShowingUser = true
        };
        InitializeComponent();
	}  

    private async void OnBackButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

	private void OnSearchAreaButtonClicked(object sender, EventArgs e)
	{
		Location location = new Location(49.28374145586325, -123.13921578560719);
		MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);

		Map map = new Map(mapSpan)
		{
            MapType = MapType.Street
        };
        InitializeComponent();
    }
}