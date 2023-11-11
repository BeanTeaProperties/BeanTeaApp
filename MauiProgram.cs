using MauiAuth0App.Auth0;
using Microsoft.Extensions.Logging;

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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<RentingPage>();

            builder.Services.AddSingleton(new Auth0Client(new()
            {
                Domain = "lenders.auth0.com",
                ClientId = "w1LO07P1OsVqvRLGwGGa5X90TG4lTY8l",
                Scope = "openid profile",
                //RedirectUri = "myapp://callback"
                RedirectUri = "beantea://callback"
            }));

            return builder.Build();
        }
    }
}