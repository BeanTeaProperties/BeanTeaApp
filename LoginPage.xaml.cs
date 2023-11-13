using MauiAuth0App.Auth0;
using Newtonsoft.Json;

namespace BeanTea;

public partial class LoginPage : ContentPage
{
    private readonly Auth0Client auth0Client;


    public LoginPage()
    { 
        InitializeComponent(); 
    }

    public LoginPage(Auth0Client client)
	{
		InitializeComponent();
        auth0Client = client;
    }

    private async void Sign_In_Button_Clicked(object sender, EventArgs e)
    {
        var loginResult = await auth0Client.LoginAsync();

        if (loginResult.AccessToken != null) {
            lblSignedUser.Text = JsonConvert.SerializeObject(loginResult.User.Claims);
        }
    }
}