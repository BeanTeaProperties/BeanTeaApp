﻿
using BeanTea.Auth0;

namespace MauiAuth0App.Auth0;

public class Auth0ClientOptions
{
    public Auth0ClientOptions()
    {
        Scope = "openid";
        RedirectUri = "beantea://callback";
        Browser = new WebBrowserAuthenticator();
    }

    public string Domain { get; set; }

    public string ClientId { get; set; }

    public string RedirectUri { get; set; }

    public string Scope { get; set; }

    public IdentityModel.OidcClient.Browser.IBrowser Browser { get; set; }
}