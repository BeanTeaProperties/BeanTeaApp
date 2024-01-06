using BeanTea.Auth0;
using BeanTea.Infrastructer;
using MauiAuth0App.Auth0;
using Microsoft.Extensions.Logging;
using BeanTea.Services;
using BeanTea.Services.BeanTeaServices;
using Microsoft.Extensions.Configuration;
using System.Reflection;


namespace BeanTea
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiMaps()
                .ConfigureEssentials(essentials => {
                    essentials.UseMapServiceToken("AtAkX23cj_LE_8ZJGwbX3KbjAeAdq1lCwHwrI0X3C5vT7w1TjWwSygqo8-TLbl5Q");
                });

    #if DEBUG
		    builder.Logging.AddDebug();
#endif
            ///testing the PR

            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.appsettings.json");

           // using var stream = FileSystem.OpenAppPackageFileAsync("appsettings.json").Result;
           // using var reader = new StreamReader(stream);

           

           // using var stream = assembly.GetFile("appsettings.json");

            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();

            builder.Configuration.AddConfiguration(config);

            builder.Services.AddSingleton<MainPage>();
           // builder.Services.AddSingleton<RentingPage>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<ApiClient>();
            builder.Services.AddSingleton<AuthUserServices>();
            builder.Services.AddSingleton<WatchService>();
            builder.Services.AddSingleton<PostingsServices>();
          

            builder.Services.AddSingleton(new Auth0Client(new()
            {
                Domain = "lenders.auth0.com",
                ClientId = "w1LO07P1OsVqvRLGwGGa5X90TG4lTY8l",
                Scope = "openid profile email",
             //   RedirectUri = "myapp://callback",
                RedirectUri = "beantea://callback",
                Browser = new WebBrowserAuthenticator()

        }));

            return builder.Build();
        }
    }
}