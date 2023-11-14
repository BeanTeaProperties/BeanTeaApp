using BeanTea.Services.BeanTeaServices;
using MauiAuth0App.Auth0;
using Newtonsoft.Json;

namespace BeanTea;

public partial class LoginPage : ContentPage
{
    private readonly Auth0Client _auth0Client;
    private readonly AuthUserServices _authUserService;

    public LoginPage()
    { 
        InitializeComponent(); 
    }

    public LoginPage(Auth0Client client, AuthUserServices authUserService)
	{
		InitializeComponent();
        _auth0Client = client;
        _authUserService = authUserService;
    }

    private async void Sign_Out_Button_Clicked(object sender, EventArgs e)
    {
        await _auth0Client.LogoutAsync();
        btnSignOut.IsVisible = false;
        btnSignIn.IsVisible = true;
        lblSignedUser.Text = string.Empty;
        imageUserImage.Source = string.Empty;
        await SecureStorage.SetAsync("auth-token", "");
    }

    private async void Sign_In_Button_Clicked(object sender, EventArgs e)
    {
        var loginResult = await _auth0Client.LoginAsync();

        var email = loginResult.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == "email").Value;
        var picture = loginResult.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == "picture").Value;

        await SecureStorage.SetAsync("auth-token", loginResult.AccessToken);
        await SecureStorage.SetAsync("email", email);

        imageUserImage.Source = picture;
        lblSignedUser.Text = loginResult.User.Identity.Name;
        btnSignOut.IsVisible = true;
        btnSignIn.IsVisible = false;

        await _authUserService.CreateUser(email);
    }
}