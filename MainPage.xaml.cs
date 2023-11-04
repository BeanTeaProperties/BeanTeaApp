﻿using IdentityModel.OidcClient;
using MauiAuth0App.Auth0;
using Newtonsoft.Json;

namespace BeanTea
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly Auth0Client auth0Client;

        public MainPage(Auth0Client client)
        {
            InitializeComponent();
            auth0Client = client;
            //auth0Client = client;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var loginResult = await auth0Client.LoginAsync();

            lblSignUserName.Text = loginResult.User.Identity.Name;
            SignOutBtn.IsVisible = true;

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

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            var logoutResult = await auth0Client.LogoutAsync();

            lblSignUserName.Text = "";
            SignOutBtn.IsVisible = false;
            //if (!logoutResult.IsError)
            //{
            //    HomeView.IsVisible = false;
            //    LoginView.IsVisible = true;
            //}
            //else
            //{
            //    await DisplayAlert("Error", logoutResult.ErrorDescription, "OK");
            //}
        }

        private async void OnRentingBtnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RentingPage(auth0Client));
        }
    }
}