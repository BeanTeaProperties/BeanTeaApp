using BeanTea.Services.BeanTeaServices;
using BeanTea.ViewModels;
using IdentityModel.OidcClient;
using MauiAuth0App.Auth0;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Graphics;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace BeanTea;

public partial class LoginPage : ContentPage
{
    private readonly Auth0Client _auth0Client;
    private readonly AuthUserServices _authUserService;
    private readonly PostingsServices _postingsServices;
    private readonly WatchService _watchService;
    public ObservableCollection<WatchFoundViewModel> _watchFoundViewModels;
 

    public LoginPage()
    { 
        InitializeComponent(); 
    }

    public LoginPage(Auth0Client client, AuthUserServices authUserService, PostingsServices postingsServices, WatchService watchService)
	{
		InitializeComponent();
        _auth0Client = client;
        _authUserService = authUserService;
        _postingsServices = postingsServices;
        _watchService = watchService;

    }

    private async void Sign_Out_Button_Clicked(object sender, EventArgs e)
    {
        await _auth0Client.LogoutAsync();
        WatchFoundCollection.ItemsSource = null;
        SignedUserLabel.Text = string.Empty;
        LogOutBtn.IsVisible = false;
        LogInBtn.IsVisible = true;

        SecureStorage.Remove("auth-token");
        SecureStorage.Remove("access-token");
        SecureStorage.Remove("auth-token");
        SecureStorage.Remove("email");
        SecureStorage.Remove("picture");
    }

    private async void Sign_In_Button_Clicked(object sender, EventArgs e)
    {
        var loginResult = await _auth0Client.LoginAsync();

        var email = loginResult.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == "email").Value;

        await SecureStorage.SetAsync("access-token", loginResult.AccessToken);
        await SecureStorage.SetAsync("auth-token", loginResult.AccessToken);
        await SecureStorage.SetAsync("email", email);


        var welcomeMessage = $"Welcome, {loginResult.User.Identity.Name}. Here are your latest form your watched areas.";
        string renderingWarning = " Loading your watches.....";

        SignedUserLabel.Text = welcomeMessage + renderingWarning;
        LogOutBtn.IsVisible = true;
        LogInBtn.IsVisible = false;

        await _authUserService.CreateUser(email);
     
        var watchFound = await _watchService.GetWatches(email);  
        _watchFoundViewModels = new ObservableCollection<WatchFoundViewModel>(watchFound);

        WatchFoundCollection.ItemsSource = _watchFoundViewModels;

        var totalFoundText = $" Found a total of {watchFound.Count} properties in your area.";

        SignedUserLabel.Text = welcomeMessage + totalFoundText;

    }

    private async void View_Watch_Clicked(object sender, EventArgs e)
    {
        var layout = (BindableObject)sender;
        var item = (WatchFoundViewModel)layout.BindingContext;

        if (await _postingsServices.IsItADeadLink(item.Url))
        {
            await _postingsServices.RemovePosting(JsonConvert.SerializeObject(item));
            await DisplayAlert("Unfortunately this listing is no longer active.", "Thanks for bringing this to our attention we will de list it.", "Back");
            // Result.Remove(item);
        }
        else
        {
            await Launcher.OpenAsync(new Uri(item.Url));
        }
    }

    private async void Remove_Watch_Clicked(object sender, EventArgs e)
    {
        var layout = (BindableObject)sender;
        var item = (WatchFoundViewModel)layout.BindingContext;

        item.Email = await SecureStorage.GetAsync("email");

        await _watchService.DeleteWatch(item);
        _watchFoundViewModels.Remove(item);
            
    }
}