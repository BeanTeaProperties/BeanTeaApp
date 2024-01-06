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
using System.Collections.ObjectModel;
using BeanTea.Models;
using Microsoft.Extensions.Configuration;

namespace BeanTea
{
    public partial class MainPage : ContentPage
    {
        private Location selectedLocation;
        private double distance;
        private readonly Auth0Client auth0Client;
        private readonly WatchService _watchservice;
        AddWatchViewModel _watchEntity;
        PostingsServices _postingsServices;
        int maxBudget = 0;
        int minBudget = 0;
        IConfiguration _config;

        public MainPage(Auth0Client client, WatchService watchService, PostingsServices postingsServices, IConfiguration configuration)
        {
            InitializeComponent();
            auth0Client = client;
            _watchservice = watchService;
            _postingsServices = postingsServices;
            _watchEntity = new AddWatchViewModel();
            _config = configuration;

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
            lblSearchingWarning.Text = "Select an Area";
            maps.MapElements.Clear();

            var circle = new Circle
            {
                Center = location,
                Radius = Distance.FromMeters(radius),
                StrokeColor = Color.FromHex("#88FF0000"),
                FillColor = Color.FromHex("#88FFC0CB"),
                StrokeWidth = 2
            };

            maps.MapElements.Clear();
            maps.MapElements.Add(circle);
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblSearchingWarning.Text = "Select an Area";

            distance = e.NewValue;
            DrawACircleOnTheMap(e.NewValue, selectedLocation);
        }

        private async void Watch_Button_Clicked(object sender, EventArgs e)
        {
            var token = await SecureStorage.GetAsync("auth-token");
           
            if (!string.IsNullOrEmpty(token))
            {
                lblSearchingWarning.Text = "Adding a watch in this area...";
                var email = await SecureStorage.GetAsync("email");
                var addWatchRequest = (AddWatchViewModel)BindingContext;
                addWatchRequest.latitude = selectedLocation.Latitude.ToString();
                addWatchRequest.longitude = selectedLocation.Longitude.ToString();
                var distanceWatch = (int)(distance / 1000);
                addWatchRequest.email = email;

                var watch = new BeanTeaWatchDto(addWatchRequest.MinBudget, addWatchRequest.MaxBudget, distanceWatch, addWatchRequest.latitude, addWatchRequest.longitude, addWatchRequest.email);

                if (await _watchservice.AddWatch(watch))
                    await DisplayAlert("Sucess!", "We will notify you a posting comes available", "back");
                else
                    await DisplayAlert("Failed!", "Unfortunately we have unexpected error, Please try again", "back");

                lblSearchingWarning.Text = "Select an Area";
            }
            else
            {
                await DisplayAlert("Login In", "Please login before notified of a listing in this area.", "back");
            }

        }

        private async void OnSearchAreaButtonClicked(object sender, EventArgs e)
        {
            lblSearchingWarning.Text = "Searching....";

            if (minBudget > maxBudget)
            {
                minBudget = maxBudget;
            }

            var result = await _postingsServices.ReturnPostings(minBudget, maxBudget);

            var searchLocations = await _postingsServices.FilterSearchResult(result, selectedLocation, (int)distance / 1000);

            if (searchLocations.Count() == 0)
            {
                lblSearchingWarning.Text = $"Nothing was found in that area";
                return;
            }

            lblSearchingWarning.Text = $"Loading: {searchLocations.Count()}";

            var observableCollection = new ObservableCollection<SearchResultViewModel>(searchLocations);
            await Navigation.PushAsync(new SearchResultsPage(observableCollection, _config)); 

        }

        private void BudgetMacSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblSearchingWarning.Text = "Select an Area";

            var newStep = Math.Round(e.NewValue / 100) * 100;
            maxBudget = (int)newStep;

            lblMaxBudget.Text = $"${(int)newStep}";
        }


        private void BudgetMinSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblSearchingWarning.Text = "Select an Area";

            var newStep = Math.Round(e.NewValue / 100) * 100;
            minBudget = (int)newStep;

            lblMinBudget.Text = $"${(int)newStep}";
        }

    }
}