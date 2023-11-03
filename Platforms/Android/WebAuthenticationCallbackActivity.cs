// Platforms/Android/WebAuthenticationCallbackActivity.cs

using Android.App;
using Android.Content.PM;

namespace MauiAuth0App;

[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(new[] { Android.Content.Intent.ActionView },
              Categories = new[] {
                Android.Content.Intent.CategoryDefault,
                Android.Content.Intent.CategoryBrowsable
              },
              DataScheme = CALLBACK_SCHEME)]
public class WebAuthenticationCallbackActivity : Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity
{
    const string CALLBACK_SCHEME = "com.beantea.beantea://lenders.auth0.com/android/YOUR_ANDROID_PACKAGE_NAME/callback";
}