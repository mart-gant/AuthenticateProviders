using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Auth;
using AuthenticateProviders;
using AuthenticateProviders.iOS;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace AuthenticateProviders.iOS
{
    class LoginPageRenderer : PageRenderer
    {
        LoginPage page;
        bool loginInProgress;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;
            page = e.NewElement as LoginPage;
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            if (page == null || loginInProgress)
                return;
            loginInProgress = true;
            try
            {
                // Twój identyfikator kliencki OAuth2
                OAuth2Authenticator auth = new OAuth2Authenticator(
                  page.ProviderOAuthSettings.ClientId,
                  // Twoje hasło klienckie OAuth2
                  page.ProviderOAuthSettings.ClientSecret,
                  // Zakresy.
                  page.ProviderOAuthSettings.ScopesString,
                  // Zakresy rozdzielone znakiem "+"
                  new Uri(page.ProviderOAuthSettings.AuthorizeUrl),
                  // Przekierowujący adres URL
                  new Uri(page.ProviderOAuthSettings.RedirectUrl),
                  new Uri(page.ProviderOAuthSettings.AccessTokenUrl)
                );
                auth.AllowCancel = true;
                auth.Completed += async (sender, args) => {
                    // Wykonywane operacje
                    await DismissViewControllerAsync(true);
                    await page.Navigation.PopModalAsync();
                    loginInProgress = false;
                };
                auth.Error += (sender, args) => {
                    Console.WriteLine("Błąd uwierzytelnienia: {0}", args.Exception);
                };
                await PresentViewControllerAsync(auth.GetUI(), true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
