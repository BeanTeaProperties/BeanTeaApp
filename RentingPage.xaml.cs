namespace BeanTea;

using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using MauiAuth0App.Auth0;

public partial class RentingPage : ContentPage
{
    Location selectedLocation;
    private readonly Auth0Client auth0Client;

    public RentingPage(Auth0Client client)
    {       
        InitializeComponent();        
        auth0Client = client;
    }  


    private async void OnSearchAreaButtonClicked(object sender, EventArgs e)
	{
        
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var loginResult = await auth0Client.LoginAsync();

        //if (!loginResult.IsError)
        //{
        //    LoginView.IsVisible = false;
        //    HomeView.IsVisible = true;
        //}
        //else
        //{
        //    await DisplayAlert("Error", loginResult.ErrorDescription, "OK");
        //}
    }

    private void OnMapTapped(object sender, MapClickedEventArgs e)
    {
        selectedLocation = e.Location;

        var radius = new Circle
        {
            Center = selectedLocation,
            Radius = Distance.FromMeters(SearchSlider.Value),
            StrokeColor = Color.FromHex("#88FF0000"),
            FillColor = Color.FromHex("#88FFC0CB"),
            StrokeWidth = 2
        };

        map.MapElements.Clear();
        map.MapElements.Add(radius);
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