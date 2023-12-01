using BeanTea.Services.BeanTeaServices;
using IdentityModel.OidcClient;
using MauiAuth0App.Auth0;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Graphics;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace BeanTea;

public partial class LoginPage : ContentPage
{
    private readonly Auth0Client _auth0Client;
    private readonly AuthUserServices _authUserService;
    private string picture { get; set; }

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
        //imageUserImage.Source = string.Empty;
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
       // picture = loginResult.User.Identities.FirstOrDefault().Claims.FirstOrDefault(x => x.Type == "picture").Value;        

        await SecureStorage.SetAsync("access-token", loginResult.AccessToken);
        await SecureStorage.SetAsync("auth-token", loginResult.AccessToken);
        await SecureStorage.SetAsync("email", email);
      //  await SecureStorage.SetAsync("picture", picture);

        //imageUserImage.Source = picture;
        lblSignedUser.Text = loginResult.User.Identity.Name;
        btnSignOut.IsVisible = true;
        btnSignIn.IsVisible = false;

        await _authUserService.CreateUser(email);
    }
}