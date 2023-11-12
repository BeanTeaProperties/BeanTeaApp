using MauiAuth0App.Auth0;


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
    }
}