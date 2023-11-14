using IdentityModel.OidcClient;
using MauiAuth0App.Auth0;
using Newtonsoft.Json;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Maps;
using BeanTea.Services.BeanTeaServices;
using BeanTea.ViewModels;
using System.Diagnostics.CodeAnalysis;

namespace BeanTea
{
    public partial class MainPage : ContentPage
    {
        private Location selectedLocation;
        private double distance;
        private readonly Auth0Client auth0Client;
        private readonly WatchService _watchservice;
        AddWatchEntity _watchEntity;

        public MainPage(Auth0Client client, WatchService watchService)
        {
            InitializeComponent();
            auth0Client = client;
            _watchservice = watchService;
            _watchEntity = new AddWatchEntity();
            BindingContext = _watchEntity;

            distance = 2500;
            selectedLocation = new Location(49.2901, -123.1376);
            DrawACircleOnTheMap(distance, selectedLocation);
        }

        private void OnMapTapped(object sender, MapClickedEventArgs e)
        {
            selectedLocation = e.Location;
            DrawACircleOnTheMap(distance, e.Location);          
        }

        private void DrawACircleOnTheMap(double radius, Location location)
        {
            var circle = new Circle
            {
                Center = location,
                Radius = Distance.FromMeters(radius),
                StrokeColor = Color.FromHex("#88FF0000"),
                FillColor = Color.FromHex("#88FFC0CB"),
                StrokeWidth = 2
            };

            map.MapElements.Clear();
            map.MapElements.Add(circle);
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            distance = e.NewValue;
            DrawACircleOnTheMap(e.NewValue, selectedLocation);            
        }

        private void BudgetSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblBudget.Text = $"${(int)e.NewValue}";
        }

        private async void Watch_Button_Clicked(object sender, EventArgs e)
        {
            var token = await SecureStorage.GetAsync("auth-token");
            if (!string.IsNullOrEmpty(token))
            {
                var addWatchRequest = (AddWatchEntity)BindingContext;      
                addWatchRequest.latitude = selectedLocation.Latitude.ToString();
                addWatchRequest.longitude = selectedLocation.Longitude.ToString();
            
                await _watchservice.AddWatch(JsonConvert.SerializeObject(addWatchRequest)); 
            }
            else
            {
                await DisplayAlert("Login In", "Please login before notified of a listing in this area.", "cancel");
            }

        }

        private async void OnSearchAreaButtonClicked(object sender, EventArgs e)
        {

        }

      
    }
}