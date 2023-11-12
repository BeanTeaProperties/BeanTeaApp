using IdentityModel.OidcClient;
using MauiAuth0App.Auth0;
using Newtonsoft.Json;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;

namespace BeanTea
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private Location selectedLocation;
        private readonly Auth0Client auth0Client;

        public MainPage(Auth0Client client)
        {

            InitializeComponent();
            auth0Client = client;
       
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

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var centerLocation = new Location(49.2901, -123.1376);
            if (selectedLocation != null)
            {
                centerLocation = selectedLocation;
            }

            var radius = new Circle
            {
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

        private void BudgetSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblBudget.Text = $"${(int)e.NewValue}";
        }

        private async void OnSearchAreaButtonClicked(object sender, EventArgs e)
        {

        }

    }
}